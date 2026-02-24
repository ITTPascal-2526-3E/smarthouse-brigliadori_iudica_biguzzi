using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
using BlaisePascal.SmartHouse.Domain.Heat.Repository;

namespace BlaisePascal.SmartHouse.Application.Device.HeatDevice.Command
{
    internal class SetTargetThemperatureThermostatCommand
    {
        private readonly IThermostatRepository thermostatRepository;

        public SetTargetThemperatureThermostatCommand(IThermostatRepository _thermostatRepository) 
        {
            thermostatRepository = _thermostatRepository;
        }

        public void Execute(TargetTemperature targetTemperature,Guid ID) 
        {
             var thermostat = thermostatRepository.GetById(ID);
            if (thermostat != null) 
            {
                thermostat.SetTargetTemperature(targetTemperature);
            }
        }
    }
}
