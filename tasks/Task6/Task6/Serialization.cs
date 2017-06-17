using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Task6
{
    class Serialization
    {
        public static void Run(IDress[] items)
        {

            // alle items serialisieren
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            Console.WriteLine(JsonConvert.SerializeObject(items, settings));

            // im file "items.json" am Desktop speichern
            var text = JsonConvert.SerializeObject(items, settings);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "items.json");
            File.WriteAllText(filename, text);

            // deserialisieren der items von "items.json"
            var textFromFile = File.ReadAllText(filename);
            var itemsFromFile = JsonConvert.DeserializeObject<IDress[]>(textFromFile, settings);

        }
    }
}
