using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class LampTest
    {
        [Fact]
        public void Lamp_isOn_turnOffMethod_AssertEquals() 
        { 
            Lamp lamp = new Lamp(true, 50, true, 60, 18, 23);
            lamp.turnOff();
            Assert.False( lamp.isOn);
        }

        [Fact]
        public void Lamp_isOn_checkLitghIntensity_AssertEquals()
        {
            Lamp lamp = new Lamp(true, 50, true, 60, 18, 23);
            Assert.Equal(50, lamp.lightIntensityPropriety);
        }

        [Fact]
        public void Lamp_isOn_turnOffMethod_checkLitghIntensity_AssertEquals()
        {
            Lamp lamp = new Lamp(true, 50, true, 60, 18, 23);
            lamp.turnOff();
            Assert.Equal(0, lamp.lightIntensityPropriety);
        }

        [Fact]
        public void Lamp_isOff_turnOnMethod_AssertEquals()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, 18, 23);
            lamp.turnOn();
            Assert.True( lamp.isOn);
        }

        [Fact]
        public void Lamp_isOff_turnOnMethod_checkLitghIntensity_AssertEquals()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, 18, 23);
            lamp.turnOn();
            Assert.Equal(100, lamp.lightIntensityPropriety);
        }

        [Fact]
        public void Lamp_setColor_colorDontExistInList_AssertThrow()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, 18, 23);
            Assert.Throws<InvalidOperationException>( () => lamp.setColor("C"));
        }

        [Fact]
        public void Lamp_setColor_emptyString_AssertEqual()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, 18, 23);

            Assert.Throws<InvalidOperationException>(() => lamp.setColor(" ")); 
        }

        [Fact]
        public void Lamp_setColor_colorExistInList_AssertEquals()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, 18, 23);
            lamp.setColor("red");
            Assert.Equal("red", lamp.getColor());
        }

        [Fact]
        public void Lamp_AplyyScheduleNow_sameHour_AssertEquals()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, DateTime.Now.Hour, DateTime.Now.Hour);
            lamp.ApllyScheduleNow();
            Assert.False( lamp.isOn);
        }

        [Fact]
        public void Lamp_AplyyScheduleNow_differentHour_AssertEquals()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, DateTime.Now.Hour, DateTime.Now.Hour+1);
            lamp.ApllyScheduleNow();
            Assert.True( lamp.isOn);
        }

        [Fact]
        public void Lamp_AplyyScheduleNow_differentHour2_AssertEquals()
        {
            Lamp lamp = new Lamp(false, 50, true, 60, DateTime.Now.Hour+1, DateTime.Now.Hour);
            lamp.ApllyScheduleNow();
            Assert.False( lamp.isOn);
        }
    }
}
