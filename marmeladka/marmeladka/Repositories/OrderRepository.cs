using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using marmeladka.core.entities;
using marmeladka.DTOs;

namespace marmeladka.Repositories
{
    public class OrderRepository : BaseRepository<order>
    {
        #region Controllers
        public OrderRepository() : this(new marmeladkaDBEntities1()) { }

        public OrderRepository(marmeladkaDBEntities1 marmDb)
            : base(marmDb)
        {

        }
        #endregion

        public order CreateNewOrder(user userModel, OrderRequestDTO dto)
        {
            order order = new order
            {
                id = Guid.NewGuid(),
                order_time = DateTime.Now,
                user = userModel,
                userId = userModel.id,
                order_price = dto.OrderPrice,
                OrderWeight = CalculateFullOrderWeight(dto)
            };
            return order;
        }

        private int CalculateFullOrderWeight(OrderRequestDTO dto)
        {
            return dto.ProductList.Sum(t => t.CurrentWeight);
        }

        public int? CalculateFullWeight()
        {
            int? weight = DbSet.Sum(x => x.OrderWeight);
            return weight;
        }

        public decimal? CalculateFullOrdersCost()
        {
            return DbSet.Sum(x => x.order_price);
        }

        public override order Delete(Guid id)
        {
            ActionOrderRepository actionRep = new ActionOrderRepository();

            PerformTransaction(() =>
            {
                actionRep.DeleteActionRangeByOrderId(id);
                base.Delete(id); 
            });
            return null;
        }
    }
}