using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Models.ViewModels
{
    public class PeriodInfo
    {
        public int PeriodType { get; set; }
        public int CurrentPeriod { get; set; }
        public string Date {
            get {
                DateTime begin, end;
                switch (PeriodType)
                {
                    case 1:
                        begin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, CurrentPeriod);
                        return begin.ToString("g");
                    case 2:
                        begin = new DateTime(DateTime.Now.Year, 1, 1).AddDays((CurrentPeriod - 1) * 7);
                        end = new DateTime(DateTime.Now.Year, 1, 1).AddDays((CurrentPeriod - 1) * 7 + 6);
                        return $"{begin.ToString("g")} - {end.ToString("g")}";
                    case 3:
                        begin = new DateTime(DateTime.Now.Year, CurrentPeriod, 1);
                        end = begin.AddDays(DateTime.DaysInMonth(DateTime.Now.Year, CurrentPeriod));
                        return $"{begin.ToString("g")} - {end.ToString("g")}";
                    case 4:
                        begin = new DateTime(CurrentPeriod, 1, 1);
                        end = new DateTime(CurrentPeriod, 12, 31);
                        return $"{begin.ToString("g")} - {end.ToString("g")}";
                    default:
                        begin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, CurrentPeriod);
                        return begin.ToString("g");
                }
            }
        }
    }
}
