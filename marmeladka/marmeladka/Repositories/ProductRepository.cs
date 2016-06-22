using marmeladka.core.entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace marmeladka.Repositories
{
    public class ProductRepository : BaseRepository<product>
    {
        public ProductRepository()
            : base(new marmeladkaDBEntities1())
        {

        }

        public ProductRepository(marmeladkaDBEntities1 marmDb) : base(marmDb)
        {
            
        }

        public IEnumerable<product> GetProducts()
        {
            return DbSet.ToList();
        }

        public product GetProductById(Guid? id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<product> GetProductsByCategory(Guid id)
        {
            return DbSet.Where(x => x.categoryId == id);
        }

        public IEnumerable<product> GetProductsByListId(List<Guid> list)
        {
            List<product> products = new List<product>();
            if (list != null)
            {
                foreach (var id in list)
                {
                    products.Add(GetProductById(id));
                }
            }
            return products;
        }

        public void UpdateRangeOfProducts(List<product> prod)
        {
            base.UpdateRange(prod);
        }
    }
}