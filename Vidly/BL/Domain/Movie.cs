using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.BL.Domain
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        public int NumberInStock { get; set; }
        public Genre Genre { get; set; }
    }
}