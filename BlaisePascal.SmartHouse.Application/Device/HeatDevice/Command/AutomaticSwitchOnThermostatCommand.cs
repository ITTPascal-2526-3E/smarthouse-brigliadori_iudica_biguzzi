using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
using BlaisePascal.SmartHouse.Domain.Heat.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Device.HeatDevice.Command
{
    internal class AutomaticSwitchOnThermostatCommand
    {
        private readonly IThermostatRepository thermostatRepository;

        public AutomaticSwitchOnThermostatCommand(IThermostatRepository _thermostatRepository)
        {
            thermostatRepository = _thermostatRepository;
        }

        public void Execute( Guid ID)
        {
            var thermostat = thermostatRepository.GetById(ID);
            if (thermostat != null)
            {
                thermostat.AutomaticSwicthOn();
            }
            else
            {
                throw new InvalidOperationException("Thermostat not found");
            }
        }
    }
}
