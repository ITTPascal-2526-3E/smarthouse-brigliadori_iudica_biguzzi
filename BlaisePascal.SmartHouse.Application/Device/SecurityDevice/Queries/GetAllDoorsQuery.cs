using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
namespace BlaisePascal.SmartHouse.Application.Device.SecurityDevice.Queries
{
    public class GetAllDoorsQuery
    {
        private readonly IDoorRepository doorRepository;
        public GetAllDoorsQuery(IDoorRepository doorRepository)
        {
            this.doorRepository = doorRepository;
        }
        public IEnumerable<Door> Execute()
        {
            return doorRepository.GetAll();
        }
    }
}
