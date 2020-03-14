using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vidly.BL.Domain;
using Vidly.DAL;

namespace Vidly.BL.Repositories
{
    public class UsersRepository : Repository<ApplicationUser>, IUserRepository
    {
        private VidlyDbContext context;
        public UsersRepository(VidlyDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public void Update(ApplicationUser user)
        {
            this.context.Users.Attach(user);
            this.context.Entry(user).State = EntityState.Modified;
        }
    }

}