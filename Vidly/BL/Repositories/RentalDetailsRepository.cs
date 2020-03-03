using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DAL;

namespace Vidly.BL.Repositories
{
    public class RentalDetailsRepository : Repository<RentalDetailsRepository>, IRentalDetailsRepository
    {
        public RentalDetailsRepository(VidlyDbContext context)
        : base(context)
        {

        }
    }
}