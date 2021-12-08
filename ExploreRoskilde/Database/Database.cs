using System;
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
        public static string UsersFilePath = "Database/Places.json";
        
        public static void WriteToJson(string filePath, Dictionary<string, Place> places)
        {
            var output = JsonConvert.SerializeObject(places);
            File.WriteAllText(filePath, output);
        }

        public static void WriteToJsonUsers(string filePath, Dictionary<string, User> users)
        {
            var output = JsonConvert.SerializeObject(users);
            File.WriteAllText(filePath, output);
        }

        public static Dictionary<string, Place> ReadJson(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<string, Place>>(jsonString);
        }

        public static Dictionary<string, User> ReadJsonUsers(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<string, User>>(jsonString);

        }
    }
}