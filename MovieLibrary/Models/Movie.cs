using System;

namespace MovieLibrary.Models
{
    // create model based on movies.csv file

    public class Movie
    {
        public UInt64 Id { get; set; }
        public string Title { get; set; }
        public string Genres { get; set; }
    }
    
}
