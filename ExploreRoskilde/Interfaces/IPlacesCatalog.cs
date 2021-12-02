using System.Collections.Generic;
using ExploreRoskilde.Models;

namespace ExploreRoskilde.Interfaces
{
    public interface IPlacesCatalog
    {

        public Dictionary<int, Place> AllPlaces();

        public Place GetPlaceById(int id);

        public void AddPlace(Place place);




    }
}