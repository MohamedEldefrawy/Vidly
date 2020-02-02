using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidly.BL.Repositories;

namespace Vidly.BL.UOW
{
    public interface IUnitOFWork
    {
        ICustomerRepository CustomerRepository { get; }
        IMovieRepository MovieRepository { get; }
        int Complete();
    }
}
