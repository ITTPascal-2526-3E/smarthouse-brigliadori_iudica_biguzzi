using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Door
    {
        public bool isOpen { get; private set; }
        public int doorCode { get; private set; }
        public bool isLocked { get; private set; }
        public string name { get; set; }
        public Guid Id { get; } = Guid.NewGuid();

        // costructor for Door
        public Door(bool isopen, bool islocked, int doorcode)
        {
            isOpen = isopen;
            isLocked = islocked;
            doorCode = doorcode;
        }
        //metod for open the door
        public void openDoor()
        {
            if (isLocked == false)
                isOpen = true;
        }
        //metod for close the door
        public void closeDoor()
        {
            if (isLocked == true)
                isOpen = false;
        }

        //metod for unlocking the door
        public void unlockDoor(int code)
        {
            if ( isLocked==true && isOpen==false && code == doorCode)
                isLocked = false;
        }
        //metod for locking the door
        public void lockDoor()
        {  
            if (isOpen==false)
                isLocked = true;
        }

    }
}
