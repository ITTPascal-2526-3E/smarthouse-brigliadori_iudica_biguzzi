using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    internal class CCTV
    {
        public bool isOn { get; private set; }
        public string name { get; set; }
        public Guid Id { get; } = Guid.NewGuid();
        private DateTime salvaOrario;
        public int turnOnHour { get; private set; }
        public int turnOffHour { get; private set; }


        public CCTV(bool ison, int turnonhour, int turnoffhour)
        {
            isOn = ison;
            if (turnonhour > 0 && turnonhour > 0 && turnoffhour <= 23 && turnoffhour <= 23)
            {
                turnOnHour = turnonhour;
                turnOffHour = turnoffhour;
            }
        }

        public void turnOn()
        {
            isOn = true;
        }

        public void turnOff()
        {
            isOn = false;
        }

        

        // Automatic turn on/off based on the set hours
        private void AutomaticTurnOn()
        {
            DateTime currentTime = DateTime.Now;
            int h = currentTime.Hour;

            bool shouldBeOn;
            if (turnOnHour == turnOffHour)
            {
                //choosen same hour for always off
                shouldBeOn = false;
            }
            else if (turnOnHour < turnOffHour)
            {
                // if the on time is before the off time (e.g. on=6 off=20) -> on if h >=6 AND h <20
                shouldBeOn = (h >= turnOnHour && h < turnOffHour);
            }
            else
            {
                //if the on time is after the off time(e.g.on= 20 off= 6) -> on if h >= 20 OR h<6
                shouldBeOn = (h >= turnOnHour || h < turnOffHour);
            }

            if (shouldBeOn == true)
            {
                turnOn();
            }
            else
                turnOff();
        }


    }
}
