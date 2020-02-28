using System;
using System.Linq;
using System.Web.Mvc;
using Vidly.BL.Domain;
using Vidly.DAL;
using Vidly.DAL.UOW;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private readonly UnitOFWork UOW = new UnitOFWork(new VidlyDbContext());

        // GET: Movies
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var ViewModel = new MoviesViewModel()
                {
                    Movie = movie,
                    Genres = UOW.GenreRepository.GetAll("No")
                };

                return View("New", ViewModel);
            }

            UOW.MovieRepository.Update(new Movie
            {
                ID = movie.ID,
                Name = movie.Name,
                ReleaseDate = movie.ReleaseDate,
                NumberInStock = movie.NumberInStock,
                GenreID = movie.GenreID,
            });

            UOW.Complete();
            UOW.Dispose();

            return RedirectToAction("Index");

        }

        public ActionResult New()
        {

            MoviesViewModel moviesView = new MoviesViewModel()
            {
                Genres = UOW.GenreRepository.GetAll("No"),
            };

            return View(moviesView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var ViewModel = new MoviesViewModel()
                {
                    Movie = movie,
                    Genres = UOW.GenreRepository.GetAll("No")
                };

                return View("New", ViewModel);
            }


            UOW.MovieRepository.Add(new Movie
            {
                Name = movie.Name,
                ReleaseDate = movie.ReleaseDate,
                NumberInStock = movie.NumberInStock,
                GenreID = movie.GenreID,
            });

            UOW.Complete();
            UOW.Dispose();
            return RedirectToAction("Index");
        }
    }
}