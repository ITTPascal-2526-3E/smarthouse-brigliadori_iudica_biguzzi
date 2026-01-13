using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Gambling
{
    public sealed class BlackJack
    {
        private int benchExtractedNumber;
        private int benchExtractedNumber2;
        private int playExtractedNumber;
        private int playExtractedNumber2;
        public int bet { get; protected set; }
        public BlackJack(int _bet) 
        {
            if (_bet > 0)
            {
                bet = _bet;
            }
            else 
            {
                throw new   ArgumentException("bet cant be lower than 0");
            }
        }
        private int BjBenchNumber() 
        {
            Random random = new Random();
            benchExtractedNumber = random.Next(0,10);
            Random random2 = new Random();
            benchExtractedNumber2 = random.Next(0, 10);
            
            return benchExtractedNumber+benchExtractedNumber2;
        }

        private int PlayerNumber() 
        {
            Random random = new Random();
            playExtractedNumber = random.Next(0, 10);
            Random random2 = new Random();
            playExtractedNumber2 = random.Next(0, 10);

            return playExtractedNumber+playExtractedNumber2;
        }

        public int Play() 
        {
            int player = PlayerNumber();
            int bench = BjBenchNumber();

            if (player > bench)
            {
                return bet * 2;
            }
            else 
            {
                return 0;
            }
        }
    }
}
