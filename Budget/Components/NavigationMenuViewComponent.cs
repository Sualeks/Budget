using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Budget.Models;
using System.Collections.Generic;

namespace Budget.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IPurchaseRepository repository;

        public NavigationMenuViewComponent(IPurchaseRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            return View(new Dictionary<int, string> { { 1, "Day" }, { 2, "Week" }, { 3, "Month" }, { 4, "Year" } });
        }
    }
}
