using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Gambling
{
    public sealed class RussianRoulette
    {
        public int bet { get; protected set; }
        public int TotalCash { get; protected set; }
        Random random = new Random();
        public RussianRoulette(int Bet)
        {
            bet = Bet;
        }

        public int PlayRussianRoulette(bool FirstToPlay, int roundToPlay)
        {
            int chamberPosition = random.Next(1, 7);
            if (FirstToPlay==true)
            {
                for (int i = 1; i < roundToPlay + 1; i += 2)
                {
                    if (chamberPosition == i)
                    {
                        TotalCash = 0;
                        return TotalCash;
                    }
                    else
                    {
                        if (chamberPosition != i && i + 1 == chamberPosition)
                        {
                            TotalCash = bet * (100 * i);
                            return TotalCash;
                        }
                    }
                }
            }
            else
            {
                for (int i = 2; i < roundToPlay + 1; i += 2)
                {
                    if (chamberPosition == i)
                    {
                        TotalCash = 0;
                        return TotalCash;
                    }
                    else
                    {
                        if (chamberPosition != i && i - 1 == chamberPosition)
                        {
                            TotalCash = bet * (100 * i);
                            return TotalCash;
                        }
                    }
                }
            }

            // Ensure all code paths return a value
            TotalCash = 0;
            return TotalCash;
        }
    }
}
