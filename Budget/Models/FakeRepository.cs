using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Models
{
    public class FakeRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product { Name = "Хлеб", Description = "Delicios", CategoryID = 1 },
            new Product { Name = "Сыр", Description = "Delicios" }
        }.AsQueryable();
        public IQueryable<Category> Categories => new List<Category>
        {
            new Category { Name = "Еда", Description = "Delicios", CategoryID = 1, CategoryTypeID = 1 },
        }.AsQueryable();
        public IQueryable<CategoryType> CategoryTypes => new List<CategoryType>
        {
            new CategoryType { Name = "Необходимое", Description = "Delicios", CategoryTypeID = 1 },
        }.AsQueryable();

        public void AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void AddCategoryType(CategoryType type)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategoryType(CategoryType type)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategoryType(CategoryType type)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
