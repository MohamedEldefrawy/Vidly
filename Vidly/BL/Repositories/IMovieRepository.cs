﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidly.BL.Domain;

namespace Vidly.BL.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        void Update(Movie movie);
    }
}
