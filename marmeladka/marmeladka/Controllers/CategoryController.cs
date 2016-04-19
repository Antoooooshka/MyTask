using marmeladka.Repositories;
using System.Linq;
using System.Web.Mvc;
using marmeladka.Mappers;

namespace marmeladka.Controllers
{
    public class CategoryController : Controller
    {
        public PartialViewResult GetCategorys()
        {
            CategoryRepository catRep = new CategoryRepository();
            var viewModel = catRep.GetAllCategory().Where(x => x.isDelete == false).Select(x => Mapper.Map(x));
            return PartialView("_CategoryPartialView", viewModel);
        }
    }
}
