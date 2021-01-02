using System;

namespace mastermind
{
    public class Game
    {
        public int[] Answer { get; set; } = new int[4];

        public int getRandomDigit()
        {
            Random random = new Random();
            return random.Next();
        }

        public void generateRandomAnswer()
        {
        }
    }
}
