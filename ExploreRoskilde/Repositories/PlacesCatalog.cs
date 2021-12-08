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

        public Dictionary<string, Place> SearchByTitle(string title)
        {
            Dictionary<string, Place> places = AllPlaces();
            Dictionary<string, Place> filtered_places = new Dictionary<string, Place>();

            foreach (var place in places)
            {
                if (place.Value.Title.StartsWith(title))
                {
                    filtered_places.Add(place.Key, place.Value);
                }
            }
            return filtered_places;
        }

        public Dictionary<string, Place> SearchByCategory(Category category)
        {
            Dictionary<string, Place> places = AllPlaces();
            Dictionary<string, Place> filtered_places = new Dictionary<string, Place>();

            foreach (var place in places)
            {
                if (place.Value.Category == category)
                {
                    filtered_places.Add(place.Key, place.Value);
                }
            }
            return filtered_places;
        }

        public Dictionary<string, Place> Searching(string searching, int category)
        {
            Dictionary<string, Place> places = AllPlaces();
            Dictionary<string, Place> filtered_places = new Dictionary<string, Place>();

            if ((string.IsNullOrEmpty(searching) == false) && (category < 1)) //case that there is value in search bar and not in category
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
            else if(string.IsNullOrEmpty(searching) && (category > 0)) //case that there is value in category and not in search bar
            {

                foreach (var place in places)
                {
                    if ((int)place.Value.Category == category)
                        filtered_places.Add(place.Key, place.Value);
                }
                    
                return filtered_places;
            }
            else if((string.IsNullOrEmpty(searching) == false) && (category > 0)) //case that there is value either in category and search bar
            {
                return places;
            }
            else //both null
            {
                return places;
            }
        }

    }
}