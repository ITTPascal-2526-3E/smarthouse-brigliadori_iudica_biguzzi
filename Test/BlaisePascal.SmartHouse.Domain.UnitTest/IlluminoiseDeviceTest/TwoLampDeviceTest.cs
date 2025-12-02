using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class TwoLampDeviceTest
    {
        
        [Fact]
        public void TwoLampDevice_AddLamp_lampMoreThan2_assertThrowns()
        {
            var device = new TwoLampDevice();
            var lamp1 = new Lamp(true, 50, true, 60, 18, 23);
            var lamp2 = new Lamp(true, 70, true, 80, 18, 23);
            var lamp3 = new Lamp(false, 80, true, 90, 18, 23);
            device.addLamp(lamp1);
            device.addLamp(lamp2);
            Assert.Throws<ArgumentOutOfRangeException>(() => device.addLamp(lamp3));
        }

        [Fact]
        public void TwoLampDevice_RemoveLamp_assertEquals()
        {
            var device = new TwoLampDevice();
            var lamp1 = new Lamp(true, 50, true, 60, 18, 23);
            var lamp2 = new Lamp(true, 70, true, 80, 18, 23);
            device.addLamp(lamp1);
            device.addLamp(lamp2);
            device.removeLamp(lamp1);
            Assert.Equal(1, device.LampDevice.Count);
        }

        [Fact]
        public void TwoLampDevice_RemoveEcoLamp_assertEquals()
        {
            var device = new TwoLampDevice();
            var lamp1 = new Lamp(true, 70, true, 80, 18, 23);
            var lamp2 = new EcoLamp(true, 15, true, 15, 2);
            device.addLamp(lamp1);
            device.addEcoLamp(lamp2);
            device.removeEcoLamp(lamp2);
            Assert.Equal(1, device.LampDevice.Count);
        }

        [Fact]
        public void TwoLampDevice_AddEcoLamp_lampMoreThan2_assertThrowns()
        {
            var device = new TwoLampDevice();
            var lamp1 = new Lamp(true, 50, true, 60, 18, 23);
            var lamp2 = new Lamp(true, 70, true, 80, 18, 23);
            var lamp3 = new EcoLamp(true, 15, true, 15, 2);
            device.addLamp(lamp1);
            device.addLamp(lamp2);
            Assert.Throws<ArgumentOutOfRangeException>(() => device.addEcoLamp(lamp3));
        }

        [Fact]
        public void TwoLampDevice_TurnOffOneLamp_assertFalse()
        {
            var device = new TwoLampDevice();
            var lamp1 = new Lamp(true, 50, true, 60, 18, 23);
            var lamp2 = new Lamp(true, 70, true, 80, 18, 23);
            device.addLamp(lamp1);
            device.addLamp(lamp2);
            device.turnOffOneLamp(0);
            Assert.False(lamp1.isOn);
        }

        [Fact]
        public void TwoLampDevice_TurnOnOneLamp_assertTrue()
        {
            var device = new TwoLampDevice();
            var lamp1 = new Lamp(false, 50, true, 60, 18, 23);
            var lamp2 = new Lamp(true, 70, true, 80, 18, 23);
            device.addLamp(lamp1);
            device.addLamp(lamp2);
            device.turnOnOneLamp(0);
            Assert.True(lamp1.isOn);
        }

        [Fact]
        public void TwoLampDevice_TurnOnAllLamp_assertTrue()
        {
            var device = new TwoLampDevice();
            var lamp1 = new Lamp(false, 50, true, 60, 18, 23);
            var lamp2 = new Lamp(true, 70, true, 80, 18, 23);
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
            var lamp1 = new Lamp(false, 50, true, 60, 18, 23);
            var lamp2 = new Lamp(true, 70, true, 80, 18, 23);
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
            var lamp1 = new Lamp(false, 50, true, 60, 18, 23);
            var lamp2 = new Lamp(true, 70, true, 80, 18, 23);
            device.addLamp(lamp1);
            device.addLamp(lamp2);
            device.setColorOneLamp(1, "red");
            Assert.Equal("red", lamp2.getColor());
        }

        [Fact]
        public void TwoLampDevice_setColorAllLamp_assertEquals()
        {
            var device = new TwoLampDevice();
            var lamp1 = new Lamp(false, 50, true, 60, 18, 23);
            var lamp2 = new Lamp(true, 70, true, 80, 18, 23);
            device.addLamp(lamp1);
            device.addLamp(lamp2);
            device.setColorAllLamps("red");
            Assert.Equal("red", lamp2.getColor());
            Assert.Equal("red", lamp1.getColor());
        }
    }
}
