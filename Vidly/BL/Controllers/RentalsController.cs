﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.BL.Roles;

namespace Vidly.BL.Controllers
{
    [Authorize(Roles = RoleNames.CanManageMovies)]
    public class RentalsController : Controller
    {
        // GET: Rentals
        public ActionResult New()
        {
            return View();
        }
    }
}