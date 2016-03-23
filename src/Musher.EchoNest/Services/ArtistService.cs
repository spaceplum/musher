using System.Collections.Generic;
using System.Linq;
using Musher.EchoNest.Data;
using Musher.EchoNest.Models;

namespace Musher.EchoNest.Services
{
    public class ArtistService : Service, IArtistService, IService
    {
        public ArtistService(IDataProvider dataProvider) : base(dataProvider)
        {
        }

        public List<Artist> GetArtists(string name = null, string genre = null)
        {
            return DataProvider.SearchArtists(name, genre);
        }

        public Artist GetArtistProfile(string id)
        {
            return DataProvider.GetArtistProfile(id);
        }

        public List<Artist> GetSimilarArtists(string id)
        {
            return DataProvider.GetSimilarArtists(id);
        }

        public List<Genre> GetGenres(string id)
        {
            return DataProvider.GetGenres(id);
        }

        public List<Term> GetTerms(string id)
        {
            var moods = DataProvider.GetArtistTerms(id, TermType.Mood);
            var styles = DataProvider.GetArtistTerms(id, TermType.Style);

            return moods.Concat(styles).ToList();
        }
    }
}
