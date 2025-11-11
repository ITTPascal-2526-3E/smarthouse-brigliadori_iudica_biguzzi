using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    internal class Door
    {
        public bool isOpen { get; private set; }
        public bool isLocked { get; private set; }
        public Guid Id { get; } = Guid.NewGuid();

        // costructor for Door
        public Door(bool isopen, bool islocked)
        {
            isOpen = isopen;
            isLocked = islocked;
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
        public void unlockDoor()
        {
            if ( isOpen==false)
                isLocked = false;
        }
        //metod for locking the door
        public void lockDoor()
        {  
            if (isOpen==true)
                isLocked = true;
        }

    }
}
