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
    }
}
