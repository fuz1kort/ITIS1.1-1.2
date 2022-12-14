using System.Security.Cryptography.X509Certificates;

namespace Lab
{
    class Program
    {
        public static void Main()
        {
            MyCompany company = new();
            company.Init();
            Timeboard timeboard = new();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("***********************************");
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Добавить сотрудника");
                Console.WriteLine("2. Просмотреть всех сотрудников");
                Console.WriteLine("3. Просмотреть табель рабочего времени");
                Console.WriteLine("4. Заполнить табель рабочего времени");
                Console.WriteLine("5. Посчитать зарплату сотрудику");
                Console.WriteLine("6. Выйти");

                var k = int.Parse(Console.ReadLine());
                Console.Clear();
                int cnt = 0;
                switch (k)
                {
                    case 1:
                        {
                            Employee emp = new();
                            cnt++;
                            emp.Number = cnt;
                            Console.WriteLine("Введите ФИО сотрудника");
                            emp.FullName = Console.ReadLine();
                            Console.WriteLine("0. Электрик\n1. Плотник\n2. Резчик по дереву");
                            Console.WriteLine("3. Столяр\n4. Маляр\n5. Каменщик");
                            Console.WriteLine("Введите номер должности");
                            var code = int.Parse(Console.ReadLine());
                            foreach(var pos in company.Positions)
                            {
                                if (pos.Code == code)
                                {
                                    emp.SetPosition(pos);
                                    break;
                                }
                            }
                            Console.WriteLine("Введите разряд");
                            emp.Rating = int.Parse(Console.ReadLine());
                            emp.SetHourlyRate();
                            Console.WriteLine("Введите дату приёма на должность(год, месяц, день через Enter)");
                            var y = int.Parse(Console.ReadLine());
                            var m = int.Parse(Console.ReadLine());
                            var d = int.Parse(Console.ReadLine());
                            DateOnly date = new(y, m, d);
                            emp.EmploymentDate = date;
                            Console.WriteLine("Является ли сотрудник членом профсоюза?(Да, Нет)");
                            if (Console.ReadLine() == "Да") emp.IsMemberOfLaborUnion = true;
                            else emp.IsMemberOfLaborUnion = false;
                            emp.AddEmployee();
                            Console.WriteLine("Добавить еще одного сотрудника?(Да, Нет)");
                            if (Console.ReadLine() == "Да")
                            {
                                Console.Clear();
                                goto case 1;
                            }
                            else Console.Clear();
                            break;
                        }

                    case 2:
                        {
                            PrintEmp();
                            break;
                        }

                    case 3:
                        {
                            var dict = timeboard.GetTimesheet();
                            foreach (KeyValuePair<DateOnly, SortedDictionary<int,int>> d in dict)
                            {
                                foreach(KeyValuePair<int,int> e in d.Value)
                                {
                                    var s = company.GetEmploymentByCode(e.Key, e);
                                    if (d.Key >= s.EmploymentDate) Console.WriteLine($"Дата: {d.Key} - {d.Key.DayOfWeek},\nРаботник - {s.FullName},\nВремя работы в часах: {e.Value}\n");
                                }
                                Console.WriteLine("***********************************");
                            }
                            break;
                        }

                    case 4:
                        {
                            PrintEmplNum();
                            var n = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите дату(год, месяц, день через Enter)");
                            var y = int.Parse(Console.ReadLine());
                            var m = int.Parse(Console.ReadLine());
                            var d = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите количество отработанных часов");
                            var h = int.Parse(Console.ReadLine());
                            timeboard.ReadTimesheet(y, m, d, n, h);
                            break;
                        }

                    case 5:
                        {
                            PrintEmplNum();
                            var num = int.Parse(Console.ReadLine());
                            Employee curemp = null;
                            foreach(var emp in company.GetAllEmployees())
                            {
                                if (emp.Number == num) curemp = emp;
                                else
                                {
                                    Console.WriteLine("Нет такого сотрудника");
                                    goto case 5;
                                }
                            }

                            Console.WriteLine("Введите дату начальной даты(год, месяц, день через Enter)");
                            var sy = int.Parse(Console.ReadLine());
                            var sm = int.Parse(Console.ReadLine());
                            var sd = int.Parse(Console.ReadLine());
                            timeboard.ReadStartDate(sy,sm,sd);
                            Console.WriteLine("Введите дату конечной даты(год, месяц, день через Enter)");
                            var ey = int.Parse(Console.ReadLine());
                            var em = int.Parse(Console.ReadLine());
                            var ed = int.Parse(Console.ReadLine());
                            timeboard.ReadEndDate(ey, em, ed);
                            Console.Write($"Заработная плата сотрудника равна - {curemp.GetSalary(timeboard)} рублей");
                            break;

                        }
                    case 6: { Console.Clear(); exit = true; break; }
                }
            }
            
            void PrintEmplNum()
            {
                var employees = company.GetAllEmployees();
                var num = 0;
                foreach (var employee in employees)
                {
                    num++;
                    Console.WriteLine($"{num}. {employee.FullName}, {employee.Position.Name}");
                }
                Console.WriteLine("Введите табельный номер работника");
            }

            void PrintEmp()
            {
                Console.WriteLine("Список сотрудников:");
                foreach (var a in company.GetAllEmployees())
                {
                    Console.WriteLine(a);
                }
            }
        }
    }
}
