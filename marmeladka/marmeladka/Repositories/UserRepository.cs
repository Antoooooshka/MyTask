using marmeladka.core.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace marmeladka.Repositories
{
    public class UserRepository : BaseRepository<user>
    {
        public UserRepository() : base(new marmeladkaDBEntities1())
        {
            
        }
        public IEnumerable<user> GetUsers() 
        {
            return dbSet.ToList();
        }
    }
}