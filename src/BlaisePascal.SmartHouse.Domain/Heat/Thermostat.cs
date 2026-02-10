using BlaisePascal.SmartHouse.Domain.Abstraction;
using BlaisePascal.SmartHouse.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
namespace BlaisePascal.SmartHouse.Domain.Heat
{
    public sealed class Thermostat : Device, ISwitchable, IAutomaticSwicth
    {
        public double CurrentTemperature { get; private set; }
        public double TargetTemperature { get; private set; }
        public bool IsOn { get; set; }
        public double atWhatExternalTemperatureTurnAutomaticalyOn { get; protected set; }
        public double atWhatExternalTemperatureTurnAutomaticalyOff { get; protected set; }
        public double externalTemperature { get; set; }



        public Thermostat(double currentTemperature, double targetTemperature, bool isOn, double _atWhatExternalTemperatureTurnAutomaticalyOn, double _atWhatExternalTemperatureTurnAutomaticalyOff)
        {
            if (targetTemperature < 5 || targetTemperature > 30)
            {
                throw new ArgumentOutOfRangeException("Target temperature must be between 5 and 30 degrees Celsius.");
            }
            else if (currentTemperature < -30 || currentTemperature > 50)
            {
                throw new ArgumentOutOfRangeException("Current temperature must be between -30 and 50 degrees Celsius.");
            }
            else if (_atWhatExternalTemperatureTurnAutomaticalyOn < -30 || _atWhatExternalTemperatureTurnAutomaticalyOn > 50)
            {
                throw new ArgumentOutOfRangeException("Automatic turn-on temperature must be between -30 and 50 degrees Celsius.");
            }
            else if (_atWhatExternalTemperatureTurnAutomaticalyOff > -30 || _atWhatExternalTemperatureTurnAutomaticalyOff < 50)
            {
                throw new ArgumentOutOfRangeException("Automatic turn-off temperature must be between -30 and 50 degrees Celsius.");

            }
            else
            {

                CurrentTemperature = currentTemperature;
                TargetTemperature = targetTemperature;
                IsOn = isOn;
                atWhatExternalTemperatureTurnAutomaticalyOn = _atWhatExternalTemperatureTurnAutomaticalyOn;
                atWhatExternalTemperatureTurnAutomaticalyOff = _atWhatExternalTemperatureTurnAutomaticalyOff;
            }
        }
        public void SetName(string thermostatname)
        {
            if (string.IsNullOrEmpty(thermostatname))
            {
                throw new ArgumentNullException("thermostatname");
            }
            lastMod = DateTime.Now;
            name = new Name(thermostatname);
        }
        public void SetTargetTemperature(double newTargetTemperature)
        {
            if (newTargetTemperature < 5 || newTargetTemperature > 30)
            {
                throw new ArgumentOutOfRangeException("Target temperature must be between 5 and 30 degrees Celsius.");
            }
            lastMod = DateTime.Now;
            TargetTemperature = newTargetTemperature;
        }
        public void SetCurrentTemperature(double newCurrentTemperature)
        {
            if (newCurrentTemperature < -30 || newCurrentTemperature > 50)
            {
                throw new ArgumentOutOfRangeException("Current temperature must be between -30 and 50 degrees Celsius.");
            }
            lastMod = DateTime.Now;
            CurrentTemperature = newCurrentTemperature;
        }

        public void AdjustTemperature(double newTargetTemperature)
        {
            lastMod = DateTime.Now;
            TargetTemperature = newTargetTemperature;
        }

        public void UpdateCurrentTemperature(double newCurrentTemperature)
        {
            lastMod = DateTime.Now;
            if (newCurrentTemperature < -30 || newCurrentTemperature > 50)
            {
                throw new ArgumentOutOfRangeException("New current temperature cannot be lower than the existing current temperature.");
            }
            CurrentTemperature = newCurrentTemperature;
        }

        public void TurnOn()
        {
            lastMod = DateTime.Now;
            IsOn = true;
            CurrentTemperature = TargetTemperature;
        }

        public void TurnOff()
        {
            lastMod = DateTime.Now;
            IsOn = false;

        }

        public void SetAutomaticTurnOn(double externalTemperature)
        {
            if (externalTemperature < -30 || externalTemperature > 50)
            {
                throw new ArgumentOutOfRangeException("Automatic turn-on temperature must be between -30 and 50 degrees Celsius.");
            }
            lastMod = DateTime.Now;
            atWhatExternalTemperatureTurnAutomaticalyOn = externalTemperature;
        }
        public void SetAutomaticTurnOff(double externalTemperature)
        {
            if (externalTemperature > -30 || externalTemperature < 50)
            {
                throw new ArgumentOutOfRangeException("Automatic turn-off temperature must be between -30 and 50 degrees Celsius.");
            }
            lastMod = DateTime.Now;
            atWhatExternalTemperatureTurnAutomaticalyOff = externalTemperature;
        }
        public double SetexternalTemperature(double temp)
        {
            externalTemperature = temp;
            return externalTemperature;
        }

        public void AutomaticSwicthOn()
        {
            if (externalTemperature <= atWhatExternalTemperatureTurnAutomaticalyOn)
            {
                lastMod = DateTime.Now;
                TurnOn();
            }
        }
        public void AutomaticSwicthOff()
        {
            if (externalTemperature >= atWhatExternalTemperatureTurnAutomaticalyOff)
            {
                lastMod = DateTime.Now;
                TurnOff();
            }
        }

    }
}
