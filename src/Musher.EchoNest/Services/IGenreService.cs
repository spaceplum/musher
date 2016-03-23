using System.Collections.Generic;
using Musher.EchoNest.Models;

namespace Musher.EchoNest.Services
{
    public interface IGenreService : IService
    {
        Genre GetGenreProfile(string name);
        List<Genre> GetSimilarGenres(string name);
        List<Artist> GetArtists(string name);
    }
}
