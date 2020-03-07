using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.BL.Domain;
using Vidly.DAL;

namespace Vidly.BL.Repositories
{
    public class RentalRepository : Repository<Rental>, IRentalRepository
    {
        private VidlyDbContext context;
        public RentalRepository(VidlyDbContext context)
        : base(context)
        {
            this.context = context;
        }

        public int GetCurrentIdentValue()
        {
            var rental = context.Rentals.OrderByDescending(r => r.ID).FirstOrDefault();
            if (rental == null)
            {
                return 0;
            }

            return rental.ID;

        }
    }
}