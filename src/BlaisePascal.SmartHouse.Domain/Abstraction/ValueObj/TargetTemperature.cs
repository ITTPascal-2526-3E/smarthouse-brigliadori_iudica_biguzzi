using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj
{
    public class TargetTemperature: CurrentTemperature
    {

        public TargetTemperature(double value) : base(value) 
        {
            if (value <5 || value >30) 
            {
                throw new ArgumentOutOfRangeException("value out of range");
            }
        }
    }
}
