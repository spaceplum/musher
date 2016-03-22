using System.Collections.Generic;
using Musher.EchoNest.Models;

namespace Musher.EchoNest.Services
{
    public interface IService
    {
        List<Genre> GetGenres();
        List<Term> GetMoods();
        List<Term> GetStyles();
        List<Artist> GetArtists(string name = null, string genre = null);
        Artist GetArtistProfile(string id);
        List<Artist> GetSimilarArtists(string id);
        List<Genre> GetGenres(string id);
        List<Term> GetTerms(string id);
        Genre GetGenreProfile(string name);
        List<Genre> GetSimilarGenres(string name);
        List<Artist> GetArtists(string name);
        List<Artist> GetArtists(RecommendationQueryArgs args);
        List<Song> GetSongs(RecommendationQueryArgs args);
    }
}
