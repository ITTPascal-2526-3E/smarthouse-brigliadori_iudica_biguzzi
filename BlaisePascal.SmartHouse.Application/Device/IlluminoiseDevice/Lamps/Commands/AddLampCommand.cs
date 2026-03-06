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

        public void Execute(string name)
        {
            var lamp = new Lamp(
                ison: false,
                ligthpower: 50,
                iswireless: true,
                consumationvalue: 10,
                _lightonspecifictime: new Hour(18),
                _lightoffspecifictime: new Hour(6)
            );
            _lampRepository.Add(lamp);
        }
    }
}
