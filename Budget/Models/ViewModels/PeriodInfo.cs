using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Models.ViewModels
{
    public class PeriodInfo
    {
        public int PeriodType { get; set; } = 2;
        public int CurrentPeriod { get; set; } = DateTime.Now.DayOfYear / 7 + 1;
        public int CurrentYear { get; set; } = DateTime.Now.Year;

        public int TotalPeriods
        {
            get
            {
                switch (PeriodType)
                {
                    case 1: return new DateTime(CurrentYear, 12, 31).DayOfYear;
                    case 2: return new DateTime(CurrentYear, 12, 31).DayOfYear / 7;
                    case 3: return 12;
                    case 4: return 1;
                    default: return new DateTime(CurrentYear, 12, 31).DayOfYear;
                }
            }
        }
        public int TotalPrevPeriods
        {
            get
            {
                switch (PeriodType)
                {
                    case 1: return new DateTime(CurrentYear - 1, 12, 31).DayOfYear;
                    case 2: return new DateTime(CurrentYear - 1, 12, 31).DayOfYear / 7;
                    case 3: return 12;
                    case 4: return 1;
                    default: return new DateTime(CurrentYear - 1, 12, 31).DayOfYear;
                }
            }
        }
        public DateTime PeriodBegin
        {
            get
            {
                DateTime begin;
                switch (PeriodType)
                {
                    case 1:
                        begin = new DateTime(CurrentYear, 1, 1).AddDays(CurrentPeriod - 1);
                        return begin;
                    case 2:
                        begin = new DateTime(CurrentYear, 1, 1).AddDays((CurrentPeriod - 1) * 7);
                        return begin;
                    case 3:
                        begin = new DateTime(CurrentYear, CurrentPeriod, 1);
                        return begin;
                    case 4:
                        begin = new DateTime(CurrentYear, 1, 1);
                        return begin;
                    default:
                        begin = new DateTime(CurrentYear, 1, 1).AddDays(CurrentPeriod - 1);
                        return begin;
                }
            }
        }
        public DateTime PeriodEnd
        {
            get
            {
                DateTime begin, end;
                switch (PeriodType)
                {
                    case 1:
                        begin = new DateTime(CurrentYear, 1, 1).AddDays(CurrentPeriod);
                        return begin;
                    case 2:
                        begin = new DateTime(CurrentYear, 1, 1).AddDays((CurrentPeriod - 1) * 7);
                        end = new DateTime(CurrentYear, 1, 1).AddDays((CurrentPeriod - 1) * 7 + 6);
                        return end;
                    case 3:
                        begin = new DateTime(CurrentYear, CurrentPeriod, 1);
                        end = begin.AddDays(DateTime.DaysInMonth(DateTime.Now.Year, CurrentPeriod));
                        return end;
                    case 4:
                        begin = new DateTime(CurrentYear, 1, 1);
                        end = new DateTime(CurrentYear, 12, 31);
                        return end;
                    default:
                        begin = new DateTime(CurrentYear, 1, 1).AddDays(CurrentPeriod - 1);
                        return begin;
                }
            }
        }
        public string Date
        {
            get
            {
                if (PeriodType == 1)
                {
                    return PeriodBegin.ToString("g");
                }
                else
                {
                    return $"{PeriodBegin.ToString("g")} - {PeriodEnd.ToString("g")}";
                }
            }
        }
        public int CurrentPeriodConvertToType(int type)
        {
            if(type == PeriodType)
            {
                return CurrentPeriod;
            }
            else 
            {
                switch (type)
                {
                    case 1: return PeriodBegin.DayOfYear;
                    case 2:return (PeriodBegin.DayOfYear / 7) + 1;
                    case 3:return PeriodBegin.Month;
                    case 4:return 1;
                    default: return PeriodBegin.DayOfYear;
                }
            }            
        }
    }
}
