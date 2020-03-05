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

        public IMemmberShipTypeRepository MemmberShipTypeRepository { get; set; }

        public IGenreRepository GenreRepository { get; set; }


        public IRentalRepository RentalRepository { get; set; }

        public IRentalDetailsRepository RentalDetailsRepository { get; set; }

        private readonly VidlyDbContext VidlyModel;

        public UnitOFWork(VidlyDbContext VidlyModel)
        {
            this.VidlyModel = VidlyModel;
            this.CustomerRepository = new CustomerRepository(VidlyModel);
            this.MovieRepository = new MovieRepository(VidlyModel);
            this.MemmberShipTypeRepository = new MemmberShipTypeRepository(VidlyModel);
            this.GenreRepository = new GenreRepository(VidlyModel);
            this.RentalRepository = new RentalRepository(VidlyModel);
            this.RentalDetailsRepository = new RentalDetailsRepository(VidlyModel);
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