using System.Collections.Generic;
using ExploreRoskilde.Interfaces;
using ExploreRoskilde.Models;
using ExploreRoskilde.Database;
using System;

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

       
        public Dictionary<string, Place> Searching(string searching, int category)
        {
            Dictionary<string, Place> places = AllPlaces();
            Dictionary<string, Place> filtered_places = new Dictionary<string, Place>();

            if ((string.IsNullOrEmpty(searching) == false) && (category < 1)) 
            {
                foreach (var place in places)
                {
                    if (place.Value.Title.StartsWith(searching))
                    {
                        filtered_places.Add(place.Key, place.Value);
                    }
                }

                return filtered_places;
            }
            
            else if(string.IsNullOrEmpty(searching) && (category > 0)) 
            {

                foreach (var place in places)
                {
                    if ((int)place.Value.Category == category)
                        filtered_places.Add(place.Key, place.Value);
                }
                    
                return filtered_places;
            }

            else if((string.IsNullOrEmpty(searching) == false) && (category > 0))
            {   
                
                foreach (var place in places)
                {

                    if(place.Value.Title.StartsWith(searching) && (int)place.Value.Category == category)
                        filtered_places.Add(place.Key, place.Value);
                }

                return filtered_places;
            }

            else
            {
                return places;
            }
        }

    }
}