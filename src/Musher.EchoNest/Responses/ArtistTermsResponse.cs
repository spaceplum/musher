using System.Collections.Generic;
using Musher.EchoNest.Models;

namespace Musher.EchoNest.Responses
{
    public class ArtistTermsResponse : BaseResponse
    {
        public List<Term> Terms { get; set; }
    }
}
