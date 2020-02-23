﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.BL.Domain
{
    public class Movie
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock")]

        [Required]
        public int NumberInStock { get; set; }

        public Genre Genre { get; set; }

        [Required]

        public int GenreID { get; set; }
    }
}