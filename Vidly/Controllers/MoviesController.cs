using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
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
            var CustomerMovies = new CustomerMoviesViewModel()
            {
                Customer = customer,
                Movies = movies
            };
            return View(CustomerMovies);
        }
    }
}