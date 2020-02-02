using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.BL.Domain;
using Vidly.BL.Repositories;
using Vidly.BL.UOW;

namespace Vidly.DAL.UOW
{
    public class UnitOFWork : IUnitOFWork, IDisposable
    {
        public ICustomerRepository CustomerRepository { get; private set; }

        public IMovieRepository MovieRepository { get; private set; }
        private readonly VidlyDbContext VidlyModel;

        public UnitOFWork(VidlyDbContext VidlyModel)
        {
            this.VidlyModel = VidlyModel;
            this.CustomerRepository = new CustomerRepository(VidlyModel);
            this.MovieRepository = new MovieRepository(VidlyModel);
        }

        public int Complete()
        {
            return this.VidlyModel.SaveChanges();
        }

        public void Dispose()
        {
            this.VidlyModel.Dispose();
        }
    }
}