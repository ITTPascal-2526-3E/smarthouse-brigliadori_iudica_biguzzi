using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Heat
{
    public   class Thermostat : Device
    {
        
        
        public double CurrentTemperature { get; protected set; }
        public double TargetTemperature { get;protected set; }
        public bool IsOn { get; set; }  
        public double atWhatExternalTemperatureTurnAutomaticalyOn { get; protected  set; }

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
                
                CurrentTemperature = currentTemperature;
                TargetTemperature = targetTemperature;
                IsOn = isOn;
                atWhatExternalTemperatureTurnAutomaticalyOn = _atWhatExternalTemperatureTurnAutomaticalyOn;
            }
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
                throw new ArgumentOutOfRangeException( "New current temperature cannot be lower than the existing current temperature.");
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
                throw new ArgumentOutOfRangeException( "Automatic turn-on temperature must be between -30 and 50 degrees Celsius.");
            }
            lastMod = DateTime.Now;
            atWhatExternalTemperatureTurnAutomaticalyOn = externalTemperature;
        }
        public void CheckAndTurnOnAutomatically(double externalTemperature)
        {
            if (externalTemperature <= atWhatExternalTemperatureTurnAutomaticalyOn)
            {
                lastMod = DateTime.Now;
                TurnOn();
            }
        }


    }
}
