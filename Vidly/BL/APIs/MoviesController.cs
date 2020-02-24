using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.BL.Domain;
using Vidly.BL.DTOs;
using Vidly.DAL;
using Vidly.DAL.UOW;

namespace Vidly.BL.APIs
{
    public class MoviesController : ApiController
    {
        private readonly UnitOFWork UOW = new UnitOFWork(new VidlyDbContext());
        private readonly ObjectMapper objectMapper = new ObjectMapper();

        //GET api/movies
        [HttpGet]

        public IHttpActionResult GetMovies()
        {
            return Ok(UOW.MovieRepository.GetAll("No")
                .Select(objectMapper.Mapper.Map<Movie, MovieDTO>));
        }

        //GET api/movies/(id)
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var Movie = UOW.MovieRepository.Find(m => m.ID == id, "NO").SingleOrDefault();

            if (Movie == null)
            {
                return NotFound();
            }

            var mappedMovie = objectMapper.Mapper.Map<Movie, MovieDTO>(Movie);

            return Ok(mappedMovie);
        }

        //POST api/movies/
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Movie = objectMapper.Mapper.Map<MovieDTO, Movie>(movieDTO);

            UOW.MovieRepository.Add(Movie);
            UOW.Complete();
            UOW.Dispose();

            return Created(new Uri(Request.RequestUri + "/" + Movie.ID), movieDTO);
        }

        //PUT api/movies/(id)
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var selectedMovie = UOW.MovieRepository.Find(m => m.ID == id, "No").SingleOrDefault();
            if (selectedMovie == null)
            {
                return NotFound();
            }

            objectMapper.Mapper.Map(movieDTO, selectedMovie);
            selectedMovie.ID = id;
            UOW.MovieRepository.Update(selectedMovie);
            UOW.Complete();
            UOW.Dispose();

            return Ok();
        }

        //Delete api/movies/(id)
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var selectedMovie = UOW.MovieRepository.Find(m => m.ID == id, "no").SingleOrDefault();
            if (selectedMovie == null)
                return NotFound();
            UOW.MovieRepository.Remove(selectedMovie);
            UOW.Complete();
            UOW.Dispose();

            return Ok();
        }
    }
}
