using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.BL.Domain;

namespace Vidly.ViewModels
{
    public class CustomerViewModel
    {
        public IEnumerable<MemberShipType> MemmberShipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}