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
            Console.WriteLine("Your goal is to guess the 4 digit answer I have generated.\n");
            Console.WriteLine("RULES:");
            Console.WriteLine("Each digit is an integer between 1-6.");
            Console.WriteLine("Digits can be repeated.");
            Console.WriteLine("You will have 10 chances to guess the answer.");
            Console.WriteLine("I will give you a + (plus) symbol for every digit that is correct and in the correct position.");
            Console.WriteLine("I will give you a - (minus) symbol for every digit that is correct, but in the wrong position.");
            Console.WriteLine("Enter exactly 4 digits for each guess. Do not include spaces or commas.");
            Console.WriteLine("\nGood Luck!\n");
        }
    }
}
