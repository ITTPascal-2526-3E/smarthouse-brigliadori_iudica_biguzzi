using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class LampDevice
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

        

        public string lampDeviceStatus()
        {
            string status = "";
            foreach (var item in lampDevice)
            {
                if (item is Lamp)
                {
                    Lamp lamp = (Lamp)item;
                    status += $"Lamp - isOn: {lamp.isOn}, lightIntensity: {lamp.lightIntensityPropriety}, isWireless: {lamp.isWireless}, consumationValue: {lamp.consumationValue}, lightOnSpecificTime: {lamp.lightOnSpecificTime}, lightOffSpecificTime: {lamp.lightOffSpecificTime}\n";
                }
                else if (item is EcoLamp)
                {
                    EcoLamp ecolamp = (EcoLamp)item;
                    status += $"EcoLamp - isOn: {ecolamp.isOn}, lightIntensity: {ecolamp.lightIntensityProperty}, isWireless: {ecolamp.isWireless}, consumationValue: {ecolamp.consumationValue}, maxTimeOn: {ecolamp.maxTimeOn}\n";
                }
            }
            return status;
        }





    }
}
