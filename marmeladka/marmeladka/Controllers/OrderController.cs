using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using marmeladka.DTOs;
using marmeladka.Mappers;
using marmeladka.Repositories;

namespace marmeladka.Controllers
{
    public class OrderController : Controller
    {

        private void CompareAndSortOrder(List<ProductOrderDTO> productByDb, List<ProductDTO> dtos)
        {
            for (int i = 0; i < productByDb.Count; i++)
            {
                foreach (ProductDTO t in dtos)
                {
                    if (productByDb[i].Id == t.Id)
                    {
                        productByDb[i].CurrentWeight = t.CurrentWeight;
                        productByDb[i].TotalCategoryPrice = t.CurrentWeight * (productByDb[i].Retail_price / 100);
                    }
                }
            }
        } 

        [HttpPost]
        public async Task<ActionResult> Cart(List<ProductDTO> dtos)
        {
            if (dtos != null)
            {
                IEnumerable<Guid> products = dtos.Select(x => x.Id);
                ProductRepository productRep = new ProductRepository();
                Task<List<ProductOrderDTO>> task = Task<List<ProductOrderDTO>>.Factory.StartNew(() => productRep.GetProducts()
                                                                                           .Where(x => products.Contains(x.id))
                                                                                           .Select(x => Mapper.MapDto(x))
                                                                                           .ToList());
                var task2 = task.ContinueWith(t => CompareAndSortOrder(task.Result, dtos));

                OrderRequestDTO orderDto = new OrderRequestDTO();

                await task2.ContinueWith(t =>
                {
                    orderDto.ProductList = task.Result;
                });
                
                return PartialView("_ConfirmOrderPartialView", orderDto);
            }
            return HttpNotFound("Как обидно, что-то пошо не так");
        }

        [HttpPost]
        public async Task<ActionResult> AddNewActionOrder(OrderRequestDTO orderRequestDto)
        {
            // nen проверить на с уществование такого юзера с почтой, если такого нет, создать нового
            if (orderRequestDto != null)
            {
                ActionOrderRepository actionRep = new ActionOrderRepository();
                await Task.Factory.StartNew(() => actionRep.CreateActionOrder(orderRequestDto));
                return Content("Заказ оформлен!, спасибо за покупку!");
            }
            return Content("Заказ провалился...");
        }
    }
}
