using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
using BlaisePascal.SmartHouse.Domain.Heat;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Heat
{
    public class ThermostatTest
    {
        [Fact]
        public void Thermostat_constructorValidParameters_AssertEquals()
        {
            CurrentTemperature currentTemp = new CurrentTemperature(20.0);
            TargetTemperature TargetTemp1 = new TargetTemperature(22.0);
            CurrentTemperature AutomaticOn = new CurrentTemperature(10.0);
            CurrentTemperature AutomaticOff = new CurrentTemperature(10.0);
            Thermostat thermostat = new Thermostat(currentTemp, TargetTemp1, true, AutomaticOn, AutomaticOff);
            Assert.Equal(20.0, thermostat.CurrentTemperature.Value);
            Assert.Equal(22.0, thermostat.TargetTemperature.Value);
            Assert.False(thermostat.IsOn);
            Assert.Equal(10.0, thermostat.atWhatExternalTemperatureTurnAutomaticalyOn.Value);
        }
        [Fact]
        public void Thermostat_constructorInvalidTargetTemperature_ThrowsArgumentOutOfRangeException()
        {
            CurrentTemperature currentTemp = new CurrentTemperature(20.0);
            TargetTemperature TargetTemp1 = new TargetTemperature(35.0);
            CurrentTemperature AutomaticOn = new CurrentTemperature(10.0);
            CurrentTemperature AutomaticOff = new CurrentTemperature(10.0);

            Assert.Throws<ArgumentOutOfRangeException>(() => new Thermostat(currentTemp, TargetTemp1, true, AutomaticOn, AutomaticOff));
        }
        [Fact]
        public void Thermostat_constructorInvalidCurrentTemperature_ThrowsArgumentOutOfRangeException()
        {
            CurrentTemperature currentTemp = new CurrentTemperature(20.0);
            TargetTemperature TargetTemp1 = new TargetTemperature(22.0);
            CurrentTemperature AutomaticOn = new CurrentTemperature(10.0);
            CurrentTemperature AutomaticOff = new CurrentTemperature(10.0);
            Assert.Throws<ArgumentOutOfRangeException>(() => new Thermostat(currentTemp, TargetTemp1, true, AutomaticOn, AutomaticOff));
        }
        [Fact]
        public void Thermostat_constructorInvalidAutomaticTurnOnTemperature_ThrowsArgumentOutOfRangeException()
        {
            CurrentTemperature currentTemp = new CurrentTemperature(20.0);
            TargetTemperature TargetTemp1 = new TargetTemperature(22.0);
            CurrentTemperature AutomaticOn = new CurrentTemperature(60.0);
            CurrentTemperature AutomaticOff = new CurrentTemperature(10.0);
            Assert.Throws<ArgumentOutOfRangeException>(() => new Thermostat(currentTemp, TargetTemp1, true, AutomaticOn, AutomaticOff));
        }
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
        public void Thermostat_AdjustTemperature_UpdatesTargetTemperature()
        {
            CurrentTemperature currentTemp = new CurrentTemperature(20.0);
            TargetTemperature TargetTemp1 = new TargetTemperature(22.0);
            CurrentTemperature AutomaticOn = new CurrentTemperature(10.0);
            CurrentTemperature AutomaticOff = new CurrentTemperature(10.0);
            Thermostat thermostat = new Thermostat(currentTemp, TargetTemp1, true, AutomaticOn, AutomaticOff);
            TargetTemperature newTargetTemp = new TargetTemperature(25.0);
            thermostat.AdjustTemperature(newTargetTemp);
            Assert.Equal(25.0, thermostat.TargetTemperature.Value);
        }
        [Fact]
        public void Thermostat_UpdateCurrentTemperature_UpdatesCurrentTemperature()
        {
            CurrentTemperature currentTemp = new CurrentTemperature(20.0);
            TargetTemperature TargetTemp1 = new TargetTemperature(22.0);
            CurrentTemperature AutomaticOn = new CurrentTemperature(10.0);
            CurrentTemperature AutomaticOff = new CurrentTemperature(10.0);
            Thermostat thermostat = new Thermostat(currentTemp, TargetTemp1, true, AutomaticOn, AutomaticOff);
            CurrentTemperature newCurrentTemp = new CurrentTemperature(23.0);
            thermostat.UpdateCurrentTemperature(newCurrentTemp);
            Assert.Equal(23.0, thermostat.CurrentTemperature.Value);
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

        [Fact]
        public void Thermostat_UpdateCurrentTemperature_OutOfRange_ThrowsArgumentOutOfRangeException()
        {
            CurrentTemperature currentTemp = new CurrentTemperature(20.0);
            TargetTemperature TargetTemp1 = new TargetTemperature(22.0);
            CurrentTemperature AutomaticOn = new CurrentTemperature(10.0);
            CurrentTemperature AutomaticOff = new CurrentTemperature(10.0);
            Thermostat thermostat = new Thermostat(currentTemp, TargetTemp1, true, AutomaticOn, AutomaticOff);
            CurrentTemperature currentTemp1 = new CurrentTemperature(55.0);
            Assert.Throws<ArgumentOutOfRangeException>(() => thermostat.UpdateCurrentTemperature(currentTemp1));
        }

        [Fact]
        public void CheckAndTurnOnAutomatically_TemperatureBelowThreshold_TurnsOnThermostat()
        {
            CurrentTemperature currentTemp = new CurrentTemperature(20.0);
            TargetTemperature TargetTemp1 = new TargetTemperature(22.0);
            CurrentTemperature AutomaticOn = new CurrentTemperature(10.0);
            CurrentTemperature AutomaticOff = new CurrentTemperature(10.0);
            Thermostat thermostat = new Thermostat(currentTemp, TargetTemp1, true, AutomaticOn, AutomaticOff);
            CurrentTemperature currentTemp1 = new CurrentTemperature(10.0);
            thermostat.SetAutomaticTurnOn(currentTemp1);
            thermostat.AutomaticSwicthOn();
            Assert.True(thermostat.IsOn);
        }
        [Fact]
        public void CheckAndTurnOffAutomatically_TemperatureAboveThreshold_TurnsOffThermostat()
        {
            CurrentTemperature currentTemp = new CurrentTemperature(20.0);
            TargetTemperature TargetTemp1 = new TargetTemperature(22.0);
            CurrentTemperature AutomaticOn = new CurrentTemperature(10.0);
            CurrentTemperature AutomaticOff = new CurrentTemperature(10.0);
            Thermostat thermostat = new Thermostat(currentTemp, TargetTemp1, true, AutomaticOn, AutomaticOff);
            CurrentTemperature currentTemp1 = new CurrentTemperature(30.0);
            thermostat.SetAutomaticTurnOff(currentTemp1);
            thermostat.AutomaticSwicthOff();
            Assert.False(thermostat.IsOn);

        }
    }
}
