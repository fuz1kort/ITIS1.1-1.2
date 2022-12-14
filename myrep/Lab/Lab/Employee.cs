﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Employee
    {
        public int Number { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int Rating { get; set; }
        public DateOnly EmploymentDate { get; set; }
        public bool IsMemberOfLaborUnion { get; set; }
        public Position Position { get; set; }

        public override string ToString()
        {
            return $"{FullName}, разряд - {Rating}, работает в этой компании с {EmploymentDate}";
        }

        public void AddEmployee()
        {
            MyCompany.Employees.Add(this);
        }

        public void SetPosition(Position pos)
        {
            Position = pos;
        }
    }
}
