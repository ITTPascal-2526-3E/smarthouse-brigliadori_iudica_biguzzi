using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace BlaisePascal.SmartHouse.Domain.Gambling
{
    internal class RussianRoulette
    {
        private int extractedNumber;
        
        public int bet { get; private set; }

        private List<int> redNumber = new List<int> { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
        
        private List<int> blackNumber = new List<int> { 2, 4, 6, 8, 10, 11 ,13, 15, 17, 20, 22, 24, 26, 18, 29, 31, 33, 35 };
        public RussianRoulette(int _bet)
        {
            bet = _bet;
            
        }

        
        public int PlayNumber(int choosenNumber)
        {
            
            Random random = new Random();
            extractedNumber = random.Next(1, 37);

            if (extractedNumber == choosenNumber)
            {
                return bet * 35;
            }
            else 
            {
                return 0;
            }
        }
        //true = rosso false = nero
        public bool PlayColor(bool choosenColor) 
        {
            Random random = new Random();
            extractedNumber = random.Next(1, 37);
            if (redNumber.Contains(extractedNumber)) 
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}
