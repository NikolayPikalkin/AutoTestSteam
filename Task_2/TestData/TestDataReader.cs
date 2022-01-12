using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Task_2.TestData
{
    public static class TestDataReader
    {
        private static string nameJsonFile = BaseDirectory.BaseDirect + "TestData\\TestData.json";
        public static void TestDataRead(out TestDataModel testModelObject)
        {
            string objectJsonFile = File.ReadAllText(nameJsonFile);
            testModelObject = JsonSerializer.Deserialize<TestDataModel>(objectJsonFile);
        }
    }
}
