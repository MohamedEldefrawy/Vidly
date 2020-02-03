using System;
using System.Linq;
using System.Web.Mvc;
using Vidly.DAL;
using Vidly.DAL.UOW;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private readonly UnitOFWork UOW = new UnitOFWork(new VidlyDbContext());
        // GET: Movies
        public ActionResult Index()
        {

            return View(UOW.MovieRepository.GetAll(null));
        }

        public ActionResult Details(int id)
        {
            try
            {
                return View(UOW.MovieRepository.Find(m => m.ID == id, null).ToList());
            }
            catch (InvalidOperationException e)
            {

                return HttpNotFound();
            }
            catch (ArgumentNullException e)
            {
                return HttpNotFound();
            }
        }
    }
}