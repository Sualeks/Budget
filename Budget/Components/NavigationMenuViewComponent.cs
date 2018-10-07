using Budget.Models;
using Budget.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

        public IViewComponentResult Invoke(PeriodInfo info)
        {
            Dictionary<int, string> periods = new Dictionary<int, string>
            {
                { 1, "Day" },
                { 2, "Week" },
                { 3, "Month" },
                { 4, "Year" }
            };
            return View(new NavigationMenuViewModel { Info = info, Periods = periods });
        }
    }
}
