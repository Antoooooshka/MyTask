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
            var products = productRep.GetProducts().Select(x => Mapper.MapDto(x));
            return PartialView("_ProductPartialView", products);
        }

        public ActionResult GetProductImage(Guid id)
        {
            ProductRepository prodRep = new ProductRepository();
            var image = prodRep.GetProductById(id).img;
            return image != null ? File(image, "image") : null;
        }

        [HttpGet]
        public PartialViewResult GetProductsByCategory(Guid id)
        {
            if (id != Guid.Empty)
            {
                ProductRepository prodRep = new ProductRepository();
                var products = prodRep.GetProductsByCategory(id).Select(x => Mapper.MapDto(x));
                return PartialView("_ProductPartialView", products);
            }
            return GetProducts();

        }

    }
}
