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
        public void generateRandomAnswer_Should_Create_4_Digit_Answer()
        {
            sut.generateRandomAnswer();

            Assert.Equal(4, sut.Answer.Length);
        }
    }
}
