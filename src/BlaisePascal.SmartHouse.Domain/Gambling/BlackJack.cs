using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Gambling
{
    internal class BlackJack
    {
        private int benchExtractedNumber;
        private int benchExtractedNumber2;
        private int playExtractedNumber;
        private int playExtractedNumber2;
        public int bet { get; private set; }
        public BlackJack(int _bet) 
        {
            bet = _bet;
        }
        private int BjBenchNumber() 
        {
            Random random = new Random();
            benchExtractedNumber = random.Next(0,22);
            Random random2 = new Random();
            benchExtractedNumber2 = random.Next(0, 22);
            
            return benchExtractedNumber+benchExtractedNumber2;
        }

        public int PlayerNumber() 
        {
            Random random = new Random();
            playExtractedNumber = random.Next(0, 22);
            Random random2 = new Random();
            playExtractedNumber2 = random.Next(0, 22);

            return playExtractedNumber+playExtractedNumber2;
        }

        public int PlayNumber() 
        {
            int player=PlayerNumber();
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
