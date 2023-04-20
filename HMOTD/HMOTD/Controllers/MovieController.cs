using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMOTD.Models;
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

        public IActionResult ViewMovie(int id)
        {
            var movie = repo.GetMovie(id);
            return View(movie);
        }

        public IActionResult UpdateMovie(int id)
        {
            Movies movie = repo.GetMovie(id);
            if (movie == null)
            {
                return View("MovieNotFound");
            }
            return View(movie);
        }

        public IActionResult UpdateMovieToDatabase(Movies movie)
        {
            repo.UpdateMovie(movie);
            return RedirectToAction("ViewMovie", new {id = movie.ID});
        }

        public IActionResult InsertMovie()
        {
            var movie = new Movies();
            return View(movie);
        }

        public IActionResult InsertMovieToDatabase(Movies movieToInsert)
        {
            repo.InsertMovie(movieToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteMovie(Movies movie)
        {
            repo.DeleteMovie(movie);
            return RedirectToAction("Index");
        }
    }
}
