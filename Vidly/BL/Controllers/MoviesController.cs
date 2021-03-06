﻿using System;
using System.Linq;
using System.Web.Mvc;
using Vidly.BL;
using Vidly.BL.Domain;
using Vidly.BL.Roles;
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

            if (User.IsInRole(RoleNames.CanManageMovies))
            {
                return View("Index");

            }

            return View("IndexUser");
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleNames.CanManageMovies)]

        public ActionResult Update(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var ViewModel = new MoviesViewModel()
                {
                    Movie = movie,
                    Genres = UOW.GenreRepository.GetAll()
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

        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult New()
        {

            MoviesViewModel moviesView = new MoviesViewModel()
            {
                Genres = UOW.GenreRepository.GetAll(),
            };

            return View(moviesView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleNames.CanManageMovies)]

        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var ViewModel = new MoviesViewModel()
                {
                    Movie = movie,
                    Genres = UOW.GenreRepository.GetAll()
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