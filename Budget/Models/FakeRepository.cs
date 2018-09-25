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
            new Product { Name = "Хлеб", Price = 50 },
            new Product { Name = "Сыр", Price = 250 }
        }.AsQueryable();
    }
}
