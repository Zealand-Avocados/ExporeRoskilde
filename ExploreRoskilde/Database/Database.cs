using ExploreRoskilde.Models;
using System.Collections.Generic;
using System.IO;


namespace ExploreRoskilde.Database
{
    public static class Database
    {
        public static string PlacesFilePath = "Database/Places.json";

        public static void WriteToJson(string filePath, Dictionary<int, Place> places)
        {
            string output = System.Text.Json.JsonSerializer.Serialize(places);
            File.WriteAllText(filePath, output);
        }

        public static Dictionary<int, Place> ReadJson(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return System.Text.Json.JsonSerializer.Deserialize<Dictionary<int,Place>>(jsonString);
        }
    }
}
