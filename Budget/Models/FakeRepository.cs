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
            new Product { Name = "Хлеб", Description = "Delicios" },
            new Product { Name = "Сыр", Description = "Delicios" }
        }.AsQueryable();
    }
}
