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
            var rental = context.Rentals.LastOrDefault();
            if (rental == null)
            {
                throw new NullReferenceException("There are no Rentlas yet.");
            }

            return rental.ID;

        }
    }
}