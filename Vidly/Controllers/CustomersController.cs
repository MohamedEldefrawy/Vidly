using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.BL.Domain;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        List<Customer> customers = new List<Customer>
            {
                new Customer{ID = 1,Name = "Mohamed"},
                new Customer{ID = 2,Name="Ahmed"}
        };

        // GET: Customers
        public ActionResult Index()
        {


            return View(customers.ToList());
        }

        public ActionResult Details(int id)
        {
            try
            {
                var selectedcustomer = customers.Where(c => c.ID == id).Single();
                return View(selectedcustomer);

            }
            catch (ArgumentNullException e)
            {

                return HttpNotFound();
            }
            catch (InvalidOperationException e)
            {
                return HttpNotFound();
            }

        }
    }
}