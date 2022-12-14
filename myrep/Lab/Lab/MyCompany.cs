namespace Lab
{
    public class MyCompany
    {
        private static List<Employee> Employees { get; set; } = new List<Employee>();
        private static List<Position> Positions { get; set; } = new List<Position>();

        public void Init()
        {
            Positions.Add(new Position(0, "Электрик", 90));
            Positions.Add(new Position(1, "Плотник", 110));
            Positions.Add(new Position(2, "Разработчик", 140));
            Positions.Add(new Position(3, "Столяр", 120));
            Positions.Add(new Position(4, "Маляр", 80));
            Positions.Add(new Position(5, "Каменщик", 130));
        }
        public List<Position> GetAllPositions() => Positions;

        public List<Employee> GetAllEmployees()
        {
            TimeOnly time = new(0, 0);
            Employees.Sort((x, y) => DateTime.Compare(x.GetEmploymentDate().ToDateTime(time), y.GetEmploymentDate().ToDateTime(time)));
            return Employees;
        }


        public Employee GetEmploymentByCode(int code, KeyValuePair<int, int> code_hours)
        {
            foreach (var employee in GetAllEmployees())
            {
                if (employee.GetNumber() == code_hours.Key)
                {
                    return employee;
                }
            }
            return new();
        }
    }
}
