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
                Code = 0,
                Name = "Электрик",
                BaseHourlyRate = 300
            });
            Positions.Add(new Position()
            {
                Code = 1,
                Name = "Плотник",
                BaseHourlyRate = 110
            });
            Positions.Add(new Position()
            {
                Code = 2,
                Name = "Резчик по дереву",
                BaseHourlyRate = 140
            });
            Positions.Add(new Position()
            {
                Code = 3,
                Name = "Столяр",
                BaseHourlyRate = 120
            });
            Positions.Add(new Position()
            {
                Code = 4,
                Name = "Маляр",
                BaseHourlyRate = 80
            });
            Positions.Add(new Position()
            {
                Code = 5,
                Name = "Каменщик",
                BaseHourlyRate = 130
            });
        }

        public List<Employee> GetAllEmployees()
        {
            //Employees.Sort((x,y) => string.Compare(x.FullName, y.FullName));
            return Employees;
        }

        public Employee GetEmploymentByCode(int code, KeyValuePair<int, int> e)
        {
            foreach (var a in GetAllEmployees())
            {
                if (a.Number == e.Key)
                {
                    return a;
                }
            }
            return null;
        }
    }
}
