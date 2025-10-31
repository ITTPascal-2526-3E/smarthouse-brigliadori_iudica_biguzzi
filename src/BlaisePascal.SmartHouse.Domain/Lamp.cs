namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {
        private bool isOn { get; set; }
        private int lightPower { get; set; }
        private bool isWireless { get; set; }
        private string[] ligthColorsArray= new string[0];

        // costructor for lamp
        public void lamp(bool ison, int ligthpower , bool iswireless)
        {   
            isOn=ison;
            lightPower = ligthpower;
            isWireless=iswireless;
        }

        public void turnOn()
        {
            isOn = true;
        }

        public void turnOff()
        {
            isOn = false;
        }
    }
}
