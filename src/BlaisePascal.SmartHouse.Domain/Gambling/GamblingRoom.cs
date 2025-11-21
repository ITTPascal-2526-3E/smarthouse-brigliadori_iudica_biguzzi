using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum Game 
{
   ROULETTE,
   BLACKJACK,
   SLOTT,
    RUSSIANROULETTE
}

namespace BlaisePascal.SmartHouse.Domain.Gambling
{
    public class GamblingRoom
    {
        public void SelectGame(Game game,int bet) 
        {
            if (game == Game.ROULETTE)
            {
                Roulette newRoulette = new Roulette(bet);
            }
            else if (game == Game.BLACKJACK)
            {
                BlackJack newBlackJack = new BlackJack(bet);
            }
            else if (game == Game.SLOTT) 
            {
                Slot newSlott= new Slot(bet);
            }
            else if (game == Game.RUSSIANROULETTE) 
            {
                RussianRoulette newRussianRoulette = new RussianRoulette(bet);
            }
        }


    }
}
