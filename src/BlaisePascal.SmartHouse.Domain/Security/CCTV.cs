using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Security
{
    public class CCTV
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
        public void AutomaticTurnOn()
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
                
                shouldBeOn = h >= turnOnHour && h < turnOffHour;
            }
            else
            {
                
                shouldBeOn = h >= turnOnHour || h < turnOffHour;
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
