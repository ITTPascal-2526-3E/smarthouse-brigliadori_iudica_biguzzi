using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Device.IlluminoiseDevice.Lamps.Commands
{
     public class RemoveLampCommand
    {
        private readonly ILampRepository _lampRepository;

        public RemoveLampCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid id)
        {
            _lampRepository.Remove(id);
        }
    }
}
