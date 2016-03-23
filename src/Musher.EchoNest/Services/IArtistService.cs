using System.Collections.Generic;
using Musher.EchoNest.Models;

namespace Musher.EchoNest.Services
{
    public interface IArtistService : IService
    {
        List<Artist> GetArtists(string name = null, string genre = null);
        Artist GetArtistProfile(string id);
        List<Artist> GetSimilarArtists(string id);
        List<Genre> GetGenres(string id);
        List<Term> GetTerms(string id);
    }
}
