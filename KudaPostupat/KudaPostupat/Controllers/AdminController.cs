using KudaPostupat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KudaPostupat.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddUniversityForm()
        {
            return View();
        }

        [HttpGet]
        private void AddUniversity(UniversityViewModel viewModel) // TODO: Save To DB 
        {

        }

        private void AddCountry()
        {

        }
    }
}