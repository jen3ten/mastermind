using System;

namespace mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface.DisplayRules();

            // Set difficulty and initialize new game
            string difficulty = UserInterface.SetDifficulty(); 

            Game game;
            switch (difficulty.ToLower())
            {
                case "easy":
                    game = new Game(new AnswerEasy());
                    break;
                case "medium":
                    game = new Game(new AnswerMedium());
                    break;
                case "hard":
                    game = new Game(new AnswerHard());
                    break;
                default:
                    game = new Game(new AnswerMedium());
                    break;
            }

            // For development only
            game.DisplayAnswer();

            int guessNumber = 1;
            bool continueGuessing = true;

            // Ask for guesses until user wins or reaches maximum number of guesses
            do
            {
                // Request valid guess from user
                do
                {
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
                }
                // If not a winning guess, identify number of digits that match answer and display result
                else
                {
                    game.CompareCorrectDigit();
                    game.DisplayResult();

                    // Display message and stop game if maximum number of guesses have been reached
                    if(guessNumber >= game.answerGenerator.MaximumGuesses)
                    {
                        continueGuessing = false;
                        UserInterface.LosingMessage(game.answerGenerator.MaximumGuesses);
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
