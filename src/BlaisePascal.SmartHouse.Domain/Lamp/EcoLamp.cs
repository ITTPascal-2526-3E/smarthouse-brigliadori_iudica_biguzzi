using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Lamp
{
    public class EcoLamp
    {

        public bool isOn { get; private set; }// true = on , false = off
        private int lightIntensity;// how much light power the lamp has range 1-20
        public string name { get; set; }// name of the lamp
        public bool isWireless { get; }// true = wireless , false = wired
        private string[] ligthColorsArray = new string[7] { "red", "yellow", "orange", "blue", "green", "purple", "white" };// array of colors the lamp can emit
        private string actualColor = "white";// actual color of the lamp at the beggining is white
        public int consumationValue { get; }     // how much energy the lamp consumes in W
        public int maxTimeOn { get; private set; } // max time the lamp can stay on in hours
        public DateTime? startTime;
        public Guid Id { get; }

        // costructor for lamp
        public EcoLamp(bool ison, int ligthpower, bool iswireless, int consumationvalue, int maxtimeon)
        {
            if (consumationvalue < 20)
            {
                consumationValue = consumationvalue; // limit the consumption value to 20W for EcoLamp
            }
            if (ligthpower > 0 && ligthpower < 20)
            {
                lightIntensity = ligthpower;
            }
            isOn = ison;
            isWireless = iswireless;
            if (maxtimeon >= 0 && maxtimeon <= 3)
            {
                maxTimeOn = maxtimeon;
            }

            
        }
        //metod for the light on
        public void turnOn()
        {
            SaveAccensionTime();
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
        public int lightIntensityProperty
        {
            get { return lightIntensity; }
            set
            {
                // controllo sul range
                if (value > 0 && value < 20)
                {
                    lightIntensity= value;
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

        private void SaveAccensionTime()
        {
            startTime = DateTime.Now;
        }

      

        public void EcoActivation()
        {
            if (startTime == null)
                return;

            DateTime now = DateTime.Now;

            // after an hour till the activetion
            if ((now - startTime.Value).TotalHours >= maxTimeOn)
            {
                isOn= false;
                lightIntensity = 0;
            }

            // at night from 10pm to 6am
            if (now.Hour >= 23 || now.Hour < 7)
            {
                isOn = false;
                lightIntensity = 0;
            }
        }



    }
}
