using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    internal class EcoLamp
    {

        private bool isOn;// true = on , false = off
        private int lightIntensity;// how much light power the lamp has range 1-100
        private bool isWireless;// true = wireless , false = wired
        private string[] ligthColorsArray = new string[7] { "red", "yellow", "orange", "blue", "green", "purple", "white" };// array of colors the lamp can emit
        private string actualColor = "white";// actual color of the lamp at the beggining is white
        public int consumationValue { get; }     // how much energy the lamp consumes in W
        public int maxTimeOn { get; } = 1; // max time the lamp can stay on in hours
        public Timer timer;

        // costructor for lamp
        public EcoLamp(bool ison, int ligthpower, bool iswireless, int consumationvalue)
        {
           if (consumationvalue <20)
            {
                consumationValue = consumationvalue; // limit the consumption value to 20W for EcoLamp
            }
            if (ligthpower > 0 && ligthpower < 20)
            {
                lightIntensity = ligthpower;
            }
            isOn = ison;
            isWireless = iswireless;
        }
        //metod for the light on
        public void turnOn()
        {
            DateTime now = DateTime.Now;
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
                if (value > 0 && value < 20)
                {
                    value = lightIntensity;
                }
                else
                {
                    //Console.WriteLine("Light intensity must be between 0 and 20");
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

        


    }
}
