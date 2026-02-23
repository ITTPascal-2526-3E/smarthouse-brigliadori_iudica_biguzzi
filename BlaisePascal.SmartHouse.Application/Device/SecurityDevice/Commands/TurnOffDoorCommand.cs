using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
namespace BlaisePascal.SmartHouse.Application.Device.SecurityDevice.Commands
{
    public class TurnOffDoorCommand
    {
        private readonly IDoorRepository doorRepository;
        public TurnOffDoorCommand(IDoorRepository doorRepository)
        {
            this.doorRepository = doorRepository;
        }
        public void Execute(Guid id)
        {
            var door = doorRepository.GetById(id);
            if (door != null)
            {
                door.TurnOff();
                doorRepository.Update(door);
            }
            else
            {
                throw new Exception("Door not found");
            }
        }
    }
}
