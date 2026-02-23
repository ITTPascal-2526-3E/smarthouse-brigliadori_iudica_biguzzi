using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
using BlaisePascal.SmartHouse.Domain.Heat;
using BlaisePascal.SmartHouse.Domain.Heat.Repository;
using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Device.HeatDevice.Command
{
    internal class AddThermostatCommand
    {
        private readonly IThermostatRepository thermostatRepository;
        public AddThermostatCommand(IThermostatRepository thermostatRepository)
        {
            this.thermostatRepository = thermostatRepository;
        }
        public void Execute(CurrentTemperature _currentTemp, TargetTemperature _targetTemp, CurrentTemperature _automaticOn, CurrentTemperature _automaticOff)
        {
            CurrentTemperature currentTemp = _currentTemp;
            TargetTemperature TargetTemp1 = _targetTemp;
            CurrentTemperature AutomaticOn = _automaticOn;
            CurrentTemperature AutomaticOff = _automaticOff;
            var thermostat = new Thermostat(currentTemp, TargetTemp1, true, AutomaticOn, AutomaticOff);
            thermostatRepository.Add(thermostat);
        }
    }
}
