using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Device.IlluminoiseDevice.Lamps.Commands
{
    public class SwitchLampOnCommand
    {
        private readonly ILampRepository _lampRepository;

        public SwitchLampOnCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid id)
        {
            var lamp = _lampRepository.GetById(id);
            if (lamp != null)
            {
                lamp.TurnOn();
                _lampRepository.Update(lamp);
            }
        }
    }
}
