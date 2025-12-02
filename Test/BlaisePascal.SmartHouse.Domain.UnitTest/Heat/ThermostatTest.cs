using BlaisePascal.SmartHouse.Domain.Heat;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.Heat
{
    public class ThermostatTest
    {
        [Fact]
        public void Thermostat_constructorValidParameters_AssertEquals()
        {
            Thermostat thermostat = new Thermostat(20.0, 22.0, false, 10.0);
            Assert.Equal(20.0, thermostat.CurrentTemperature);
            Assert.Equal(22.0, thermostat.TargetTemperature);
            Assert.False(thermostat.IsOn);
            Assert.Equal(10.0, thermostat.atWhatExternalTemperatureTurnAutomaticalyOn);
        }
        [Fact]
        public void Thermostat_constructorInvalidTargetTemperature_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Thermostat(20.0, 35.0, false, 10.0));
        }
        [Fact]
        public void Thermostat_constructorInvalidCurrentTemperature_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Thermostat(55.0, 22.0, false, 10.0));
        }
        [Fact]
        public void Thermostat_constructorInvalidAutomaticTurnOnTemperature_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Thermostat(20.0, 22.0, false, 60.0));
        }
        [Fact]
        public void Thermostat_TurnOn_SetsIsOnToTrue()
        {
            Thermostat thermostat = new Thermostat(20.0, 22.0, false, 10.0);
            thermostat.TurnOn();
            Assert.True(thermostat.IsOn);
        }
        [Fact]
        public void Thermostat_AdjustTemperature_UpdatesTargetTemperature()
        {
            Thermostat thermostat = new Thermostat(20.0, 22.0, false, 10.0);
            thermostat.AdjustTemperature(25.0);
            Assert.Equal(25.0, thermostat.TargetTemperature);
        }
        [Fact]
        public void Thermostat_UpdateCurrentTemperature_UpdatesCurrentTemperature()
        {
            Thermostat thermostat = new Thermostat(20.0, 22.0, false, 10.0);
            thermostat.UpdateCurrentTemperature(23.0);
            Assert.Equal(23.0, thermostat.CurrentTemperature);
        }
        [Fact]
        public void Thermostat_TurnOff_SetsIsOnToFalse()
        {
            Thermostat thermostat = new Thermostat(20.0, 22.0, true, 10.0);
            thermostat.TurnOff();
            Assert.False(thermostat.IsOn);
        }
        [Fact]
        public void Thermostat_setAutomaticTurnOn_UpdatesAutomaticTurnOnTemperature()
        {
            Thermostat thermostat = new Thermostat(20.0, 22.0, false, 10.0);
            thermostat.SetAutomaticTurnOn(5.0);
            Assert.Equal(5.0, thermostat.atWhatExternalTemperatureTurnAutomaticalyOn);
        }

        [Fact]
        public void Thermostat_UpdateCurrentTemperature_OutOfRange_ThrowsArgumentOutOfRangeException()
        {
            Thermostat thermostat = new Thermostat(20.0, 22.0, false, 10.0);
            Assert.Throws<ArgumentOutOfRangeException>(() => thermostat.UpdateCurrentTemperature(55.0));
        }

        [Fact]
        public void CheckAndTurnOnAutomatically_TemperatureBelowThreshold_TurnsOnThermostat()
        {
            Thermostat thermostat = new Thermostat(20.0, 22.0, false, 10.0);
            thermostat.SetAutomaticTurnOn(10.0);
            thermostat.CheckAndTurnOnAutomatically(5.0);
            Assert.True(thermostat.IsOn);
        }

    }
}
