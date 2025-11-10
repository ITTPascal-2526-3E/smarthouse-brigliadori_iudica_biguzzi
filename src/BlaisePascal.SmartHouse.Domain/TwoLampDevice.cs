using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class TwoLampDevice
    {
        public ArrayList LampDevice = new ArrayList();

        
        public void addLamp( Lamp lamp)
        { 
           if (LampDevice.Count<2)
            LampDevice.Add(lamp);
        }

        public void addEcoLamp( EcoLamp ecolamp)
        {
            if (LampDevice.Count < 2)
                LampDevice.Add(ecolamp);
        }

        public void removeLamp( Lamp lamp)
        {
            LampDevice.Remove(lamp);
        }   
        public void removeEcoLamp( EcoLamp ecolamp)
        {
            LampDevice.Remove(ecolamp);
        }

       

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
