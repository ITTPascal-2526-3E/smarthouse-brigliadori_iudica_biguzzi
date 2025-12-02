using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Game 
{
   ROULETTE,
   BLACKJACK,
   SLOT,
    RUSSIANROULETTE
}

namespace BlaisePascal.SmartHouse.Domain.Gambling
{
    public class GamblingRoom

    {
        public Game game { get; private set; }
        public void SelectGame(Game _game, int bet)
        {
            game = _game;
            if (bet <= 0 || _game == null)
            {
                throw new ArgumentException("Bet must be greater than zero and a valid game must be selected.");
            }
            else { 
                if (game == Game.ROULETTE)
                {
                    Roulette newRoulette = new Roulette(bet);
                }
                else if (game == Game.BLACKJACK)
                {
                    BlackJack newBlackJack = new BlackJack(bet);
                }
                else if (game == Game.SLOT)
                {
                    Slot newSlott = new Slot(bet);
                }
                else if (game == Game.RUSSIANROULETTE)
                {
                    RussianRoulette newRussianRoulette = new RussianRoulette(bet);
                }
            }
        }


    }
}
