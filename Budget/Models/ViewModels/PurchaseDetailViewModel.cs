using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Models.ViewModels
{
    public class PurchaseDetailViewModel
    {
        public IEnumerable<Purchase> Purchases { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
