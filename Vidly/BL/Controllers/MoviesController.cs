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

            return View(UOW.MovieRepository.GetAll("Genre"));
        }

        public ActionResult Details(int id)
        {
            try
            {
                MoviesViewModel moviesViewModel = new MoviesViewModel()
                {
                    Movie = UOW.MovieRepository.Find(m => m.ID == id, "Genre").SingleOrDefault(),
                    Genres = UOW.GenreRepository.GetAll("No")
                };

                return View(moviesViewModel);
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

        [HttpPost]
        public ActionResult Update(Movie movie)
        {
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
        public ActionResult Create(Movie movie)
        {
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