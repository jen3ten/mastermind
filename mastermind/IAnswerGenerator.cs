using System;
using System.Collections.Generic;
using System.Text;

namespace mastermind
{
    public interface IAnswerGenerator
    {
        public string[] Answer { get; set; } 
        public int NumberDigits { get; set; }
        public int MaximumGuesses { get; set; }

        void SetAnswerSize();
        public int GetRandomDigit();
        public void GenerateRandomAnswer();

    }
}
