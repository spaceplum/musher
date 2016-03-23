using System.Collections.Generic;
using Musher.EchoNest.Models;

namespace Musher.EchoNest.Services
{
    public interface IRecommendationService : IService
    {
        List<Artist> GetArtists(RecommendationQueryArgs args);
        List<Song> GetSongs(RecommendationQueryArgs args);
    }
}
