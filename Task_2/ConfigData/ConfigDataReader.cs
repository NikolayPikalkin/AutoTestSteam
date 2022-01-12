using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Task_2.ConfigData
{
    public class ConfigDataReader
    {
        private static string nameJsonFile = BaseDirectory.BaseDirect+"ConfigData\\ConfigData.json";
        public static void ConfDataRead(out ConfigModel configModelObject)
        {
            string objectJsonFile = File.ReadAllText(nameJsonFile);
            configModelObject = JsonSerializer.Deserialize<ConfigModel>(objectJsonFile);
        }
    }
}
