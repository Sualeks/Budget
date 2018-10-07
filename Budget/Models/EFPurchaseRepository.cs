using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        private ApplicationDbContext context;

        public EFPurchaseRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Purchase> Purchases => context.Purchases;

        public IQueryable<PurchaseDocument> PurchaseDocuments => context.PurchaseDocuments;

        public void AddPurchase(Purchase purchase)
        {
            context.Purchases.Add(purchase);
            context.SaveChanges();
        }

        public void AddPurchaseDocument(PurchaseDocument document)
        {
            context.PurchaseDocuments.Add(document);
            context.SaveChanges();
        }

        public void DeletePurchase(Purchase purchase)
        {
            context.Purchases.Remove(purchase);
            context.SaveChanges();
        }

        public void DeletePurchaseDocument(PurchaseDocument document)
        {
            context.PurchaseDocuments.Remove(document);
            context.SaveChanges();
        }

        public void UpdatePurchase(Purchase purchase)
        {
            context.Purchases.Update(purchase);
            context.SaveChanges();
        }

        public void UpdatePurchaseDocument(PurchaseDocument document)
        {
            context.PurchaseDocuments.Update(document);
            context.SaveChanges();
        }
    }
}
