using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj
{
    public class Hour
    {
        public int Value { get; private set; }
        public Hour(int value) 
        {
            if (value < 0 || value > 23) 
            {
                throw new ArgumentException("Hour must be between 0 and 23.");

            }
            Value = value;
        }
    }
}
