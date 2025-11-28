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
        public void Roulette_constructorbet_AssertEquals()
        {
            Roulette roulette = new Roulette(10);
            Assert.Equal(10, roulette.bet);
        }
        public void Roulette_constructorbet_LowerThanZero_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Roulette(0));
        }
    }
}
