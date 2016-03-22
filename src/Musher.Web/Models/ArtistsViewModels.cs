using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Musher.EchoNest.Models;

namespace Musher.Web.Models
{
    public class ArtistsArtistViewModel
    {
        private const int NumberOfDisplayedImages = 4;

        public Artist Artist { get; set; }

        public string ArtistBiography()
        {
            var biography = Artist.Biographies.FirstOrDefault(x => !x.Truncated);

            return biography != null ? biography.Text : null;
        }

        public List<Image> Images()
        {
            return Artist.Images
                .Where(x => !x.Url.Contains("last.fm"))
                .Take(NumberOfDisplayedImages)
                .ToList();
        }
    }

    public class ArtistsSearchViewModel
    {
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Genre")]
        public string Genre { get; set; }
        public List<Artist> Artists { get; set; } = new List<Artist>();
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public bool IsSearch { get; set; }
    }

    public class SimilarArtistsViewModel
    {
        [Required]
        public string Artist { get; set; }
        public List<Artist> SimilarArtists { get; set; } = new List<Artist>();
    }

    public class ArtistsGenresViewModel
    {
        [Required]
        public string Artist { get; set; }
        public List<Genre> Genres { get; set; } = new List<Genre>();
    }

    public class ArtistsListViewModel
    {
        public List<Artist> Artists { get; set; } = new List<Artist>();
    }
}
