using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;
using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Gambling;
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

        TwoLampDevice lampDevice = new TwoLampDevice();
        lampDevice.addLamp(lamp);
        lampDevice.addEcoLamp(ecoLamp);
        lampDevice.turnOnAllLamps();
        lampDevice.turnOffOneLamp(0);
        Console.WriteLine("--------------------------------------------");
        RollerShutter rollerShutter = new RollerShutter(true, 50);
        Console.WriteLine("rollerShutter is open: " + rollerShutter.isOpen);
        Console.Write("insert rollerShutter position: ");
        rollerShutter.ShutterPosition=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("rollerShutter position is: " + rollerShutter.ShutterPosition + "%");
        Console.WriteLine("--------------------------------------------");
        CCTV cctv = new CCTV(false, 20, 6);
        Console.WriteLine("CCTV is on: " + cctv.isOn);
        cctv.turnOn();
        Console.WriteLine("CCTV is on after turnOn method: " + cctv.isOn);
        cctv.AutomaticTurnOn();
        Console.WriteLine("CCTV is on after AutomaticTurnOn method: " + cctv.isOn);
        Console.WriteLine("--------------------------------------------");
        Door door = new Door(false, true,10);
        Console.WriteLine("Door is open: " + door.isOpen);
        door.openDoor();
        Console.WriteLine("Door is open after OpenDoor method: " + door.isOpen);
        Console.WriteLine("Door is locked: " + door.isLocked);
        door.unlockDoor(10);
        Console.WriteLine("Door is locked after UnlockDoor method: " + door.isLocked);
        door.closeDoor();
        Console.WriteLine("Door is open after CloseDoor method: " + door.isOpen);
        door.lockDoor();
        Console.WriteLine("Door is locked after LockDoor method: " + door.isLocked);
        Console.WriteLine("--------------------------------------------");
        GamblingRoom gamblingRoom = new GamblingRoom();
        Console.WriteLine("select a game: slott, roulette, russianRoulette, blackjack");
        Console.Write("your choice: ");
        Game gameChoice = Convert.Console.ReadLine();
        Console.Write("insert your bet amount: ");
        int betAmount = Convert.ToInt32(Console.ReadLine());
        gamblingRoom.SelectGame(gameChoice, betAmount);





    }
}
