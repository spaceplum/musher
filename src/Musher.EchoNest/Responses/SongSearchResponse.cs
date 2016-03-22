using System.Collections.Generic;
using Musher.EchoNest.Models;

namespace Musher.EchoNest.Responses
{
    public class SongSearchResponse : BaseResponse
    {
        public List<Song> Songs { get; set; }
    }
}
