using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Budget.Models;
using Budget.Models.ViewModels;

namespace Budget.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int pageSize = 4;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int prPage = 1) => View(new ProductListViewModel
        {
            Products = repository.Products
            .OrderBy(t => t.ProductID)
            .Skip((prPage - 1) * pageSize)
            .Take(pageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = prPage,
                ItemsPerPage = pageSize,
                TotalItems = repository.Products.Count()
            }
        });

        public IActionResult Index()
        {
            return View();
        }
    }
}