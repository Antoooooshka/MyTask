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
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cart(List<ProductDTO> dtos)
        {
            if (dtos != null)
                Session["basket"] = dtos;
            IEnumerable<Guid> products = dtos.Select(x => x.Id);
            ProductRepository productRep = new ProductRepository();
            List<ProductOrderDTO> productByDb = productRep.GetProducts().Where(x => products.Contains(x.id)).Select(x => Mapper.DtoMap(x)).ToList();
            for (int i = 0; i < productByDb.Count; i++)
            {
                foreach (ProductDTO t in dtos)
                {
                    if (productByDb[i].Id == t.Id)
                    {
                        productByDb[i].ProductWeight = t.ProductWeight;
                        productByDb[i].TotalPrice = t.ProductWeight * (productByDb[i].Retail_price / 100);
                    }
                }
            }
            OrderRequestDTO orderDto = new OrderRequestDTO();
            orderDto.ProductList = productByDb;
            return PartialView("_ConfirmOrderPartialView", orderDto);
        }

        [HttpPost]
        public string Order(OrderRequestDTO orderRequestDto)
        {
            if (orderRequestDto != null)
            {
                UserRepository userRep = new UserRepository();
                userRep.Add(new user
                {
                    id = Guid.NewGuid(),
                    adress = orderRequestDto.Adress,
                    email = orderRequestDto.Email,
                    name = orderRequestDto.Name,
                    second_name = orderRequestDto.Second_name,
                    postcode = orderRequestDto.Postcode
                });
               return "Спасибо. Ваш заказ записан!";
            }
            return "Что-то пошло не так";
        }

    }
}
