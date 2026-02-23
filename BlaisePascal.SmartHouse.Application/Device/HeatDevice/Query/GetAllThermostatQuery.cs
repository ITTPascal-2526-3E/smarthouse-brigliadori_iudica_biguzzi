using BlaisePascal.SmartHouse.Domain.Heat;
using BlaisePascal.SmartHouse.Domain.Heat.Repository;
using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Device.HeatDevice.Query
{
    internal class GetAllThermostatQuery
    {
        private readonly IThermostatRepository thermostatRepository;
        public GetAllThermostatQuery(IThermostatRepository thermostatRepository)
        {
            this.thermostatRepository = thermostatRepository;
        }
        public IEnumerable<Thermostat> Execute()
        {
            return thermostatRepository.GetAll();
        }
    }
}
