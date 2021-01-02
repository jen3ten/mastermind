using System;

namespace mastermind
{
    public class Game
    {
        public int[] Answer { get; set; } = new int[4];
        public int[] Guess { get; set; } = new int[4];


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

        public void ConvertInputToGuess(string input)
        {

        }
    }
}
