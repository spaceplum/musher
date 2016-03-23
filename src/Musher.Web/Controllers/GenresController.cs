using System.Web.Mvc;
using Musher.EchoNest.Services;
using Musher.Web.Models;

namespace Musher.Web.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreService _service;

        public GenresController(IGenreService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            var genres = _service.GetAllGenres();
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

            var genre = _service.GetGenreProfile(id);

            if (genre == null)
            {
                return RedirectToAction("Index");
            }

            var artists = _service.GetArtists(genre.Name);
            var similarGenres = _service.GetSimilarGenres(genre.Name);

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

            var artists = _service.GetArtists(id);
            var model = new GenresArtistsViewModel
            {
                Genre = id,
                Artists = artists
            };

            return View(model);
        }
    }
}
