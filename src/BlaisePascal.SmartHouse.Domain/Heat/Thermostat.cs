using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Heat
{
    internal class Thermostat
    {
        public Guid Id { get; private set; }
        
        public double CurrentTemperature { get; private set; }
        public double TargetTemperature { get;private set; }
        public bool IsOn { get; set; }  
        public double atWhatExternalTemperatureTurnAutomaticalyOn { get; private  set; }

        public Thermostat(double currentTemperature, double targetTemperature, bool isOn, double atWhatExternalTemperatureTurnAutomaticalyOn)
        {
            Id = Guid.NewGuid();
            CurrentTemperature = currentTemperature;
            TargetTemperature = targetTemperature;
            IsOn = isOn;
            atWhatExternalTemperatureTurnAutomaticalyOn = atWhatExternalTemperatureTurnAutomaticalyOn;
        }

        public void AdjustTemperature(double newTargetTemperature)
        {
            TargetTemperature = newTargetTemperature;
        }

        public void UpdateCurrentTemperature(double newCurrentTemperature)
        {
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
