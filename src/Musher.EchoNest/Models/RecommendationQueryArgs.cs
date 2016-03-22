using System.Collections.Generic;

namespace Musher.EchoNest.Models
{
    public class RecommendationQueryArgs
    {
        public List<string> Genre { get; set; } = new List<string>();
        public List<string> Mood { get; set; } = new List<string>();
        public List<string> Style { get; set; } = new List<string>();
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
    }
}
