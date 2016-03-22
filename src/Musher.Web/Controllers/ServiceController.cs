using System.Web.Mvc;
using Musher.EchoNest.Services;

namespace Musher.Web.Controllers
{
    public abstract class ServiceController : Controller
    {
        protected readonly IService Service;

        protected ServiceController(IService service)
        {
            Service = service;
        }
    }
}
