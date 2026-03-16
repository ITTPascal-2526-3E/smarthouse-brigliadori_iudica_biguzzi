using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice.Repositories;
using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;


namespace BlaisePascal.SmartHouse.Application.Device.IlluminoiseDevice.Lamps.Commands
{
    public class AddLampCommand
    {
        private readonly ILampRepository _lampRepository;

        public AddLampCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(bool isOn, int ligthpower, bool iswireless, int consumationvalue, Hour _lightonspecifictime, Hour _lightoffspecifictime, Name name)
        {
            var lamp = new Lamp(isOn, ligthpower, iswireless, consumationvalue, _lightonspecifictime, _lightoffspecifictime);
            lamp.SetName(name);
            _lampRepository.Add(lamp);
        }
    }
}
