using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Device
    {
        protected Guid Id { get; set; } = Guid.NewGuid();
        protected DateTime installationDate { get; set; } = DateTime.Now;
        protected DateTime lastMod { get; set; } = DateTime.Now;
    }
}