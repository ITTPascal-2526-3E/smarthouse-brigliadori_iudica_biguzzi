using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Heat
{
    public   class Thermostat
    {
        public Guid Id { get; private set; }
        
        public double CurrentTemperature { get; private set; }
        public double TargetTemperature { get;private set; }
        public bool IsOn { get; set; }  
        public double atWhatExternalTemperatureTurnAutomaticalyOn { get; private  set; }

        public Thermostat(double currentTemperature, double targetTemperature, bool isOn, double _atWhatExternalTemperatureTurnAutomaticalyOn)
        {
            if (targetTemperature < 5 || targetTemperature > 30)
            {
                throw new ArgumentOutOfRangeException( "Target temperature must be between 5 and 30 degrees Celsius.");
            }
            else if (currentTemperature < -30 || currentTemperature > 50)
            {
                throw new ArgumentOutOfRangeException( "Current temperature must be between -30 and 50 degrees Celsius.");
            }
            else if (_atWhatExternalTemperatureTurnAutomaticalyOn < -30 || _atWhatExternalTemperatureTurnAutomaticalyOn > 50)
            {
                throw new ArgumentOutOfRangeException( "Automatic turn-on temperature must be between -30 and 50 degrees Celsius.");
            }
            else
            {
                Id = Guid.NewGuid();
                CurrentTemperature = currentTemperature;
                TargetTemperature = targetTemperature;
                IsOn = isOn;
                atWhatExternalTemperatureTurnAutomaticalyOn = _atWhatExternalTemperatureTurnAutomaticalyOn;
            }
        }

        public void AdjustTemperature(double newTargetTemperature)
        {
            TargetTemperature = newTargetTemperature;
        }

        public void UpdateCurrentTemperature(double newCurrentTemperature)
        {
            if (newCurrentTemperature < -30 || newCurrentTemperature > 50)
            {
                throw new ArgumentOutOfRangeException( "New current temperature cannot be lower than the existing current temperature.");
            }
            CurrentTemperature = newCurrentTemperature;
        }   

        public void TurnOn()
        {
            IsOn = true;
            CurrentTemperature = TargetTemperature;
        }  
        
        public void TurnOff()
        {
            IsOn = false;

        }

        public void SetAutomaticTurnOn(double externalTemperature)
        {
            if (externalTemperature < -30 || externalTemperature > 50)
            {
                throw new ArgumentOutOfRangeException( "Automatic turn-on temperature must be between -30 and 50 degrees Celsius.");
            }
            atWhatExternalTemperatureTurnAutomaticalyOn = externalTemperature;
        }
        public void CheckAndTurnOnAutomatically(double externalTemperature)
        {
            if (externalTemperature <= atWhatExternalTemperatureTurnAutomaticalyOn)
            {
                TurnOn();
            }
        }


    }
}
