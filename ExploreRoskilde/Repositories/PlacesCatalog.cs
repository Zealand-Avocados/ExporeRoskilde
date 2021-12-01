using System.Collections.Generic;
using ExploreRoskilde.Interfaces;
using ExploreRoskilde.Models;
using ExploreRoskilde.Database;


namespace ExploreRoskilde.Repositories
{
    public class PlacesCatalog : IPlacesCatalog
    {
        public Dictionary<int, Place> AllPlaces() => Database.Database.ReadJson(Database.Database.PlacesFilePath);

        public Place GetPlaceById(int id)
        {
            return AllPlaces()[id];
        }
        
        
        
        
        
    }
}