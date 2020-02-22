using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.BL.Domain;
using Vidly.DAL;
using System.Data.Entity;

namespace Vidly.BL.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private VidlyDbContext context;
        public CustomerRepository(VidlyDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public void Update(Customer customer)
        {
            this.context.Customers.Attach(customer);
            this.context.Entry(customer).State = EntityState.Modified;
        }
    }
}