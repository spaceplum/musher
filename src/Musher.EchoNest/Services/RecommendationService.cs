using System.Collections.Generic;
using Musher.EchoNest.Data;
using Musher.EchoNest.Models;

namespace Musher.EchoNest.Services
{
    public class RecommendationService: Service, IRecommendationService
    {
        public RecommendationService(IDataProvider dataProvider) : base(dataProvider)
        {
        }

        public List<Artist> GetArtists(RecommendationQueryArgs args)
        {
            return DataProvider.GetArtists(args);
        }

        public List<Song> GetSongs(RecommendationQueryArgs args)
        {
            return DataProvider.GetSongs(args);
        }
    }
}
