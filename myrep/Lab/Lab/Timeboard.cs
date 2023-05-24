namespace Lab
{
    [Serializable]
    public class Timeboard
    {
        [NonSerialized]
        public DateOnly StartDate;

        [NonSerialized]
        public DateOnly EndDate;

        public SortedDictionary<DateOnly, SortedDictionary<int, int>> Timesheet { get; set; } = new();

        public Timeboard() { }

        public void ReadStartDate(int year, int month, int day) => StartDate = new DateOnly(year, month, day);
        public void ReadEndDate(int year, int month, int day) => EndDate = new DateOnly(year, month, day);
        public void ReadTimesheet(int year, int month, int day, int number, int hours)
        {
            DateOnly date = new(year, month, day);
            Timesheet.Add(date, new SortedDictionary<int, int> { [number] = hours });
        }
        public SortedDictionary<DateOnly, SortedDictionary<int, int>> GetTimesheet() => Timesheet;
        public DateOnly GetStartDate() => StartDate;
        public DateOnly GetEndDate() => EndDate;
    }
}
