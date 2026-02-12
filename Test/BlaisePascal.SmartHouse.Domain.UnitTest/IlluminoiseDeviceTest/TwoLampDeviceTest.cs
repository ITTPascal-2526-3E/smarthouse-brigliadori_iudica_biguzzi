using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class TwoLampDeviceTest
    {

        [Fact]
        public void TwoLampDevice_AddLamp_lampMoreThan2_assertThrowns()
        {
            var device = new TwoLampDevice();
            Hour hour = new Hour(15);
            Hour hour2 = new Hour(2);
            Hour hour3 = new Hour(10);
            Lamp lamp = new Lamp(true, 50, true, 60, hour2, hour);
            Lamp lamp1 = new Lamp(true, 50, true, 60, hour2, hour);
            Lamp lamp2 = new Lamp(true, 50, true, 60, hour2, hour);
            Lamp lamp3 = new Lamp(true, 50, true, 60, hour2, hour); 
            
            device.addLamp(lamp1);
            device.addLamp(lamp2);
            Assert.Throws<ArgumentOutOfRangeException>(() => device.addLamp(lamp3));
        }

        [Fact]
        public void TwoLampDevice_RemoveLamp_assertEquals()
        {
            var device = new TwoLampDevice();
            Hour hour = new Hour(15);
            Hour hour2 = new Hour(2);
            Hour hour3 = new Hour(10);
            Lamp lamp = new Lamp(true, 50, true, 60, hour2, hour);
            Lamp lamp1 = new Lamp(true, 50, true, 60, hour2, hour);
            Lamp lamp2 = new Lamp(true, 50, true, 60, hour2, hour);
            Lamp lamp3 = new Lamp(true, 50, true, 60, hour2, hour);
            device.addLamp(lamp1);
            device.addLamp(lamp2);
            device.removeLamp(lamp1);
            Assert.Equal(1, device.LampDevice.Count);
        }

        

        [Fact]
        public void TwoLampDevice_TurnOffOneLamp_assertFalse()
        {
            var device = new TwoLampDevice();
            Hour hour = new Hour(15);
            Hour hour2 = new Hour(2);
            Hour hour3 = new Hour(10);
            Lamp lamp = new Lamp(true, 50, true, 60, hour2, hour);
            Lamp lamp1 = new Lamp(true, 50, true, 60, hour2, hour);
            Lamp lamp2 = new Lamp(true, 50, true, 60, hour2, hour);
            Lamp lamp3 = new Lamp(true, 50, true, 60, hour2, hour);
            device.addLamp(lamp1);
            device.addLamp(lamp2);
            device.turnOffOneLamp(0);
            Assert.False(lamp1.isOn);
        }

        [Fact]
        public void TwoLampDevice_TurnOnOneLamp_assertTrue()
        {
            var device = new TwoLampDevice();
            Hour hour = new Hour(15);
            Hour hour2 = new Hour(2);
            Hour hour3 = new Hour(10);
            Lamp lamp = new Lamp(true, 50, true, 60, hour2, hour);
            Lamp lamp1 = new Lamp(true, 50, true, 60, hour2, hour);
            Lamp lamp2 = new Lamp(true, 50, true, 60, hour2, hour);
            Lamp lamp3 = new Lamp(true, 50, true, 60, hour2, hour);
            device.addLamp(lamp1);
            device.addLamp(lamp2);
            device.turnOnOneLamp(0);
            Assert.True(lamp1.isOn);
        }

        [Fact]
        public void TwoLampDevice_TurnOnAllLamp_assertTrue()
        {
            var device = new TwoLampDevice();
            Hour hour = new Hour(15);
            Hour hour2 = new Hour(2);
            Hour hour3 = new Hour(10);
            Lamp lamp = new Lamp(true, 50, true, 60, hour2, hour);
            Lamp lamp1 = new Lamp(true, 50, true, 60, hour2, hour);
            Lamp lamp2 = new Lamp(true, 50, true, 60, hour2, hour);
            Lamp lamp3 = new Lamp(true, 50, true, 60, hour2, hour);
            device.addLamp(lamp1);
            device.addLamp(lamp2);
            device.turnOnAllLamps();
            Assert.True(lamp1.isOn);
            Assert.True(lamp2.isOn);
        }

        [Fact]
        public void TwoLampDevice_TurnOffAllLamp_assertFalse()
        {
            var device = new TwoLampDevice();
            Hour hour = new Hour(15);
            Hour hour2 = new Hour(2);
            Hour hour3 = new Hour(10);
            Lamp lamp = new Lamp(true, 50, true, 60, hour2, hour);
            Lamp lamp1 = new Lamp(true, 50, true, 60, hour2, hour);
            Lamp lamp2 = new Lamp(true, 50, true, 60, hour2, hour);
            Lamp lamp3 = new Lamp(true, 50, true, 60, hour2, hour);
            device.addLamp(lamp1);
            device.addLamp(lamp2);
            device.turnOffAllLamps();
            Assert.False(lamp1.isOn);
            Assert.False(lamp2.isOn);
        }

        [Fact]
        public void TwoLampDevice_setColorOnOneLamp_assertEquals()
        {
            var device = new TwoLampDevice();
            Hour hour = new Hour(15);
            Hour hour2 = new Hour(2);
            Hour hour3 = new Hour(10);
            Lamp lamp = new Lamp(true, 50, true, 60, hour2, hour);
            Lamp lamp1 = new Lamp(true, 50, true, 60, hour2, hour);
            Lamp lamp2 = new Lamp(true, 50, true, 60, hour2, hour);
            Lamp lamp3 = new Lamp(true, 50, true, 60, hour2, hour);
            device.addLamp(lamp1);
            device.addLamp(lamp2);
            device.setColorOneLamp(1, IlluminoiseDevice.Color.RED);
            Assert.Equal(IlluminoiseDevice.Color.RED, lamp2.getColor());
        }

        
    }
}
