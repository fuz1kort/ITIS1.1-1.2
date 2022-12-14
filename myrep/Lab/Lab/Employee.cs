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

        public override string ToString() => $"{FullName}, должность - {Position.GetName()}, разряд - {Rating}, работает в компании с {EmploymentDate}, з/п - {HourlyRate}";

        public void AddEmployee(MyCompany company) => company.GetAllEmployees().Add(this);

        public void SetPosition(Position position) => Position = position;

        public void SetHourlyRate()
        {
            var basehourlyrate = (double)Position.GetBaseHourlyRate();
            var rating = (double)Rating;
            HourlyRate = (int)Math.Round((((rating - 1) * 10) + 100) / 100 * basehourlyrate);
        }

        public double GetSalary(Timeboard timeboard)
        {
            var timesheet = timeboard.GetTimesheet();
            double salary = 0;
            var startdate = timeboard.GetStartDate();
            var enddate = timeboard.GetEndDate();
            foreach (KeyValuePair<DateOnly, SortedDictionary<int, int>> day in timesheet)
            {
                if (day.Key >= startdate)
                {
                    var ratio = 1;
                    if (day.Key.DayOfWeek == DayOfWeek.Saturday || day.Key.DayOfWeek == DayOfWeek.Sunday)
                        ratio *= 2;
                    foreach (KeyValuePair<int, int> code_hours in day.Value)
                    {
                        if (code_hours.Key == Number)
                        {
                            if (code_hours.Value > 8)
                                salary += (((code_hours.Value - 8) * 2) + 8) * ratio * HourlyRate;
                            else 
                                salary += code_hours.Value * ratio * HourlyRate;
                        }
                    }
                }

                if (day.Key > enddate)
                    break;
            }

            if (IsMemberOfLaborUnion)
                return salary - ((salary * 0.13) + (salary * 0.02));
            return salary - (salary * 0.13);
        }

        public string GetFullName() => FullName;
        public int GetNumber() => Number;
        public DateOnly GetEmploymentDate() => EmploymentDate;
        public Position GetPosition() => Position;
    }
}
