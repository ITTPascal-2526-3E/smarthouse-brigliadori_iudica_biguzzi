using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
namespace BlaisePascal.SmartHouse.Application.Device.SecurityDevice.Commands
{
    public class AddDoorCommand
    {
        private readonly IDoorRepository doorRepository;
        public AddDoorCommand(IDoorRepository doorRepository)
        {
            this.doorRepository = doorRepository;
        }
        public void Execute(bool isOpen, bool isLooked, int passcode)
        {
            var door = new Door(isOpen, isLooked, passcode);
            doorRepository.Add(door);
        }
    }
}
