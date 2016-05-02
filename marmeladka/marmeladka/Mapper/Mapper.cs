using marmeladka.core.entities;
using marmeladka.ViewModel;
using System;
using marmeladka.DTOs;
using marmeladka.ViewModel;

namespace marmeladka.Mappers
{
    public static class Mapper
    {
        public static UserViewModel Map(user user)
        {
            var viewModel = new UserViewModel
            {
                Id = user.id,
                Name = user.name,
                Second_name = user.second_name,
                Email = user.email,
                Postcode = user.postcode,
                Adress = user.adress
            };
            return viewModel;
        }

        public static user Map(UserViewModel userView)
        {
            var user = new user
            {
                id = Guid.NewGuid(),
                name = userView.Name,
                second_name = userView.Second_name,
                email = userView.Email,
                postcode = userView.Postcode,
                adress = userView.Adress

            };
            return user;
        }
        public static CategoryViewModel Map(category category)
        {
            var viewModel = new CategoryViewModel
            {
                Id = category.id,
                Name = category.name,
                IsDelete = category.isDelete
            };
            return viewModel;
        }

        public static category Map(CategoryViewModel categoryView)
        {
            var category = new category
            {
                id = categoryView.Id,
                name = categoryView.Name,
                isDelete = categoryView.IsDelete
            };
            return category;
        }
        public static CompanyViewModel Map(company company)
        {
            var companyView = new CompanyViewModel
            {
                Id = company.id,
                Name = company.name,
                IsDelete = company.isDelete
            };
            return companyView;
        }
        public static company Map(CompanyViewModel companuView)
        {
            var company = new company
            {
                id = companuView.Id,
                name = companuView.Name,
                isDelete = companuView.IsDelete
            };
            return company;
        }
        public static ProductViewModel Map(product product)
        {
            var productView = new ProductViewModel
            {
                Id = product.id,
                Name = product.name,
                Opt_price = product.opt_price,
                Retail_price = product.retail_price,
                Product_weight = product.product_weight,
                CategoryId = product.categoryId,
                CompanyId = product.companyId,
                Company = Map(product.company),
                Category = Map(product.category)
            };
            return productView;
        }
        public static product Map(ProductViewModel productView)
        {
            var product = new product
            {
                id = productView.Id,
                name = productView.Name,
                opt_price = productView.Opt_price ?? 0,
                retail_price = productView.Retail_price ?? 0,
                product_weight = productView.Product_weight ?? 0,
                categoryId = productView.CategoryId,
                companyId = productView.CompanyId
            };
            return product;
        }
        public static Admin Map(AdminViewModel viewModel)
        {
            var admin = new Admin
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Password = viewModel.Password
            };
            return admin;
        }
        public static AdminViewModel Map(Admin admin)
        {
            var viewModel = new AdminViewModel
            {
                Id = admin.Id,
                Name = admin.Name,
                Password = admin.Password
            };
            return viewModel;
        }
    }
}