using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
namespace BlaisePascal.SmartHouse.Application.Device.SecurityDevice.Queries
{
    public class GetDoorQuery
    {
        private readonly IDoorRepository doorRepository;
        public GetDoorQuery(IDoorRepository doorRepository)
        {
            this.doorRepository = doorRepository;
        }
        public Door Execute(Guid id)
        {
            var door = doorRepository.GetById(id);
            if (door != null)
            {
                return door;
            }
            else
            {
                throw new Exception("Door not found");
            }
        }
    }
}
