using marmeladka.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using marmeladka.Mappers;
using marmeladka.ViewModel;

namespace marmeladka.Controllers
{
    public class CompanyController : Controller
    {
        public async Task<PartialViewResult> GetCompany()
        {
            CompanyRepository companyRep = new CompanyRepository();
            var company = await Task<IEnumerable<CompanyViewModel>>.Factory.StartNew(() => companyRep.GetAllCompany().Where(x => x.isDelete == false).Select(x => Mapper.Map(x)));
            return PartialView("_CompanyPartialView", company);
        }
    }
}
