using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Security;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class CCTVTest
    {
        [Fact]
        public void CCTV_IsOn_turnOff_assertFalse()
        {
            CCTV cctv = new CCTV(true, 6, 22);
            cctv.turnOff();
            Assert.False(cctv.isOn);
        }
        [Fact]
        public void CCTV_IsOff_turnOn_assertTrue()
        {
            CCTV cctv = new CCTV(false, 6, 22);
            cctv.turnOn();
            Assert.True(cctv.isOn);
        }
        [Fact]
        public void CCTV_AutomaticTurnOn_turnOnRheCCTV_assertTrue()
        {
            CCTV cctv = new CCTV(false, 6, 20);
            cctv.AutomaticTurnOn();
            Assert.True(cctv.isOn);
        }
        [Fact]
        public void CCTV_AutomaticTurnOn_dontTurnOnRheCCTV_assertFalse()
        {
            CCTV cctv = new CCTV(false, 16, 20);
            cctv.AutomaticTurnOn();
            Assert.False(cctv.isOn);
        }


    }
}
