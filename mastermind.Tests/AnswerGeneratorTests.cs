using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace mastermind.Tests
{
    public class AnswerGeneratorTests
    {
        IAnswerGenerator sut;

        public AnswerGeneratorTests()
        {
            sut = new AnswerMedium();
        }

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

    }
}
