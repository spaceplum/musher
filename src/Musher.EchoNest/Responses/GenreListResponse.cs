using System.Collections.Generic;
using Musher.EchoNest.Models;

namespace Musher.EchoNest.Responses
{
    public class GenreListResponse : BaseResponse
    {
        public List<Genre> Genres { get; set; }
    }
}
