using System.Configuration;
using System.Web.Mvc;
using Musher.EchoNest.Data;
using Musher.EchoNest.Services;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace Musher.Web
{
    public class EchoNestConfig
    {
        public static void RegisterServices()
        {
            string apiUrl = ConfigurationManager.AppSettings["EchoNestApiUrl"];
            string apiKey = ConfigurationManager.AppSettings["EchoNestApiKey"];
            var container = new Container();
            container.Register<IDataProvider>(() => new DataProvider(apiUrl, apiKey));
            container.Register<IArtistService, ArtistService>();
            container.Register<IGenreService, GenreService>();
            container.Register<IRecommendationService, RecommendationService>();
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
