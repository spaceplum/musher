using System.Collections.Generic;
using Musher.EchoNest.Models;

namespace Musher.EchoNest.Data
{
    public interface IDataProvider
    {
        List<Artist> GetArtists(RecommendationQueryArgs args);
        List<Song> GetSongs(RecommendationQueryArgs args);
        List<Artist> GetSimilarArtists(string name);
        List<Genre> GetGenres();
        List<Genre> GetGenres(string artistName);
        List<Term> GetTerms(TermType type);
        List<Term> GetArtistTerms(string name, TermType type);
        List<Artist> GetArtists(string genre);
        List<Artist> SearchArtists(string name, string genre);
        Artist GetArtistProfile(string name);
        Genre GetGenreProfile(string name);
        List<Genre> GetSimilarGenres(string name);
    }
}