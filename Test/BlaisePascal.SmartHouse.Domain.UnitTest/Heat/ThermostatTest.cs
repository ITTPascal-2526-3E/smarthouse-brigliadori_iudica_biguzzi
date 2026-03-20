using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
using BlaisePascal.SmartHouse.Domain.Heat;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Heat
{
    public class ThermostatTest
    {
        
        
        [Fact]
        public void Thermostat_TurnOn_SetsIsOnToTrue()
        {
            CurrentTemperature currentTemp = new CurrentTemperature(20.0);
            TargetTemperature TargetTemp1 = new TargetTemperature(22.0);
            CurrentTemperature AutomaticOn = new CurrentTemperature(10.0);
            CurrentTemperature AutomaticOff = new CurrentTemperature(10.0);
            Thermostat thermostat = new Thermostat(currentTemp, TargetTemp1, false, AutomaticOn, AutomaticOff);
            thermostat.TurnOn();
            Assert.True(thermostat.IsOn);
        }
    
        
        [Fact]
        public void Thermostat_TurnOff_SetsIsOnToFalse()
        {
            CurrentTemperature currentTemp = new CurrentTemperature(20.0);
            TargetTemperature TargetTemp1 = new TargetTemperature(22.0);
            CurrentTemperature AutomaticOn = new CurrentTemperature(10.0);
            CurrentTemperature AutomaticOff = new CurrentTemperature(10.0);
            Thermostat thermostat = new Thermostat(currentTemp, TargetTemp1, true, AutomaticOn, AutomaticOff);
            thermostat.TurnOff();
            Assert.False(thermostat.IsOn);
        }
        [Fact]
        public void Thermostat_setAutomaticTurnOn_UpdatesAutomaticTurnOnTemperature()
        {
            CurrentTemperature currentTemp = new CurrentTemperature(20.0);
            TargetTemperature TargetTemp1 = new TargetTemperature(22.0);
            CurrentTemperature AutomaticOn = new CurrentTemperature(10.0);
            CurrentTemperature AutomaticOff = new CurrentTemperature(10.0);
            Thermostat thermostat = new Thermostat(currentTemp, TargetTemp1, true, AutomaticOn, AutomaticOff);
            CurrentTemperature newAutomaticOnTemp = new CurrentTemperature(5.0);
            thermostat.SetAutomaticTurnOn(newAutomaticOnTemp);
            Assert.Equal(5.0, thermostat.atWhatExternalTemperatureTurnAutomaticalyOn.Value);
        }

       

       
    }
}
