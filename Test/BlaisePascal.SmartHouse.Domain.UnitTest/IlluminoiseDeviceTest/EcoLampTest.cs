using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class EcoLampTest
    {
        [Fact]
        public void Ecolamp_isOn_turnOffMethod_AssertEquals()
        {
            Hour hour = new Hour(15);
            Hour hour2 = new Hour(2);
            Hour hour3 = new Hour(10);
            EcoLamp lamp = new EcoLamp(true, 15, true,10,hour3, hour, hour2);
            lamp.TurnOff();
            Assert.False(lamp.isOn);
        }

        [Fact]
        public void Ecolamp_isOn_checkLitghIntensity_AssertEquals()
        {
            Hour hour = new Hour(15);
            Hour hour2 = new Hour(2);
            Hour hour3 = new Hour(10);
            EcoLamp lamp = new EcoLamp(true, 15, true, 10, hour3, hour, hour2);
            Assert.Equal(15, lamp.brigthness.Value);
        }
        [Fact]
        public void Ecolamp_isOn_turnOffMethod_checkLitghIntensity_AssertEquals()
        {
            Hour hour = new Hour(15);
            Hour hour2 = new Hour(2);
            Hour hour3 = new Hour(10);
            EcoLamp lamp = new EcoLamp(true, 15, true, 10, hour3, hour, hour2);
            lamp.TurnOff();
            Assert.Equal(0, lamp.brigthness.Value);
        }

        [Fact]
        public void Ecolamp_isOff_turnOnMethod_AssertEquals()
        {
            Hour hour = new Hour(15);
            Hour hour2 = new Hour(2);
            Hour hour3 = new Hour(10);
            EcoLamp lamp = new EcoLamp(true, 15, true, 10, hour3, hour, hour2);
            lamp.TurnOn();
            Assert.True(lamp.isOn);
        }

        [Fact]
        public void Ecolamp_isOff_turnOnMethod_checkLitghIntensity_AssertEquals()
        {
            Hour hour = new Hour(15);
            Hour hour2 = new Hour(2);
            Hour hour3 = new Hour(10);
            EcoLamp lamp = new EcoLamp(true, 15, true, 10, hour3, hour, hour2);
            lamp.TurnOn();
            Assert.Equal(100, lamp.brigthness.Value);
        }

       

      

        [Fact]
        public void Ecolamp_setColor_colorExistInList_AssertEquals()
        {
            Hour hour = new Hour(15);
            Hour hour2 = new Hour(2);
            Hour hour3 = new Hour(10);
            EcoLamp lamp = new EcoLamp(true, 15, true, 10, hour3, hour, hour2);
            
            lamp.setColor( IlluminoiseDevice.Color.RED);
            Assert.Equal(IlluminoiseDevice.Color.RED, lamp.getColor());
        }

        [Fact]
        public void Ecolamp_EcoActvation_AssertEquals()
        {
            Hour hour = new Hour(15);
            Hour hour2 = new Hour(2);
            Hour hour3 = new Hour(10);
            EcoLamp lamp = new EcoLamp(true, 15, true, 10, hour3, hour, hour2);
            lamp.EcoActivation();
            Assert.True(lamp.isOn);
        }
    }
}
