using System.Collections.Generic;
using Musher.EchoNest.Models;

namespace Musher.EchoNest.Responses
{
    public class SimilarGenresResponse : BaseResponse
    {
        public List<Genre> Genres { get; set; }
    }
}
