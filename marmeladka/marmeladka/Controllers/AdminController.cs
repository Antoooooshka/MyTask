using marmeladka.Mappers;
using marmeladka.Repositories;
using marmeladka.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace marmeladka.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Administration()
        {
            return View();
        }

        public ActionResult GetAllUsers()
        {
            UserRepository userRepository = new UserRepository();
            var user = userRepository.GetUsers().Select(x => Mapper.Map(x));
            return PartialView("_UserPartialView", user);
        }

        public ActionResult DeleteUser(Guid id)
        {
            UserRepository userRep = new UserRepository();
            var user = userRep.Delete(id);
            if (user != null)
                userRep.Savechanges();
            return RedirectToAction("GetAllUsers", "Admin");
        }

        public ActionResult GetAllCompany()
        {
            CompanyRepository compRepository = new CompanyRepository();
            var company = compRepository.GetCompany().Where(x => x.isDelete == false).Select(x => Mapper.Map(x));
            return View(company);
        }
        public ActionResult DeleteCompany(Guid id)
        {
            CompanyRepository compRes = new CompanyRepository();
            var company = compRes.Delete(id);
            if (company != null)
                compRes.Savechanges();
            return RedirectToAction("GetAllCompany", "Admin");
        }

        public ActionResult GetAllCategories()
        {
            CategoryRepository catRep = new CategoryRepository();
            var category = catRep.GetCategory().Select(x => Mapper.Map(x));
            return View(category);
        }
        public ActionResult DeleteCategory(Guid id)
        {
            CategoryRepository catRep = new CategoryRepository();
            var category = catRep.Delete(id);
            if (category != null)
                catRep.Savechanges();
            return RedirectToAction("GetAllCategories", "Admin");
        }

        public ActionResult GetAllProduct()
        {
            ProductRepository prodRep = new ProductRepository();
            ViewBag.Categories = new CategoryRepository().GetCategory().Select(item => new SelectListItem { Text = item.name, Value = item.id.ToString() });
            ViewBag.Companies = new CompanyRepository().GetCompany().Select(item => new SelectListItem { Text = item.name, Value = item.id.ToString() });
            var product = prodRep.GetProducts().Select(x => Mapper.Map(x));
            return View(product);
        }
        public ActionResult DeleteProduct(Guid id)
        {
            ProductRepository productRep = new ProductRepository();
            var product = productRep.Delete(id);
            if (product != null)
                productRep.Savechanges();
            return RedirectToAction("GetAllProduct", "Admin");
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryViewModel viewModel)
        {
            CategoryRepository catRep = new CategoryRepository();

            var category = Mapper.Map(viewModel);
            if (ModelState.IsValid)
            {
                catRep.Add(category);
                catRep.Savechanges();
            }

            return RedirectToAction("GetAllCategories", "Admin");
        }
        
        [HttpPost]
        public ActionResult AddCompany(CompanyViewModel viewModel)
        {
            CompanyRepository compRes = new CompanyRepository();
            var company = Mapper.Map(viewModel);
            if (ModelState.IsValid)
            {
                compRes.Add(company);
                compRes.Savechanges();
            }
            return RedirectToAction("GetAllCompany", "Admin");
        }

        [HttpPost]
        public ActionResult AddProduct(ProductViewModel viewModel)
        {
            ProductRepository productRep = new ProductRepository();
            var product = Mapper.Map(viewModel);
            if (ModelState.IsValid)
            {
                productRep.Add(product);
                productRep.Savechanges();
            }
            return RedirectToAction("GetAllProduct", "Admin");
        }

        [HttpGet]
        public ActionResult UpdateCategory(Guid id)
        {
            if (id == null) { return HttpNotFound(); }
            CategoryRepository catRep = new CategoryRepository();
            var viewModel = Mapper.Map(catRep.GetCategoryById(id));
            return PartialView("_UpdateCategoryPartialView", viewModel);
        }

        [HttpPost]
        public ActionResult UpdateCategory(CategoryViewModel viewModel)
        {
            CategoryRepository catRep = new CategoryRepository();
            var category = Mapper.Map(viewModel);
            if (ModelState.IsValid)
            {
                catRep.Update(category);
                catRep.Savechanges();
            }
            return RedirectToAction("GetAllCategory","Admin");
        }
    }
}
