using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Security
{
    public class Door
    {
        public bool isOpen { get; private set; }
        public int doorCode { get; private set; }
        public bool isLocked { get; private set; }
        public string name { get; set; }
        public Guid Id { get; } 

        // costructor for Door
        public Door(bool isopen, bool islocked, int doorcode)
        {
            isOpen = isopen;
            isLocked = islocked;
            doorCode = doorcode;
            Id = Guid.NewGuid();
        }
        //metod for open the door
        public void openDoor()
        {
            if (isLocked == false)
                isOpen = true;
            else
                throw new Exception("door is locked cant be open");
        }
        //metod for close the door
        public void closeDoor()
        {
            if (isLocked == true)
                isOpen = false;
            else
                throw new Exception("door is locked cant be close");
        }

        //metod for unlocking the door
        public void unlockDoor(int code)
        {
            if (isLocked == true && isOpen == false && code == doorCode)
                isLocked = false;
            else
                throw new Exception("cant be locked if the code isn't rigth or the door is already unloocked");
        }
        //metod for locking the door
        public void lockDoor()
        {
            if (isOpen == false)
                isLocked = true;
            else
                throw new Exception("cant close if door is open");

    }

    }
}
