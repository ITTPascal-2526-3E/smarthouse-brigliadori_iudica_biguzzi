using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Security;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class DoorTest
    {
        [Fact]
        public void Door_openDoor_unlocked_assertTrue()
        {
            Door door = new Door(false, false, 012);
            door.TurnOn();
            Assert.Equal(true,door.isOpen);
        }

        [Fact]
        public void Door_openDoor_locked_assertThrow()
        {
            Door door = new Door(false,true, 012);
            Assert.Throws<Exception>(door.TurnOn);
        }

        [Fact]
        public void Door_closeDoor_unlocked_assertFalse()
        {
            Door door = new Door(true, true, 012);
            door.TurnOff();
            Assert.False(door.isOpen);
        }

        [Fact]
        public void Door_closeDoor_locked_assertThrown()
        {
            Door door = new Door(true, false, 012);
            Assert.Throws<Exception>(door.TurnOff);
        }

        [Fact]
        public void Door_unlocked_assertTrue()
        {
            Door door = new Door(false, true , 012);
            door.UnlockDoor(012);
            Assert.Equal(false , door.isLocked);
        }

        [Fact]
        public void Door_unlocked_wrongCode_assertThrow()
        {
            Door door = new Door(false, false, 012);
            Assert.Throws<Exception>(() => door.UnlockDoor(123));
        }

        [Fact]
        public void Door_unlocked_doorOpen_assertThrow()
        {
            Door door = new Door(true, false, 012);
            Assert.Throws<Exception>(() => door.UnlockDoor(012));
        }

        [Fact]
        public void Door_unlocked_doorunlocked_assertThrow()
        {
            Door door = new Door(false, true, 012);
            Assert.Throws<Exception>(() => door.UnlockDoor(010));
        }

        [Fact]
        public void Door_locked_doorClose_assertFalse()
        {
            Door door = new Door(false, false, 012);
            door.LockDoor();
            Assert.True(door.isLocked);
        }

        [Fact]
        public void Door_locked_doorOpen_assertFalse()
        {
            Door door = new Door(true, false, 012);
            Assert.Throws<Exception>(() => door.LockDoor());
        }

    }
}
