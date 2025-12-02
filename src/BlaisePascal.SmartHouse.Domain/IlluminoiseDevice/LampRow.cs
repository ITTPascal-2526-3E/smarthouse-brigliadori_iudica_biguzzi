using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.IlluminoiseDevice
{
    public class LampRow 
    {
        private List<Lamp> lamps;

        public LampRow()
        {
            lamps = new List<Lamp>();
        }

        public void AddLamp(Lamp lamp)
        {
            lamps.Add(lamp);
        }
        public void AddLampInPosition(Lamp lamp, int position)
        {
            lamps[position]=lamp;
        }
        public void RemoveLamp(string name)
        {
            foreach (Lamp lamp in lamps) {
                if (lamp.name == name)
                {
                    lamps.Remove(lamp);
                    break;
                }
            }
        }
        public void ReamoveLampAtPosition(int position)
        {
            lamps[position]=null;
        }

        public void SwitchOnAllLamp()
        {
            foreach (var lamp in lamps)
            {
                lamp.turnOn();
            }
        }

        public void SwitchOn(string name)
        {
            foreach (Lamp lamp in lamps)
            {
                if (lamp.name == name)
                {
                    lamp.turnOn();
                    break;
                }
            }
        }

        public void SwitchOff(string name)
        {
            foreach (Lamp lamp in lamps)
            {
                if (lamp.name == name)
                {
                    lamp.turnOff();
                    break;
                }
            }
        }

        public void SwitchOffAllLamp()
        {
            foreach (var lamp in lamps)
            {
                lamp.turnOff();
            }
        }

        public void SetIntensityForAllLamp(int intensity)
        {
            foreach (var lamp in lamps)
            {
                lamp.lightIntensityPropriety = intensity;
            }
        }

        public void SetIntensityForLamp(string name, int intensity)
        {
            foreach (Lamp lamp in lamps)
            {
                if (lamp.name == name)
                {
                    lamp.lightIntensityPropriety = intensity;
                    break;
                }
            }
        }

        public Lamp FindLampWithMaxIntensity()
        {
            Lamp maxLamp = lamps[0];
            foreach (Lamp lamp in lamps)
            {
                if (lamp.lightIntensityPropriety > maxLamp.lightIntensityPropriety)
                {
                    maxLamp = lamp;
                }
            }
            return maxLamp;
        }

        public Lamp FindLampWithMinIntensity()
        {
            Lamp minLamp = lamps[0];
            foreach (Lamp lamp in lamps)
            {
                if (lamp.lightIntensityPropriety < minLamp.lightIntensityPropriety)
                {
                    minLamp = lamp;
                }
            }
            return minLamp;
        }

        public Lamp FindLampsByIntensityRange(int min, int max)
        {
            foreach (Lamp lamp in lamps)
            {
                if (lamp.lightIntensityPropriety >= min && lamp.lightIntensityPropriety <= max)
                {
                    return lamp;
                }
                else
                {
                    return null;
                }
                
            }
            return null;
        }

        public Lamp FindAllOn()
        {
            foreach (Lamp lamp in lamps)
            {
                if (lamp.isOn)
                {
                    return lamp;
                }
            }
            return null;
        }
        public Lamp FindAllOff()
        {
            foreach (Lamp lamp in lamps)
            {
                if (lamp.isOn==false)
                {
                    return lamp;
                }
            }
            return null;
        }
        public Lamp FindLampById(Guid id)
        {
            foreach (Lamp lamp in lamps)
            {
                if (lamp.Id == id)
                {
                    return lamp;
                }
            }
            return null;
        }

        public void SortByIntensity(bool descending)
        {
            if (descending == true)
            {
                for (int i = 0; i < lamps.Count - 1; i++)
                {
                    for (int j = i + 1; j < lamps.Count; j++)
                    {
                        if (lamps[i].lightIntensityPropriety < lamps[j].lightIntensityPropriety)
                        {
                            var temp = lamps[i];
                            lamps[i] = lamps[j];
                            lamps[j] = temp;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < lamps.Count - 1; i++)
                {
                    for (int j = i + 1; j < lamps.Count; j++)
                    {
                        if (lamps[i].lightIntensityPropriety > lamps[j].lightIntensityPropriety)
                        {
                            var temp = lamps[i];
                            lamps[i] = lamps[j];
                            lamps[j] = temp;
                        }
                    }
                }
            }
        }


    }
}
