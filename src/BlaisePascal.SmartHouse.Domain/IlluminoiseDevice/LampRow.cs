using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.IlluminoiseDevice
{
    public sealed class LampRow : Device 
    {
        public List<Lamp> lamps;

        public LampRow()
        {
            lamps = new List<Lamp>();
        }

        public void AddLamp(Lamp lamp)
        {
            lastMod = DateTime.Now;
            lamps.Add(lamp);
        }
        public void AddLampAtPosition(Lamp lamp, int position)
        {
            lastMod = DateTime.Now;
            if (position >= 0)
            {
                lamps[position] = lamp;
            }
            else
            {
                throw new ArgumentException("Position must be non-negative");

            }
        } 
        public void RemoveLamp(string name)
        {
            foreach (Lamp lamp in lamps) {
                if (lamp.name == name)
                {
                    lastMod = DateTime.Now;
                    lamps.Remove(lamp);
                    break;
                }
            }
        }
        public void ReamoveLampAtPosition(int position)
        {
            lastMod = DateTime.Now;
            lamps[position]=null;
        }

        public void SwitchOnAllLamp()
        {
            lastMod = DateTime.Now;
            foreach (var lamp in lamps)
            {
                lamp.TurnOn();
            }
        }

        public void SwitchOn(string name)
        {
            foreach (Lamp lamp in lamps)
            {
                if (lamp.name == name)
                {
                    lastMod = DateTime.Now;
                    lamp.TurnOn();
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
                    lastMod = DateTime.Now;
                    lamp.TurnOff();
                    break;
                }
            }
        }

        public void SwitchOffAllLamp()
        {
            lastMod = DateTime.Now;
            foreach (var lamp in lamps)
            {
                lamp.TurnOff();
            }
        }

        public void SetIntensityForAllLamp(int intensity)
        {
            lastMod = DateTime.Now;
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
                    lastMod = DateTime.Now;
                    lamp.lightIntensityPropriety = intensity;
                    break;
                }
            }
        }

        public Lamp FindLampWithMaxIntensity()
        {
            Lamp maxLamp = new Lamp(true, 1, true, 60, 18, 23);
            foreach (Lamp lamp in lamps)
            {
                if (lamp.lightIntensityPropriety > maxLamp.lightIntensityPropriety)
                {
                    lastMod = DateTime.Now;
                    maxLamp = lamp;
                }
            }
            return maxLamp;
        }

        public Lamp FindLampWithMinIntensity()
        {
            Lamp minLamp = new Lamp(true, 99, true, 60, 18, 23);
            foreach (Lamp lamp in lamps)
            {
                if (lamp.lightIntensityPropriety < minLamp.lightIntensityPropriety)
                {
                    lastMod = DateTime.Now; 
                    minLamp = lamp;
                }
            }
            return minLamp;
        }

        public List<Lamp> FindLampsByIntensityRange(int min, int max)
        {
            List<Lamp> lampsInRange = new List<Lamp>();
            foreach (Lamp lamp in lamps)
            {
                if (lamp.lightIntensityPropriety >= min && lamp.lightIntensityPropriety <= max)
                {
                    lastMod = DateTime.Now;
                    lampsInRange.Add(lamp);
                    return lampsInRange;
                }
             
                
            }
            return null;
        }

        public List<Lamp> FindAllOn()
        {
            List<Lamp> onLamps = new List<Lamp>();
            foreach (Lamp lamp in lamps)
            {
                if (lamp.isOn)
                {
                    lastMod = DateTime.Now;
                    onLamps.Add(lamp);
                }
            }
            return onLamps;
        }
        public List<Lamp> FindAllOff()
        {
            List<Lamp> offLamps = new List<Lamp>();
            foreach (Lamp lamp in lamps)
            {
                if (lamp.isOn==false)
                {
                    lastMod = DateTime.Now;
                    offLamps.Add(lamp);
                }
            }
            return offLamps;
        }
        /*public Lamp FindLampById(Guid id)
        {
            foreach (Lamp lamp in lamps)
            {
                if (lamp.Id == id)
                {
                    return lamp;
                }
            }
            return null;
        }*/

        public List<Lamp> SortByIntensity(bool descending)
        {
            if (descending == true)
            {
                for (int i = 0; i < lamps.Count - 1; i++)
                {
                    for (int j = i + 1; j < lamps.Count; j++)
                    {
                        if (lamps[i].lightIntensityPropriety < lamps[j].lightIntensityPropriety)
                        {
                            lastMod = DateTime.Now;
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
                            lastMod = DateTime.Now;
                            var temp = lamps[i];
                            lamps[i] = lamps[j];
                            lamps[j] = temp;
                        }
                    }
                }
            }
            return lamps;
        }


    }
}
