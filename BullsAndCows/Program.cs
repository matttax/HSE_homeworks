using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.Write("A number with N unique digits is to be guessed.\nEnter N from 2 to 10: ");
                int N = ReadN();
                Console.WriteLine($"\nNow try to guess that number.\n" +
                    $"Enter your guesses and number of \"bulls\" and \"cows\" will be given.\n" +
                    "\"Bulls\" are matching digits in their right positions.\n\"Cows\" are matching digits on the wrong positions.");
                PlayGame(N);
                Console.WriteLine("\nPress Enter to continue and any other key to finish\n");
            } while (Console.ReadKey().Key == ConsoleKey.Enter);
        }


        /// <summary> Launch the game. 
        /// While number is not guessed, the game goes on. </summary>
        static void PlayGame(int N)
        {
            List<int> GenNum = GeneratedNumber(N);
            do
            {
                Console.WriteLine();
            } while (CheckInput(ReadInput(N), GenNum, N) != N);
        }

        /// <summary> Check if N (number of digits in the round) is correct. </summary>
        /// <returns> N when it is correctly entered. </returns>
        static int ReadN()
        {
            int N;
            bool NIsCorrect = true;
            do
            {
                if (!NIsCorrect) 
                    Console.Write("Number is invalid.\nEnter a number from 2 to 10: ");
                NIsCorrect = int.TryParse(Console.ReadLine(), out N) && N >= 2 && N <= 10;
            } while (!NIsCorrect);
            return N;
        }

        /// <summary> Check if given N-digital number is valid. </summary>
        /// <returns> When number is valid the method returns it. </returns>
        static long ReadInput(int N)
        {
            long input;
            bool isCorrectNumber = true;
            do
            {
                if (!isCorrectNumber)
                    Console.WriteLine("Invalid number!");
                Console.Write($"Enter a number with {N} unique digits: ");
                isCorrectNumber = long.TryParse(Console.ReadLine(), out input) && 
                    ((int)Math.Log10(input) + 1 == N) && DifferentDigits(input);
            } while (!isCorrectNumber);
            return input;
        }

        /// <summary> Find number of bulls and cows. </summary>
        /// <returns> Number of cows. </returns>
        static int CheckInput(long input, List<int> GenNum, int N)
        {
            int Bulls = 0;
            List<int> inputList = input.ToString().ToCharArray().Select(x => x.ToString()).Select(int.Parse).ToList();

            // Number of bulls.
            for (int i = 0; i < N; i++)
                if (GenNum[i] == inputList[i])
                    Bulls++;
            // Number of cows.
            IEnumerable<int> Cows = GenNum.AsQueryable().Intersect(inputList);

            if (Bulls == N)
                Console.WriteLine("Congrats! You win!");
            else PrintResult(Bulls, Cows.Count() - Bulls);
            return Bulls;
        }

        /// <summary> Generates random N-digital number with unique digits. </summary>
        /// <returns> List of digits of the random number. </returns>
        static List<int> GeneratedNumber(int N)
        {
            Random random = new Random();
            List<int> digits = Enumerable.Range(0, 10).ToList();
            for (int i = 0; i < N; i++)
            {
                int rand = random.Next(0, 10);
                (digits[i], digits[rand]) = (digits[rand], digits[i]);
            }
            if (digits[0] == 0)
                (digits[0], digits[1]) = (digits[1], digits[0]);
            return digits.GetRange(0, N);
        }

        /// <summary> Check if digits in the N-digital number are different. </summary>
        /// <returns> 1, if digits are different; 0, if not. </returns>
        static bool DifferentDigits(long num) =>
            num.ToString().Length == num.ToString().ToCharArray().Distinct().Count();


        /// <summary> Print information about bulls and cows. </summary>
        static void PrintResult(int bulls, int cows)
        {
            string bullsText = "";
            switch (bulls)
            {
                case 0: 
                    bullsText += "No bulls";
                    break;
                case 1: 
                    bullsText += "1 bull";
                    break;
                default:
                    bullsText += $"{bulls} bulls";
                    break;
            }
            string cowsText = "";
            switch (cows)
            {
                case 0:
                    cowsText += "\nNo cows";
                    break;
                case 1:
                    cowsText += "\n1 cow";
                    break;
                default:
                    bullsText += $"\n{cows} cows";
                    break;
            }
            Console.WriteLine(bullsText + cowsText);
        }
    }
}