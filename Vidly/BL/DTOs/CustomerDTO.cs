using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.BL.DTOs
{
    public class CustomerDTO
    {
        public int ID { get; set; }
        
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsetter { get; set; }


        public byte MemmberShipTypeID { get; set; }

        //[Min18YearsIfMember]
        public DateTime BirthDate { get; set; }
    }
}