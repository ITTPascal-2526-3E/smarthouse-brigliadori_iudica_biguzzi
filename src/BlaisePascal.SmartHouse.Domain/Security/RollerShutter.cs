using BlaisePascal.SmartHouse.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Security
{
    public sealed class RollerShutter : Device , ISwitchable
    {
        public bool isOpen { get; private set; }
        public int position { get; private set; } // position from 0 to 100
        

        // costructor for RollerShutter
        public RollerShutter(bool isopen, int _position)
        {
            isOpen = isopen;
            if (_position > 0 && _position < 100 && isopen==true)
            {
                position = _position;
            }
            
        }
        public void SetName(string shuttername)
        {
            if (string.IsNullOrEmpty(shuttername))
            {
                throw new ArgumentNullException("shuttername");
            }
            lastMod = DateTime.Now;
            name = shuttername;
        }
        //metod for open the roller shutter
        public void TurnOn()
        {
            lastMod = DateTime.Now;
            isOpen = true;
            position = 100;
        }
        //metod for close the roller shutter
        public void TurnOff()
        {
            lastMod = DateTime.Now;
            isOpen = false;
            position = 0;
        }
        // property for position you can set your roller shutter position from 0 to 100
        public int ShutterPosition
        {
            get { return position; }
            set 
            { 
                if (value >= 0 && value <= 100)
                {
                    lastMod = DateTime.Now;
                    position = value;
                    isOpen = position > 0;
                }
            }
        }

    }
}
