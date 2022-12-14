namespace Lab
{
    public class Timeboard
    {
        private DateOnly StartDate { get; set; }
        private DateOnly EndDate { get; set; }
        private static SortedDictionary<DateOnly, SortedDictionary<int, int>> Timesheet = new SortedDictionary<DateOnly, SortedDictionary<int, int>>();
        public void ReadStartDate(int year, int month, int day) => StartDate = new DateOnly(year, month, day);

        public void ReadEndDate(int year, int month, int day) => EndDate = new DateOnly(year, month, day);

        public void ReadTimesheet(int year, int month, int day, int number, int hours)
        {
            DateOnly date = new DateOnly(year, month, day);
            Timesheet.Add(date, new SortedDictionary<int, int> { [number] = hours });
        }
        public SortedDictionary<DateOnly, SortedDictionary<int, int>> GetTimesheet() => Timesheet;
        public DateOnly GetStartDate() => StartDate;
        public DateOnly GetEndDate() => EndDate;
    }
}
