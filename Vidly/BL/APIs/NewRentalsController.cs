using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Vidly.BL.Domain;
using Vidly.BL.DTOs;
using Vidly.BL.Roles;
using Vidly.DAL;
using Vidly.DAL.UOW;
using Vidly.ViewModels;

namespace Vidly.BL.APIs
{
    public class NewRentalsController : ApiController
    {
        private readonly UnitOFWork UOW = new UnitOFWork(new VidlyDbContext());
        private readonly ObjectMapper ObjectMapper = new ObjectMapper();


        // /api/newrental
        [HttpPost]
        public IHttpActionResult NewRental(RentalDTO rentalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            foreach (var rentDetail in rentalDto.RentalDetails)
            {
                if (UOW.MovieRepository.Find(m => m.ID == rentDetail.MovieID, ChildrenOfEntities.NoChildren)
                    .SingleOrDefault().NumberInStock < rentDetail.quantity)
                {
                    return BadRequest("Movie is not available");
                }
            }

            UOW.RentalRepository.Add(ObjectMapper.Mapper.Map<RentalDTO, Rental>(rentalDto));
            UOW.Complete();
            UOW.Dispose();

            return Ok();
        }


        // /api/newrental
        [HttpGet]

        public IHttpActionResult NewREental()
        {
            return Ok(new
            {
                customers = UOW.CustomerRepository.GetAll(ChildrenOfEntities.NoChildren),
                movies = UOW.MovieRepository.GetAll(ChildrenOfEntities.Genre),
            });
        }
    }
}
