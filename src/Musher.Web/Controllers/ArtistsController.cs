using System.Web.Mvc;
using Musher.EchoNest.Services;
using Musher.Web.Models;

namespace Musher.Web.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IArtistService _service;

        public ArtistsController(IArtistService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Search");
        }

        public ActionResult Artist(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            var artist = _service.GetArtistProfile(id);
            var model = new ArtistsArtistViewModel
            {
                Artist = artist,
            };

            return View(model);
        }

        public ActionResult Similar(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            var artists = _service.GetSimilarArtists(id);
            var model = new SimilarArtistsViewModel
            {
                Artist = id,
                SimilarArtists = artists
            };

            return View(model);
        }

        public ActionResult Search(ArtistsSearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var genres = _service.GetAllGenres();
            model.Genres = genres;

            if (!string.IsNullOrEmpty(model.Name) || !string.IsNullOrEmpty(model.Genre))
            {
                var artists = _service.GetArtists(model.Name, model.Genre);
                model.Artists = artists;
                model.IsSearch = true;
            }

            return View(model);
        }

        public ActionResult Genres(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            var genres = _service.GetGenres(id);
            var model = new ArtistsGenresViewModel
            {
                Artist = id,
                Genres = genres
            };

            return View(model);
        }
    }
}
