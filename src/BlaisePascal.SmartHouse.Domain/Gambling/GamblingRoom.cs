using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
enum Game 
{
    ROULETTE,
    BLACKJACK,
   SLOTT
}

namespace BlaisePascal.SmartHouse.Domain.Gambling
{
    internal class GamblingRoom
    {
        public void selectGame(Game game,int bet) 
        {
            if (game == Game.ROULETTE)
            {
                RussianRoulette newRoulette = new RussianRoulette(bet);
            }
            else if (game == Game.BLACKJACK)
            {
                BlackJack newBlackJack = new BlackJack(bet);
            }
            else if (game == Game.SLOTT) 
            {
                Slot newSlott= new Slot(bet);
            }
        }


    }
}
