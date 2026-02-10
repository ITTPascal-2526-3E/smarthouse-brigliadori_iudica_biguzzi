using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.IlluminoiseDeviceTest
{
    public class MatrixLedTest
    {
        [Fact]
        public void MatrixLed_SwicthAllOn_AssertTrue()
        {
            Led led = new Led("red", 0);
            MatrixLed matrixled = new MatrixLed(3, 3, led);
            matrixled.SwitchOnAll();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.True(led.isOn);
                    Assert.Equal(100, led.brigthness.Value);
                }
            }
        }

        [Fact]
        public void MatrixLed_SwicthAllOff_AssertFalse()
        {
            Led led = new Led("red", 100);
            MatrixLed matrixled = new MatrixLed(3, 3, led);
            matrixled.SwitchOffAll();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.False(led.isOn);
                    Assert.Equal(0, led.brigthness.Value);
                }
            }
        }

        [Fact]
        public void MatrixLed_SetIntensityAll_AssertEquals()
        {
            Led led = new Led("red", 100);
            MatrixLed matrixled = new MatrixLed(3, 3, led);
            matrixled.SetIntensityAll(30);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.Equal(30, led.brigthness.Value);
                }
            }
        }

        [Fact]
        public void MatrixLed_GetLed_AssertEquals()
        {
            Led led = new Led("red", 100);
            MatrixLed matrixled = new MatrixLed(3, 3, led);
            Led ledex = matrixled.GetLed(0, 0);
            Assert.Equal(led, ledex);
        }

        [Fact]
        public void MatrixLed_GetLedsInRow_AssertEquals()
        {
            Led led = new Led("red", 100);
            MatrixLed matrixled = new MatrixLed(3, 3, led);
            List<Led> ledex = matrixled.GetLedsInRow(0);
            List<Led> leds = new List<Led> { led, led, led };
            Assert.Equal(leds, ledex);
        }

        [Fact]
        public void MatrixLed_GetLedsInCollum_AssertEquals()
        {
            Led led = new Led("red", 100);
            MatrixLed matrixled = new MatrixLed(3, 3, led);
            List<Led> ledex = matrixled.GetLedsInColumn(0);
            List<Led> leds = new List<Led> { led, led, led };
            Assert.Equal(leds, ledex);
        }

    }
}
