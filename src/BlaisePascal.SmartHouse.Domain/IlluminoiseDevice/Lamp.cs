using BlaisePascal.SmartHouse.Domain.Interfaces;
using System.Diagnostics.Metrics;

namespace BlaisePascal.SmartHouse.Domain.IlluminoiseDevice
{
    public class Lamp : Device , ISwitchable
    {
        public bool isOn { get; protected set; }// true = on , false = off
        protected int lightIntensity;// how much light power the lamp has range 1-100
        public string name { get; private set; }// name of the ecolamp
        public bool isWireless { get; }// true = wireless , false = wired
        public string[] ligthColorsArray = new string[7] { "red", "yellow", "orange", "blue", "green", "purple", "white" };// array of colors the lamp can emit
        public string actualColor = "white";// actual color of the lamp at the beggining is white
        public int consumationValue { get; }// how much energy the lamp consumes in W
        public int lightOnSpecificTime { get; private set; }// at what time the lamp goes on every day
        public int lightOffSpecificTime { get; private set; } // at what time the lamp goes off every day
        public DateTime? startTime;

        // costructor for lamp
        public Lamp(bool ison, int ligthpower, bool iswireless, int consumationvalue, int lightonspecifictime, int lightoffspecifictime)
        {
            if (consumationvalue < 100 && consumationvalue > 0)
            {
                consumationValue = consumationvalue;
            }

            if (ligthpower > 0 && ligthpower < 100)
            {
                lightIntensity = ligthpower;
            }

            isOn = ison;

            isWireless = iswireless;
            if (lightonspecifictime > 0 && lightoffspecifictime > 0 && lightoffspecifictime <= 23 && lightonspecifictime <= 23)
            {
                lightOnSpecificTime = lightonspecifictime;
                lightOffSpecificTime = lightoffspecifictime;
            }


        }
        public void SetName(string lampname)
        {
            if (string.IsNullOrEmpty(lampname))
            {
                throw new ArgumentNullException("lampname");
            }
            lastMod = DateTime.Now;
            name = lampname;
        }
        public void SetLightOnSpecificTime(int hour)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException("hour", "Hour must be between 0 and 23.");
            }
            lastMod = DateTime.Now;
            lightOnSpecificTime = hour;
        }
        public void SetLightOffSpecificTime(int hour)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException("hour", "Hour must be between 0 and 23.");
            }
            lastMod = DateTime.Now;
            lightOffSpecificTime = hour;
        }


        //metod for the light on
        public virtual void TurnOn()
        {
            lastMod = DateTime.Now;
            
            isOn = true;
            lightIntensity = 100;
        }
        //metod for the light off
        public virtual void TurnOff()
        {
            lastMod = DateTime.Now;
            isOn = false;
            lightIntensity = 0;
        }
        // property for lightPower you can set your light power from 0 to 100
        public int lightIntensityPropriety
        {
            get { return lightIntensity; }
            set { lightIntensity = value; }
        }
        // metod to set the color of the lamp
        public virtual void setColor(string color)
        {
            // ceck if the color is valid
            if (string.IsNullOrEmpty(color))
            {
                throw new ArgumentNullException("color");
            }
            foreach (string c in ligthColorsArray)
            {
                if (c == color)
                {
                    lastMod = DateTime.Now;
                    actualColor = color;// if the color is in the array set the actual color

                }
            }
            if (actualColor != color)
            {
                throw new InvalidOperationException(" the color doesn't exist in the list");
            }
        }
        public virtual string getColor()
        {
            return actualColor;
        }
        // metod to set the schedule of the lamp
        public virtual void ApllyScheduleNow()
        {
            //apply the schedule hours immediately
            AutomaticLightOn(DateTime.Now);
            

        }

        protected virtual void AutomaticLightOn(DateTime currentTime)
        {
            
            int h = currentTime.Hour;

            bool shouldBeOn;
            if (lightOnSpecificTime == lightOffSpecificTime)
            {
                lastMod = DateTime.Now;
                //choosen same hour for always off
                shouldBeOn = false;
            }
            else if (lightOnSpecificTime < lightOffSpecificTime)
            {
                lastMod = DateTime.Now;
                // if the on time is before the off time (e.g. on=6 off=20) -> on if h >=6 AND h <20
                shouldBeOn = h >= lightOnSpecificTime && h < lightOffSpecificTime;
            }
            else
            {
                lastMod = DateTime.Now;
                //if the on time is after the off time(e.g.on= 20 off= 6) -> on if h >= 20 OR h<6
                shouldBeOn = h >= lightOnSpecificTime || h < lightOffSpecificTime;
            }

            if (shouldBeOn == true)
            {
                TurnOn();
            }
            else
                TurnOff();
        }


    }
}