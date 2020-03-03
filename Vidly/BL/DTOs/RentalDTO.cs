using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.BL.Domain;

namespace Vidly.BL.DTOs
{
    public class RentalDTO
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public ICollection<RentalDetailsDTO> RentalDetails { get; set; }
    }


}