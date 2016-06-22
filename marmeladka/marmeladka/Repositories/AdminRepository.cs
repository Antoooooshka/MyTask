using marmeladka.core.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marmeladka.Repositories
{
    public class AdminRepository : BaseRepository<Admin>
    {
        public AdminRepository() : base(new marmeladkaDBEntities1())
        {
            
        }

        public IEnumerable<Admin> GetAllAdmin()
        {
            return DbSet.ToList();
        }

        public Admin GetAdminById(Guid id)
        {
            return DbSet.Find(id);
        }
        public async Task<Admin> ChekUniqueAdminName(string name)
        {
            Admin model = await Task<Admin>.Factory.StartNew(() => DbSet.SingleOrDefault(x => x.Name == name));
            return model != null ? model : null;             
        }
    }
}