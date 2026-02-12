using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
using BlaisePascal.SmartHouse.Domain.Security;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class CCTVTest
    {
        [Fact]
        public void CCTV_IsOn_turnOff_assertFalse()
        {
            Hour turnOnHour = new Hour(6);
            Hour turnOffHour = new Hour(22);
            CCTV cctv = new CCTV(true, turnOnHour, turnOffHour);
            cctv.TurnOff();
            Assert.False(cctv.isOn);
        }
        [Fact]
        public void CCTV_IsOff_turnOn_assertTrue()
        {
            Hour turnOnHour = new Hour(6);
            Hour turnOffHour = new Hour(22);
            CCTV cctv = new CCTV(false, turnOnHour, turnOffHour);
            cctv.TurnOn();
            Assert.True(cctv.isOn);
        }
        [Fact]
        public void CCTV_AutomaticTurnOn_turnOnRheCCTV_assertTrue()
        {
            Hour turnOnHour = new Hour(6);
            Hour turnOffHour = new Hour(20);
            CCTV cctv = new CCTV(false, turnOnHour, turnOffHour);
            cctv.AutomaticSwicthOn();
            Assert.True(cctv.isOn);
        }
        [Fact]
        public void CCTV_AutomaticTurnOn_dontTurnOnRheCCTV_assertFalse()
        {
            Hour turnOnHour = new Hour(6);
            Hour turnOffHour = new Hour(20);
            CCTV cctv = new CCTV(true, turnOnHour, turnOffHour);
            cctv.AutomaticSwicthOff();
            Assert.False(cctv.isOn);
        }


    }
}
