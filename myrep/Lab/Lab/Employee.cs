using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Employee
    {
        public int Number { get; set; }
        public string FullName { get; set; }
        public int Rating { get; set; }
        public DateTime EmploymentDate { get; set; }
        public bool IsMemberOfLaborUnion { get; set; }

        public override string ToString()
        {
            return $"{FullName}, разряд - {Rating}, работает в этой компании с {EmploymentDate}";
        }
    }
}
