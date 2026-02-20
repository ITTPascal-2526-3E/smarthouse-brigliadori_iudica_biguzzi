using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice.Repositories;


namespace BlaisePascal.SmartHouse.Application.Device.IlluminoiseDevice.Lamps.Commands
{
    public class SwitchLampOffCommand
    {
        private readonly ILampRepository _lampRepository;

        public SwitchLampOffCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid id)
        {
            var lamp = _lampRepository.GetById(id);
            if (lamp != null)
            {
                lamp.SwitchOff();
                _lampRepository.Update(lamp);
            }
        }
    }
}
