using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Models
{
    public class EFContrageltRepository : IContragentRepository
    {
        private ApplicationDbContext context;

        public EFContrageltRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Buyer> Buyers => context.Buyers;

        public IQueryable<Seller> Sellers => context.Sellers;

        public void AddBuyer(Buyer buyer)
        {
            context.Buyers.Add(buyer);
            context.SaveChanges();
        }

        public void AddSeller(Seller seller)
        {
            context.Sellers.Add(seller);
            context.SaveChanges();
        }

        public void DeleteBuyer(Buyer buyer)
        {
            context.Buyers.Remove(buyer);
            context.SaveChanges();
        }

        public void DeleteSeller(Seller seller)
        {
            context.Sellers.Remove(seller);
            context.SaveChanges();
        }

        public void UpdateBuyer(Buyer buyer)
        {
            context.Buyers.Update(buyer);
            context.SaveChanges();
        }

        public void UpdateSeller(Seller seller)
        {
            context.Update(seller);
            context.SaveChanges();
        }
    }
}
