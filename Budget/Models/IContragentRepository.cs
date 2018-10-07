using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Models
{
    public interface IContragentRepository
    {
        IQueryable<Buyer> Buyers { get; }
        void AddBuyer(Buyer buyer);
        void UpdateBuyer(Buyer buyer);
        void DeleteBuyer(Buyer buyer);

        IQueryable<Seller> Sellers { get; }
        void AddSeller(Seller seller);
        void UpdateSeller(Seller seller);
        void DeleteSeller(Seller seller);
    }
}
