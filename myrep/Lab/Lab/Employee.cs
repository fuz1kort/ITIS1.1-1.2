namespace Lab
{
    public class Employee
    {
        private int Number { get; set; }
        private string FullName { get; set; } = string.Empty;
        private int Rating { get; set; }
        private DateOnly EmploymentDate { get; set; }
        private bool IsMemberOfLaborUnion { get; set; }
        private Position Position { get; set; } = new();
        private int HourlyRate { get; set; }
        public Employee() { }

        public Employee(int number, string fullName, int rating, DateOnly employmentDate, bool isMemberOfLaborUnion)
        {
            Number = number;
            FullName = fullName;
            Rating = rating;
            EmploymentDate = employmentDate;
            IsMemberOfLaborUnion = isMemberOfLaborUnion;
        }

        public override string ToString() => $"{FullName}, разряд - {Rating}, работает в этой компании с {EmploymentDate}, з/п - {HourlyRate}";

        public void AddEmployee(MyCompany company) => company.GetAllEmployees().Add(this);

        public void SetPosition(Position pos) => Position = pos;

        public void SetHourlyRate()
        {
            var pb = (double)Position.GetBaseHourlyRate();
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

        public string GetFullName() => FullName;
        public int GetNumber() => Number;
        public DateOnly GetEmploymentDate() => EmploymentDate;
        public Position GetPosition() => Position;
    }
}
