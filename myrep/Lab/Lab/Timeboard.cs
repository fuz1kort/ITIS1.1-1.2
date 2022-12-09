using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Timeboard
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateOnly Date { get; set; }
        public int Hours { get; set; }
        public void Timesheet(DateOnly data, int hours)
        {
            Date = data;
            Hours = hours;
        }

    }
}
