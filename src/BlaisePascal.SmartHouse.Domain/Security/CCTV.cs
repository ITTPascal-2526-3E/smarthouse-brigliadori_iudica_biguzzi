using BlaisePascal.SmartHouse.Domain.Abstraction;
using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
using BlaisePascal.SmartHouse.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Security
{
    public sealed class CCTV : Device, ISwitchable, IAutomaticSwicth
    {
        public bool isOn { get; private set; }
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
            else
            {
                throw new ArgumentException("Hours must be between 0 and 23.");
            }
        }
        public void SetName(Name cctvname)
        {
           
            lastMod = DateTime.Now;
            name = cctvname;
        }

        public void TurnOn()
        {
            lastMod = DateTime.Now;
            isOn = true;
        }

        public void TurnOff()
        {
            lastMod = DateTime.Now;
            isOn = false;
        }
        public void SetTurnOnHour(int hour)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException("hour", "Hour must be between 0 and 23.");
            }
            lastMod = DateTime.Now;
            turnOnHour = hour;
        }
        public void SetTurnOffHour(int hour)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException("hour", "Hour must be between 0 and 23.");
            }
            lastMod = DateTime.Now;
            turnOffHour = hour;
        }


        // Automatic turn on/off based on the set hours
        public void AutomaticSwicthOn()
        {
            DateTime currentTime = DateTime.Now;
            int h = currentTime.Hour;

            bool shouldBeOn;
            if (turnOnHour == turnOffHour)
            {
                lastMod = DateTime.Now;
                //choosen same hour for always off
                shouldBeOn = false;
            }
            else if (turnOnHour < turnOffHour)
            {
                lastMod = DateTime.Now;

                shouldBeOn = h >= turnOnHour && h < turnOffHour;
            }
            else
            {
                lastMod = DateTime.Now;

                shouldBeOn = h >= turnOnHour || h < turnOffHour;
            }

            if (shouldBeOn == true)
            {
                TurnOn();
            }
            else
                TurnOff();
        }

        public void AutomaticSwicthOff()
        {
            DateTime currentTime = DateTime.Now;
            int h = currentTime.Hour;

            bool shouldBeOff;
            if (turnOnHour == turnOffHour)
            {
                lastMod = DateTime.Now;
                //choosen same hour for always off
                shouldBeOff = false;
            }
            else if (turnOnHour < turnOffHour)
            {
                lastMod = DateTime.Now;

                shouldBeOff = h >= turnOnHour && h < turnOffHour;
            }
            else
            {
                lastMod = DateTime.Now;

                shouldBeOff = h >= turnOnHour || h < turnOffHour;
            }

            if (shouldBeOff == true)
            {
                TurnOff();
            }
            else
                TurnOn();
        }
    }
}
