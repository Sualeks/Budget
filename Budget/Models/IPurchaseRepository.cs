using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Models
{
    public interface IPurchaseRepository
    {
        IQueryable<Purchase> Purchases { get; }
        void AddPurchase(Purchase purchase);
        void UpdatePurchase(Purchase purchase);
        void DeletePurchase(Purchase purchase);

        IQueryable<PurchaseDocument> PurchaseDocuments { get; }
        void AddPurchaseDocument(PurchaseDocument document);
        void UpdatePurchaseDocument(PurchaseDocument document);
        void DeletePurchaseDocument(PurchaseDocument document);

    }
}
