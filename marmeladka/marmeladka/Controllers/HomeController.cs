using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using marmeladka.core.entities;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using marmeladka.DTOs;
using marmeladka.ViewModel;
using marmeladka.Repositories;
using marmeladka.Mappers;

namespace marmeladka.Controllers
{

    public class HomeController : Controller
    {
        //private static Dictionary<string, List<ProductDTO>> sessionOrder = new Dictionary<string, List<ProductDTO>>();
        private static List<ProductDTO> product = new List<ProductDTO>();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public bool AddToRecycle(ProductDTO dto)
        {          
            bool flag = false;
            if (product.Count == 0)
            {
                product.Add(dto);
            }
            else
            {
                for (int i = 0; i < product.Count; i++)
                {
                    if (product[i].Id == dto.Id)
                    {
                        product[i].ProductWeight += 100;
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    product.Add(dto);
                }
            }
            //sessionOrder.Add(Session.SessionID, product);
            return true;
        }

        public ActionResult Order()
        {
            IEnumerable<Guid> products = HomeController.product.Select(x => x.Id);
            ProductRepository productRep = new ProductRepository();
            var product = productRep.GetProducts().Where(x => products.Contains(x.id)).Select(x => Mapper.Map(x)); // тут косяк
            return View("Order", product);
        }

    }
}
