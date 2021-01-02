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
        public void GetRandomDigit_Should_Return_Integer()
        {
            int digit = sut.GetRandomDigit();

            Assert.IsType<int>(digit);
        }

        [Fact]
        public void GetRandomDigit_Should_Return_Integer_Between_1_And_6()
        {
            for(int i = 0; i < 50; i++)
            {
                int digit = sut.GetRandomDigit();

                Assert.InRange(digit, 1, 6);
            }
        }

        [Fact]
        public void GenerateRandomAnswer_Should_Create_4_Digit_Answer()
        {
            sut.GenerateRandomAnswer();

            Assert.Equal(4, sut.Answer.Length);
        }

        [Fact]
        public void GenerateRandomAnswer_Should_Create_Answer_With_Digits_Between_1_And_6()
        {
            sut.GenerateRandomAnswer();

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

        [Fact]
        public void ConvertInputToStringArray_Should_Convert_String_To_String_Array()
        {
            string userInput = "5555";
            sut.ConvertInputToStringArray(userInput);

            Assert.All(sut.InputStringArray, item => Assert.Equal("5", item));
        }
    }
}
