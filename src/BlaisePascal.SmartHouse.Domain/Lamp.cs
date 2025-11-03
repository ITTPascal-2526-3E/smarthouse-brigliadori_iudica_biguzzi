using System.Diagnostics.Metrics;

namespace BlaisePascal.SmartHouse.Domain
{
    internal class Lamp
    {
        private bool isOn;// true = on , false = off
        private int lightIntensity;// how much light power the lamp has range 1-100
        private bool isWireless;// true = wireless , false = wired
        private string[] ligthColorsArray = new string[7] { "red", "yellow", "orange", "blue", "green", "purple", "white" };// array of colors the lamp can emit
        private string actualColor = "white";// actual color of the lamp at the beggining is white
        public int consumationValue { get; }// how much energy the lamp consumes in W
        private int lightOnSpecificTime;// at what time the lamp goes on every day
        private int lightOffSpecificTime; // at what time the lamp goes off every day
        

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
        }
        //metod for the light off
        public void turnOff()
        {
            isOn = false;
        }
        // property for lightPower you can set your light power from 0 to 100
        public int lightIntensityProperty
        {
            get { return lightIntensity; }
            set
            {
                // controllo sul range
                if (value > 0 && value < 100)
                {
                    value = lightIntensity;
                }
                else
                {
                    //Console.WriteLine("Light intensity must be between 0 and 100");
                }
            }

        }
        // metod to set the color of the lamp
        public void setColor(string color)
        {
            // ceck if the color is valid
            if (string.IsNullOrEmpty(color))
            {
                //Console.WriteLine("Color can't be empty");
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
                //Console.WriteLine("Color not available or written wrong (red, yellow, orange, blue, green, purple, white)");
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
                CheckAndApplySchedule(DateTime.Now);
            
        }

        public void CheckAndApplySchedule(DateTime currentTime)
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
                shouldBeOn = (h >= lightOnSpecificTime && h < lightOffSpecificTime);
            }
            else
            {
                //if the on time is after the off time(e.g.on= 20 off= 6) -> on if h >= 20 OR h<6
                shouldBeOn = (h >= lightOnSpecificTime || h < lightOffSpecificTime);
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
