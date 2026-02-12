using BlaisePascal.SmartHouse.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;

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
            foreach (Lamp lamp in lamps)
            {
                if (lamp.name.Value == name)
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
            lamps[position] = null;
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
                if (lamp.name.Value == name)
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
                if (lamp.name.Value == name)
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
                lamp.brigthness = new Brigthness(intensity);
            }
        }

        public void SetIntensityForLamp(string name, int intensity)
        {
            foreach (Lamp lamp in lamps)
            {
                if (lamp.name.Value == name)
                {
                    lastMod = DateTime.Now;
                    lamp.brigthness = new Brigthness(intensity);
                    break;
                }
            }
        }

        public Lamp FindLampWithMaxIntensity()
        {
            Hour hour = new Hour(18);
            Hour hour2 = new Hour(23);
            Lamp maxLamp = new Lamp(true, 1, true, 60, hour, hour2);
            foreach (Lamp lamp in lamps)
            {
                if (lamp.brigthness.Value > maxLamp.brigthness.Value)
                {
                    lastMod = DateTime.Now;
                    maxLamp = lamp;
                }
            }
            return maxLamp;
        }

        public Lamp FindLampWithMinIntensity()
        {
            Hour hour = new Hour(18);
            Hour hour2 = new Hour(23);
            Lamp minLamp = new Lamp(true, 99, true, 60, hour, hour2);
            foreach (Lamp lamp in lamps)
            {
                if (lamp.brigthness.Value < minLamp.brigthness.Value)
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
                if (lamp.brigthness.Value >= min && lamp.brigthness.Value <= max)
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
                if (lamp.isOn == false)
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
                        if (lamps[i].brigthness.Value < lamps[j].brigthness.Value)
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
                        if (lamps[i].brigthness.Value > lamps[j].brigthness.Value)
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
