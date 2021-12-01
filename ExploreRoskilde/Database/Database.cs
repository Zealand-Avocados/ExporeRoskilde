using ExploreRoskilde.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreRoskilde.Database
{
    public static class Database
    {
        private static string _filePath = "Places.json";

        public static void WriteToJson(string filePath, Dictionary<int, Place> places)
        {
            string output = System.Text.Json.JsonSerializer.Serialize(places);
            File.WriteAllText(filePath, output);
        }

        public static Dictionary<int, Place> ReadJson(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return System.Text.Json.JsonSerializer.Deserialize<Dictionary<int, Place>>(jsonString);
        }
    }
}
