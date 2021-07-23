using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace FileManager
{
    public static class FileCommands
    {
        /// <summary>
        /// Try to create a text file in "way" directory.
        /// </summary>
        public static void CreateFile(string way)
        {
            try
            {
                string name = Program.ReadFileOrDirectoryName("Name the file");
                Console.Clear();
                string extention = PickTextFileExtention();
                Console.Clear();
                string dirname = Path.Combine(way, name);
                dirname += extention;
                Encoding encoding = PickEncoding();
                File.WriteAllLines(dirname, TextToFile(), encoding);
            }
            catch (Exception)
            {
                Program.Alert("You cannot create files here.", true);
            }
        }

        /// <summary>
        /// Try to copy file to written directory.
        /// </summary>
        /// <returns> Directory to open next. </returns>
        public static string CopyFile(string way, string file)
        {
            string directoryPath = Path.Combine(DirectoryCommands.ReadDirectoryName("copy"), 
                Path.GetFileNameWithoutExtension(file) + "_copy" + Path.GetExtension(file));
            try
            {
                File.Copy(file, directoryPath);
                return Path.GetDirectoryName(directoryPath);
            }
            catch (Exception)
            {
                Program.Alert("Invalid path", true);
                return way;
            }
        }

        /// <summary>
        /// Try to move file to written directory.
        /// </summary>
        /// <returns> Directory to open next. </returns>
        public static string MoveFile(string way, string file)
        {
            string pathDirectory = Path.Combine(DirectoryCommands.ReadDirectoryName("move"), Path.GetFileName(file));
            try
            {
                File.Move(file, pathDirectory);
                return Path.GetDirectoryName(pathDirectory);
            }
            catch (Exception)
            {
                Program.Alert("Invalid path", true);
                return way;
            }
        }

        /// <summary>
        /// Try to delete given file.
        /// </summary>
        /// <returns> Directory to open next. </returns>
        public static string DeleteFile(string way, string file)
        {
            try
            {
                File.Delete(file);
                Console.Clear();
                return Path.GetDirectoryName(file);
            }
            catch (Exception)
            {
                Program.Alert("You can't delete this file", true);
                return way;
            }
        }

        /// <summary>
        /// Try to rename given file.
        /// </summary>
        /// <returns> Directory to open next. </returns>
        public static string RenameFile(string way, string file)
        {
            try
            {
                string fullname = Path.Combine(Path.GetDirectoryName(file), 
                    Program.ReadFileOrDirectoryName("Rename the file") + Path.GetExtension(file));
                File.Move(file, fullname);
            }
            catch (Exception)
            {
                Program.Alert("You can't rename this file", true);
            }
            return way;
        }

        /// <summary>
        /// Try to concatinate two text files into a single one. 
        /// </summary>
        /// <returns> Directory to open next. </returns>
        public static string GlueFiles(string way, string file)
        {
            try
            {
                List<string> newTextFile = File.ReadAllLines(file).Concat(File.ReadAllLines(ReadFileName())).ToList();
                string name = Program.ReadFileOrDirectoryName("Name the file");
                Console.Clear();
                string extention = PickTextFileExtention();
                string fullPath = "";
                if (way.EndsWith("/") || way.EndsWith(@"\"))
                    fullPath = way + name;
                else fullPath = Path.Combine(way, name);
                fullPath += extention;
                Console.Clear();
                Encoding encoding = PickEncoding();
                File.WriteAllLines(fullPath, newTextFile.ToArray(), encoding);
                return OpenFile(way, fullPath, encoding);
            }
            catch (Exception)
            {
                Program.Alert("Concatination failed", true);
                return way;
            }
        }

        /// <summary>
        /// Try to read text file and print it.
        /// </summary>
        /// <returns> Directory to open next. </returns>
        public static string OpenFile(string way, string file, Encoding encoding)
        {
            try
            {
                if (Path.GetExtension(file) == ".txt" || Path.GetExtension(file) == ".rtf")
                {
                    Console.Clear();
                    string[] text = File.ReadAllLines(file);
                    if (encoding == null)
                        Console.OutputEncoding = PickEncoding();
                    else Console.OutputEncoding = encoding;
                    Program.Alert("Press Esc to exit", true);
                    foreach (var item in text)
                        Console.WriteLine(item);
                    Console.OutputEncoding = Encoding.Default;
                    bool check = true;
                    do
                    {
                        if (!check)
                            Program.Alert("\nPlease press Esc", false);
                        check = Console.ReadKey().Key == ConsoleKey.Escape;
                    } while (!check);
                    Console.Clear();
                    return way;
                }
                else
                {
                    Program.Alert("Invalid extention\nOnly .txt and .rtf are openable\n", true);
                    return way;
                }
            }
            catch (Exception)
            {
                Program.Alert("You can't open this file", true);
                return way;
            }
        }

        /// <summary>
        /// Check if file exists and if it is a text file.
        /// </summary>
        /// <returns> Directory to open next. </returns>
        public static string ReadFileName()
        {
            string fileDirectory = "";
            bool checkExistance = true, checkTextFile = true;
            do
            {
                if (!checkExistance)
                    Program.Alert("File does not exist", true);
                else if
                    (!checkTextFile) Program.Alert("Not a text file", true);
                Console.WriteLine("Write the path of the file which you want to concatinate with the specified file: ");
                fileDirectory = Console.ReadLine();
                checkExistance = File.Exists(fileDirectory);
                checkTextFile = (Path.GetExtension(fileDirectory) == ".txt") || (Path.GetExtension(fileDirectory) == ".rtf");
            } while (!(checkExistance && checkTextFile));
            return fileDirectory;
        }

        /// <summary>
        /// User picks extention for the text file.
        /// </summary>
        /// <returns> Directory to open next. </returns>
        public static string PickTextFileExtention()
        {
            Console.WriteLine("Pick file extention:\n1\ttxt\n2\trtf");
            switch (Console.ReadLine())
            {
                case "1": return ".txt";
                case "2": return ".rtf";
                default:
                    Program.Alert("Extention does not exist.", true);
                    return PickTextFileExtention();
            }
        }

        /// <summary>
        /// User picks encoding.
        /// </summary>
        /// <returns> Encoding selected by user. </returns>
        public static Encoding PickEncoding()
        {
            Console.WriteLine("Pick encoding:\n1\tUTF7\n2\tUTF8\n3\tASCII\n4\tUnicode");
            switch (Console.ReadLine())
            {
                case "1": return Encoding.UTF7;
                case "2": return Encoding.UTF8;
                case "3": return Encoding.ASCII;
                case "4": return Encoding.Unicode;
                default:
                    Program.Alert("Encoding does not exist", true);
                    return PickEncoding();
            }
        }

        /// <summary>
        /// User writes a text file.
        /// </summary>
        /// <returns> List of text file's lines. </returns>
        public static List<string> TextToFile()
        {
            Console.Clear();
            List<string> text = new List<string>();
            Console.WriteLine("Write something\nType \"SaveFile\" to save\n");
            do
            {
                text.Add(Console.ReadLine());
            } while (text[^1] != "SaveFile");
            text.RemoveAt(text.Count - 1);
            return text;
        }
    }
}