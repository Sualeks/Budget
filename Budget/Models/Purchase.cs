using System.Collections.Generic;

namespace Budget.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public int PurchaseDocumentID { get; set; }
        public int ProductID { get; set; }
        public float Quantity { get; set; }
        public int Sum { get; set; }
        public int Price { get; set; }

        public ICollection<Product> Products { get; set; }
        public PurchaseDocument PurchaseDocument { get; set; }
    }
}
