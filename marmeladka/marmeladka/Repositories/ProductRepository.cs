using marmeladka.core.entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace marmeladka.Repositories
{
    public class ProductRepository : BaseRepository<product>
    {
        public ProductRepository() : base(new marmeladkaDBEntities1())
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

    }
}