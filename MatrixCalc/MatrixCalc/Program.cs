using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace MatrixCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            uint rowsA = ReadSize("Rows");
            uint columnsA = ReadSize("Columns");
            Matrix A = rowsA == columnsA ? new SquareMatrix(rowsA, true) : new Matrix(rowsA, columnsA, true);
            Matrix B = null;
            string cmd = "";
            do
            {
                Console.Clear();
                cmd = B == null ? SingleMatrixCommand(ref A, ref B, 0, cmd, true) : ReadCommandAB(ref A, ref B, cmd);
                if (cmd == "exit")
                    break;
                Console.WriteLine(cmd);
            } while (true);
        }

        /// <summary>
        /// Read and execute user's command for one matrix.
        /// </summary>
        /// <returns> Result of the command. </returns>
        private static string SingleMatrixCommand(ref Matrix A, ref Matrix B, int command, string prevResult, bool isA)
        {
            Console.WriteLine("A =\n" + A + "\n");
            string message = "\nChoose what to do:\n" +
                "0 - set matrix B\n1 - reset matrix A\n2 - det(A)\n3 - tr(A)\n4 - A^(T)\n5 - A*const\n\nExit - *guess what*\n";
            string matrixName = isA ? "A" : "B";
            if (isA)
                Console.WriteLine(message);
            else Console.WriteLine(message.Replace("A", "B").Replace("B", "A"));
            Console.WriteLine(prevResult);
            string singleCommand = command == 0 ? Console.ReadLine() : command.ToString();
            if (singleCommand is null)
                return "Command does not exist";
            switch (singleCommand.Trim())
            {
                case "exit": return "exit";
                case "0":
                    Console.Clear();
                    uint rowsB = ReadSize("Rows");
                    uint columnsB = ReadSize("Columns");
                    B = rowsB == columnsB ? new SquareMatrix(rowsB, true) : new Matrix(rowsB, columnsB, true);
                    return "";
                case "1":
                    Console.Clear();
                    uint rowsA = ReadSize("Rows");
                    uint columnsA = ReadSize("Columns");
                    A = rowsA == columnsA ? new SquareMatrix(rowsA, true) : new Matrix(rowsA, columnsA, true); ;
                    return "";
                case "2": return A is SquareMatrix ? $"det({matrixName}) = " + (A as SquareMatrix).Det() : 
                        $"{matrixName} is not square";
                case "3": return A is SquareMatrix ? $"tr({matrixName}) = " + (A as SquareMatrix).Trace(false) :
                        $"{matrixName} is not square"; ;
                case "4": return $"{matrixName}^T =\n" + A.Transpose().ToString();
                case "5":
                    Console.Clear();
                    Console.WriteLine("Const =\n");
                    return double.TryParse(Console.ReadLine(), out double c) ? $"{c}*{matrixName} =\n" + (c * A).ToString() :
                        "Incorrect input";
                default: return "Command does not exist";
            }
        }

        /// <summary>
        /// Read and execute user's command for two matrices.
        /// </summary>
        /// <returns> Result of the command. </returns>
        private static string ReadCommandAB(ref Matrix A, ref Matrix B, string prevResult)
        {
            Console.WriteLine("A =\n" + A + "\n");
            Console.WriteLine("B =\n" + B + "\n");
            Console.WriteLine("\nChoose what to do:\n\nA1 - reset matrix A\nA2 - det(A)\nA3 - tr(A)\nA4 - A^(T)\nA5 - A*const\n");
            Console.WriteLine("B1 - reset matrix B\nB2 - det(B)\nB3 - tr(B)\nB4 - B^(T)\nB5 - B*const\n");
            Console.WriteLine("1 - A+B\n2 - A-B\n3 - A*B\n4 - B*A\n5 - Linear system (A*X = B)\n\nExit - *guess what*\n");
            Console.WriteLine(prevResult);
            string command = Console.ReadLine();
            if (command is null)
                return "Command does not exist";
            switch (command.Trim().ToLower())
            {
                case "exit": return "exit";
                case "1": 
                    try { return "A+B =\n" + (A + B).ToString(); }
                    catch { return "Matrices mismatch"; }
                case "2":
                    try { return "A-B =\n" + (A + (-1) * B).ToString(); }
                    catch { return "Matrices mismatch"; }
                case "3":
                    try { return "A*B =\n" + (A * B).ToString(); }
                    catch { return "Matrices mismatch"; }
                case "4": 
                    try { return "B*A =\n" + (B * A).ToString(); }
                    catch { return "Matrices mismatch"; }  
                case "5":
                    try { return A is SquareMatrix ? "X =\n" + ((A as SquareMatrix) / B).ToString() : "A is not square"; }
                    catch (ArrayTypeMismatchException) { return "Matrices mismatch"; }
                    catch (InvalidOperationException) { return "det(A) = 0\nCannot solve A*X = B"; }
                default:
                    if (command.StartsWith("a") && int.TryParse(command.Trim().ToLower().Replace("a", ""), out int cmdA) &&
                        cmdA > 0 && cmdA < 6)
                        return SingleMatrixCommand(ref A, ref B, cmdA, "", true);
                    if (command.StartsWith("b") && int.TryParse(command.Trim().ToLower().Replace("b", ""), out int cmdB) &&
                        cmdB > 0 && cmdB < 6)
                        return SingleMatrixCommand(ref B, ref A, cmdB, "", false);
                    else return "Command does not exist";
            }
        }

        /// <summary>
        /// Read number of rows or columns for the new matrix.
        /// </summary>
        /// <returns> Number of rows or columns. </returns>
        private static uint ReadSize(string what)
        {
            bool check = true;
            uint num;
            do
            {
                if (!check)
                    Console.WriteLine($"Number of {what.ToLower()} must be integer from 1 to 10");
                else
                    Console.Write($"Set the matrix: \n{what}: ");
                check = uint.TryParse(Console.ReadLine(), out num) && num > 0 && num <= 10;
            } while (!check);
            return num;
        }
    }
}
