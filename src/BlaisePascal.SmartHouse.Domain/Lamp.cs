namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {
        private bool isOn { get; set; } // true = on , false = off
        private int lightPower { get; set; }// how much light power the lamp has
        private bool isWireless { get; set; }// true = wireless , false = wired
        private string[] ligthColorsArray= new string[0];// array of colors the lamp can emit

        // costructor for lamp
        public void lamp(bool ison, int ligthpower , bool iswireless)
        {   
            isOn=ison;
            lightPower = ligthpower;
            isWireless=iswireless;
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
    }
}
