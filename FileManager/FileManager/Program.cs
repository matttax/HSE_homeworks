using System;
using System.IO;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;
            do
            {
                path = ToDrives();
                if (path == "exit")
                    return;
            } while (!Directory.Exists(path));
            do
            {
                path = NextStep(path);
            } while (path != "exit");
        }

        /// <summary>
        /// Main menu with drives.
        /// </summary>
        /// <returns> Selected drive or another command. </returns>
        public static string ToDrives()
        {
            try
            {
                DriveInfo[] allDrives = DriveInfo.GetDrives();
                int picked = PickDrive(allDrives);
                if (picked == 0)
                    return "exit";
                if (picked == -2)
                {
                    Help();
                    Console.Clear();
                    return "help";
                }
                string way = allDrives[picked - 1].ToString();
                Console.Clear();
                return way;
            }
            catch (Exception)
            {
                Alert("File system cannot be reached.", false);
                return "exit";
            }
        }

        /// <summary>
        /// Print list of drives and make user to choose one of them or write any valid command.
        /// </summary>
        /// <returns> Selected drive or another command index. </returns>
        static int PickDrive(DriveInfo[] dri)
        {
            int picked = 0;
            bool check = true;
            string cmd;
            do
            {
                if (!check) 
                    Alert("Incorrect input", true);
                Alert("Write \"Help\" to see the list of comands", false);
                Console.WriteLine("Pick drive: \n");
                for (int i = 0; i < dri.Length; i++)
                    Console.WriteLine($"{i + 1}\t{dri[i]}");
                cmd = Console.ReadLine();
                if (cmd == null)
                    continue;
                check = int.TryParse(cmd, out picked) && (dri.Length - picked >= 0) && (dri.Length - picked < dri.Length);
                if (cmd.ToLower() == "exit")
                {
                    check = true;
                    picked = 0;
                }
                if (cmd.ToLower() == "help")
                {
                    check = true;
                    picked = -2;
                }
            } while (!check);
            return picked;
        }

        /// <summary>
        /// Print directory and read command.
        /// </summary>
        /// <returns> Directory to be opened next. </returns>
        private static string NextStep(string way)
        {
            string[] directories = null;
            string[] files = null;
            if (!DirectoryCommands.OpenNextDirectory(way, ref directories, ref files))// Метод выдаёт два массива: один с директориями, другой с файлами (всё указанной директории).
                return Path.GetDirectoryName(way);
            string command = ReadInput(files.Length, directories.Length, out char[] FileOrDirectory, out int which); // Метод считывает пользовательскую команду и возвращает либо индекс файла, либо символы, нужные для дальнейшей работы. Метод может вернуть только правильное значение.
            switch (command)
            {
                case "back":
                    Console.Clear();
                    if (Path.GetDirectoryName(way) == null)
                    {
                        string cmd;
                        do
                        {
                            cmd = ToDrives();
                        } while (cmd == "help");
                        return cmd;
                    }
                    return Path.GetDirectoryName(way);
                case "d0":
                    DirectoryCommands.CreateDirectory(way);
                    Console.Clear();
                    return way;
                case "f0":
                    FileCommands.CreateFile(way);
                    Console.Clear();
                    return way;
                case "help":
                    Help();
                    Console.Clear();
                    return way;
                case "incorrect": return way;
                case "exit": return "exit";
                default:
                    if (FileOrDirectory[0] == 'f')
                        return CommandsForFile(way, files[which-1], FileOrDirectory[1]);
                   else return CommandsForDirectory(way, directories[which-1], FileOrDirectory[1]);
            }
        }

        /// <summary>
        /// Launch proper command for given file.
        /// </summary>
        /// <returns> Directory to be opened next. </returns>
        private static string CommandsForFile(string way, string file, char command)
        {
            switch (command)
            {
                case ' ': return FileCommands.OpenFile(way, file, null);
                case 'c': return FileCommands.CopyFile(way, file);
                case 'm': return FileCommands.MoveFile(way, file);
                case 'd': return FileCommands.DeleteFile(way, file);
                case 'g': return FileCommands.GlueFiles(way, file);
                case 'n': return FileCommands.RenameFile(way, file);
                default: return way;
            }
        }

        /// <summary>
        /// Launch proper command for given directory.
        /// </summary>
        /// <returns> Directory to be opened next. </returns>
        private static string CommandsForDirectory(string way, string directory, char command)
        {
            switch (command)
            {
                case ' ': return directory;
                case 'm': return DirectoryCommands.MoveDirectory(way, directory);
                case 'd': return DirectoryCommands.DeleteDirectory(way, directory);
                case 'n': return DirectoryCommands.RenameDirectory(way, directory);
                default: return way;
            }
        }

        /// <summary>
        /// User writes command.
        /// </summary>
        /// <returns> Command written by user and additional info about directory or file index. </returns>
        static string ReadInput(int filesQuantity, int directoriesQuantity, out char[] inputInfo, out int which)
        {
            which = 0;
            inputInfo = new char[2];
            bool validateInput = true;
            string input = null;
            do
            {
                if (!validateInput)
                {
                    Alert("Incorrect input", true);
                    return "incorrect";
                }
                input = Console.ReadLine();
                input = input == null ? "incorrect" : input.ToLower();
                if (input == "d0" || input == "f0" || input == "exit" || input == "back" || input == "help")
                {
                    Console.Clear();
                    return input;
                }
                string[] inputData = input.Split('.');
                if (inputData[0].StartsWith("d") && (inputData[0].Length - inputData[0].Replace("d", "").Length) == 1 
                    && int.TryParse(inputData[0].Replace("d", ""), out which) && inputInfo.Length < 3)
                {
                    inputInfo[0] = 'd';
                    if (inputData.Length == 2)
                        inputInfo[1] = CheckCommand(false, inputData[1]);
                    else inputInfo[1] = ' ';
                    if (inputInfo[1] == '@' || which > directoriesQuantity || which < 0)
                        validateInput = false;
                }
                else if (inputData[0].StartsWith("f") && ((inputData[0].Length - inputData[0].Replace("f", "").Length) == 1)
                        && int.TryParse(inputData[0].Replace("f", ""), out which) && inputInfo.Length < 3)
                {
                    inputInfo[0] = 'f';
                    if (inputData.Length == 2)
                        inputInfo[1] = CheckCommand(true, inputData[1]);
                    else inputInfo[1] = ' ';
                    if (inputInfo[1] == '@' || which > filesQuantity || which < 0)
                        validateInput = false;
                }
                else validateInput = false; 
            } while (!validateInput);
            Console.Clear();
            return input;
        }

        /// <summary>
        /// Validate command given by user. Addition for "ReadInput" method.
        /// </summary>
        /// <returns> Char code of the command. </returns>
        private static char CheckCommand(bool isFile, string cmd)
        {
            switch (cmd)
            {
                case "copy": return isFile ? 'c' : '@';
                case "concatinate": return isFile ? 'g' : '@';
                case "rename": return 'n';
                case "move": return 'm';
                case "delete": return 'd';
                default: return '@';
            }
        }

        /// <summary>
        /// Highlight important message for user.
        /// </summary>
        public static void Alert(string text, bool clear)
        {
            if (clear)
                Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// User writes name of file or directory to be created.
        /// </summary>
        /// <returns> Name of file or directory </returns>
        public static string ReadFileOrDirectoryName(string message)
        {
            bool checkLength = true, checkName = true;
            string input;
            string allowed = "qwertyuiopasdfghjklzxcvbnm+-_@1234567890";
            do
            {
                Console.Clear();
                if (!checkName) 
                    Alert("Only latin letters, digits, @, +, -, _ are allowed", false);
                if (!checkLength) 
                    Alert("Name must contain no more than 25 symbols and cannot be null", false);
                Console.WriteLine(message);
                input = Console.ReadLine();
                if (input == null)
                {
                    checkLength = true;
                    checkName = false;
                    continue;
                }
                if (input.Length > 25) 
                    checkLength = false;
                else
                {
                    checkName = true;
                    foreach (char ch in input.ToLower())
                        if (!allowed.Contains(ch))
                        {
                            checkName = false;
                            break;
                        }
                }
            } while (!checkLength || !checkName);
            return input;
        }

        /// <summary>
        /// Print useful info.
        /// </summary>
        static void Help()
        {
            Alert("Press Esc to close", true);
            Console.WriteLine("List of commands:\n\nHelp - This list\nBack - Go to previous directory\nSearch - Quick acces to file or directory by writing it's path\nExit - Finish program\n");
            Console.WriteLine("<file indicator> - Open file (F1, F34 etc.)");
            Console.WriteLine("<file indicator>.move - Move chosen file (F7.move, F36.move, etc.)\n<file indicator>.copy - Copy chosen file (F7.copy, F36.copy, etc.)\n<file indicator>.delete - Delete chosen file (F7.delete, F36.delete, etc.)");
            Console.WriteLine("<file indicator>.concatinate - Concatinate chosen file with another one (F7.concatinate, F36.concatinate, etc.) \n<file indicator>.rename - Reaname chosen file (F7.rename, F36.rename, etc.)\n");
            Console.WriteLine("<directory indicator> - Open directory (D1, D15, etc.)");
            Console.WriteLine("<directory indicator>.move - Move chosen directory (D8.move, D12.move) \n<directory indicator>.delete - Delete chosen directory (D8.delete, D12.delete) \n<directory indicator>.rename - Rename chosen directory (D8.rename, D12.rename) \n");
            bool check = true;
            do
            {
                if (!check) Alert("Please press Esc", false);
                check = Console.ReadKey().Key == ConsoleKey.Escape;
            } while (!check);
        }
    }
}
