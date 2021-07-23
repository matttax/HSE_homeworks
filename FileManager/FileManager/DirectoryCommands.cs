using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    public static class DirectoryCommands
    {
        /// <summary>
        /// Fill two string arrays with files and directories from "way" directory and print them.
        /// </summary>
        /// <returns> 1 if "way" directory is accessable, 0 of not. </returns>
        public static bool OpenNextDirectory(string way, ref string[] dir, ref string[] fil)
        {
            try
            {
                Console.WriteLine(way + "\n");
                dir = Directory.GetDirectories(way);
                fil = Directory.GetFiles(way);
                Console.WriteLine("Directories:\n");
                Console.WriteLine("D0\tCreate new directory");
                for (int i = 0; i < dir.Length; i++)
                    Console.WriteLine($"D{i + 1}\t{Path.GetFileName(dir[i])}");
                Console.WriteLine("\nFiles:\n");
                Console.WriteLine("F0\tCreate new text file");
                for (int i = 0; i < fil.Length; i++)
                    Console.WriteLine($"F{i + 1}\t{Path.GetFileName(fil[i])}");
                Console.WriteLine();
                return true;
            }
            catch (Exception)
            {
                Program.Alert("Unauthorized access", true);
                return false;
            }
        }

        /// <summary>
        /// Try to create a new directory inside "way" directory.
        /// </summary>
        public static void CreateDirectory(string way)
        {
            try
            {
                string dirname = Path.Combine(way, Program.ReadFileOrDirectoryName("Name the directory"));
                Directory.CreateDirectory(dirname);
            }
            catch (Exception)
            {
                Program.Alert("You cannot create directory here", true);
            }
        }

        /// <summary>
        /// Try to rename given directory.
        /// </summary>
        /// <returns> Directory to open next. </returns>
        public static string RenameDirectory(string way, string directory)
        {
            try
            {
                Console.WriteLine("Write a new name: ");
                string fullname = Path.Combine(Path.GetDirectoryName(directory), Program.ReadFileOrDirectoryName("Rename the directory"));
                Directory.Move(directory, fullname);
            }
            catch (Exception)
            {
                Program.Alert("You cannot rename this directory", true);
            }
            return way;
        }

        /// <summary>
        /// Try to delete all files and subdirectories in given directory recursively. Then detete empty directory.
        /// </summary>
        /// <returns> Directory to open next. </returns>
        public static string DeleteDirectory(string way, string directory)
        {
            try
            {
                string[] deleteFiles = Directory.GetFiles(directory);
                if (deleteFiles.Length > 0)
                    foreach (var item in deleteFiles)
                        File.Delete(item);
                string[] deleteDirectories = Directory.GetDirectories(directory);
                if (deleteDirectories.Length > 0)
                    foreach (var item in deleteDirectories)
                        DeleteDirectory(way, item);
                Directory.Delete(directory);
                return Path.GetDirectoryName(directory);
            }
            catch (Exception)
            {
                Program.Alert("You can't delete this directory", true);
                return way;
            }
        }

        /// <summary>
        /// Try to move given directory.
        /// </summary>
        /// <returns> Directory to open next. </returns>
        public static string MoveDirectory(string way, string directory)
        {
            string directoryPath = ReadDirectoryName("move");
            directoryPath = Path.Combine(directoryPath, Path.GetFileName(directory));
            try
            {
                Directory.Move(directory, directoryPath);
                return Path.GetDirectoryName(directoryPath);
            }
            catch (ArgumentException)
            {
                Program.Alert("Invalid path", true);
                return way;
            }
            catch (Exception)
            {
                Program.Alert("You can't move this directory there", true);
                return way;
            }
        }

        /// <summary>
        /// Check if written directory exists.
        /// </summary>
        /// <returns> Directory name when it exists. </returns>
        public static string ReadDirectoryName(string todo)
        {
            bool check = true;
            string pathDirectory = "";
            do
            {
                if (!check)
                    Program.Alert("Directory does not exist", true);
                Console.WriteLine($"Write the path of the directory where you want to {todo} specified file: ");
                pathDirectory = Console.ReadLine();
                check = Directory.Exists(pathDirectory);
            } while (!check);
            return pathDirectory;
        }
    }
}