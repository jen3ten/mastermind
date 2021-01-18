using System;
using System.Collections.Generic;
using System.Text;

namespace mastermind
{
    public class UserInterface
    {
        public static void DisplayRules()
        {
            Console.WriteLine("Mastermind!\n");
            Console.WriteLine("Your goal is to guess the 3, 4, or 5 digit answer I will randomly generate.\n");
            Console.WriteLine("RULES:");
            Console.WriteLine("Each digit is an integer between 1-6.");
            Console.WriteLine("Digits can be repeated.");
            Console.WriteLine("You will have 8, 10, or 12 chances to guess the answer.");
            Console.WriteLine("I will give you a + (plus) symbol for every digit that is correct and in the correct position.");
            Console.WriteLine("I will give you a - (minus) symbol for every digit that is correct, but in the wrong position.");
            Console.WriteLine("Enter the exact number of digits for each guess. Do not include spaces or commas.");
            Console.WriteLine("\nGood Luck!\n");
        }

        public static string SetDifficulty()
        {
            Console.Write("How difficult do you want the game to be?  Please select easy (3 digits), medium (4 digits), or hard (5 digits): ");
            return Console.ReadLine();
        }

        public static string ReadGuess(int guessNumber)
        {
            string guessPrompt = $"Guess #{guessNumber}:";
            Console.Write($"{guessPrompt,-12}");
            return Console.ReadLine();
        }

        public static void WinningMessage(int numberGuesses)
        {
            Console.WriteLine($"Congratulations!  You guessed the answer in {numberGuesses} tries!");
        }

        public static void LosingMessage(int maximumGuesses)
        {
            Console.WriteLine($"Too bad!  You didn't guess the answer in {maximumGuesses} tries.");

        }
    }
}
