using System;
using System.Collections.Generic;
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

        [Theory]
        [InlineData("")]
        [InlineData("+")]
        [InlineData("++")]
        [InlineData("+++")]
        public void IncreaseCorrectPositionCount_Should_Increase_Plus_Symbols_By_1(string initialPositionCount)
        {
            sut.CorrectPositionCount = initialPositionCount;
            int expectedCount = sut.CorrectPositionCount.Length + 1;

            sut.IncreaseCorrectPositionCount();

            Assert.Equal(expectedCount, sut.CorrectPositionCount.Length);
        }

        [Theory]
        [InlineData("")]
        [InlineData("+")]
        [InlineData("++")]
        [InlineData("+++")]
        public void CorrectPositionCount_Should_Consist_Of_Only_Plus_Symbols_After_Increase_Count(string initialPositionCount)
        {
            sut.CorrectPositionCount = initialPositionCount;
            sut.IncreaseCorrectPositionCount();

            Assert.All(sut.CorrectPositionCount, character => Assert.Equal('+', character));
        }

        [Fact]
        public void AddToGuessDigits_Should_Add_Digit_To_GuessDigitsRemaining_List()
        {
            int index = 0;
            int expectedCount = sut.GuessDigitsRemaining.Count + 1;
            sut.ConvertInputToStringArray("1234");

            sut.AddToGuessDigits(index);

            Assert.Equal(expectedCount, sut.GuessDigitsRemaining.Count);
        }

        [Theory]
        [InlineData(0, "2134")]
        [InlineData(0, "2222")]
        [InlineData(2, "2222")]
        [InlineData(1, "1234")]
        [InlineData(2, "1324")]
        [InlineData(3, "4312")]
        public void AddToGuessDigits_Should_Add_Value_2_To_GuessDigitsRemaining_List(int index, string inputString)
        {
            sut.ConvertInputToStringArray(inputString);

            sut.AddToGuessDigits(index);

            Assert.Contains("2", sut.GuessDigitsRemaining);
        }

        [Fact]
        public void AddToAnswerDigits_Should_Add_Digit_To_AnswerDigitsRemaining_List()
        {
            int index = 0;
            int expectedCount = sut.AnswerDigitsRemaining.Count + 1;
            sut.Answer = new string[] { "1", "2", "3", "4" };

            sut.AddToAnswerDigits(index);

            Assert.Equal(expectedCount, sut.AnswerDigitsRemaining.Count);
        }

        [Theory]
        [InlineData(0, new string[] { "2", "1", "3", "4" })]
        [InlineData(0, new string[] { "2", "2", "2", "2" })]
        [InlineData(2, new string[] { "2", "2", "2", "2" })]
        [InlineData(1, new string[] { "1", "2", "3", "4" })]
        [InlineData(2, new string[] { "1", "3", "2", "4" })]
        [InlineData(3, new string[] { "4", "3", "1", "2" })]
        public void AddToAnswerDigits_Should_Add_Value_2_To_AnswerDigitsRemaining_List(int index, string[] inputArray)
        {
            sut.Answer = inputArray;

            sut.AddToAnswerDigits(index);

            Assert.Contains("2", sut.AnswerDigitsRemaining);
        }

        [Fact]
        public void CompareCorrectPosition_Should_Add_4_Plus_Symbols_To_Correct_Position_And_Nothing_To_Digit_Lists()
        {
            sut.Guess = new string[] { "1", "2", "3", "4" };
            sut.Answer = new string[] { "1", "2", "3", "4" };

            sut.CompareCorrectPosition();

            Assert.Equal("++++", sut.CorrectPositionCount);
            Assert.Empty(sut.GuessDigitsRemaining);
            Assert.Empty(sut.AnswerDigitsRemaining);
        }

        [Fact]
        public void CompareCorrectPosition_Should_Add_0_Plus_Symbols_To_Correct_Position_And_4_Values_To_Digit_Lists()
        {
            sut.Guess = new string[] { "1", "2", "3", "4" };
            sut.Answer = new string[] { "4", "3", "2", "1" };

            sut.CompareCorrectPosition();

            Assert.Equal("", sut.CorrectPositionCount);
            Assert.Equal(4, sut.GuessDigitsRemaining.Count);
            Assert.Equal(4, sut.AnswerDigitsRemaining.Count);
        }

        [Fact]
        public void CompareCorrectPosition_Should_Add_2_Plus_Symbols_To_Correct_Position_And_2_Values_To_Digit_Lists()
        {
            sut.Guess = new string[] { "1", "2", "3", "4" };
            sut.Answer = new string[] { "1", "5", "6", "4" };

            sut.CompareCorrectPosition();

            Assert.Equal("++", sut.CorrectPositionCount);
            Assert.Equal(2, sut.GuessDigitsRemaining.Count);
            Assert.Equal(2, sut.AnswerDigitsRemaining.Count);
        }

        [Theory]
        [InlineData(new string[] { "1", "2", "3", "4" }, "1")]
        [InlineData(new string[] { "1", "2", "3", "4" }, "2")]
        [InlineData(new string[] { "1", "1", "1", "1" }, "1")]
        [InlineData(new string[] { "2", "3", "4", "1" }, "1")]
        public void FindDigitInAnswer_Should_Return_True_If_Digit_Exists_In_AnswerDigitsRemaining_List(string[] answerDigits, string guessDigit)
        {
            sut.AnswerDigitsRemaining = new List<string>(answerDigits);

            Assert.True(sut.FindDigitInAnswer(guessDigit));
        }

        [Theory]
        [InlineData(new string[] { "1", "2", "3", "4" }, "5")]
        [InlineData(new string[] { "1", "2", "3"}, "5")]
        [InlineData(new string[] { "1", "1", "1", "1" }, "5")]
        [InlineData(new string[] { "2", "3", "4", "1" }, "5")]
        public void FindDigitInAnswer_Should_Return_False_If_Digit_Does_Not_Exist_In_AnswerDigitsRemaining_List(string[] answerDigits, string guessDigit)
        {
            sut.AnswerDigitsRemaining = new List<string>(answerDigits);

            Assert.False(sut.FindDigitInAnswer(guessDigit));
        }

        [Theory]
        [InlineData("")]
        [InlineData("-")]
        [InlineData("--")]
        [InlineData("---")]
        public void IncreaseCorrectDigitCount_Should_Increase_Minus_Symbols_By_1(string initialDigitCount)
        {
            sut.CorrectDigitCount = initialDigitCount;
            int expectedCount = sut.CorrectDigitCount.Length + 1;

            sut.IncreaseCorrectDigitCount();

            Assert.Equal(expectedCount, sut.CorrectDigitCount.Length);
        }

        [Theory]
        [InlineData("")]
        [InlineData("-")]
        [InlineData("--")]
        [InlineData("---")]
        public void CorrectDigitCount_Should_Consist_Of_Only_Minus_Symbols_After_Increase_Count(string initialDigitCount)
        {
            sut.CorrectDigitCount = initialDigitCount;
            sut.IncreaseCorrectDigitCount();

            Assert.All(sut.CorrectDigitCount, character => Assert.Equal('-', character));
        }

        [Theory]
        [InlineData("2", new string[] { "2", "1", "3", "4" })]
        [InlineData("2", new string[] { "1", "2", "3" })]
        [InlineData("2", new string[] { "2", "2", "2", "2" })]
        [InlineData("2", new string[] { "4", "3", "2", "2" })]
        [InlineData("2", new string[] { "2" })]
        public void RemoveFromAnswerDigits_Should_Remove_One_Matching_Digit_From_AnswerDigitsRemaining_List(string digit, string[] inputArray)
        {
            sut.AnswerDigitsRemaining = new List<string>(inputArray);
            int expectedCount = sut.AnswerDigitsRemaining.Count - 1;

            sut.RemoveFromAnswerDigits(digit);

            Assert.Equal(expectedCount, sut.AnswerDigitsRemaining.Count);
        }

        [Theory]
        [InlineData("2", new string[] { "2", "1", "3", "4" })]
        [InlineData("2", new string[] { "1", "2", "3", "4" })]
        [InlineData("2", new string[] { "1", "3", "2", "4" })]
        [InlineData("2", new string[] { "4", "3", "1", "2" })]
        public void RemoveFromAnswerDigits_Should_Remove_Value_2_From_AnswerDigitsRemaining_List(string digit, string[] inputArray)
        {
            sut.AnswerDigitsRemaining = new List<string>(inputArray);

            sut.RemoveFromAnswerDigits(digit);

            Assert.DoesNotContain("2", sut.AnswerDigitsRemaining);
        }

    }
}
