using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Helpers
{
    public class RepositoryInMemory : IRepository
    {
        public List<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie() { Title = "Spider-man", ReleaseDate = new DateTime(2019, 7, 16) },
                new Movie() { Title = "Bronson", ReleaseDate = new DateTime(2010, 7, 16) },
                new Movie() { Title = "Chopper", ReleaseDate = new DateTime(2019, 7, 16) },
            };
        }
    }
}
