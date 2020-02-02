using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Vidly.BL.Domain;

namespace Vidly.DAL
{
    public class VidlyDbContext : IdentityDbContext<ApplicationUser>
    {
        public VidlyDbContext()
            : base("VidlyDBContext")
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }


    }
}