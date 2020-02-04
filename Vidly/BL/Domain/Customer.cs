using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.BL.Domain
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsetter { get; set; }
        public MemberShipType MemberShipType { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}