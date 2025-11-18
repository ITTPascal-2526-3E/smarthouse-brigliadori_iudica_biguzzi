using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Gambling
{
    internal class RussianRoulette
    {
        public int bet { get; private set; }
        public int choosenNumber { get; private set; } 
        private Array redNumber = new Array[1,3,5,7,9,12,14,16,18,19,21,23,25,27,30,32,34,36];
        private Array blackNumber = new Array[2,4,6,8,10,11,15,17,20,22,24,26,18,29,31,33,35];
        public RussianRoulette(int _bet, int _choosenNumber) 
        {
            bet = _bet;
            choosenNumber = _choosenNumber;
        }
        
        
        public int Play()
        {
            Random random = new Random.Next(0,37);

        }


    }
}
