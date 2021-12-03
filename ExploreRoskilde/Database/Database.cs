﻿using System;
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
        
        private static Dictionary<int, Place> _places = new Dictionary<int, Place>();

        public static void WriteToJson(string filePath, Dictionary<int, Place> places)
        {
            //  string output = System.Text.Json.JsonSerializer.Serialize(places);
            // var output = JsonConvert.SerializeObject(places);
            // string output = "{:::::: }";
            // File.WriteAllText(filePath, output);
            _places = places;
        }

        public static Dictionary<int, Place> ReadJson(string filePath)
        {
            // var jsonString = File.ReadAllText(filePath);
            // return JsonConvert.DeserializeObject<Dictionary<int, Place>>(jsonString);
            
            return _places;
        }
    }
}