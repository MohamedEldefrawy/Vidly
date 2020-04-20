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
using Vidly.BL.Roles;
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
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customerQuery = UOW.CustomerRepository.GetAll(ChildrenOfEntities.MemberShipType);

            if (!string.IsNullOrWhiteSpace(query))
            {
                customerQuery = customerQuery.Where(c => c.Name.Contains(query)).ToList();
            }

            var customerDTOs = customerQuery.Select(objectMapper.Mapper.Map<Customer, CustomerDTO>);

            return Ok(customerDTOs);
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
        [Authorize(Roles = RoleNames.CanManageMovies)]
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
        [Authorize(Roles = RoleNames.CanManageMovies)]

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
        [Authorize(Roles = RoleNames.CanManageMovies)]

        public IHttpActionResult DeleteCustomer(int id)
        {
            var selectedCustomer = UOW.CustomerRepository.Find(c => c.ID == id).SingleOrDefault();

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
