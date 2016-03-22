using System.Collections.Generic;

namespace Musher.EchoNest.Models
{
    public class Artist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<Term> Terms { get; set; } = new List<Term>();
        public List<Image> Images { get; set; } = new List<Image>();
        public List<Biography> Biographies { get; set; } = new List<Biography>();
    }
}
