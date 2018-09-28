using System;

namespace Budget.Models
{
    public class PurchaseDocument
    {
        public int PurchaseDocumentID { get; set; }
        public int ProductID { get; set; }
        public int BuyerID { get; set; }
        public int SellerID { get; set; }
        public DateTime PurchaseDT { get; set; }
        public decimal TotalCost { get; set; }
    }
}
