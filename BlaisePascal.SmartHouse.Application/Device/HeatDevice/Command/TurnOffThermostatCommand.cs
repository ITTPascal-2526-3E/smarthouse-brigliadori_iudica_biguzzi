using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Heat.Repository;
using BlaisePascal.SmartHouse.Domain.Security;

namespace BlaisePascal.SmartHouse.Application.Device.HeatDevice.Command
{
    internal class TurnOffThermostatCommand
    {
        private readonly IThermostatRepository thermostatRepository;
        public TurnOffThermostatCommand(IThermostatRepository thermostatRepository)
        {
            this.thermostatRepository = thermostatRepository;
        }
        public void Execute(Guid thermostatId) 
        {
            var thermostat = thermostatRepository.GetById(thermostatId);
            if (thermostat != null)
            {
                thermostat.TurnOff();
                thermostatRepository.Update(thermostat);
            }
        }


    }
}
