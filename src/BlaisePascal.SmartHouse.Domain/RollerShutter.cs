using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class RollerShutter
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
        //metod for open the roller shutter
        public void openShutter()
        {
            isOpen = true;
            position = 100;
        }
        //metod for close the roller shutter
        public void closeShutter()
        {
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
                    position = value;
                    isOpen = position > 0;
                }
            }
        }








    }
}
