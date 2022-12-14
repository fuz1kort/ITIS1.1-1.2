namespace Lab
{
    public class MyCompany
    {
        private List<Employee> Employees { get; set; } = new List<Employee>();
        private List<Position> Positions { get; set; } = new List<Position>();
        
        public void Init()
        {
            Positions.Add(new Position(0,"Электрик", 90));
            Positions.Add(new Position(1, "Плотник", 110));
            Positions.Add(new Position(2, "Резчик по дереву", 140));
            Positions.Add(new Position(3, "Столяр", 120));
            Positions.Add(new Position(4, "Маляр", 80));
            Positions.Add(new Position(5, "Каменщик", 130));
        }
        public List<Position> GetAllPositions() => Positions;

        public List<Employee> GetAllEmployees() => Employees;
        //Employees.Sort((x,y) => string.Compare(x.FullName, y.FullName));

        public Employee GetEmploymentByCode(int code, KeyValuePair<int, int> e)
        {
            foreach (var a in GetAllEmployees())
            {
                if (a.GetNumber() == e.Key)
                {
                    return a;
                }
            }
            return new();
        }
    }
}
