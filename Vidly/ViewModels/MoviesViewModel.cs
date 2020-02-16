using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.BL.Domain;

namespace Vidly.ViewModels
{
    public class MoviesViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}