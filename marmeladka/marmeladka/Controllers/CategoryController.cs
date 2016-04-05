using marmeladka.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using marmeladka.Mappers;

namespace marmeladka.Controllers
{
    public class CategoryController : Controller
    {
        public PartialViewResult GetCategorys()
        {
            CategoryRepository catRep = new CategoryRepository();
            var category = catRep.GetCategory().Select(z => Mapper.Map(z));
            return PartialView("_CategoryPartialView", category);
        }
    }
}
