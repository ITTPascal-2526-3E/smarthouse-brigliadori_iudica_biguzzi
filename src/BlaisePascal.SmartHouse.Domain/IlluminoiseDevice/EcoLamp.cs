using BlaisePascal.SmartHouse.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
namespace BlaisePascal.SmartHouse.Domain.IlluminoiseDevice
{
    public sealed class EcoLamp : Lamp
    {
        public Hour maxTimeOn { get; protected set; } // max time the lamp can stay on in hours


        // costructor for lamp
        public EcoLamp(bool ison, int ligthpower, bool iswireless, int consumationvalue, Hour maxtimeon, Hour h1, Hour h2) : base(ison, ligthpower, iswireless, consumationvalue,h1, h2 )
        {
            maxTimeOn = maxtimeon;


        }
        public override void TurnOn()
        {
            lastMod = DateTime.Now;
            SaveAccensionTime();
            isOn = true;
            brigthness = new Brigthness(100);
        }

        public override void TurnOff()
        {
            lastMod = DateTime.Now;
            isOn = false;
            brigthness = new Brigthness(0);
        }
        private void SaveAccensionTime()
        {
            startTime = DateTime.Now;
        }


        public void EcoActivation()
        {
            if (startTime == null)
                return;

            DateTime now = DateTime.Now;

            // after an hour till the activetion
            if ((now - startTime.Value).TotalHours >= maxTimeOn.Value)
            {
                isOn = false;
                brigthness = new Brigthness(0);
            }

            // at night from 10pm to 6am
            if (now.Hour >= 23 || now.Hour < 7)
            {
                isOn = false;
                brigthness = new Brigthness(0);
            }
        }



    }
}