using System;
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

        public void DeletePlace(Place place)
        {
            Dictionary<string, Place> places = AllPlaces();
            places.Remove(place.Id);
            Database.Database.WriteToJson(Database.Database.PlacesFilePath, places);
        }
        
        


        public void UpdatePlace(Place place)
        {
            Dictionary<string, Place> places = AllPlaces();
            if (place != null)
            {
                
                foreach (Place i in places.Values)
                {
                    if (i.Id == place.Id)
                    {
                        i.Address = place.Address;
                        i.Category = place.Category;
                        i.Description = place.Description;
                        i.Rating = place.Rating;
                        i.Title = place.Title;
                        i.ImageUrl = place.ImageUrl;
                        
                    }
                }
                Database.Database.WriteToJson(Database.Database.PlacesFilePath, places);
                //JsonFileItemService.SaveJsonItems(_items);
            }

        }
        
        
        
        
        
    }
}