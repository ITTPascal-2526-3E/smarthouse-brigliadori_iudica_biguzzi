using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;

using BlaisePascal.SmartHouse.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.IlluminoiseDevice
{
    public sealed class Led : ISwitchable
    {
        public Brigthness brigthness;
        public string color { get; set; }
        public bool isOn { get; private set; }

        public Led(string color, int lightIntensity)
        {
            this.color = color;

            isOn = false;
            brigthness = new Brigthness(lightIntensity);
        }
        public void TurnOn()
        {
            isOn = true;
            brigthness = new Brigthness(100);
        }
        public void TurnOff()
        {
            isOn = false;
            brigthness = new Brigthness(0);
        }



    }
}
