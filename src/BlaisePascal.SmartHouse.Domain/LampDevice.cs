using System;
using System.Collections;
using System.Collections.Generic;
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
           lampDevice.Add(lamp);
        }

        public void addEcoLamp(bool ask, EcoLamp ecolamp)
        {
                lampDevice.Add(ecolamp);
        }


    }
}
