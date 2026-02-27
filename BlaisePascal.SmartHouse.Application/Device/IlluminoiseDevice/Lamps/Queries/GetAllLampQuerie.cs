using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Device.IlluminoiseDevice.Lamps.Queris
{
     public class GetAllLampQuerie
    {
        private readonly ILampRepository _lampRepository;

        public GetAllLampQuerie(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }


        public List<Lamp> Execute()
        {
            List<Lamp> lamp = _lampRepository.GetAll();
            return lamp;
        }
    }
}
