﻿using System;

namespace mastermind
{
    public class Game
    {
        public int[] Answer { get; set; } = new int[4];
        public int[] Guess { get; set; } = new int[4];
        public string[] InputStringArray { get; set; }


        public int GetRandomDigit()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }

        public void GenerateRandomAnswer()
        {
            for(int i = 0; i < 4; i++)
            {
                Answer[i] = GetRandomDigit();
            }
        }

        public void ConvertInputToStringArray(string input)
        {
            char[] inputCharacterArray = input.ToCharArray();
            InputStringArray = new string[input.Length];
            for(int i = 0; i < input.Length; i++)
            {
                InputStringArray[i] = inputCharacterArray[i].ToString();
            }
        }

        public bool InputIs4Digits()
        {
            return InputStringArray.Length == 4;
        }

        public bool InputDigitsAreIntegers()
        {
            int number;
            foreach(string digit in InputStringArray)
            {
                if(Int32.TryParse(digit, out number) == false)
                {
                    return false;
                }
            }
            return true;
        }

        public bool InputDigitsInRange()
        {
            int number;
            bool success;
            foreach (string digit in InputStringArray)
            {
                success = Int32.TryParse(digit, out number);
                if (success && (number < 1 || number > 6))
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckValidityOfInput()
        {
            string message = "";
            bool validity = true;

            if (!InputIs4Digits())
            {
                message += "The input does not contain exactly 4 digits. ";
                validity = false;
            }

            if (!InputDigitsAreIntegers())
            {
                message += "The input consists of digits that are not integers. ";
                validity = false;
            }

            if (!InputDigitsInRange())
            {
                message += "The input contains digits that are not integers between 1-6. ";
                validity = false;
            }

            if (message != "")
            {
                Console.WriteLine("Input ERROR: " + message + "Please enter a valid guess.");
            }

            return validity;
        }
    }
}
