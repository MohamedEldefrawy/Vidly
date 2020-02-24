using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.BL.DTOs
{
    public class MovieDTO
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }


        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }


        [Required]

        public int GenreID { get; set; }

    }
}