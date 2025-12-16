using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Gambling
{
    public class Slot
    {
        private int ExtractedNumber;
        private int ExtractedNumber2;
        private int ExtractedNumber3;

        public int bet { get; protected set; }

        public Slot(int _bet)
        {
            if (_bet <= 0)
            {
                throw new ArgumentException("Bet must be greater than zero");
            }
            bet = _bet;

        }

        public int playSlot() 
        {
            Random random = new Random();
            ExtractedNumber = random.Next(0, 11);
            Random random2 = new Random();
            ExtractedNumber2 = random.Next(0, 11);
            Random Random3 = new Random();
            ExtractedNumber3 = random2.Next(0, 11);

            if (ExtractedNumber == ExtractedNumber2 && ExtractedNumber == ExtractedNumber3)
            {
                return bet * 2;
            }
            else if (ExtractedNumber == ExtractedNumber3 && ExtractedNumber == ExtractedNumber2 && ExtractedNumber == 1)
            {
                return playBonus();
            }
            else 
            {
                return 0;
            }


        }

        private int playBonus() 
        {
            return bet * 10;
        }

    }
}
