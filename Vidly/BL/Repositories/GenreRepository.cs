using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.BL.Domain;
using Vidly.DAL;

namespace Vidly.BL.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(VidlyDbContext context)
            : base(context)
        {

        }
    }
}