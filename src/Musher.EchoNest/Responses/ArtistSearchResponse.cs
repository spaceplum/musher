using System.Collections.Generic;
using Musher.EchoNest.Models;

namespace Musher.EchoNest.Responses
{
    public class ArtistSearchResponse : BaseResponse
    {
        public List<Artist> Artists { get; set; }
    }
}
