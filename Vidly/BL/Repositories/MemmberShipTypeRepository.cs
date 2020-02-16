using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Vidly.BL.Domain;
using Vidly.DAL;

namespace Vidly.BL.Repositories
{
    public class MemmberShipTypeRepository : Repository<MemberShipType>, IMemmberShipTypeRepository
    {
        public MemmberShipTypeRepository(VidlyDbContext context)
            : base(context)
        {

        }
    }
}