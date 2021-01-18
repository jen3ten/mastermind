using System;
using System.Collections.Generic;
using System.Text;

namespace mastermind
{
    public class AnswerGenerator
    {
        public string[] Answer { get; set; } = new string[4];

        public AnswerGenerator()
        {
            GetRandomDigit();
            GenerateRandomAnswer();
        }

        public int GetRandomDigit()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }

        public void GenerateRandomAnswer()
        {
            for (int i = 0; i < 4; i++)
            {
                Answer[i] = GetRandomDigit().ToString();
            }
        }

    }
}
