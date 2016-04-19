using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using marmeladka.core.entities;
using System.Data.Entity;
using marmeladka.ViewModel;
using marmeladka.Repositories;
using marmeladka.Mappers;

namespace marmeladka.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
