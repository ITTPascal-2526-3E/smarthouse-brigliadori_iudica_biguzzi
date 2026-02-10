using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;
using BlaisePascal.SmartHouse.Domain;
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
            Assert.Equal(lamp, lampRow.lamps[0]);
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
            lampRow.RemoveLamp(lamp.name.Value);
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
            lampRow.RemoveLamp(lamp1.name.Value);
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
            lamp2.SetName("lamp kaiba");
            lampRow.AddLamp(lamp);
            lampRow.AddLamp(lamp1);
            lampRow.AddLamp(lamp2);
            lampRow.AddLamp(lamp3);
            lampRow.SwitchOn(lamp2.name.Value);
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
            lamp2.SetName("lamp kaiba");
            LampRow lampRow = new LampRow();
            lampRow.AddLamp(lamp);
            lampRow.AddLamp(lamp1);
            lampRow.AddLamp(lamp2);
            lampRow.AddLamp(lamp3);
            lampRow.SwitchOff(lamp2.name.Value);
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
            Assert.Equal(23, lamp.brigthness.Value);
            Assert.Equal(23, lamp1.brigthness.Value);
            Assert.Equal(23, lamp2.brigthness.Value);
            Assert.Equal(23, lamp3.brigthness.Value);
        }

        [Fact]
        public void LampRow_setIntensityLamp_assertEquals()
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
            lampRow.SetIntensityForLamp(lamp2.name.Value, 23);
            Assert.Equal(23, lamp.brigthness.Value);
        }

        [Fact]
        public void LampRow_findLampWithMaxIntensisty_assertEquals()
        {
            Lamp lamp = new Lamp(true, 10, true, 60, 18, 23);
            Lamp lamp1 = new Lamp(true, 50, true, 60, 18, 23);
            Lamp lamp2 = new Lamp(true, 50, true, 60, 18, 23);
            Lamp lamp3 = new Lamp(true, 70, true, 60, 18, 23);
            LampRow lampRow = new LampRow();
            lampRow.AddLamp(lamp);
            lampRow.AddLamp(lamp1);
            lampRow.AddLamp(lamp2);
            lampRow.AddLamp(lamp3);
            Lamp lampex = lampRow.FindLampWithMaxIntensity();
            Assert.Equal(lamp3, lampex);
        }

        [Fact]
        public void LampRow_findLampWithMinIntensisty_assertEquals()
        {
            Lamp lamp = new Lamp(true, 60, true, 60, 18, 23);
            Lamp lamp1 = new Lamp(true, 80, true, 60, 18, 23);
            Lamp lamp2 = new Lamp(true, 50, true, 60, 18, 23);
            Lamp lamp3 = new Lamp(true, 70, true, 60, 18, 23);
            LampRow lampRow = new LampRow();
            lampRow.AddLamp(lamp);
            lampRow.AddLamp(lamp1);
            lampRow.AddLamp(lamp2);
            lampRow.AddLamp(lamp3);
            Lamp lampex = lampRow.FindLampWithMinIntensity();
            Assert.Equal(lamp2, lampex);
        }

        [Fact]
        public void LampRow_findLampsByIntensistyRange_assertEquals()
        {
            Lamp lamp = new Lamp(true, 60, true, 60, 18, 23);
            Lamp lamp1 = new Lamp(true, 80, true, 60, 18, 23);
            Lamp lamp2 = new Lamp(true, 50, true, 60, 18, 23);
            Lamp lamp3 = new Lamp(true, 70, true, 60, 18, 23);
            LampRow lampRow = new LampRow();
            lampRow.AddLamp(lamp);
            lampRow.AddLamp(lamp1);
            lampRow.AddLamp(lamp2);
            lampRow.AddLamp(lamp3);
            List<Lamp> lampeq = new List<Lamp>();
            lampeq.Add(lamp2);
            List<Lamp> lampex = lampRow.FindLampsByIntensityRange(30, 59);
            Assert.Equal(lampeq, lampex);
        }

        [Fact]
        public void LampRow_findAllLampOn_assertEquals()
        {
            Lamp lamp = new Lamp(true, 60, true, 60, 18, 23);
            Lamp lamp1 = new Lamp(true, 80, true, 60, 18, 23);
            Lamp lamp2 = new Lamp(false, 50, true, 60, 18, 23);
            Lamp lamp3 = new Lamp(true, 70, true, 60, 18, 23);
            LampRow lampRow = new LampRow();
            lampRow.AddLamp(lamp);
            lampRow.AddLamp(lamp1);
            lampRow.AddLamp(lamp2);
            lampRow.AddLamp(lamp3);
            List<Lamp> lampeq = new List<Lamp>();
            lampeq.Add(lamp);
            lampeq.Add(lamp1);
            lampeq.Add(lamp3);
            List<Lamp> lampex = lampRow.FindAllOn();
            Assert.Equal(lampeq, lampex);
        }

        [Fact]
        public void LampRow_findAllLampOff_assertEquals()
        {
            Lamp lamp = new Lamp(false, 60, true, 60, 18, 23);
            Lamp lamp1 = new Lamp(false, 80, true, 60, 18, 23);
            Lamp lamp2 = new Lamp(true, 50, true, 60, 18, 23);
            Lamp lamp3 = new Lamp(false, 70, true, 60, 18, 23);
            LampRow lampRow = new LampRow();
            lampRow.AddLamp(lamp);
            lampRow.AddLamp(lamp1);
            lampRow.AddLamp(lamp2);
            lampRow.AddLamp(lamp3);
            List<Lamp> lampeq = new List<Lamp>();
            lampeq.Add(lamp);
            lampeq.Add(lamp1);
            lampeq.Add(lamp3);
            List<Lamp> lampex = lampRow.FindAllOff();
            Assert.Equal(lampeq, lampex);
        }

        [Fact]
        public void LampRow_sortByIntensityDesciengFalse_assertEquals()
        {
            Lamp lamp = new Lamp(false, 60, true, 60, 18, 23);
            Lamp lamp1 = new Lamp(false, 80, true, 60, 18, 23);
            Lamp lamp2 = new Lamp(true, 50, true, 60, 18, 23);
            Lamp lamp3 = new Lamp(false, 70, true, 60, 18, 23);
            LampRow lampRow = new LampRow();
            lampRow.AddLamp(lamp);
            lampRow.AddLamp(lamp1);
            lampRow.AddLamp(lamp2);
            lampRow.AddLamp(lamp3);
            List<Lamp> lampeq = new List<Lamp>();
            lampeq.Add(lamp2);
            lampeq.Add(lamp);
            lampeq.Add(lamp3);
            lampeq.Add(lamp1);
            List<Lamp> lampex = lampRow.SortByIntensity(false);
            Assert.Equal(lampeq, lampex);
        }

        [Fact]
        public void LampRow_sortByIntensityDesciengTrue_assertEquals()
        {
            Lamp lamp = new Lamp(false, 60, true, 60, 18, 23);
            Lamp lamp1 = new Lamp(false, 80, true, 60, 18, 23);
            Lamp lamp2 = new Lamp(true, 50, true, 60, 18, 23);
            Lamp lamp3 = new Lamp(false, 70, true, 60, 18, 23);
            LampRow lampRow = new LampRow();
            lampRow.AddLamp(lamp);
            lampRow.AddLamp(lamp1);
            lampRow.AddLamp(lamp2);
            lampRow.AddLamp(lamp3);
            List<Lamp> lampeq = new List<Lamp>();
            lampeq.Add(lamp1);
            lampeq.Add(lamp3);
            lampeq.Add(lamp);
            lampeq.Add(lamp2);
            List<Lamp> lampex = lampRow.SortByIntensity(true);
            Assert.Equal(lampeq, lampex);
        }
    }
}
