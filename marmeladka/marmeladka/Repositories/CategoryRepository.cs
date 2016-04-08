using marmeladka.core.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace marmeladka.Repositories
{
    public class CategoryRepository : BaseRepository<category>
    {
        public CategoryRepository() : base(new marmeladkaDBEntities1())
        {

        }

        public IEnumerable<category> GetAllCategory() 
        {
           return dbSet.ToList();
        }

        public category GetCategoryById(Guid id)
        {
           return dbSet.Find(id);
        }
    }
}