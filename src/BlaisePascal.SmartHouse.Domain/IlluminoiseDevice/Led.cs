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
        private int lightIntensity;
        public string color { get;  set; }
        public bool isOn { get; private set; }

        public Led(string color, int lightIntensity)
        {
            this.color = color;

            isOn = false;
            if (lightIntensity < 0)
            {
                lightIntensity = 0;
            }
            else if (lightIntensity > 100)
            {
                lightIntensity = 100;
            }
        }
        public void TurnOn()
        {
            isOn = true;
            lightIntensity = 100;
        }
        public void TurnOff()
        {
            isOn = false;
            lightIntensity = 0;
        }

        public int lightIntensityPropriety
        {
            get { return lightIntensity; }
            set
            {
                if (value < 0)
                {
                    lightIntensity = 0;
                }
                else if (value > 100)
                {
                    lightIntensity = 100;
                }
                else
                {
                    lightIntensity = value;
                }
            }
        }

    }
}
