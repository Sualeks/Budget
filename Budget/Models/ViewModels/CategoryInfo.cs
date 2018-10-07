using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Models.ViewModels
{
    public class CategoryInfo
    {
        public int CurrentCategory { get; set; }
        public IEnumerable<Category> Categories {get;set;}
    }
}
