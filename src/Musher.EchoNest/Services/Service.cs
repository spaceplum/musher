using System.Collections.Generic;
using System.Linq;
using Musher.EchoNest.Data;
using Musher.EchoNest.Models;

namespace Musher.EchoNest.Services
{
    public class Service : IService
    {
        private readonly IDataProvider _dataProvider;

        // Static "cache" for now...
        private static List<Genre> _genreCache;
        private static List<Term> _moodCache;
        private static List<Term> _styleCache;

        public Service(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public List<Genre> GetGenres()
        {
            return _genreCache ?? (_genreCache = _dataProvider.GetGenres());
        }

        public List<Term> GetMoods()
        {
            return _moodCache ?? (_moodCache = _dataProvider.GetTerms(TermType.Mood));
        }

        public List<Term> GetStyles()
        {
            return _styleCache ?? (_styleCache = _dataProvider.GetTerms(TermType.Style));
        }

        public List<Artist> GetArtists(string name = null, string genre = null)
        {
            return _dataProvider.SearchArtists(name, genre);
        }

        public Artist GetArtistProfile(string id)
        {
            return _dataProvider.GetArtistProfile(id);
        }

        public List<Artist> GetSimilarArtists(string id)
        {
            return _dataProvider.GetSimilarArtists(id);
        }

        public List<Genre> GetGenres(string id)
        {
            return _dataProvider.GetGenres(id);
        }

        public List<Term> GetTerms(string id)
        {
            var moods = _dataProvider.GetArtistTerms(id, TermType.Mood);
            var styles = _dataProvider.GetArtistTerms(id, TermType.Style);

            return moods.Concat(styles).ToList();
        }

        public Genre GetGenreProfile(string name)
        {
            return _dataProvider.GetGenreProfile(name);
        }

        public List<Genre> GetSimilarGenres(string name)
        {
            return _dataProvider.GetSimilarGenres(name);
        }

        public List<Artist> GetArtists(string name)
        {
            return _dataProvider.GetArtists(name);
        }

        public List<Artist> GetArtists(RecommendationQueryArgs args)
        {
            return _dataProvider.GetArtists(args);
        }

        public List<Song> GetSongs(RecommendationQueryArgs args)
        {
            return _dataProvider.GetSongs(args);
        }
    }
}
