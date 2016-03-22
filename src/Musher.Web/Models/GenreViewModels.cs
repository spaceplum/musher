using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Musher.EchoNest.Models;

namespace Musher.Web.Models
{
    public class GenresGenreViewModel
    {
        public Genre Genre { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Genre> SimilarGenres { get; set; }
    }

    public class GenresIndexViewModel
    {
        [DisplayName("Genres")]
        public List<Genre> Genres { get; set; } = new List<Genre>();

        public List<Genre> GetRandomGenres(int count)
        {
            Random random = new Random();
            return Genres.OrderBy(x => random.Next()).Take(count).ToList();
        }
    }

    public class GenresArtistsViewModel
    {
        public string Genre { get; set; }

        public List<Artist> Artists { get; set; } = new List<Artist>();
    }
}
