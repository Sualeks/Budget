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
        public int pageSize = 4;

        public PurchaseController(IPurchaseRepository repo)
        {
            repository = repo;
        }

        public ViewResult Purchase(int period, int periodNum, int prPage = 1)
        {
            DateTime begin, end;
            switch (period)
            {
                case 1:
                    begin = end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, periodNum);
                    break;
                case 2:
                    begin = new DateTime(DateTime.Now.Year, 1, 1).AddDays((periodNum - 1) * 7);
                    end = new DateTime(DateTime.Now.Year, 1, 1).AddDays((periodNum - 1) * 7 + 6);
                    break;
                case 3:
                    begin = new DateTime(DateTime.Now.Year, periodNum, 1);
                    end = begin.AddDays(DateTime.DaysInMonth(DateTime.Now.Year, periodNum));
                    break;
                case 4:
                    begin = new DateTime(periodNum, 1, 1);
                    end = new DateTime(periodNum, 12, 31);
                    break;
                default: begin = end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, periodNum); break;
            }
            var result = new PurchaseViewModel
            {

                PurchaseDocuments = repository.PurchaseDocuments
                .Where(t => (t.PurchaseDT >= begin) && (t.PurchaseDT <= end))
            .OrderBy(t => t.PurchaseDocumentID)
            .Skip((prPage - 1) * pageSize)
            .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = prPage,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.PurchaseDocuments.Count()
                },
                PeriodInfo = new PeriodInfo
                {
                    PeriodType = period,
                    CurrentPeriod = periodNum
                }
            };
            return View(result);
        }
    }
}