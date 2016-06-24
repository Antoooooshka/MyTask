using marmeladka.Mappers;
using marmeladka.AdminServise;
using marmeladka.Repositories;
using marmeladka.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using marmeladka.core.entities;

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
        public async Task<ActionResult> Login(string name, string password)
        {
            AdminRepository admRep = new AdminRepository();
            var admin = await admRep.ChekUniqueAdminName(name);         
            if (admin != null && admin.Password == Servise.GetHash(password, admin.Salt))
            {
                FormsAuthentication.SetAuthCookie(name, false);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Пароль не совпадает");
            }
            return RedirectToAction("Administration");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        public async Task<ActionResult> GetAllAdmin()
        {
            AdminRepository admRep = new AdminRepository();
            IEnumerable<AdminViewModel> viewAdmin = await Task<IEnumerable<AdminViewModel>>.Factory.StartNew(() =>
            {
                return admRep.GetAllAdmin().Select(x => Mapper.Map(x));
            });
            return View(viewAdmin);
        }
        public ActionResult AddAdminForm()
        {
            return PartialView("_AddAdminPartialView");
        }

        [HttpPost]
        public async Task<ActionResult> AddAdmin(AdminViewModel viewModel) // сходить в базу и смотреть главную сущность
        {
            if (ModelState.IsValid)
            {
                AdminRepository admRep = new AdminRepository();
                var model = await admRep.ChekUniqueAdminName(viewModel.Name);
                if (model == null)
                {
                    var admin = Mapper.Map(viewModel);
                    admin.Id = Guid.NewGuid();
                    admin.Salt = Servise.CreateSalt();
                    admin.Password = Servise.GetHash(viewModel.Password, admin.Salt);
                    admin.CanBeDeleted = true;
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

        public async Task<ActionResult> Administration()
        {
            ActionOrderRepository actionRep = new ActionOrderRepository();
            OrderRepository orderRep = new OrderRepository();

            var action = await Task<Dictionary<Guid, List<ActionViewModel>>>.Factory.StartNew(() =>
            {
                return actionRep.GetAllActionOrder().
                    Select(x => Mapper.Map(x)).
                    GroupBy(x => x.OrdersId).
                    ToDictionary(k => k.Key, j => j.ToList());
            });
            ViewBag.FullOrdersWeight = await Task<int?>.Factory.StartNew(() => orderRep.CalculateFullWeight());
            ViewBag.FullOrdersCost = await Task<decimal?>.Factory.StartNew(() => orderRep.CalculateFullOrdersCost());

            return View(action);
        }

        public ActionResult DeleteOrder(Guid id)
        {
            OrderRepository orderRep = new OrderRepository();
            orderRep.Delete(id);
            return RedirectToAction("Administration", "Admin");
        }

        public async Task<ActionResult> GetAllUsers()
        {
            UserRepository userRepository = new UserRepository();
            var models = await Task<IEnumerable<UserViewModel>>.Factory.StartNew(() => userRepository.GetUsers().Select(x => Mapper.Map(x)));
            return PartialView("_UserPartialView", models);
        }
        public ActionResult DeleteUser(Guid id)
        {
            UserRepository userRep = new UserRepository();
            var user = userRep.Delete(id);
            if (user != null)
                userRep.Savechanges();
            return RedirectToAction("GetAllUsers", "Admin");
        }
        public async Task<ActionResult> GetAllCompany()
        {
            CompanyRepository compRepository = new CompanyRepository();
            var company = await Task<IEnumerable<CompanyViewModel>>.Factory.StartNew(() =>
            {
                return compRepository.GetAllCompany().Where(x => x.isDelete == false).Select(x => Mapper.Map(x));
            });
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
        public async Task<ActionResult> GetAllCategories()
        {
            CategoryRepository catRep = new CategoryRepository();
            var category = await Task<IEnumerable<CategoryViewModel>>.Factory.StartNew(() => catRep.GetAllCategory().Where(x => x.isDelete == false).Select(x => Mapper.Map(x)));
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
        public async Task<ActionResult> GetAllProduct()
        {
            ProductRepository prodRep = new ProductRepository();
            var product = await Task<IEnumerable<ProductViewModel>>.Factory.StartNew(() => prodRep.GetProducts().Select(x => Mapper.Map(x)));
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
        public ActionResult GetOrUpdateCategoryForm(Guid? id)
        {
            CategoryRepository catRep = new CategoryRepository();
            if (id != null)
            {
                var viewModel = Mapper.Map(catRep.GetCategoryById(id));
                return PartialView("_AddCategoryPartialView", viewModel);
            }
            return PartialView("_AddCategoryPartialView", new CategoryViewModel { Id = Guid.Empty, IsDelete = false });
        }
        [HttpPost]
        public async Task<ActionResult> AddOrUpdateCategory(CategoryViewModel viewModel)
        {
            if (ViewData.ModelState["Name"].Errors.Count == 0)
            {
                CategoryRepository catRep = new CategoryRepository();
                if (viewModel.Id == Guid.Empty)
                {
                    var category = Mapper.Map(viewModel);
                    category.id = Guid.NewGuid();
                    var task = Task.Factory.StartNew(() => catRep.Add(category));
                    await task.ContinueWith(t => catRep.Savechanges());
                }
                else
                {
                    var task = Task<category>.Factory.StartNew(() => catRep.GetCategoryById(viewModel.Id));
                    await task.ContinueWith(t =>
                    {
                        Mapper.Map(t.Result, viewModel);
                        catRep.Savechanges();
                    });
                }
            }
            return RedirectToAction("GetAllCategories");
        }

        [HttpGet]
        public async Task<ActionResult> GetAddOrUpdateComanyForm(Guid? id)
        {
            CompanyRepository compRes = new CompanyRepository();
            if (id != null)
            {
                var viewModel = await Task<CompanyViewModel>.Factory.StartNew(() => Mapper.Map(compRes.GetCompanyById(id)));
                return PartialView("_AddCompanyPartialView", viewModel);
            }
            return PartialView("_AddCompanyPartialView", new CompanyViewModel { Id = Guid.Empty, IsDelete = false });
        }

        [HttpPost]
        public async Task<ActionResult> AddOrUpdateComany(CompanyViewModel viewModel)
        {
            if (ViewData.ModelState["Name"].Errors.Count == 0)
            {
                CompanyRepository compRes = new CompanyRepository();
                if (viewModel.Id == Guid.Empty)
                {
                    var company = Mapper.Map(viewModel);
                    company.id = Guid.NewGuid();
                    Task task = Task.Factory.StartNew(() =>
                    {
                        compRes.Add(company);
                    });
                    await task.ContinueWith(t => compRes.Savechanges());
                }
                else
                {
                    Task<company> task = Task<company>.Factory.StartNew(() => compRes.GetCompanyById(viewModel.Id));
                    await task.ContinueWith(t =>
                    {
                        Mapper.Map(t.Result, viewModel);
                        compRes.Savechanges();
                    });
                }
            }
            return RedirectToAction("GetAllCompany");
        }

        [HttpGet]
        public async Task<ActionResult> GetAddOrUpdateProductForm(Guid? id)
        {
            ViewBag.Categories = await Task<IEnumerable<SelectListItem>>.Factory.StartNew(() =>
            {
                return new CategoryRepository().GetAllCategory()
                       .Where(x => x.isDelete == false)
                       .Select(item => new SelectListItem { Text = item.name, Value = item.id.ToString() });
            });
            ViewBag.Companies = await Task<IEnumerable<SelectListItem>>.Factory.StartNew(() =>
            {
                return new CompanyRepository().GetAllCompany()
                       .Where(x => x.isDelete == false)
                       .Select(item => new SelectListItem { Text = item.name, Value = item.id.ToString() });
            });
            ProductRepository productRes = new ProductRepository();
            if (id != null)
            {
                var viewModels = await Task<ProductViewModel>.Factory.StartNew(() => Mapper.Map(productRes.GetProductById(id)));
                return PartialView("_AddProductPartialView", viewModels);
            }
            return PartialView("_AddProductPartialView", new ProductViewModel { Id = Guid.Empty, Recomended = false});
        }

        [HttpPost]
        public ActionResult AddOrUpdateProduct(ProductViewModel viewModel, HttpPostedFileBase img) //TODO: await вешать на SaveChanges()?
        {
            if (ModelState["Name"].Errors.Count == 0)
            {
                ProductRepository prodRep = new ProductRepository();
                if (viewModel.Id == Guid.Empty)
                {
                    product product = Mapper.Map(viewModel);
                    product.id = Guid.NewGuid();
                    if (img != null)
                    {
                        product.img = new byte[img.ContentLength];
                        img.InputStream.Read(product.img, 0, img.ContentLength);
                    }
                    prodRep.Add(product);
                }
                else
                {
                    product prod = prodRep.GetProductById(viewModel.Id);
                    prod = Mapper.Map(prod, viewModel);
                    if (img != null)
                    {
                        prod.img = new byte[img.ContentLength];
                        img.InputStream.Read(prod.img, 0, img.ContentLength);
                    }
                }
                prodRep.Savechanges();
            }
            return RedirectToAction("GetAllProduct");
        }

        public async Task<ActionResult> GetImage(Guid id)
        {
            ProductRepository prodRep = new ProductRepository();
            var image = await Task<byte[]>.Factory.StartNew(() => prodRep.GetProductById(id).img);
            return image != null ? File(image, "image") : null;
        }
    }
}
