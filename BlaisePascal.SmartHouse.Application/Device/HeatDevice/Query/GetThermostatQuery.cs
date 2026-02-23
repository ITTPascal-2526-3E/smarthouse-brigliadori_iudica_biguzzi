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
    internal class GetThermostatQuery
    {
        private readonly IThermostatRepository thermostatRepository;
        public GetThermostatQuery(IThermostatRepository thermostatRepository)
        {
            this.thermostatRepository = thermostatRepository;
        }
        public Thermostat Execute(Guid id)
        {
            var thermostat = thermostatRepository.GetById(id);
            if (thermostat != null)
            {
                return thermostat;
            }
            else
            {
                throw new Exception("Thermostat not found");
            }
        }
    }
}

