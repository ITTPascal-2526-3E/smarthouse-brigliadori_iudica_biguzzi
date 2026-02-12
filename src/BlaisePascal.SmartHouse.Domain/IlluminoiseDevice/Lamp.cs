using BlaisePascal.SmartHouse.Domain.Abstraction;
using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;
using BlaisePascal.SmartHouse.Domain.Interfaces;
using System.Diagnostics.Metrics;


namespace BlaisePascal.SmartHouse.Domain.IlluminoiseDevice
{
    public class Lamp : Device, ISwitchable, IAutomaticSwicth
    {
        public bool isOn { get; protected set; }// true = on , false = off
        public Brigthness brigthness;// how much light power the lamp has range 1-100

        public bool isWireless { get; }// true = wireless , false = wired
        public Color actualColor = Color.WHITE;// actual color of the lamp at the beggining is white
        public int consumationValue { get; }// how much energy the lamp consumes in W
        public Hour lightOnSpecificTime { get; private set; }// at what time the lamp goes on every day
        public Hour lightOffSpecificTime { get; private set; } // at what time the lamp goes off every day
        public DateTime? startTime;

        // costructor for lamp
        public Lamp(bool ison, int ligthpower, bool iswireless, int consumationvalue, Hour _lightonspecifictime, Hour _lightoffspecifictime)
        {
            if (consumationvalue < 100 && consumationvalue > 0)
            {
                consumationValue = consumationvalue;
            }

            brigthness = new Brigthness(ligthpower);

            isOn = ison;

            isWireless = iswireless;
            lightOffSpecificTime = _lightoffspecifictime;
            lightOnSpecificTime = _lightonspecifictime;


        }
        public void setBrightness(Brigthness _brightness) 
        {
            lastMod = DateTime.Now;
            brigthness = _brightness;
        }

        public Brigthness getBrightness() 
        {
           return brigthness;
        }
        public string getName()
        {
            return name.Value;
        }

        public void SetName(Name lampname)
        {
            
            lastMod = DateTime.Now;
            name = lampname;
        }
        public void SetLightOnSpecificTime(Hour hour)
        {
           
            lastMod = DateTime.Now;
            lightOnSpecificTime = hour;
        }
        public void SetLightOffSpecificTime(Hour hour)
        {
            
            lastMod = DateTime.Now;
            lightOffSpecificTime = hour;
        }


        //metod for the light on
        public virtual void TurnOn()
        {
            lastMod = DateTime.Now;

            isOn = true;
            brigthness = new Brigthness(100);
        }
        //metod for the light off
        public virtual void TurnOff()
        {
            lastMod = DateTime.Now;
            isOn = false;
            brigthness = new Brigthness(0);
        }


        // metod to set the color of the lamp
        public virtual void setColor(Color color)
        {
            if (color != actualColor) 
            {
                actualColor = color;

            }
            
        }
        public virtual Color getColor()
        {
            return actualColor;
        }
        // metod to set the schedule of the lamp
        public virtual void ApllyScheduleNow()
        {
            //apply the schedule hours immediately
            AutomaticSwicthOn();


        }

        public virtual void AutomaticSwicthOn()
        {
            DateTime currentTime = DateTime.Now;
            int h = currentTime.Hour;

            bool shouldBeOn;
            if (lightOnSpecificTime == lightOffSpecificTime)
            {
                lastMod = DateTime.Now;
                //choosen same hour for always off
                shouldBeOn = false;
            }
            else if (lightOnSpecificTime.Value < lightOffSpecificTime.Value)
            {
                lastMod = DateTime.Now;
                // if the on time is before the off time (e.g. on=6 off=20) -> on if h >=6 AND h <20
                shouldBeOn = h >= lightOnSpecificTime.Value && h < lightOffSpecificTime.Value;
            }
            else
            {
                lastMod = DateTime.Now;
                //if the on time is after the off time(e.g.on= 20 off= 6) -> on if h >= 20 OR h<6
                shouldBeOn = h >= lightOnSpecificTime.Value  || h < lightOffSpecificTime.Value;
            }

            if (shouldBeOn == true)
            {
                TurnOn();
            }
            else
                TurnOff();
        }

        public virtual void AutomaticSwicthOff()
        {
            DateTime currentTime = DateTime.Now;
            int h = currentTime.Hour;

            bool shouldBeOff;
            if (lightOnSpecificTime == lightOffSpecificTime)
            {
                lastMod = DateTime.Now;
                //choosen same hour for always off
                shouldBeOff = false;
            }
            else if (lightOnSpecificTime.Value < lightOffSpecificTime.Value)
            {
                lastMod = DateTime.Now;
                // if the on time is before the off time (e.g. on=6 off=20) -> on if h >=6 AND h <20
                shouldBeOff = h >= lightOnSpecificTime.Value && h < lightOffSpecificTime.Value;
            }
            else
            {
                lastMod = DateTime.Now;
                //if the on time is after the off time(e.g.on= 20 off= 6) -> on if h >= 20 OR h<6
                shouldBeOff = h >= lightOnSpecificTime.Value || h < lightOffSpecificTime.Value;
            }

            if (shouldBeOff == true)
            {
                TurnOff();
            }
            else
                TurnOn();
        }


    }
}