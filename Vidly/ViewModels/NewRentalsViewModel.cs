using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.ViewModels
{
    public class NewRentalsViewModel
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int CustomerID { get; set; }

        [Display(Name = "Rent date")]
        public DateTime RentDate { get; set; }

        public int MovieID { get; set; }

    }
}