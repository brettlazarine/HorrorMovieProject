using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HMOTD.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieInterface repo;
        public MovieController(IMovieInterface repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var movies = repo.GetAllMovies();
            return View(movies);
        }
    }
}
