using marmeladka.core.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace marmeladka.Repositories
{
    public class CompanyRepository : BaseRepository<company>
    {
        public CompanyRepository() : base(new marmeladkaDBEntities1())
        {

        }
        public IEnumerable<company> GetAllCompany()
        {
            return dbSet.ToList();
        }
        public company GetCompanyById(Guid id)
        {
            return dbSet.Find(id);
        }
    }
}