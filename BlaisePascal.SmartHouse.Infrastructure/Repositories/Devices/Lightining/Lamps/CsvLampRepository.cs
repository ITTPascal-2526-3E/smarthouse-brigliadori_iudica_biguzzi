using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObj;
using BlaisePascal.SmartHouse.Domain.IlluminoiseDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lightining.Lamps
{
    public class CsvLampRepository
    {
        private readonly string _filePath = "lamps.csv";

        public CsvLampRepository()
        {
            var solutionRoot = LocalPathHelper.GetSolutionRoot();
            var dataFolder = Path.Combine(solutionRoot, "Data");
            Directory.CreateDirectory(dataFolder);

            _filePath = Path.Combine(dataFolder, "lamps.csv");
            if (!File.Exists(_filePath))
            {
                Save(new List<Lamp>());
            }
        }

        public List<Lamp> GetAll()
        {
            return Load();
        }

        public Lamp GetById(Guid id)
        {
            return Load().First(l => l.Id == id);
        }

        private void Save(List<Lamp> lamps)
        {
            var dtos = lamps;
            var lines = new List<string>
            {
                "Id,Name,Color,Brightness,IsOn,ligthOnspecificTime,ligthOffSpecificTime"
            };

            foreach (var dto in dtos)
            {
                lines.Add(string.Join(",",
                    dto.Id,
                    dto.getName,
                    dto.actualColor,
                    dto.getBrightness(),
                    dto.isOn,
                    dto.lightOnSpecificTime,
                    dto.lightOffSpecificTime));
            }

            File.WriteAllLines(_filePath, lines);
        }

        private List<Lamp> Load()
        {
            var lines = File.ReadAllLines(_filePath);
            var lamps = new List<Lamp>();
            foreach (var line in lines.Skip(1))
            {
                var parts = line.Split(',');
                var dto = new Lamp(
                    bool.Parse(parts[4]),
                    int.Parse(parts[3]),
                    false, // Assuming isWireless is false for all lamps in this example
                    10, // Assuming a default consumationValue for all lamps in this example
                    new Hour(int.Parse(parts[5])), // lightOnSpecificTime
                    new Hour(int.Parse(parts[6]))  // lightOffSpecificTime
                );
                lamps.Add(dto);
            }
            return lamps;
        }

        public void Update(Lamp lamp)
        {
            var lamps = Load();
            var index = lamps.FindIndex(l => l.Id == lamp.Id);
            if (index >= 0)
            {
                lamps[index] = lamp;
                Save(lamps);
            }
        }

        public void Add(Lamp lamp)
        {
            var lamps = Load();
            lamps.Add(lamp);
            Save(lamps);
        }


        public void Remove(Lamp lamp)
        {
            var lamps = Load();
            lamps.RemoveAll(l => l.Id == lamp.Id);
            Save(lamps);
        }
    }
}