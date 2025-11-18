using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class LampTest
    {
        [Fact]
        public void lamp_isOn_turnOffMethod_AssertEquals() 
        { 
            Lamp lamp = new Lamp(true, 50, true, 60, 18, 23);
            lamp.turnOff();
            Assert.Equal(false, lamp.isOn);
        }

        [Fact]
        public void lamp_isOn_checkLitghIntensity_AssertEquals()
        {
            Lamp lamp = new Lamp(true, 50, true, 60, 18, 23);
            Assert.Equal(50, lamp.lightIntensityPropriety);
        }
        [Fact]
        public void lamp_isOn_turnOffMethod_checkLitghIntensity_AssertEquals()
        {
            Lamp lamp = new Lamp(true, 50, true, 60, 18, 23);
            lamp.turnOff();
            Assert.Equal(0, lamp.lightIntensityPropriety);
        }

        [Fact]
        public void lamp_isOff_turnOnMethod_AssertEquals()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, 18, 23);
            lamp.turnOn();
            Assert.Equal(true, lamp.isOn);
        }

        [Fact]
        public void lamp_isOff_turnOnMethod_checkLitghIntensity_AssertEquals()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, 18, 23);
            lamp.turnOn();
            Assert.Equal(100, lamp.lightIntensityPropriety);
        }

        [Fact]
        public void lamp_setColor_colorDontExistInList_AssertThrow()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, 18, 23);
            Assert.Throws<ArgumentException>(() => lamp.setColor("rouge"));
        }

        [Fact]
        public void lamp_setColor_emptyString_AssertThrow()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, 18, 23);
            Assert.Throws<ArgumentException>(() => lamp.setColor(" "));
        }

        [Fact]
        public void lamp_setColor_colorExistInList_AssertEquals()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, 18, 23);
            lamp.setColor("red");
            Assert.Equal("red", lamp.getColor());
        }

        [Fact]
        public void lamp_AplyyScheduleNow_sameHour_AssertEquals()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, DateTime.Now.Hour, DateTime.Now.Hour);
            lamp.ApllyScheduleNow();
            Assert.Equal(false, lamp.isOn);
        }

        [Fact]
        public void lamp_AplyyScheduleNow_differentHour_AssertEquals()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, DateTime.Now.Hour, DateTime.Now.Hour+1);
            lamp.ApllyScheduleNow();
            Assert.Equal(true, lamp.isOn);
        }

        [Fact]
        public void lamp_AplyyScheduleNow_differentHour2_AssertEquals()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, DateTime.Now.Hour+1, DateTime.Now.Hour);
            lamp.ApllyScheduleNow();
            Assert.Equal(false, lamp.isOn);
        }
    }
}
