using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class MyCompany
    {
        public static List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Position> Positions { get; set; } = new List<Position>();
        
        public void Init()
        {
            Positions.Add(new Position()
            {
                Code = 1,
                Name = "Директор",
                BaseHourlyRate = 500
            });
            Positions.Add(new Position()
            {
                Code = 2,
                Name = "Заместитель директора",
                BaseHourlyRate = 250
            });
            Positions.Add(new Position()
            {
                Code = 3,
                Name = "Бухгалтер",
                BaseHourlyRate = 200
            });
            Positions.Add(new Position()
            {
                Code = 4,
                Name = "Менеджер по продажам",
                BaseHourlyRate = 150
            });
            Positions.Add(new Position()
            {
                Code = 5,
                Name = "Управляющий",
                BaseHourlyRate = 100
            });
            Positions.Add(new Position()
            {
                Code = 6,
                Name = "Рабочий",
                BaseHourlyRate = 100
            });
        }

        public List<Employee> GetAllEmployees()
        {
            return Employees;
        }
    }
}
