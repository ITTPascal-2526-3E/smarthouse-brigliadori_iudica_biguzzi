using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Device.IlluminoiseDevice.Lamps.Commands
{
    public class ChangeIntensityCommand
    {
        private readonly ILampRepository _lampRepository;

        public ChangeIntensityCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid id, int intensity, Brigthness brigthness)
        {
            var lamp = _lampRepository.GetById(id);
            if (lamp != null)
            {
                lamp.setBrightness(brigthness);
                _lampRepository.Update(lamp);
            }
        }
    }
}
