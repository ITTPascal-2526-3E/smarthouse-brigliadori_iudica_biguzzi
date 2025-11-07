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
        ArrayList lampDevice = new ArrayList();

        public void addLamp( Lamp lamp)
        { 
           if (lampDevice.Count<2)
            lampDevice.Add(lamp);
        }

        public void addEcoLamp( EcoLamp ecolamp)
        {
            if (lampDevice.Count < 2)
                lampDevice.Add(ecolamp);
        }

        public void removeLamp( Lamp lamp)
        {
            lampDevice.Remove(lamp);
        }   
        public void removeEcoLamp( EcoLamp ecolamp)
        {
            lampDevice.Remove(ecolamp);
        }

       

        public void turnOnOneLamp(int index)
        {
            if (lampDevice[index] is Lamp lamp)
            {
                lamp.turnOn();
            }
            else if (lampDevice[index] is EcoLamp ecolamp)
            {
                ecolamp.turnOn();
            }
        }
        public void turnOnAllLamps()
        {
            foreach (var item in lampDevice)
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
            if (lampDevice[index] is Lamp lamp)
            {
                lamp.turnOff();
            }
            else if (lampDevice[index] is EcoLamp ecolamp)
            {
                ecolamp.turnOff();
            }
        }

        public void turnOffAllLamps()
        {
            foreach (var item in lampDevice)
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
            if (lampDevice[index] is Lamp lamp)
            {
                lamp.setColor(color);
            }
            else if (lampDevice[index] is EcoLamp ecolamp)
            {
                ecolamp.setColor(color);
            }
        }

        public void setColorAllLamps( string color)
        {
            foreach (var item in lampDevice)
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
            foreach (var item in lampDevice)
            {
                if (item is Lamp lamp)
                {
                    lamp.ApllyScheduleNow();
                }
            }
        }

        public void EcoActivationAllLamps()
        {
            foreach (var item in lampDevice)
            {
                if (item is EcoLamp ecolamp)
                {
                    ecolamp.EcoActivation();
                }
            }
        }

    }
}
