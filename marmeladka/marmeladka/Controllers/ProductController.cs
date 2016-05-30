using marmeladka.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using marmeladka.Mappers;

namespace marmeladka.Controllers
{
    public class ProductController : Controller
    {
        public PartialViewResult GetProducts()
        {
            ProductRepository productRep = new ProductRepository();
            var product = productRep.GetProducts().Select(x => Mapper.DtoMap(x));
            return PartialView("_ProductPartialView",product);
        }

        public ActionResult GetProductImage(Guid id)
        {
            ProductRepository prodRep = new ProductRepository();
            var image = prodRep.GetProductById(id).img;
            return image != null ? File(image, "image") : null;
        }

    }
}
