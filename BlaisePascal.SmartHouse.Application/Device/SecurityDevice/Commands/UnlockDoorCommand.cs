using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
namespace BlaisePascal.SmartHouse.Application.Device.SecurityDevice.Commands
{
    public class UnlockDoorCommand
    {
        private readonly IDoorRepository doorRepository;
        public UnlockDoorCommand(IDoorRepository doorRepository)
        {
            this.doorRepository = doorRepository;
        }
        public void Execute(Guid id, int code)
        {
            var door = doorRepository.GetById(id);
            if (door != null)
            {
                door.UnlockDoor(code);
                doorRepository.Update(door);
            }
            else
            {
                throw new Exception("Door not found");
            }
        }
    }
}