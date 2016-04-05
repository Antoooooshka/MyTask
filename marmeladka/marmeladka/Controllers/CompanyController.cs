using marmeladka.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using marmeladka.Mappers;

namespace marmeladka.Controllers
{
    public class CompanyController : Controller
    {
        public PartialViewResult GetCompany()
        {
            CompanyRepository companyRep = new CompanyRepository();
            var company = companyRep.GetCompany().Where(x => x.isDelete == false).Select(x => Mapper.Map(x));
            return PartialView("_CompanyPartialView", company);
        }
    }
}
