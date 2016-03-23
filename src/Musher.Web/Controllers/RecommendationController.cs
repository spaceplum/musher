using System.Linq;
using System.Web.Mvc;
using Musher.EchoNest.Models;
using Musher.EchoNest.Services;
using Musher.Web.Models;

namespace Musher.Web.Controllers
{
    public class RecommendationController : Controller
    {
        private readonly IRecommendationService _service;

        public RecommendationController(IRecommendationService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            var model = new RecommendationViewModel();
            Populate(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(RecommendationViewModel model)
        {
            Populate(model);

            if (!model.GenreQuery.Any() && !model.MoodQuery.Any() && !model.StyleQuery.Any() && !model.StartYearQuery.HasValue && !model.EndYearQuery.HasValue)
            {
                ModelState.AddModelError("Query", "Please select something!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var args = new RecommendationQueryArgs
            {
                Genre = model.GenreQuery,
                Mood = model.MoodQuery,
                Style = model.StyleQuery,
                StartYear = model.StartYearQuery,
                EndYear = model.EndYearQuery
            };

            model.Artists = _service.GetArtists(args);
            model.Songs = _service.GetSongs(args);
            model.IsSearch = true;

            return View(model);
        }

        private void Populate(RecommendationViewModel model)
        {
            model.Genres = _service.GetAllGenres();
            model.Moods = _service.GetAllMoods();
            model.Styles = _service.GetAllStyles();
        }
    }
}
