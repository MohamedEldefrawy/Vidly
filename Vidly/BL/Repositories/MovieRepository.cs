using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.BL.Domain;
using Vidly.DAL;
using System.Data.Entity;

namespace Vidly.BL.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private VidlyDbContext context;
        public MovieRepository(VidlyDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public void Update(Movie movie)
        {
            this.context.Movies.Attach(movie);
            this.context.Entry(movie).State = EntityState.Modified;
        }
    }
}