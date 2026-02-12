using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Abstraction
{
    public interface ILockable
    {
        public void LockDoor();
        public void UnlockDoor(int code);
    }
}
