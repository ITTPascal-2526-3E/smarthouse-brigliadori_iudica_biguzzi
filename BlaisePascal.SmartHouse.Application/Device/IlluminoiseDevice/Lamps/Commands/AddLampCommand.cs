using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice.Repositories;


namespace BlaisePascal.SmartHouse.Application.Device.IlluminoiseDevice.Lamps.Commands
{
    public class AddLampCommand
    {
        private readonly ILampRepository _lampRepository;

        public AddLampCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(string name)
        {
            var lamp = new Lamp(name);
            _lampRepository.Add(lamp);
        }
    }
}
