using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Models
{
    public class EFProductRepository : IProductRepository, ICategoryRepository, ICategoryTypeRepository
    {
        private ApplicationDbContext context;

        public EFProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Product> Products => context.Products;

        public IQueryable<Category> Categories => context.Categories;

        public IQueryable<CategoryType> CategoryTypes => context.CategoryTypes;
    }
}
