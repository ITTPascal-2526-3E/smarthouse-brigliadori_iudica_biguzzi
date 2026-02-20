using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;

namespace BlaisePascal.SmartHouse.Application.Device.IlluminoiseDevice.Lamps.Queris
{
    public class GetLampByIdQuerie
    {
        private readonly ILampRepository _lampRepository;

        public GetLampByIdQuerie(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

       
        public Lamp Execute(Guid id)
        {
            var lamp = _lampRepository.GetById(id);
            return lamp;
        }
    }
}
