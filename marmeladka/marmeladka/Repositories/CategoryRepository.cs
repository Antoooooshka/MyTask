using marmeladka.core.entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace marmeladka.Repositories
{
    public class CategoryRepository : BaseRepository<category>
    {
        public CategoryRepository() : base(new marmeladkaDBEntities1())
        {

        }

        public IEnumerable<category> GetCategory() 
        {
           return dbSet.ToList();
        }

        public category GetCategoryById(Guid id)
        {
           return dbSet.Find(id);
        }
    }
}