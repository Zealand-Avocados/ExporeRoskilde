using ExploreRoskilde.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;


namespace ExploreRoskilde.Database
{
    public static class Database
    {
        public static string PlacesFilePath = "Database/Places.json";

        public static void WriteToJson(string filePath, Dictionary<int, Place> places)
        {
            //  string output = System.Text.Json.JsonSerializer.Serialize(places);
            string output = JsonConvert.SerializeObject(places);
            File.WriteAllText(filePath, output);
        }

        public static Dictionary<int, Place> ReadJson(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<int, Place>>(jsonString);
        }
    }
}