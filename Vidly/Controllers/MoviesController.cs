using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        List<Movie> movies = new List<Movie>
            {
                 new Movie {ID = 1, Name = "Shrek" },
                 new Movie {ID = 2,Name="john Wick"}
            };

        // GET: Movies
        public ActionResult Index()
        {

            return View(movies.ToList());
        }

        public ActionResult Details(int id)
        {
            try
            {
                var selectedMovie = movies.Where(m => m.ID == id).SingleOrDefault();
                return View(selectedMovie);
            }
            catch (InvalidOperationException e)
            {

                return HttpNotFound();
            }
            catch (ArgumentNullException e)
            {
                return HttpNotFound();
            }
        }
    }
}