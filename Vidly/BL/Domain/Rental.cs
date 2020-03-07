using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.BL.Domain
{
    public class Rental
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string EmployeeID { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Customer Customer { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<RentalDetails> RentalDetails { get; set; }
    }
}