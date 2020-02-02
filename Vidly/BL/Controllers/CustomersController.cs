using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.BL.Domain;
using Vidly.DAL;
using Vidly.DAL.UOW;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        UnitOFWork UOW = new UnitOFWork(new VidlyDbContext());

        // GET: Customers
        public ActionResult Index()
        {


            return View(UOW.CustomerRepository.GetAll());
        }

        public ActionResult Details(int id)
        {
            try
            {
                return View(UOW.CustomerRepository.Find(c => c.ID == id).ToList());

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