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
        public const string PlacesFilePath = "Database/Places.json";
        public const string UsersFilePath = "Database/Users.json";
        public const string CommentsFilePath = "Database/Comments.json";
        
        public static void WriteToJsonPlaces(Dictionary<string, Place> places)
        {
            var output = JsonConvert.SerializeObject(places);
            File.WriteAllText(PlacesFilePath, output);
        }

        public static void WriteToJsonUsers(Dictionary<string, User> users)
        {
            var output = JsonConvert.SerializeObject(users);
            File.WriteAllText(UsersFilePath, output);
        }

        public static Dictionary<string, Place> ReadJsonPlaces()
        {
            var jsonString = File.ReadAllText(PlacesFilePath);
            return JsonConvert.DeserializeObject<Dictionary<string, Place>>(jsonString);
        }

        public static Dictionary<string, User> ReadJsonUsers()
        {
            var jsonString = File.ReadAllText(UsersFilePath);
            return JsonConvert.DeserializeObject<Dictionary<string, User>>(jsonString);
        }
        
        
        public static void WriteToJsonComments(Dictionary<string, Comment> users)
        {
            var output = JsonConvert.SerializeObject(users);
            File.WriteAllText(CommentsFilePath, output);
        }

        public static Dictionary<string, Comment> ReadJsonComments()
        {
            var jsonString = File.ReadAllText(CommentsFilePath);
            return JsonConvert.DeserializeObject<Dictionary<string, Comment>>(jsonString);
        }
    }
}