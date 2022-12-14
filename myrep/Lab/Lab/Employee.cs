using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Employee
    {
        public int Number { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int Rating { get; set; }
        public DateOnly EmploymentDate { get; set; }
        public bool IsMemberOfLaborUnion { get; set; }
        public Position Position { get; set; }
        private int HourlyRate { get; set; }

        public override string ToString()
        {
            return $"{FullName}, разряд - {Rating}, работает в этой компании с {EmploymentDate}, з/п - {HourlyRate}";
        }

        public void AddEmployee()
        {
            MyCompany.Employees.Add(this);
        }

        public void SetPosition(Position pos)
        {
            Position = pos;
        }

        public void SetHourlyRate()
        {
            var pb = (double)Position.BaseHourlyRate;
            var r = (double)Rating;
            HourlyRate = (int)Math.Round(((((r - 1) * 10) + 100) / 100) * pb);
        }

        public double GetSalary(Timeboard timeboard)
        {
            var timesheet = timeboard.GetTimesheet();
            double salary = 0;
            var sdate = timeboard.GetStartDate();
            var edate = timeboard.GetEndDate();
            foreach (KeyValuePair<DateOnly, SortedDictionary<int, int>> d in timesheet)
            {
                if (d.Key >= sdate)
                {
                    var coef = 1;
                    if (d.Key.DayOfWeek == DayOfWeek.Saturday || d.Key.DayOfWeek == DayOfWeek.Sunday) coef *= 2;
                    foreach (KeyValuePair<int, int> e in d.Value)
                    {
                        if (e.Key == Number)
                        {
                            if (e.Value > 8) salary += (((e.Value - 8) * 2) + 8) * coef * HourlyRate;
                            else salary += e.Value * coef * HourlyRate;
                        }
                    }
                }
                if (d.Key > edate) break;
            }
            if (IsMemberOfLaborUnion)
                return salary - (salary * 0.13 + salary * 0.02);
            return salary - salary * 0.13;
        }

        
    }
}
