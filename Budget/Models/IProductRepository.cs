using System.Linq;

namespace Budget.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
