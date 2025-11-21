using System.Diagnostics.Metrics;

namespace BlaisePascal.SmartHouse.Domain.IlluminoiseDevice
{
     public class Lamp
     {
        public bool isOn { get; private set; }// true = on , false = off
        private int lightIntensity;// how much light power the lamp has range 1-100
        public string name { get; set; }// name of the ecolamp
        public bool isWireless { get; }// true = wireless , false = wired
        private string[] ligthColorsArray = new string[7] { "red", "yellow", "orange", "blue", "green", "purple", "white" };// array of colors the lamp can emit
        private string actualColor = "white";// actual color of the lamp at the beggining is white
        public int consumationValue { get;}// how much energy the lamp consumes in W
        public int lightOnSpecificTime { get; private set; }// at what time the lamp goes on every day
        public int lightOffSpecificTime { get; private set; } // at what time the lamp goes off every day
        public Guid Id { get; }= Guid.NewGuid();

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


        //metod for the light on
        public void turnOn()
        {
            isOn = true;
            lightIntensity = 100;
        }
        //metod for the light off
        public void turnOff()
        {
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
        public void setColor(string color)
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
                    actualColor = color;// if the color is in the array set the actual color

                }
            }
            if (actualColor != color)
            {
                throw new InvalidOperationException(" the color doesn't exist in the list");
            }
        }
        public string getColor()
        {
            return actualColor;
        }
        // metod to set the schedule of the lamp
        public void ApllyScheduleNow()
        {
                //apply the schedule hours immediately
                AutomaticLightOn(DateTime.Now);
            
        }

        private void AutomaticLightOn(DateTime currentTime)
        {
            int h = currentTime.Hour;

            bool shouldBeOn;
            if (lightOnSpecificTime == lightOffSpecificTime)
            {
                //choosen same hour for always off
                shouldBeOn = false;
            }
            else if (lightOnSpecificTime < lightOffSpecificTime)
            {
                // if the on time is before the off time (e.g. on=6 off=20) -> on if h >=6 AND h <20
                shouldBeOn = h >= lightOnSpecificTime && h < lightOffSpecificTime;
            }
            else
            {
                //if the on time is after the off time(e.g.on= 20 off= 6) -> on if h >= 20 OR h<6
                shouldBeOn = h >= lightOnSpecificTime || h < lightOffSpecificTime;
            }

            if (shouldBeOn == true)
            {
                turnOn();
            }
            else
                turnOff();
        }


    }
}
