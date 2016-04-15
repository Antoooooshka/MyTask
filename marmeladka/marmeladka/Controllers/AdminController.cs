using marmeladka.Mappers;
using marmeladka.AdminServise;
using marmeladka.Repositories;
using marmeladka.Validator;
using marmeladka.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace marmeladka.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        [AllowAnonymous]
        public ActionResult LoginForm()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string name, string password) // переделать с верификацией пароля и модели
        {
            AdminRepository admRep = new AdminRepository();
            var admin = admRep.ChekUniqueAdminName(name);
            if (admin != null)
            {

                FormsAuthentication.SetAuthCookie(name, false);
            }
            return RedirectToAction("Administration");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult GetAllAdmin()
        {
            AdminRepository admRep = new AdminRepository();
            var viewAdmin = admRep.GetAllAdmin().Select(x => Mapper.Map(x));
            return View(viewAdmin);
        }
        public ActionResult AddAdminForm()
        {
            return PartialView("_AddAdminPartialView");
        }

        [HttpPost]
        public ActionResult AddAdmin(AdminViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                AdminRepository admRep = new AdminRepository();
                if (admRep.ChekUniqueAdminName(viewModel.Name) == null)
                {
                    var admin = Mapper.Map(viewModel);
                    admin.Id = Guid.NewGuid();
                    admin.Salt = Servise.CreateSalt();
                    admin.Password = Servise.GetHash(viewModel.Password, admin.Salt);
                    admRep.Add(admin);
                    admRep.Savechanges();
                }
                else 
                {
                    // отправить, что мол такое имя уже есть
                }

            }
            else 
            {
                // отправить ошибки модели
            }
            return RedirectToAction("GetAllAdmin");
        }
        public ActionResult DeleteAdmin(Guid id)
        {
            AdminRepository admRep = new AdminRepository();
            var admin = admRep.Delete(id);
            if (admin != null)
                admRep.Savechanges();
            return RedirectToAction("GetAllAdmin");

        }

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
            var company = compRepository.GetAllCompany().Where(x => x.isDelete == false).Select(x => Mapper.Map(x));
            return View(company);
        }
        public ActionResult DeleteCompany(Guid id)
        {
            CompanyRepository compRes = new CompanyRepository();
            var company = compRes.GetCompanyById(id);
            if (company != null)
            {
                compRes.Update(company);
                company.isDelete = true;
                compRes.Savechanges();
            }
            return RedirectToAction("GetAllCompany", "Admin");
        }
        public ActionResult GetAllCategories()
        {
            CategoryRepository catRep = new CategoryRepository();
            var category = catRep.GetAllCategory().Where(x => x.isDelete == false).Select(x => Mapper.Map(x));
            return View(category);
        }
        public ActionResult DeleteCategory(Guid id)
        {
            CategoryRepository catRep = new CategoryRepository();
            var category = catRep.GetCategoryById(id);
            if (category != null)
            {
                catRep.Update(category);
                category.isDelete = true;
                catRep.Savechanges();
            }
            return RedirectToAction("GetAllCategories", "Admin");
        }
        public ActionResult GetAllProduct()
        {
            ProductRepository prodRep = new ProductRepository();
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

        [HttpGet]
        public ActionResult GetAddOrUpdateCategoryForm(Guid? id)
        {
            CategoryRepository catRep = new CategoryRepository();
            if (id != null)
            {
                var viewModel = Mapper.Map(catRep.GetCategoryById(id));
                return PartialView("_AddCategoryPartialView", viewModel);
            }
            else
            {
                return PartialView("_AddCategoryPartialView", new CategoryViewModel { Id = Guid.Empty, IsDelete = false });
            }

        }
        [HttpPost]
        public ActionResult AddOrUpdateCategory(CategoryViewModel viewModel)
        {
            if (Validation.Validate(viewModel))
            {
                CategoryRepository catRep = new CategoryRepository();
                if (viewModel.Id == Guid.Empty)
                {
                    var category = Mapper.Map(viewModel);
                    category.id = Guid.NewGuid();
                    catRep.Add(category);
                    catRep.Savechanges();
                }
                else
                {
                    var category = Mapper.Map(viewModel);
                    catRep.Update(category);
                    catRep.Savechanges();
                }
            }
            return RedirectToAction("GetAllCategories");
        }

        [HttpGet]
        public ActionResult GetAddOrUpdateComanyForm(Guid? id)
        {
            CompanyRepository compRes = new CompanyRepository();
            if (id != null)
            {
                var viewModel = Mapper.Map(compRes.GetCompanyById(id));
                return PartialView("_AddCompanyPartialView", viewModel);
            }
            else
                return PartialView("_AddCompanyPartialView", new CompanyViewModel { Id = Guid.Empty, IsDelete = false });

        }

        [HttpPost]
        public ActionResult AddOrUpdateComany(CompanyViewModel viewModel)
        {
            if (Validation.Validate(viewModel))
            {
                CompanyRepository compRes = new CompanyRepository();
                if (viewModel.Id == Guid.Empty)
                {
                    var company = Mapper.Map(viewModel);
                    company.id = Guid.NewGuid();
                    compRes.Add(company);
                    compRes.Savechanges();
                }
                else
                {
                    var company = Mapper.Map(viewModel);
                    compRes.Update(company);
                    compRes.Savechanges();
                }
            }
            return RedirectToAction("GetAllCompany");
        }

        [HttpGet]
        public ActionResult GetAddOrUpdateProductForm(Guid? id)
        {
            ViewBag.Categories = new CategoryRepository().GetAllCategory().Where(x => x.isDelete == false).Select(item => new SelectListItem { Text = item.name, Value = item.id.ToString() });
            ViewBag.Companies = new CompanyRepository().GetAllCompany().Where(x => x.isDelete == false).Select(item => new SelectListItem { Text = item.name, Value = item.id.ToString() });

            ProductRepository productRes = new ProductRepository();
            if (id != null)
            {
                var viewModels = Mapper.Map(productRes.GetProductById(id));
                return PartialView("_AddProductPartialView", viewModels);
            }
            else
                return PartialView("_AddProductPartialView", new ProductViewModel { Id = Guid.Empty });
        }

        [HttpPost]
        public ActionResult AddOrUpdateProduct(ProductViewModel viewModel)
        {
            ProductRepository prodRep = new ProductRepository();
            if (Validation.Validate(viewModel))
            {
                if (viewModel.Id == Guid.Empty)
                {
                    var product = Mapper.Map(viewModel);
                    product.id = Guid.NewGuid();
                    prodRep.Add(product);
                    prodRep.Savechanges();
                }
                else
                {
                    var product = Mapper.Map(viewModel);
                    prodRep.Update(product);
                    prodRep.Savechanges();
                }
            }
            return RedirectToAction("GetAllProduct");
        }
    }
}
