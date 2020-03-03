using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.BL.Domain;
using Vidly.BL.DTOs;
using Vidly.DAL;
using Vidly.DAL.UOW;
using Vidly.ViewModels;

namespace Vidly.BL.APIs
{
    public class NewRentalsController : ApiController
    {
        UnitOFWork UOW = new UnitOFWork(new VidlyDbContext());
        ObjectMapper ObjectMapper = new ObjectMapper();

        [HttpPost]
        public IHttpActionResult NewRental(RentalDTO rentalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var rental = ObjectMapper.Mapper.Map<RentalDTO, Rental>(rentalDto);
            UOW.RentalRepository.Add(rental);
            UOW.Complete();
            UOW.Dispose();

            return Ok();
        }
    }
}
