using System.Collections.Generic;
using Musher.EchoNest.Models;

namespace Musher.EchoNest.Responses
{
    public class GenreArtistsResponse : BaseResponse
    {
        public List<Artist> Artists { get; set; }
    }
}
