using System.Collections.Generic;
using Musher.EchoNest.Data;
using Musher.EchoNest.Models;

namespace Musher.EchoNest.Services
{
    public abstract class Service : IService
    {
        protected readonly IDataProvider DataProvider;

        // Static "cache" for now...
        private static List<Genre> _genreCache;
        private static List<Term> _moodCache;
        private static List<Term> _styleCache;

        protected Service(IDataProvider dataProvider)
        {
            DataProvider = dataProvider;
        }

        public List<Genre> GetAllGenres()
        {
            return _genreCache ?? (_genreCache = DataProvider.GetGenres());
        }

        public List<Term> GetAllMoods()
        {
            return _moodCache ?? (_moodCache = DataProvider.GetTerms(TermType.Mood));
        }

        public List<Term> GetAllStyles()
        {
            return _styleCache ?? (_styleCache = DataProvider.GetTerms(TermType.Style));
        }
    }
}
