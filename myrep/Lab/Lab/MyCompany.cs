﻿namespace Lab
{
    [Serializable]
    public class MyCompany
    {
        public delegate void MyCompanyHandler(string message);

        public event MyCompanyHandler? Notify;
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Position> Positions { get; set; } = new List<Position>();
        public List<Contract> Contracts { get; set; } = new List<Contract>();

        public MyCompany() 
        {
            Init();
        }

        private void Init()
        {
            Positions.Add(new Position(0, "Электрик", 90));
            Positions.Add(new Position(1, "Плотник", 110));
            Positions.Add(new Position(2, "Разработчик", 140));
            Positions.Add(new Position(3, "Столяр", 120));
            Positions.Add(new Position(4, "Маляр", 80));
            Positions.Add(new Position(5, "Каменщик", 130));
        }

        public List<Position> GetAllPositions() => Positions;
        public List<Contract> GetAllContracts()
        {
            TimeOnly time = new(0, 0);
            Contracts.Sort((x, y) => DateTime.Compare(x.GetContractDate().ToDateTime(time), y.GetContractDate().ToDateTime(time)));
            return Contracts;
        }
        public List<Employee> GetAllEmployees()
        {
            TimeOnly time = new(0, 0);
            Employees.Sort((x, y) => DateTime.Compare(x.GetEmploymentDate().ToDateTime(time), y.GetEmploymentDate().ToDateTime(time)));
            return Employees;
        }

        public Employee GetEmploymentByCode(KeyValuePair<int, int> code_hours)
        {
            foreach (var employee in GetAllEmployees())
            {
                if (employee.GetNumber() == code_hours.Key)
                    return employee;
            }

            return new();
        }

        public double GetAmountByDate(DateOnly date)
        {
            foreach (var contract in GetAllContracts())
            {
                if (contract.GetContractDate() == date)
                    return contract.GetContractAmount();
            }
            return 0;
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
            Notify?.Invoke($"Был добавлен новый сотрудник:\n{employee.FullName}");
        }

        public void AddContract(Contract contract)
        {
            Contracts.Add(contract);
            Notify?.Invoke($"Был добавлен новый контракт\n№{contract.Number}");
        }
    }
}
