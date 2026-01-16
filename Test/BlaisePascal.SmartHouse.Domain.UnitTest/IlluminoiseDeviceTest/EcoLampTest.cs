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
        public void Ecolamp_isOn_turnOffMethod_AssertEquals()
        {
            EcoLamp lamp = new EcoLamp(true, 15, true, 15, 2);
            lamp.TurnOff();
            Assert.False(lamp.isOn);
        }

        [Fact]
        public void Ecolamp_isOn_checkLitghIntensity_AssertEquals()
        {
            EcoLamp lamp = new EcoLamp(true, 15, true, 15, 2); 
            Assert.Equal(15, lamp.lightIntensityProperty);
        }
        [Fact]
        public void Ecolamp_isOn_turnOffMethod_checkLitghIntensity_AssertEquals()
        {
            EcoLamp lamp = new EcoLamp(true, 15, true, 15, 2); 
            lamp.TurnOff();
            Assert.Equal(0, lamp.lightIntensityProperty);
        }

        [Fact]
        public void Ecolamp_isOff_turnOnMethod_AssertEquals()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, 18, 23);
            lamp.TurnOn();
            Assert.True(lamp.isOn);
        }

        [Fact]
        public void Ecolamp_isOff_turnOnMethod_checkLitghIntensity_AssertEquals()
        {
            EcoLamp lamp = new EcoLamp(false, 15, true, 15, 2);
            lamp.TurnOn();
            Assert.Equal(100, lamp.lightIntensityProperty);
        }

        [Fact]
        public void Ecolamp_setColor_colorDontExistInList_AssertThrow()
        {
            EcoLamp lamp = new EcoLamp(true, 15, true, 15, 2);
            Assert.Throws<InvalidOperationException>(() => lamp.setColor("C"));
        }

        [Fact]
        public void Ecolamp_setColor_emptyString_AssertThrow()
        {
            EcoLamp lamp = new EcoLamp(false, 50, true, 18, 23);
                Assert.Throws<InvalidOperationException>(() => lamp.setColor(" "));
            }

        [Fact]
        public void Ecolamp_setColor_colorExistInList_AssertEquals()
        {
            EcoLamp lamp = new EcoLamp(true, 15, true, 15, 2);
            lamp.setColor("red");
            Assert.Equal("red", lamp.getColor());
        }

        [Fact]
        public void Ecolamp_EcoActvation_AssertEquals()
        {
            EcoLamp lamp = new EcoLamp(true, 15, true, 15, 2);
            lamp.EcoActivation();
            Assert.True( lamp.isOn);
        }
    }
}
