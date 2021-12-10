using System;
using System.Collections.Generic;
using ExploreRoskilde.Interfaces;
using ExploreRoskilde.Models;
using ExploreRoskilde.Database;
using System;
using System.Linq;

namespace ExploreRoskilde.Repositories
{
    public class PlacesCatalog : IPlacesCatalog
    {
        public Dictionary<string, Place> AllPlaces() => Database.Database.ReadJsonPlaces();

        public Place GetPlaceById(string id)
        {
            return AllPlaces()[id];
        }


        public void AddPlace(Place place)
        {
            Dictionary<string, Place> places = AllPlaces();
            places.Add(place.Id, place);
            Database.Database.WriteToJsonPlaces(places);
        }

        public void DeletePlace(Place place)
        {
            Dictionary<string, Place> places = AllPlaces();
            places.Remove(place.Id);
            Database.Database.WriteToJsonPlaces(places);
        }


        public void UpdatePlace(Place place)
        {
            Dictionary<string, Place> places = AllPlaces();
            if (place == null) return;
            foreach (var i in places.Values.Where(i => i.Id == place.Id))
            {
                i.Address = place.Address;
                i.Category = place.Category;
                i.Description = place.Description;
                i.Rating = place.Rating;
                i.Title = place.Title;
                i.ImageUrl = place.ImageUrl;
                break;
            }

            Database.Database.WriteToJsonPlaces(places);
        }


        public Dictionary<string, Place> Searching(string searching, int category)
        {
            Dictionary<string, Place> places = AllPlaces();
            Dictionary<string, Place> filteredPlaces = new Dictionary<string, Place>();

            if ((string.IsNullOrEmpty(searching) == false) && (category < 1))
            {
                foreach (var place in places)
                {
                    if (place.Value.Title.StartsWith(searching))
                    {
                        filteredPlaces.Add(place.Key, place.Value);
                    }
                }

                return filteredPlaces;
            }

            else if (string.IsNullOrEmpty(searching) && (category > 0))
            {
                foreach (var place in places)
                {
                    if ((int) place.Value.Category == category)
                        filteredPlaces.Add(place.Key, place.Value);
                }

                return filteredPlaces;
            }

            else if ((string.IsNullOrEmpty(searching) == false) && (category > 0))
            {
                foreach (var place in places)
                {
                    if (place.Value.Title.StartsWith(searching) && (int) place.Value.Category == category)
                        filteredPlaces.Add(place.Key, place.Value);
                }

                return filteredPlaces;
            }

            else
            {
                return places;
            }
        }
    }
}