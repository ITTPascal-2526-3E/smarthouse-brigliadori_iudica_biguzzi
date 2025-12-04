using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.IlluminoiseDeviceTest
{
    public class LampRowTest
    {
        [Fact]
        public void LampRow_AddLamp_assertEquals()
        {
            Lamp lamp = new Lamp(true, 50, true, 60, 18, 23);
            LampRow lampRow = new LampRow();
            lampRow.AddLamp(lamp);
            Assert.Equal(lamp , lampRow.lamps[0]);
        }

        [Fact]
        public void LampRow_AddLampinPosition_assertEquals()
        {
            Lamp lamp = new Lamp(true, 50, true, 60, 18, 23);
            LampRow lampRow = new LampRow();
            lampRow.AddLamp(new Lamp(true, 50, true, 60, 18, 23));
            lampRow.AddLampAtPosition(lamp, 0);
            Assert.Equal(lamp, lampRow.lamps[0]);
        }

        [Fact]
        public void LampRow_RemoveLamp_assertEquals()
        {
            Lamp lamp = new Lamp(true, 50, true, 60, 18, 23);
            LampRow lampRow = new LampRow();
            lampRow.AddLamp(lamp);
            lampRow.RemoveLamp(lamp.name);
            Assert.Equal(0, lampRow.lamps.Count);
        }

        [Fact]
        public void LampRow_RemoveLampatPosition_assertEquals()
        {
            Lamp lamp = new Lamp(true, 50, true, 60, 18, 23);
            Lamp lamp1 = new Lamp(true, 50, true, 60, 18, 23);
            Lamp lamp2 = new Lamp(true, 50, true, 60, 18, 23);
            Lamp lamp3 = new Lamp(true, 50, true, 60, 18, 23);
            LampRow lampRow = new LampRow();
            lampRow.AddLamp(lamp);
            lampRow.AddLamp(lamp1);
            lampRow.AddLamp(lamp2);
            lampRow.AddLamp(lamp3);
            lampRow.RemoveLamp(lamp1.name);
            Assert.Equal(3, lampRow.lamps.Count);
        }

        [Fact]
        public void LampRow_switchOnAllLamps_assertTrue()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, 18, 23);
            Lamp lamp1 = new Lamp(false, 50, true, 60, 18, 23);
            Lamp lamp2 = new Lamp(false, 50, true, 60, 18, 23);
            Lamp lamp3 = new Lamp(false, 50, true, 60, 18, 23);
            LampRow lampRow = new LampRow();
            lampRow.AddLamp(lamp);
            lampRow.AddLamp(lamp1);
            lampRow.AddLamp(lamp2);
            lampRow.AddLamp(lamp3);
            lampRow.SwitchOnAllLamp();
            Assert.True(lamp.isOn && lamp1.isOn && lamp2.isOn && lamp3.isOn);
        }

        [Fact]
        public void LampRow_switchOnLamp_assertTrue()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, 18, 23);
            Lamp lamp1 = new Lamp(false, 50, true, 60, 18, 23);
            Lamp lamp2 = new Lamp(false, 50, true, 60, 18, 23);
            Lamp lamp3 = new Lamp(false, 50, true, 60, 18, 23);
            LampRow lampRow = new LampRow();
            lamp2.name = "LampToSwitchOn";
            lampRow.AddLamp(lamp);
            lampRow.AddLamp(lamp1);
            lampRow.AddLamp(lamp2);
            lampRow.AddLamp(lamp3);
            lampRow.SwitchOn(lamp2.name);
            Assert.True(lamp2.isOn);
        }

        [Fact]
        public void LampRow_switchOffAllLamps_assertfalse()
        {
            Lamp lamp = new Lamp(true, 50, true, 60, 18, 23);
            Lamp lamp1 = new Lamp(true, 50, true, 60, 18, 23);
            Lamp lamp2 = new Lamp(true, 50, true, 60, 18, 23);
            Lamp lamp3 = new Lamp(true, 50, true, 60, 18, 23);
            LampRow lampRow = new LampRow();
            lampRow.AddLamp(lamp);
            lampRow.AddLamp(lamp1);
            lampRow.AddLamp(lamp2);
            lampRow.AddLamp(lamp3);
            lampRow.SwitchOffAllLamp();
            Assert.False(lamp.isOn && lamp1.isOn && lamp2.isOn && lamp3.isOn);
        }

        [Fact]
        public void LampRow_switchOffLamp_assertFalse()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, 18, 23);
            Lamp lamp1 = new Lamp(false, 50, true, 60, 18, 23);
            Lamp lamp2 = new Lamp(true, 50, true, 60, 18, 23);
            Lamp lamp3 = new Lamp(false, 50, true, 60, 18, 23);
            lamp2.name = "LampToSwitchOff";
            LampRow lampRow = new LampRow();
            lampRow.AddLamp(lamp);
            lampRow.AddLamp(lamp1);
            lampRow.AddLamp(lamp2);
            lampRow.AddLamp(lamp3);
            lampRow.SwitchOff(lamp2.name);
            Assert.False(lamp2.isOn);
        }

        [Fact]
        public void LampRow_setIntensityForAllLamps_assertEqual()
        {
            Lamp lamp = new Lamp(true, 50, true, 60, 18, 23);
            Lamp lamp1 = new Lamp(true, 50, true, 60, 18, 23);
            Lamp lamp2 = new Lamp(true, 50, true, 60, 18, 23);
            Lamp lamp3 = new Lamp(true, 50, true, 60, 18, 23);
            LampRow lampRow = new LampRow();
            lampRow.AddLamp(lamp);
            lampRow.AddLamp(lamp1);
            lampRow.AddLamp(lamp2);
            lampRow.AddLamp(lamp3);
            lampRow.SetIntensityForAllLamp(23);
            Assert.Equal(23,lamp.lightIntensityPropriety);
            Assert.Equal(23, lamp1.lightIntensityPropriety);
            Assert.Equal(23, lamp2.lightIntensityPropriety);
            Assert.Equal(23, lamp3.lightIntensityPropriety);
        }

        [Fact]
        public void LampRow_setIntensityLamp_assertFalse()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, 18, 23);
            Lamp lamp1 = new Lamp(false, 50, true, 60, 18, 23);
            Lamp lamp2 = new Lamp(true, 50, true, 60, 18, 23);
            Lamp lamp3 = new Lamp(false, 50, true, 60, 18, 23);
            LampRow lampRow = new LampRow();
            lampRow.AddLamp(lamp);
            lampRow.AddLamp(lamp1);
            lampRow.AddLamp(lamp2);
            lampRow.AddLamp(lamp3);
            lampRow.SetIntensityForLamp(lamp2.name,23);
            Assert.Equal(23 , lamp.lightIntensityPropriety);
        }

    }
}
