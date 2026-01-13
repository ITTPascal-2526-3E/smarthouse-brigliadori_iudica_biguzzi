using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.IlluminoiseDevice
{
    public sealed class EcoLamp : Lamp
    {
        public int maxTimeOn { get; protected set; } // max time the lamp can stay on in hours
        

        // costructor for lamp
        public EcoLamp(bool ison, int ligthpower, bool iswireless, int consumationvalue, int maxtimeon) : base(ison, ligthpower, iswireless, consumationvalue, 0, 0)
        {
            if (maxtimeon >= 0 && maxtimeon <= 3)
            {
                maxTimeOn = maxtimeon;
            }


        }
        public override void turnOn()
        {
            lastMod = DateTime.Now;
            SaveAccensionTime();
            isOn = true;
            lightIntensity = 100;
        }
        private void SaveAccensionTime()
        {
            startTime = DateTime.Now;
        }

        // property for lightPower you can set your light power from 0 to 100
        public int lightIntensityProperty
        {
            get { return lightIntensity; }
            set
            {
                // controllo sul range
                if (value > 0 && value < 20)
                {
                    lastMod = DateTime.Now;
                    lightIntensity = value;
                }

            }

        }
        public void EcoActivation()
        {
            if (startTime == null)
                return;

            DateTime now = DateTime.Now;

            // after an hour till the activetion
            if ((now - startTime.Value).TotalHours >= maxTimeOn)
            {
                isOn = false;
                lightIntensity = 0;
            }

            // at night from 10pm to 6am
            if (now.Hour >= 23 || now.Hour < 7)
            {
                isOn = false;
                lightIntensity = 0;
            }
        }



    }
}