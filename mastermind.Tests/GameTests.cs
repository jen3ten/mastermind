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

        [Theory]
        [InlineData("5555")]
        [InlineData("7890")]
        [InlineData("aaaa")]
        [InlineData("string")]
        [InlineData("1 2 3 4")]
        [InlineData("This is a string!")]
        [InlineData("1,2,3,4")]
        public void ConvertInputToStringArray_Should_Convert_String_To_String_Array(string input)
        {
            sut.ConvertInputToStringArray(input);

            Assert.IsType<string[]>(sut.InputStringArray);
        }

        [Theory]
        [InlineData("5555")]
        [InlineData("7890")]
        [InlineData("aaaa")]
        public void InputIs4Digits_Should_Return_True_If_InputStringArray_Has_Length_of_4(string input)
        {
            sut.ConvertInputToStringArray(input);

            Assert.True(sut.InputIs4Digits());
        }

        [Theory]
        [InlineData("string")]
        [InlineData("1 2 3 4")]
        [InlineData("This is a string!")]
        [InlineData("1,2,3,4")]
        public void InputIs4Digits_Should_Return_False_If_InputStringArray_Does_Not_Have_Length_of_4(string input)
        {
            sut.ConvertInputToStringArray(input);

            Assert.False(sut.InputIs4Digits());
        }

        [Theory]
        [InlineData("5555")]
        [InlineData("7890")]
        [InlineData("123456789")]
        public void InputDigitsAreIntegers_Should_Return_True_If_InputStringArray_Elements_Can_Be_Converted_To_Int(string input)
        {
            sut.ConvertInputToStringArray(input);

            Assert.True(sut.InputDigitsAreIntegers());
        }

        [Theory]
        [InlineData("string")]
        [InlineData("1 2 3 4")]
        [InlineData("This is a string!")]
        [InlineData("1,2,3,4")]
        [InlineData("123a")]
        public void InputDigitsAreIntegers_Should_Return_False_If_Any_InputStringArray_Elements_Can_Not_Be_Converted_To_Int(string input)
        {
            sut.ConvertInputToStringArray(input);

            Assert.False(sut.InputDigitsAreIntegers());
        }
    }
}
