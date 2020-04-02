using System;
using System.Linq;
using System.Web.Mvc;
using Vidly.BL;
using Vidly.BL.Domain;
using Vidly.BL.Roles;
using Vidly.DAL;
using Vidly.DAL.UOW;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private readonly UnitOFWork UOW = new UnitOFWork(new VidlyDbContext());

        // GET: Customers
        public ActionResult Index()
        {

            if (User.IsInRole(RoleNames.CanManageMovies))
            {
                return View("Index");

            }
            return View("IndexUser");
        }

        public ActionResult Details(int id)
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleNames.CanManageMovies)]

        public ActionResult Update(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var ViewModel = new CustomerViewModel()
                {
                    Customer = customer,
                    MemmberShipTypes = UOW.MemmberShipTypeRepository.GetAll()
                };

                return View("Details", ViewModel);
            }

            UOW.CustomerRepository.Update(customer);
            UOW.Complete();
            UOW.Dispose();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult New()
        {
            var ViewModel = new CustomerViewModel
            {
                Customer = new Customer(),
                MemmberShipTypes = UOW.MemmberShipTypeRepository.GetAll()

            };

            UOW.Dispose();
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleNames.CanManageMovies)]

        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var ViewModel = new CustomerViewModel()
                {
                    Customer = customer,
                    MemmberShipTypes = UOW.MemmberShipTypeRepository.GetAll()
                };

                return View("New", ViewModel);
            }

            UOW.CustomerRepository.Add(new Customer
            {
                BirthDate = customer.BirthDate,
                IsSubscribedToNewsetter = customer.IsSubscribedToNewsetter,
                MemmberShipTypeID = customer.MemmberShipTypeID,
                Name = customer.Name
            });

            UOW.Complete();
            UOW.Dispose();
            return RedirectToAction("Index", "Customers");
        }
    }
}