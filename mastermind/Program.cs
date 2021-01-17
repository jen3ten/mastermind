using System;

namespace mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Mastermind!\n");
            //Console.WriteLine("Your goal is to guess the 4 digit answer I have generated.\n");
            //Console.WriteLine("RULES:");
            //Console.WriteLine("Each digit is an integer between 1-6.");
            //Console.WriteLine("Digits can be repeated.");
            //Console.WriteLine("You will have 10 chances to guess the answer.");
            //Console.WriteLine("I will give you a + (plus) symbol for every digit that is correct and in the correct position.");
            //Console.WriteLine("I will give you a - (minus) symbol for every digit that is correct, but in the wrong position.");
            //Console.WriteLine("Enter exactly 4 digits for each guess. Do not include spaces or commas.");
            //Console.WriteLine("\nGood Luck!\n");
            UserInterface.DisplayRules();
            // Initialize new game and generate random answer
            Game game = new Game();
            game.GenerateRandomAnswer();

            // For development only
            // game.DisplayAnswer();

            int guessNumber = 1;
            bool continueGuessing = true;

            // Ask for guesses until user wins or reaches maximum number of guesses
            do
            {
                // Request valid guess from user
                do
                {
                    //string guessPrompt = $"Guess #{guessNumber}:";
                    //Console.Write($"{guessPrompt, -12}");
                    //game.ConvertInputToStringArray(Console.ReadLine());
                    string guess = UserInterface.ReadGuess(guessNumber);
                    game.ConvertInputToStringArray(guess);
                } while (!game.CheckValidityOfInput());

                // Identify number of digits in correct position
                game.CompareCorrectPosition();

                // Display winning message if all digits are in correct position
                if (game.WinningGuess())
                {
                    continueGuessing = false;
                    UserInterface.WinningMessage(guessNumber);
                    //Console.WriteLine($"Congratulations!  You guessed the answer in {guessNumber} tries!");
                }
                // If not a winning guess, identify number of digits that match answer and display result
                else
                {
                    game.CompareCorrectDigit();
                    game.DisplayResult();

                    // Disply message and stop game if maximum number of guesses have been reached
                    if(guessNumber >= game.MaximumGuesses)
                    {
                        continueGuessing = false;
                        //Console.WriteLine($"Too bad!  You didn't guess the answer in {game.MaximumGuesses} tries.");
                        UserInterface.LosingMessage(game.MaximumGuesses);
                        game.DisplayAnswer();
                    }
                    guessNumber += 1;
                    game.ResetResult();
                }
            } while (continueGuessing);

            Console.ReadKey();
        }
    }
}
