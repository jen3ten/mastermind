using System;
using Xunit;

namespace mastermind.Tests
{
    public class GameTests
    {
        Game sut;
        public GameTests()
        {
            sut = new Game();
        }


        // Answer Tests
        [Fact]
        public void Game_Can_Set_4_Digit_Answer_Property()
        {
            sut.Answer = new int[] { 1, 2, 3, 4 };

            Assert.True(sut.Answer != null);
        }

        [Fact]
        public void Answer_Is_Integer_Array()
        {
            sut.Answer = new int[] { 1, 2, 3, 4 };

            Assert.IsType<int[]>(sut.Answer);
        }

        [Fact]
        public void getRandomDigit_Should_Return_Integer()
        {
            int digit = sut.getRandomDigit();

            Assert.IsType<int>(digit);
        }

        [Fact]
        public void getRandomDigit_Should_Return_Integer_Between_1_And_6()
        {
            for(int i = 0; i < 50; i++)
            {
                int digit = sut.getRandomDigit();

                Assert.InRange(digit, 1, 6);
            }
        }

        [Fact]
        public void generateRandomAnswer_Should_Create_4_Digit_Answer()
        {
            sut.generateRandomAnswer();

            Assert.Equal(4, sut.Answer.Length);
        }

        [Fact]
        public void generateRandomAnswer_Should_Create_Answer_With_Digits_Between_1_And_6()
        {
            sut.generateRandomAnswer();

            Assert.All(sut.Answer, digit => Assert.InRange(digit, 1, 6));
        }

        // Guess Tests
        [Fact]
        public void Game_Can_Set_4_Digit_Guess_Property()
        {
            sut.Guess = new int[] { 1, 2, 3, 4 };

            Assert.True(sut.Guess != null);
        }

        [Fact]
        public void Guess_Is_Integer_Array()
        {
            sut.Guess = new int[] { 1, 2, 3, 4 };

            Assert.IsType<int[]>(sut.Guess);
        }

    }
}
