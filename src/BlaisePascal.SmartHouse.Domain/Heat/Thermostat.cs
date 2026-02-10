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
        public  CurrentTemperature CurrentTemperature { get; private set; }
        public TargetTemperature TargetTemperature { get; private set; }
        public bool IsOn { get; set; }
        public CurrentTemperature atWhatExternalTemperatureTurnAutomaticalyOn { get; protected set; }
        public CurrentTemperature atWhatExternalTemperatureTurnAutomaticalyOff { get; protected set; }
        public CurrentTemperature externalTemperature { get; set; }



        public Thermostat(CurrentTemperature currentTemperature, TargetTemperature targetTemperature, bool isOn, CurrentTemperature _atWhatExternalTemperatureTurnAutomaticalyOn, CurrentTemperature _atWhatExternalTemperatureTurnAutomaticalyOff)
        {
            
            

                CurrentTemperature = currentTemperature;
                TargetTemperature = targetTemperature;
                IsOn = isOn;
                atWhatExternalTemperatureTurnAutomaticalyOn = _atWhatExternalTemperatureTurnAutomaticalyOn;
                atWhatExternalTemperatureTurnAutomaticalyOff = _atWhatExternalTemperatureTurnAutomaticalyOff;
        }
        
        public void SetName(Name thermostatname)
        {
            
            lastMod = DateTime.Now;
            name = thermostatname;
        }
        public void SetTargetTemperature(TargetTemperature newTargetTemperature)
        {
            
            lastMod = DateTime.Now;
            TargetTemperature = newTargetTemperature;
        }
        public void SetCurrentTemperature(CurrentTemperature newCurrentTemperature)
        {
            
            lastMod = DateTime.Now;
            CurrentTemperature = newCurrentTemperature;
        }

        public void AdjustTemperature(TargetTemperature newTargetTemperature)
        {
            lastMod = DateTime.Now;
            TargetTemperature = newTargetTemperature;
        }

        public void UpdateCurrentTemperature(CurrentTemperature newCurrentTemperature)
        {
            lastMod = DateTime.Now;
            
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

        public void SetAutomaticTurnOn(CurrentTemperature externalTemperature)
        {
            
            lastMod = DateTime.Now;
            atWhatExternalTemperatureTurnAutomaticalyOn = externalTemperature;
        }
        public void SetAutomaticTurnOff(CurrentTemperature externalTemperature)
        {
           
            lastMod = DateTime.Now;
            atWhatExternalTemperatureTurnAutomaticalyOff = externalTemperature;
        }
        public CurrentTemperature SetexternalTemperature(CurrentTemperature temp)
        {
            externalTemperature = temp;
            return externalTemperature;
        }

        public void AutomaticSwicthOn()
        {

            if (externalTemperature. <= atWhatExternalTemperatureTurnAutomaticalyOn)
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
