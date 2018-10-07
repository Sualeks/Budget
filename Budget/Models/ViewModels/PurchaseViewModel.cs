using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Models.ViewModels
{
    public class PurchaseViewModel
    {
        public IEnumerable<PurchaseDocument> PurchaseDocuments { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public CategoryInfo CategoryInfo { get; set; }
        public PeriodInfo PeriodInfo { get; set; }
    }
}
