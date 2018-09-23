using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.MovieGenre).ToList();
            return View(movies);
        }

        // GET: Movies
        public ActionResult UserMovies()
        {
            var customer = new Customer()
            {
                Name = "Lara"
            };
            var movies = new List<Movie>()
            {
                new Movie() {Name = "Shreck! the first"},
                new Movie() {Name = "Shreck! the second"}
            };
            var customerMovies = new CustomerMoviesViewModel()
            {
                Customer = customer,
                Movies = movies
            };
            return View(customerMovies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.MovieGenre).SingleOrDefault(c => c.Id == id);
            return View(movie);
        }

        public ActionResult Rent(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Edit(int id)
        {
            var viewModel = new MovieFormViewModel()
            {
                Movie = _context.Movies.Single(m => m.Id == id),
                MovieGenres = _context.MovieGenre.ToList()
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel()
            {
                MovieGenres = _context.MovieGenre.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    MovieGenres = _context.MovieGenre.ToList()

                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.CreationDate = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var dbMovie = _context.Movies.Single(m => m.Id == movie.Id);
                dbMovie.AvailableUnits = movie.AvailableUnits;
                dbMovie.Description = movie.Description;
                dbMovie.MovieGenreId = movie.MovieGenreId;
                dbMovie.Name = movie.Name;
                dbMovie.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}