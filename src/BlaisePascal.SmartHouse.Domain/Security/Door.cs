using BlaisePascal.SmartHouse.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Security
{
    public sealed class Door : Device , ISwitchable
    {
        public bool isOpen { get; private set; }
        public int doorCode { get; private set; }
        public bool isLocked { get; private set; }
        public string name { get; private set; }
        
        // costructor for Door
        public Door(bool isopen, bool islocked, int doorcode)
        {
            isOpen = isopen;
            isLocked = islocked;
            doorCode = doorcode;
            
        }
        public void SetName(string doorname)
        {
            if (string.IsNullOrEmpty(doorname))
            {
                throw new ArgumentNullException("doorname");
            }
            lastMod = DateTime.Now;
            name = doorname;
        }
        //metod for open the door
        public void TurnOn()
        {
            if (isLocked == false)
            {
                lastMod = DateTime.Now;
                isOpen = true;
            }
            else
            {
                throw new Exception("door is locked cant be open");
            }
        }
        //metod for close the door
        public void TurnOff()
        {
            if (isLocked == true)
            {
                lastMod = DateTime.Now;
                isOpen = false;
            }
            else
            {
                throw new Exception("door is locked cant be close");
            }
        }

        //metod for unlocking the door
        public void unlockDoor(int code)
        {
            if (isLocked == true && code == doorCode)
            {
                lastMod = DateTime.Now;
                isLocked = false;
            }
            else
            {
                throw new Exception("cant be locked if the code isn't rigth or the door is already unloocked");
            }       
        }

        //metod for locking the door
        public void lockDoor()
        {
            if (isOpen == false)
            {
                lastMod = DateTime.Now;
                isLocked = true;
            }
            else
            {
                throw new Exception("cant close if door is open");
            }
    }

    }
}
