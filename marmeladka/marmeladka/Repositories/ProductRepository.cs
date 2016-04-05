using marmeladka.core.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace marmeladka.Repositories
{
    public class ProductRepository : BaseRepository<product>
    {
        public ProductRepository() : base(new marmeladkaDBEntities1())
        {

        }

        public IEnumerable<product> GetProducts() 
        {
            return dbSet.ToList();
        }

    }
}