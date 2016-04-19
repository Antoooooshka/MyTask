using marmeladka.core.entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace marmeladka.Repositories
{
    public class CompanyRepository : BaseRepository<company>
    {
        public CompanyRepository() : base(new marmeladkaDBEntities1())
        {

        }
        public IEnumerable<company> GetAllCompany()
        {
            return DbSet.ToList();
        }
        public company GetCompanyById(Guid? id)
        {
            return DbSet.Find(id);
        }
    }
}