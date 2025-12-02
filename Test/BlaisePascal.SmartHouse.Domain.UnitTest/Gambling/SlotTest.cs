using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Gambling;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Gambling
{
    public class SlotTest
    {
        [Fact]
        public void Slot_constructorbet_AssertEquals()
        {
            Slot slot = new Slot(10);
            Assert.Equal(10, slot.bet);
        }
        [Fact]
        public void Slot_constructorbet_LowerThanZero_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Slot(0));
        }

    }
}
