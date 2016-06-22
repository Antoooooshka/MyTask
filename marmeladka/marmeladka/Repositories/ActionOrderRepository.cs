using System;
using System.Collections.Generic;
using System.Linq;
using marmeladka.core.entities;
using marmeladka.DTOs;

namespace marmeladka.Repositories
{
    public class ActionOrderRepository : BaseRepository<action_order>
    {

        private readonly UserRepository _userRep;
        private readonly OrderRepository _orderRep;
        private readonly ProductRepository _prodRep;

        #region Controllers
        public ActionOrderRepository() : this(new marmeladkaDBEntities1()) { }

        public ActionOrderRepository(marmeladkaDBEntities1 marmDb) : base(marmDb)
        {
            _userRep = new UserRepository(marmDb);
            _orderRep = new OrderRepository(marmDb);
            _prodRep = new ProductRepository(marmDb);
        }
        #endregion

        public void DeleteActionRangeByOrderId(Guid orderId)
        {
            if (orderId != Guid.Empty)
            {
                DbSet.RemoveRange(DbSet.Where(x => x.order.id == orderId));
                Savechanges();
            }            
        }

        public IEnumerable<action_order> GetAllActionOrder()
        {
            return DbSet.ToList();
        }

        private void ReduceProductWeight(List<action_order> actionOrder)
        {
            List<Guid> guids = actionOrder.Select(x => x.productId).ToList();
            List<product> products = _prodRep.GetProductsByListId(guids).ToList();
            for (int i = 0; i < products.Count; i++)
            {
               products[i].product_weight = products[i].product_weight - (int)actionOrder[i].CurrentProductWeight;
            }
            _prodRep.UpdateRangeOfProducts(products);
        }

        public void CreateActionOrder(OrderRequestDTO dto)
        {
            user user = _userRep.AddUser(dto);
            order order = _orderRep.CreateNewOrder(user, dto);

            List<action_order> actionList = new List<action_order>();

            for (int i = 0; i < dto.ProductList.Count; i++)
            {
                actionList.Add(new action_order
                {
                    id = Guid.NewGuid(),
                    ordersId = order.id,
                    productId = dto.ProductList[i].Id,
                    order = order,
                    CurrentProductWeight = dto.ProductList[i].CurrentWeight
                });
            }

            PerformTransaction(() =>
            {
                ReduceProductWeight(actionList);
                DbSet.AddRange(actionList);
            });
        }
    }
}