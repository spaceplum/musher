using System.Web.Mvc;
using Musher.EchoNest.Services;
using Musher.Web.Models;

namespace Musher.Web.Controllers
{
    public class GenresController : ServiceController
    {
        public GenresController(IService service) : base(service)
        {
        }

        public ActionResult Index()
        {
            var genres = Service.GetGenres();
            var model = new GenresIndexViewModel
            {
                Genres = genres
            };

            return View(model);
        }

        public ActionResult Genre(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            var genre = Service.GetGenreProfile(id);

            if (genre == null)
            {
                return RedirectToAction("Index");
            }

            var artists = Service.GetArtists(genre.Name);
            var similarGenres = Service.GetSimilarGenres(genre.Name);

            var model = new GenresGenreViewModel
            {
                Genre = genre,
                Artists = artists,
                SimilarGenres = similarGenres
            };

            return View(model);
        }

        public ActionResult Artists(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            var artists = Service.GetArtists(id);
            var model = new GenresArtistsViewModel
            {
                Genre = id,
                Artists = artists
            };

            return View(model);
        }
    }
}
