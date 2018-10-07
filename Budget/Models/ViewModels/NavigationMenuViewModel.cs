using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Models.ViewModels
{
    public class NavigationMenuViewModel
    {
        public Dictionary<int,string> Periods { get; set; }
        public PeriodInfo Info { get; set; }
    }
}
