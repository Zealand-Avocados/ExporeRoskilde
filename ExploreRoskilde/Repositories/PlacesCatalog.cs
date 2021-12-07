using System.Collections.Generic;
using ExploreRoskilde.Interfaces;
using ExploreRoskilde.Models;
using ExploreRoskilde.Database;


namespace ExploreRoskilde.Repositories
{
    public class PlacesCatalog : IPlacesCatalog
    {
        public Dictionary<string, Place> AllPlaces() => Database.Database.ReadJson(Database.Database.PlacesFilePath);

        public Place GetPlaceById(string id)
        {
            return AllPlaces()[id];
        }


        public void AddPlace(Place place)
        {
            Dictionary<string, Place> places = AllPlaces();
            places.Add(place.Id, place);
            Database.Database.WriteToJson(Database.Database.PlacesFilePath, places);
        }
    }