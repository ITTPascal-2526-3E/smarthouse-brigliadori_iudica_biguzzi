using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lightining.Lamps
{
    public class InMemoryLampRepository : ILampRepository
    {
        private readonly List<Lamp> _lamps;

        public InMemoryLampRepository()
        {
            _lamps = new List<Lamp>();
            {
                new Lamp(true, 20, false, 2, new Hour(12), new Hour(14));
            }
        }


        public void Add(Lamp lamp)
        {
            if (lamp == null)
            {
                throw new ArgumentNullException(nameof(lamp));
            }
            _lamps.Add(lamp);
        }

        public List<Lamp> GetAll()
        {
            return _lamps;
        }


        public Lamp GetById(Guid id)
        {
            return _lamps.FirstOrDefault(l => l.Id == id);
        }

        public void Remove(Guid id)
        {
            foreach (var lamp in _lamps)
            {
                if (lamp.Id == id)
                {
                    _lamps.Remove(lamp);
                    break;
                }
            }
        }

        public void Update(Lamp lamp)
        {
            //
        }

    }


}
