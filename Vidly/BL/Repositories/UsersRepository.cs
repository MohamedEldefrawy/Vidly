﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.BL.Domain;
using Vidly.DAL;

namespace Vidly.BL.Repositories
{
    public class UsersRepository : Repository<ApplicationUser>,IUserRepository
    {
        public UsersRepository(VidlyDbContext context)
            : base(context)
        {

        }
    }

}