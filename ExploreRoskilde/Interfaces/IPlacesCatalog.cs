using System.Collections.Generic;
using ExploreRoskilde.Models;

namespace ExploreRoskilde.Interfaces
{
    public interface IPlacesCatalog
    {

        public Dictionary<string, Place> AllPlaces();

        public Place GetPlaceById(string id);

        public void AddPlace(Place place);

        public Dictionary<string, Place> Searching(string searching, int category);



    }
}