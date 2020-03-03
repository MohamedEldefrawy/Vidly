using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.BL.DTOs
{
    public class RentalDetailsDTO
    {
        public int ID { get; set; }
        public int RentalID { get; set; }
        public int MovieID { get; set; }

        public decimal unitPrice { get; set; }

        public int quantity { get; set; }
    }
}