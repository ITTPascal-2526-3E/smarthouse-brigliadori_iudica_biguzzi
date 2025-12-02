using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Gambling;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class BlackJackTest
    {

        [Fact]
        public void BlackJack_constructorbet_AssertEquals()
        {
            BlackJack blackjack = new BlackJack(10);

            Assert.Equal(10, blackjack.bet);
        }

        [Fact]
        public void BlackJack_playnumber_playerNotWin_AssertEquals()
        {
            BlackJack blackjack = new BlackJack(10);
            int result = blackjack.PlayNumber();
            Assert.Equal(0, result);
        }

        [Fact]
        public void BlackJack_constructorbet_LowerThanZero_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new BlackJack(0));
        }
    }
}
