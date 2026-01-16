using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class LedTest
    {
        [Fact]
        public void Led_isOn_turnOffMethod_AssertFalse()
        {
            Led led = new Led("red", 100);
            led.TurnOff();
            Assert.False(led.isOn);
        }

        [Fact]
        public void Led_isOn_checkLitghIntensity_AssertEquals()
        {
            Led led = new Led("red", 100);
            led.TurnOff();
            Assert.Equal(0, led.lightIntensityPropriety);
        }



        [Fact]
        public void Led_isOff_turnOnMethod_AssertEquals()
        {
            Led led = new Led("red", 100);
            led.TurnOn();
            Assert.True(led.isOn);
        }

        [Fact]
        public void Led_isOff_turnOnMethod_checkLitghIntensity_AssertEquals()
        {
            Led led = new Led("red", 100);
            led.TurnOn();
            Assert.Equal(100, led.lightIntensityPropriety);
        }
    }
}
