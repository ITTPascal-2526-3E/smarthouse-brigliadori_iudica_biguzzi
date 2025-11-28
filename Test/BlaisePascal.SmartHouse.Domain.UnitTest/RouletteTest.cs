using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Gambling;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class RouletteTest
    {
        [Fact]
        public void PlayNumber_ShouldReturn35TimesBet_WhenNumberIsCorrect()
        {
            // Arrange
            int bet = 10;
            int chosenNumber = 7;
            Roulette roulette = new Roulette(bet);
            // Act
            int result = roulette.PlayNumber(chosenNumber);
            // Assert
            Assert.Equal(bet * 35, result);
        }
    }
}
