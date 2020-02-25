using System;
using System.Linq;
using System.Web.Mvc;
using Vidly.BL.Domain;
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


            return View();
        }

        public ActionResult Details(int id)
        {
            try
            {
                CustomerViewModel customerViewModel = new CustomerViewModel()
                {
                    Customer = UOW.CustomerRepository.Find(c => c.ID == id, "MemberShipType").SingleOrDefault(),
                    MemmberShipTypes = UOW.MemmberShipTypeRepository.GetAll("No")
                };

                return View(customerViewModel);

            }
            catch (ArgumentNullException)
            {

                return HttpNotFound();
            }
            catch (InvalidOperationException)
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var ViewModel = new CustomerViewModel()
                {
                    Customer = customer,
                    MemmberShipTypes = UOW.MemmberShipTypeRepository.GetAll("No")
                };

                return View(ViewModel);
            }

            UOW.CustomerRepository.Update(customer);
            UOW.Complete();
            UOW.Dispose();

            return RedirectToAction("Index");
        }

        public ActionResult New()
        {
            var ViewModel = new CustomerViewModel
            {
                Customer = new Customer(),
                MemmberShipTypes = UOW.MemmberShipTypeRepository.GetAll("No")

            };

            UOW.Dispose();
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var ViewModel = new CustomerViewModel()
                {
                    Customer = customer,
                    MemmberShipTypes = UOW.MemmberShipTypeRepository.GetAll("No")
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