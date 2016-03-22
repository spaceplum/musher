using System.Collections.Generic;
using System.ComponentModel;
using Musher.EchoNest.Models;

namespace Musher.Web.Models
{
    public class RecommendationViewModel
    {
        [DisplayName("Genre")]
        public List<string> GenreQuery { get; set; } = new List<string>();
        [DisplayName("Style")]
        public List<string> StyleQuery { get; set; } = new List<string>();
        [DisplayName("Mood")]
        public List<string> MoodQuery { get; set; } = new List<string>();
        [DisplayName("From decade")]
        public int? StartYearQuery { get; set; }
        [DisplayName("To decade")]
        public int? EndYearQuery { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Term> Moods { get; set; }
        public List<Term> Styles { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Song> Songs { get; set; }
        public bool IsSearch { get; set; }
    }
}
