using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.BL.Domain
{
    public class RentalDetails
    {
        public int ID { get; set; }
        public int RentalID { get; set; }
        public int MovieID { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public Rental Rental { get; set; }
        public Movie Movie { get; set; }


    }
}