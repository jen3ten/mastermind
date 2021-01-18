using System;
using System.Collections.Generic;
using System.Text;

namespace mastermind
{
    public class AnswerHard : IAnswerGenerator
    {
        public string[] Answer { get; set; } = new string[5];
        public int NumberDigits { get; set; } = 5;
        public int MaximumGuesses { get; set; }  = 12;

        public AnswerHard()
        {
            //SetAnswerSize();
            GetRandomDigit();
            GenerateRandomAnswer();
        }

        public void SetAnswerSize()
        {
            //Console.Write("How difficult do you want the game to be?  Please select a 4, 5, or 6 digit answer: ");
            //NumberDigits = Convert.ToInt32(Console.ReadLine());
            //Answer = new string[NumberDigits];
        }
        public int GetRandomDigit()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }

        public void GenerateRandomAnswer()
        {
            for (int i = 0; i < NumberDigits; i++)
            {
                Answer[i] = GetRandomDigit().ToString();
            }
        }

    }
}
