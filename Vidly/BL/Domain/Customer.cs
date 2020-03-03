using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.BL.CustomAttributes;

namespace Vidly.BL.Domain
{
    public class Customer
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsetter { get; set; }

        public MemberShipType MemberShipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MemmberShipTypeID { get; set; }

        [Display(Name = "Birthdate")]
        [Min18YearsIfMember]
        public DateTime BirthDate { get; set; }

        public ICollection<Rental> Rentals { get; set; }

    }
}