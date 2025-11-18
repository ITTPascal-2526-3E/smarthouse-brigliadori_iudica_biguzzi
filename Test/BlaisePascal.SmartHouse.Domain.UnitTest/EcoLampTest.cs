using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class EcoLampTest
    {
        [Fact]
        public void ecolamp_isOn_turnOffMethod_AssertEquals()
        {
            EcoLamp lamp = new EcoLamp(true, 15, true, 15, 2);
            lamp.turnOff();
            Assert.Equal(false, lamp.isOn);
        }

        [Fact]
        public void ecolamp_isOn_checkLitghIntensity_AssertEquals()
        {
            EcoLamp lamp = new EcoLamp(true, 15, true, 15, 2); 
            Assert.Equal(15, lamp.lightIntensityProperty);
        }
        [Fact]
        public void ecolamp_isOn_turnOffMethod_checkLitghIntensity_AssertEquals()
        {
            EcoLamp lamp = new EcoLamp(true, 15, true, 15, 2); 
            lamp.turnOff();
            Assert.Equal(0, lamp.lightIntensityProperty);
        }

        [Fact]
        public void ecolamp_isOff_turnOnMethod_AssertEquals()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, 18, 23);
            lamp.turnOn();
            Assert.Equal(true, lamp.isOn);
        }

        [Fact]
        public void ecolamp_isOff_turnOnMethod_checkLitghIntensity_AssertEquals()
        {
            EcoLamp lamp = new EcoLamp(false, 15, true, 15, 2);
            lamp.turnOn();
            Assert.Equal(20, lamp.lightIntensityProperty);
        }

        [Fact]
        public void ecolamp_setColor_colorDontExistInList_AssertThrow()
        {
            EcoLamp lamp = new EcoLamp(true, 15, true, 15, 2);
            Assert.Throws<ArgumentException>(() => lamp.setColor("rouge"));
        }

        [Fact]
        public void ecolamp_setColor_emptyString_AssertThrow()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, 18, 23);
            Assert.Throws<ArgumentException>(() => lamp.setColor(" "));
        }

        [Fact]
        public void ecolamp_setColor_colorExistInList_AssertEquals()
        {
            EcoLamp lamp = new EcoLamp(true, 15, true, 15, 2);
            lamp.setColor("red");
            Assert.Equal("red", lamp.getColor());
        }

        [Fact]
        public void ecolamp_EcoActvation_AssertEquals()
        {
            EcoLamp lamp = new EcoLamp(true, 15, true, 15, 2);
            lamp.EcoActivation();
            Assert.Equal(true, lamp.isOn);
        }

        [Fact]
        public void ecolamp_EcoActvation2_AssertEquals()
        {
            EcoLamp lamp = new EcoLamp(true, 15, true, 2,15);
            lamp.EcoActivation();
            Assert.Equal(false, lamp.isOn);
        }
    }
}
