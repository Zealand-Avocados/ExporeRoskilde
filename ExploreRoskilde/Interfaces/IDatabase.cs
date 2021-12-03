using System.Collections.Generic;
using ExploreRoskilde.Models;

namespace ExploreRoskilde.Interfaces
{
    public interface IDatabase
    {
        public void WriteToJson(string filePath, Dictionary<int, Place> places);
        public Dictionary<int, Place> ReadJson(string filePath);

    }
}