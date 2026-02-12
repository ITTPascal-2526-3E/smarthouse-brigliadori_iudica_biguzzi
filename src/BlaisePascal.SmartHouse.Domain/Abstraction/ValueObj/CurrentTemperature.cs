using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj
{
    public class CurrentTemperature
    {
        public double Value { get; set; }
        public CurrentTemperature(double value) 
        {
            if (value < -30 || value > 50) 
            {
                throw new ArgumentOutOfRangeException("value out of range must be between -30 , 50 ");
            }
            Value = value;
        }
    }
}
