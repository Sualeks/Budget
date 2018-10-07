using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Budget.Models;
using Budget.Models.ViewModels;
using System.Globalization;
using System;

namespace Budget.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository repository;
        public int pageSize = 10;

        public PurchaseController(IPurchaseRepository repo)
        {
            repository = repo;
        }

        public ViewResult Purchase(int period, int periodNum, int year, int prPage = 1)
        {
            var periodInfo = new PeriodInfo
            {
                PeriodType = period,
                CurrentPeriod = periodNum,
                CurrentYear = year
            };

            var result = new PurchaseViewModel
            {
                PurchaseDocuments = repository.PurchaseDocuments
                .Where(t => (t.PurchaseDT >= periodInfo.PeriodBegin) && (t.PurchaseDT <= periodInfo.PeriodEnd))
            .OrderBy(t => t.PurchaseDocumentID)
            .Skip((prPage - 1) * pageSize)
            .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = prPage,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.PurchaseDocuments.Count()
                },
                PeriodInfo = periodInfo
            };
            return View(result);
        }

        public ViewResult PurchaseDetail(int doc_id, int prPage = 1)
        {
            var result = new PurchaseDetailViewModel
            {
                Purchases = repository.Purchases.Where(t => t.PurchaseDocumentID == doc_id)
                .OrderBy(t => t.PurchaseID)
                .Skip((prPage - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = prPage,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Purchases.Where(t => t.PurchaseDocumentID == doc_id).Count()
                },

            };
            return View(result);
        }
    }
}