using System;
using System.Collections.Generic;

namespace Budget.Models
{
    public class PurchaseDocument
    {
        public int PurchaseDocumentID { get; set; }
        public int BuyerID { get; set; }
        public int SellerID { get; set; }
        public DateTime PurchaseDT { get; set; }
        public decimal TotalCost { get; set; }

        public Buyer Buyer { get; set; }
        public Seller Seller { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}
