using marmeladka.core.entities;
using System.Collections.Generic;
using System.Linq;

namespace marmeladka.Repositories
{
    public class UserRepository : BaseRepository<user>
    {
        public UserRepository() : base(new marmeladkaDBEntities1())
        {
            
        }
        public IEnumerable<user> GetUsers() 
        {
            return DbSet.ToList();
        }
    }
}