using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Timeboard
    {
        private DateOnly StartDate { get; set; }
        private DateOnly EndDate { get; set; }
        private static SortedDictionary<DateOnly, SortedDictionary<int, int>> Timesheet = new SortedDictionary<DateOnly, SortedDictionary<int, int>>();
        public void ReadStartDate(int day, int month, int year) => StartDate = new DateOnly(year, month, day);

        public void ReadEndDate(int day, int month, int year) => EndDate = new DateOnly(year, month, day);

        public void ReadTimesheet(int year, int month, int day, int number, int hours)
        {
            DateOnly date = new DateOnly(year, month, day);
            Timesheet.Add(date, new SortedDictionary<int, int> { [number] = hours });
        }
        public SortedDictionary<DateOnly, SortedDictionary<int, int>> GetTimesheet() => Timesheet;
    }
}
