using BlaisePascal.SmartHouse.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class RollerShuttersTest
    {
        [Fact] 
        public void RollerShutter_openShutter_assertTrue()
        {
            RollerShutter rollerShutter = new RollerShutter(false, 0);
            rollerShutter.TurnOn();
            Assert.True(rollerShutter.isOpen);
        }

        [Fact]
        public void RollerShutter_openShutter_position100_assertEquals()
        {
            RollerShutter rollerShutter = new RollerShutter(false, 0);
            rollerShutter.TurnOn();
            Assert.Equal(100, rollerShutter.position);
        }

        [Fact]
        public void RollerShutter_closeShutter_assertFalse()
        {
            RollerShutter rollerShutter = new RollerShutter(true, 100);
            rollerShutter.TurnOn();
            Assert.False(rollerShutter.isOpen);
        }

        [Fact]
        public void RollerShutter_closeShutter_position0_assertEquals()
        {
            RollerShutter rollerShutter = new RollerShutter(true, 100);
            rollerShutter.TurnOff();
            Assert.Equal(0, rollerShutter.position);
        }

    }
}
