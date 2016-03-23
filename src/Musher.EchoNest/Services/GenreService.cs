using System.Collections.Generic;
using Musher.EchoNest.Data;
using Musher.EchoNest.Models;

namespace Musher.EchoNest.Services
{
    public class GenreService : Service, IGenreService
    {
        public GenreService(IDataProvider dataProvider) : base(dataProvider)
        {
        }

        public Genre GetGenreProfile(string name)
        {
            return DataProvider.GetGenreProfile(name);
        }

        public List<Genre> GetSimilarGenres(string name)
        {
            return DataProvider.GetSimilarGenres(name);
        }

        public List<Artist> GetArtists(string name)
        {
            return DataProvider.GetArtists(name);
        }
    }
}
