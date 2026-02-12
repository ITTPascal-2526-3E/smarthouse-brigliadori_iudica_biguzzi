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
        public Hour turnOnHour { get; private set; }
        public Hour turnOffHour { get; private set; }


        public CCTV(bool ison, Hour _turnonhour, Hour _turnoffhour)
        {
            isOn = ison;
            turnOnHour = _turnonhour;
            turnOffHour = _turnoffhour;
        }
        public string getName()
        {
            return name.Value;
        }

        public void SetName(Name lampname)
        {

            lastMod = DateTime.Now;
            name = lampname;
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
        public void SetTurnOnHour(Hour hour)
        {
            
            turnOnHour = hour;
        }
        public void SetTurnOffHour(Hour hour)
        {
            
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
            else if (turnOnHour.Value < turnOffHour.Value)
            {
                lastMod = DateTime.Now;

                shouldBeOn = h >= turnOnHour.Value && h < turnOffHour.Value;
            }
            else
            {
                lastMod = DateTime.Now;

                shouldBeOn = h >= turnOnHour.Value || h < turnOffHour.Value;
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
            else if (turnOnHour.Value < turnOffHour.Value)
            {
                lastMod = DateTime.Now;

                shouldBeOff = h >= turnOnHour.Value && h < turnOffHour.Value;
            }
            else
            {
                lastMod = DateTime.Now;

                shouldBeOff = h >= turnOnHour.Value || h < turnOffHour.Value;
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
