using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Lamp
{
    public class TwoLampDevice
    {
        public ArrayList LampDevice = new ArrayList();

        // add a lamp to the device
        public void addLamp( Lamp lamp)
        { 
           if (LampDevice.Count<2)
            LampDevice.Add(lamp);
        }

        // add an ecolamp to the device
        public void addEcoLamp( EcoLamp ecolamp)
        {
            if (LampDevice.Count < 2)
                LampDevice.Add(ecolamp);
        }

        // remove a lamp to the device
        public void removeLamp( Lamp lamp)
        {
            LampDevice.Remove(lamp);
        }

        // remove an ecolamp to the device
        public void removeEcoLamp( EcoLamp ecolamp)
        {
            LampDevice.Remove(ecolamp);
        }

       
        // method to turn on one lamp or ecolamp 
        public void turnOnOneLamp(int index)
        {
            if (LampDevice[index] is Lamp lamp)
            {
                lamp.turnOn();
            }
            else if (LampDevice[index] is EcoLamp ecolamp)
            {
                ecolamp.turnOn();
            }
        }

        // method to turn on all lamp and ecolamp
        public void turnOnAllLamps()
        {
            foreach (var item in LampDevice)
            {
                if (item is Lamp lamp)
                {
                    lamp.turnOn();
                }
                else if (item is EcoLamp ecolamp)
                {
                    ecolamp.turnOn();
                }
            }
        }

        // method to turn off one lamp or ecolamp 
        public void turnOffOneLamp(int index)
        {
            if (LampDevice[index] is Lamp lamp)
            {
                lamp.turnOff();
            }
            else if (LampDevice[index] is EcoLamp ecolamp)
            {
                ecolamp.turnOff();
            }
        }

        // method to turn off all lamp and ecolamp
        public void turnOffAllLamps()
        {
            foreach (var item in LampDevice)
            {
                if (item is Lamp lamp)
                {
                    lamp.turnOff();
                }
                else if (item is EcoLamp ecolamp)
                {
                    ecolamp.turnOff();
                }
            }
        }

        // method to set a color to one lamp or ecolamp
        public void setColorOneLamp(int index, string color)
        {
            if (LampDevice[index] is Lamp lamp)
            {
                lamp.setColor(color);
            }
            else if (LampDevice[index] is EcoLamp ecolamp)
            {
                ecolamp.setColor(color);
            }
        }

        // method to set a color to all lamp and ecolamp
        public void setColorAllLamps( string color)
        {
            foreach (var item in LampDevice)
            {
                if (item is Lamp lamp)
                {
                    lamp.setColor(color);
                }
                else if (item is EcoLamp ecolamp)
                {
                    ecolamp.setColor(color);
                }
            }
        }

        // method to apply schedule to all lamp
        public void ApllyScheduleAllLamps()
        {
            foreach (var item in LampDevice)
            {
                if (item is Lamp lamp)
                {
                    lamp.ApllyScheduleNow();
                }
            }
        }

        // method that apply ecoactivation to all ecolamp
        public void EcoActivationAllLamps()
        {
            foreach (var item in LampDevice)
            {
                if (item is EcoLamp ecolamp)
                {
                    ecolamp.EcoActivation();
                }
            }
        }

    }
}
