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
            if (lightonspecifictime > 1 && lightoffspecifictime > 1 && lightoffspecifictime <= 24 && lightonspecifictime <= 24)
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
            // controllo sulla string vuota
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

        public void SetSchedule(int onHour, int offHour)
        {
            if (onHour < 0 || onHour > 23 || offHour < 0 || offHour > 23)
            {


                lightOnSpecificTime = onHour;
                lightOffSpecificTime = offHour;
                // Applica subito lo stato in base all'ora corrente
                CheckAndApplySchedule(DateTime.Now);
            }
        }

        public void CheckAndApplySchedule(DateTime currentTime)
        {
            if (lightOnSpecificTime < 0 || lightOffSpecificTime < 0)
                return; // schedule non impostata

            int h = currentTime.Hour;

            bool shouldBeOn;
            if (lightOnSpecificTime == lightOffSpecificTime)
            {
                // comportamento scelto: se uguali -> sempre spento
                shouldBeOn = false;
            }
            else if (lightOnSpecificTime < lightOffSpecificTime)
            {
                // es. on=8 off=22 -> acceso se h in [8,21]
                shouldBeOn = (h >= lightOnSpecificTime && h < lightOffSpecificTime);
            }
            else
            {
                // es. on=20 off=6 -> acceso se h >=20 OR h <6 (attraversa mezzanotte)
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
