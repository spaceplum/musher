using System.Collections.Generic;
using Musher.EchoNest.Models;

namespace Musher.EchoNest.Responses
{
    public class SimilarArtistsResponse : BaseResponse
    {
        public List<Artist> Artists { get; set; }
    }
}
