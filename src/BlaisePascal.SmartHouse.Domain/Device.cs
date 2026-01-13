using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Device
    {
        public string name {  get; protected set; }
        public Guid Id { get; protected set; } = Guid.NewGuid();
        public DateTime installationDate { get; protected set; } = DateTime.Now;
        public DateTime lastMod { get; protected set; } = DateTime.Now;
    }
}