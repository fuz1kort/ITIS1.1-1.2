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
        private double HourlyRate { get; set; }
        private int NumberOfScheme { get; set; }
        public Employee() { }
        public Employee(int number, string fullName, int rating, DateOnly employmentDate, bool isMemberOfLaborUnion, int numberOfScheme)
        {
            Number = number;
            FullName = fullName;
            Rating = rating;
            EmploymentDate = employmentDate;
            IsMemberOfLaborUnion = isMemberOfLaborUnion;
            NumberOfScheme = numberOfScheme;
        }

        public override string ToString() => $"*****\n{FullName}, должность - {Position.GetName()}, разряд - {Rating}, работает в компании с {EmploymentDate}, з/п - {HourlyRate}\n*****";
        public void SetPosition(Position position) => Position = position;
        public void SetHourlyRate()
        {
            var basehourlyrate = Position.GetBaseHourlyRate();
            var rating = (double)Rating;
            HourlyRate = (int)Math.Round((((rating - 1) * 10) + 100) / 100 * basehourlyrate);
        }

        public double GetBaseRate() => Position.GetBaseHourlyRate();

        public int GetNumberOfScheme() => NumberOfScheme;
        public double GetSalary(Timeboard timeboard, MyCompany company)
        {
            double salary = 0;
            int numberOfScheme = NumberOfScheme;
            switch (numberOfScheme)
            {
                case 1:
                    {
                        var timesheet = timeboard.GetTimesheet();
                        var startdate = timeboard.GetStartDate();
                        var enddate = timeboard.GetEndDate();
                        foreach (KeyValuePair<DateOnly, SortedDictionary<int, int>> day in timesheet)
                        {
                            if (day.Key >= startdate)
                            {
                                if (numberOfScheme == 2)
                                {
                                    foreach (var contract in company.GetAllContracts())
                                        salary += company.GetAmountByDate(day.Key) * 0.05;
                                }
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
                            salary -= (salary * 0.13) + (salary * 0.02);
                        else salary -= salary * 0.13;
                        return salary;
                    }
                case 2:
                    {
                        goto case 1;
                    }
                case 3:
                    {
                        var timesheet = timeboard.GetTimesheet();
                        var startdate = timeboard.GetStartDate();
                        var enddate = timeboard.GetEndDate();
                        foreach (KeyValuePair<DateOnly, SortedDictionary<int, int>> day in timesheet)
                        {
                            if (day.Key >= startdate)
                            {
                                foreach (KeyValuePair<int, int> code_hours in day.Value)
                                {
                                    if (code_hours.Key == Number)
                                        salary += code_hours.Value  * HourlyRate;
                                }
                            }

                            if (day.Key > enddate)
                                break;
                        }

                        if (IsMemberOfLaborUnion)
                        {
                            if(numberOfScheme == 5)
                                salary -= (salary * 0.13) + (salary * 0.01);
                            else 
                                salary -= (salary * 0.13) + (salary * 0.015);
                        }
                        else salary -= salary * 0.13;
                        return salary;
                    }
                case 4:
                    {
                        var basehourlyrate = GetBaseRate();
                        var timesheet = timeboard.GetTimesheet();
                        var startdate = timeboard.GetStartDate();
                        var enddate = timeboard.GetEndDate();
                        foreach (KeyValuePair<DateOnly, SortedDictionary<int, int>> day in timesheet)
                        {
                            if (day.Key >= startdate)
                            {
                                if (numberOfScheme == 5)
                                {
                                    foreach (var contract in company.GetAllContracts())
                                        salary += company.GetAmountByDate(day.Key) * 0.07;
                                }
                                foreach (KeyValuePair<int, int> code_hours in day.Value)
                                {
                                    if (code_hours.Key == Number)
                                        salary += code_hours.Value * basehourlyrate ;
                                }
                            }

                            if (day.Key > enddate)
                                break;
                        }

                        if (IsMemberOfLaborUnion)
                            if (numberOfScheme == 5)
                                salary -= (salary * 0.13) + (salary * 0.01);
                            else
                                salary -= (salary * 0.13) + (salary * 0.005);
                        else salary -= salary * 0.13;
                        return salary;
                    }
                case 5:
                    {
                        goto case 4;
  
                    }
                case 6:
                    {
                        var startdate = timeboard.GetStartDate();
                        var enddate = timeboard.GetEndDate();
                        foreach (var contract in company.GetAllContracts())
                            if (contract.GetContractDate() <= enddate && contract.GetContractDate() >= startdate) 
                            salary += contract.GetContractAmount() * 0.1;
                        salary *= 0.87;
                        return salary;
                    }
                default:
                    {
                        return salary;
                    }
            }
            
        }

        public string GetFullName() => FullName;
        public int GetNumber() => Number;
        public DateOnly GetEmploymentDate() => EmploymentDate;
        public Position GetPosition() => Position;
    }
}
