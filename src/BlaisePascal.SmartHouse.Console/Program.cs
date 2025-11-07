using BlaisePascal.SmartHouse.Domain;
internal class Program
{
    static void Main(string[] args)
    {
        Lamp lamp = new Lamp(true, 50, true, 60, 18, 23);
        Console.WriteLine("lamp is on: " + lamp.isOn);
        Console.WriteLine("lamp light intensity: " + lamp.lightIntensityPropriety);
        Console.WriteLine("lamp is wireless: " + lamp.isWireless);
        Console.WriteLine("lamp consumption value: " + lamp.consumationValue);
        Console.WriteLine("lamp turns on at: " + lamp.lightOnSpecificTime + "h");
        Console.WriteLine("lamp turns off at: " + lamp.lightOffSpecificTime + "h");
        lamp.turnOff();
        Console.WriteLine("lamp is on after turnOff method: " + lamp.isOn);
        lamp.lightIntensityPropriety = 80;
        Console.WriteLine("lamp light intensity after setting to 80: " + lamp.lightIntensityPropriety);
        lamp.setColor("red");
        Console.WriteLine("lamp actual color after setting to : " + lamp.getColor());
        lamp.ApllyScheduleNow();
        Console.WriteLine("lamp is on after CheckAndApplySchedule method: " + lamp.isOn);
        Console.WriteLine("-----------------------------");
        EcoLamp ecoLamp = new EcoLamp(false, 15, false, 15, 2);
        Console.WriteLine("ecoLamp is on: " + ecoLamp.isOn);
        Console.WriteLine("ecoLamp light intensity: " + ecoLamp.lightIntensityProperty);
        Console.WriteLine("ecoLamp is wireless: " + ecoLamp.isWireless);
        Console.WriteLine("ecoLamp consumption value: " + ecoLamp.consumationValue);
        Console.WriteLine("ecoLamp max time on: " + ecoLamp.maxTimeOn + "h");
        ecoLamp.turnOn();
        Console.WriteLine("ecoLamp is on after turnOn method: " + ecoLamp.isOn);
        ecoLamp.lightIntensityProperty = 18;
        Console.WriteLine("ecoLamp light intensity after setting to 18: " + ecoLamp.lightIntensityProperty);
        ecoLamp.setColor("green");
        Console.WriteLine("ecoLamp actual color after setting to green: " + ecoLamp.getColor());
        ecoLamp.EcoActivation();
        Console.WriteLine("--------------------------------------------");

        LampDevice lampDevice = new LampDevice();
        lampDevice.addLamp(lamp);
        lampDevice.addEcoLamp(ecoLamp);
        lampDevice.lampDeviceStatus();



    }
}
