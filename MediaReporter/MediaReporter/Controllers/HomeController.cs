using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaReporter.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult User()
        {
            //char[] separators = { '=', '&' };
            //string[] responseContent = responseString.Split(separators);
            //string accessToken = responseContent[1];
            //int userId = Int32.Parse(responseContent[5]);
            return View();
        }

        private void NearUsers(object[] items)
        {
        }

    }
}
