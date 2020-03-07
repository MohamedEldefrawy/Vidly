using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.BL.Domain;
using Vidly.BL.DTOs;

namespace Vidly.ViewModels
{
    public class NewRentalsViewModel
    {
        public int LastIdentValue { get; set; }
        public List<MovieDTO> Movies { get; set; }
        public List<CustomerDTO> Customers { get; set; }

        [Display(Name = "Return date")]
        public DateTime? ReturnDate { get; set; }


    }
}