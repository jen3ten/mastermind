using System;
using System.Collections.Generic;

namespace mastermind
{
    public class Game
    {
        public string[] Answer { get; set; } = new string[4];
        public string[] Guess { get; set; }
        public string CorrectPositionCount { get; set; } = "";
        public List<string> GuessDigitsRemaining { get; set; } = new List<string>();
        public List<string> AnswerDigitsRemaining { get; set; } = new List<string>();

        public int GetRandomDigit()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }

        public void GenerateRandomAnswer()
        {
            for(int i = 0; i < 4; i++)
            {
                Answer[i] = GetRandomDigit().ToString();
            }
        }

        public void ConvertInputToStringArray(string input)
        {
            char[] inputCharacterArray = input.ToCharArray();
            Guess = new string[input.Length];
            for(int i = 0; i < input.Length; i++)
            {
                Guess[i] = inputCharacterArray[i].ToString();
            }
        }

        public bool InputIs4Digits()
        {
            return Guess.Length == 4;
        }

        public bool InputDigitsAreIntegers()
        {
            int number;
            foreach(string digit in Guess)
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
            foreach (string digit in Guess)
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

        public bool MatchPositionInAnswer(int index)
        {
            return Answer[index].Equals(Guess[index]);
        }

        public void IncreaseCorrectPositionCount()
        {
            CorrectPositionCount += "+";
        }

        public void AddToGuessDigits(int index)
        {
            GuessDigitsRemaining.Add(Guess[index]);
        }

        public void AddToAnswerDigits(int index)
        {
            AnswerDigitsRemaining.Add(Answer[index]);
        }

        public void CompareCorrectPosition()
        {
            for(int index = 0; index < 4; index++)
            {
                if (MatchPositionInAnswer(index))
                {
                    IncreaseCorrectPositionCount();
                }
                else
                {
                    AddToAnswerDigits(index);
                    AddToGuessDigits(index);
                }
            }
        }
    }
}
