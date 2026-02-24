using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
using BlaisePascal.SmartHouse.Domain.Heat.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Device.HeatDevice.Command
{
    internal class SetCurrentTemperatureThermostatCommand
    {

        private readonly IThermostatRepository thermostatRepository;

        public SetCurrentTemperatureThermostatCommand(IThermostatRepository _thermostatRepository)
        {
            thermostatRepository = _thermostatRepository;
        }

        public void Execute(CurrentTemperature targetTemperature, Guid ID)
        {
            var thermostat = thermostatRepository.GetById(ID);
            if (thermostat != null)
            {
                thermostat.SetCurrentTemperature(targetTemperature);
            }else 
            {
                throw new InvalidOperationException("thermostat not found");
            }
        }
    }
}
