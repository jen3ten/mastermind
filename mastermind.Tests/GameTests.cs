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
            sut.Answer = new string[] { "1", "2", "3", "4" };

            Assert.True(sut.Answer != null);
        }

        [Fact]
        public void Answer_Is_String_Array()
        {
            sut.Answer = new string[] { "1", "2", "3", "4" };

            Assert.IsType<string[]>(sut.Answer);
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
            for (int i = 0; i < 50; i++)
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
            string validDigits = "123456";
            sut.GenerateRandomAnswer();

            Assert.All(sut.Answer, digit => Assert.Contains(digit, validDigits));
        }

        // Guess Tests
        [Fact]
        public void Game_Can_Set_4_Digit_Guess_Property()
        {
            sut.Guess = new string[] { "1", "2", "3", "4" };

            Assert.True(sut.Guess != null);
        }

        [Fact]
        public void Guess_Is_String_Array()
        {
            sut.Guess = new string[] { "1", "2", "3", "4" };

            Assert.IsType<string[]>(sut.Guess);
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

            Assert.IsType<string[]>(sut.Guess);
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

        [Theory]
        [InlineData("5555")]
        [InlineData("1234")]
        [InlineData("3344")]
        [InlineData("123456")]
        [InlineData("123a")]
        [InlineData("1 2 3 4")]
        [InlineData("1,2,3,4")]
        public void InputDigitsInRange_Should_Return_True_If_InputStringArray_Digits_Are_Between_1_And_6(string input)
        {
            sut.ConvertInputToStringArray(input);

            Assert.True(sut.InputDigitsInRange());
        }

        [Theory]
        [InlineData("7890")]
        [InlineData("1273")]
        [InlineData("1203")]
        [InlineData("123456789")]
        [InlineData("7777")]
        [InlineData("0000")]
        public void InputDigitsInRange_Should_Return_False_If_InputStringArray_Digits_Are_Not_Between_1_And_6(string input)
        {
            sut.ConvertInputToStringArray(input);

            Assert.False(sut.InputDigitsInRange());
        }

        // Compare Correct Position Tests
        [Theory]
        [InlineData("1234", 0)]
        [InlineData("1234", 1)]
        [InlineData("1234", 2)]
        [InlineData("1234", 3)]
        [InlineData("1111", 0)]
        [InlineData("4324", 3)]
        public void MatchPositionInAnswer_Should_Return_True_If_Guess_Matches_Answer_At_Index(string guessString, int index)
        {
            sut.Answer = new string[] { "1", "2", "3", "4" };
            sut.ConvertInputToStringArray(guessString);

            Assert.True(sut.MatchPositionInAnswer(index));
        }
    }
}
