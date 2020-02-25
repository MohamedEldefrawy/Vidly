﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.BL.Domain;
using Vidly.BL.DTOs;

namespace Vidly.BL
{
    public class ObjectMapper
    {
        public IMapper Mapper { get; set; }
        public ObjectMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>();
                cfg.CreateMap<CustomerDTO, Customer>();
                cfg.CreateMap<Movie, MovieDTO>();
                cfg.CreateMap<MovieDTO, Movie>();
                cfg.CreateMap<MemberShipType, MembershipDTO>();
            });

            this.Mapper = config.CreateMapper();
        }

    }
}