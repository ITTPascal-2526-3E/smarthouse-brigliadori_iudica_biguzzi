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

            Assert.Equal(10,blackjack.bet);
        }
        [Fact]
        public void BBlackJack_constructorbet_AssertThrow()
        {
            BlackJack blackJack;

            Assert.Throws<ArgumentException>(blackJack = new BlackJack(0));
        }   
    }
}
