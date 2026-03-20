using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class LampTest
    {
        [Fact]
        public void Lamp_isOn_turnOffMethod_AssertEquals()
        {
            Hour hour = new Hour(15);
            Hour hour2 = new Hour(2);
            Hour hour3 = new Hour(10);
            Lamp lamp = new Lamp(true, 50, true, 60, hour2, hour);
            lamp.TurnOff();
            Assert.False(lamp.isOn);
        }

        [Fact]
        public void Lamp_isOn_checkLitghIntensity_AssertEquals()
        {
            Hour hour = new Hour(15);
            Hour hour2 = new Hour(2);
            Hour hour3 = new Hour(10);
            Lamp lamp = new Lamp(true, 50, true, 60, hour2, hour);
            Assert.Equal(50, lamp.brigthness.Value);
        }

        [Fact]
        public void Lamp_isOn_turnOffMethod_checkLitghIntensity_AssertEquals()
        {
            Hour hour = new Hour(15);
            Hour hour2 = new Hour(2);
            Hour hour3 = new Hour(10);
            Lamp lamp = new Lamp(true, 50, true, 60, hour2, hour);
            lamp.TurnOff();
            Assert.Equal(0, lamp.brigthness.Value);
        }

        [Fact]
        public void Lamp_isOff_turnOnMethod_AssertEquals()
        {
            Hour hour = new Hour(15);
            Hour hour2 = new Hour(2);
            Hour hour3 = new Hour(10);
            Lamp lamp = new Lamp(true, 50, true, 60, hour2, hour);
            lamp.TurnOn();
            Assert.True(lamp.isOn);
        }

        [Fact]
        public void Lamp_isOff_turnOnMethod_checkLitghIntensity_AssertEquals()
        {
            Hour hour = new Hour(15);
            Hour hour2 = new Hour(2);
            Hour hour3 = new Hour(10);
            Lamp lamp = new Lamp(true, 50, true, 60, hour2, hour); lamp.TurnOn();
            Assert.Equal(100, lamp.brigthness.Value);
        }

        
        
        
        

        [Fact]
        public void Lamp_setColor_colorExistInList_AssertEquals()
        {
            Hour hour = new Hour(15);
            Hour hour2 = new Hour(2);
            Hour hour3 = new Hour(10);
            Lamp lamp = new Lamp(true, 50, true, 60, hour2, hour);
            lamp.setColor(Colors.RED);
            Assert.Equal(Colors.RED, lamp.getColor());
        }

    }
}
