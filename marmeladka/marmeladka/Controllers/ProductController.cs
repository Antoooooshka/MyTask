using marmeladka.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using marmeladka.Mappers;

namespace marmeladka.Controllers
{
    public class ProductController : Controller
    {
        public PartialViewResult GetProducts()
        {
            ProductRepository productRep = new ProductRepository();
            var product = productRep.GetProducts().Select(x => Mapper.Map(x));
            return PartialView("_ProductPartialView",product);
        }

    }
}
