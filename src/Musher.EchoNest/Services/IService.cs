using System.Collections.Generic;
using Musher.EchoNest.Models;

namespace Musher.EchoNest.Services
{
    public interface IService
    {
        List<Genre> GetAllGenres();
        List<Term> GetAllMoods();
        List<Term> GetAllStyles();
    }
}
