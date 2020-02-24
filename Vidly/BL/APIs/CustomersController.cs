using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.BL;
using Vidly.BL.Domain;
using Vidly.BL.DTOs;
using Vidly.DAL;
using Vidly.DAL.UOW;

namespace Vidly.BL.APIs
{
    public class CustomersController : ApiController
    {

        UnitOFWork UOW = new UnitOFWork(new VidlyDbContext());
        ObjectMapper objectMapper = new ObjectMapper();

        //Get api/customers
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {

            //CustomerDTO customerDTO = new CustomerDTO
            return Ok(UOW.CustomerRepository.GetAll("MemberShipType")
                .Select(objectMapper.Mapper.Map<Customer, CustomerDTO>));
        }

        //Get api/customers/id
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var selectedCustomer = UOW.CustomerRepository.Find(c => c.ID == id, "NO").SingleOrDefault();
            if (selectedCustomer == null)
            {
                return NotFound();
            }

            var customer = objectMapper.Mapper.Map<Customer, CustomerDTO>(selectedCustomer);
            return Ok(customer);
        }


        //Post api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = objectMapper.Mapper.Map<CustomerDTO, Customer>(customerDTO);

            UOW.CustomerRepository.Add(customer);
            UOW.Complete();
            UOW.Dispose();
            return Created(new Uri(Request.RequestUri + "/" + customer.ID), customerDTO);
        }

        //Put api/customers/id
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            var customer = UOW.CustomerRepository.Find(c => c.ID == id, "No").SingleOrDefault();
            if (customer == null)
            {
                return NotFound();
            }

            objectMapper.Mapper.Map(customerDTO, customer);
            customer.ID = id;
            UOW.CustomerRepository.Update(customer);
            UOW.Complete();
            UOW.Dispose();

            return Ok();
        }

        //Delete api/customers/id
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var selectedCustomer = UOW.CustomerRepository.Find(c => c.ID == id, "No").SingleOrDefault();

            if (selectedCustomer == null)
            {
                return NotFound();
            }

            UOW.CustomerRepository.Remove(selectedCustomer);
            UOW.Complete();
            UOW.Dispose();

            return Ok();
        }
    }
}
