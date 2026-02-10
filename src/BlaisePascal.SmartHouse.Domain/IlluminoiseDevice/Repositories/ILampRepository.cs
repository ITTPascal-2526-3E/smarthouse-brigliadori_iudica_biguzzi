using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.IlluminoiseDevice.Repositories
{
    public interface ILampRepository
    {
        public interface ILampRepository
        {
            void Add(Lamp lamp);
            void Update(Lamp lamp);
            void Remove(Guid id);
            Lamp GetById(Guid id);
            List<Lamp> GetAll();

        }
    }
}
