using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Security.Repositories
{
    public interface IDoorRepository
    {
        public interface IDoorRepository
        {
            void Add(Door door);
            void Update(Door door);
            void Remove(Guid id);
            Lamp GetById(Guid id);
            List<Door> GetAll();

        }
    }
}
