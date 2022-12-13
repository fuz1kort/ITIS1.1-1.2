namespace Lab
{
    class Program
    {
        public static void Main()
        {
            MyCompany company = new MyCompany();
            company.Init();
            Timeboard timeboard = new Timeboard();
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
                Console.WriteLine("5. Посчитать зарплату сотрудику");               //Хз как реализовать пока что...

                var k = int.Parse(Console.ReadLine());
                Console.Clear();
                int cnt = 0;

                switch (k)
                {
                    case 1:
                        {
                            Employee emp = new Employee();
                            cnt++;
                            emp.Number = cnt;
                            Console.WriteLine("Введите фамилию и имя сотрудника");
                            emp.FullName = Console.ReadLine();
                            Console.WriteLine("0. Электрик\n1. Плотник\n2.Резчик по дереву");
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
                            emp.EmploymentDate = DateTime.Now;
                            Console.WriteLine("Является ли сотрудник членом профсоюзе?(Да, Нет)");
                            if (Console.ReadLine() == "Да") emp.IsMemberOfLaborUnion = true;
                            else emp.IsMemberOfLaborUnion = false;
                            emp.AddEmployee(emp);
                            Console.WriteLine("Добавить еще одного сотрудника?(Да, Нет)");
                            if (Console.ReadLine() == "Да")
                            {
                                Console.Clear();
                                goto case 1;
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Список сотрудников:");
                            foreach (var a in company.GetAllEmployees())
                            {
                                Console.WriteLine(a);
                            }
                            break;
                        }
                    case 3:
                        {
                            var dict = timeboard.WriteTimesheet();
                            foreach (KeyValuePair<DateOnly, Dictionary<int,int>> d in dict)
                            {
                                foreach(KeyValuePair<int,int> e in d.Value)
                                {
                                    string s = string.Empty;
                                    foreach (var a in company.GetAllEmployees())
                                    {
                                        if (a.Number == e.Key)
                                        {
                                            s = a.FullName;
                                        } 
                                    }
                                    Console.WriteLine($"Дата: {d.Key},\nРаботник - {s},\nВремя работы в часах: {e.Value}");
                                }
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Введите год");
                            var y = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите месяц");
                            var m = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите день");
                            var d = int.Parse(Console.ReadLine());
                            var employees = company.GetAllEmployees();
                            int cnt = 0;
                            foreach(var employee in employees)
                            {
                                cnt++;
                                Console.WriteLine($"{cnt}. {employee.FullName}, {employee.Position.Name}");
                            }
                            Console.WriteLine("Введите табельный номер работника");
                            var n = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите количество отработанных часов");
                            var h = int.Parse(Console.ReadLine());
                            timeboard.ReadTimesheet(y, m, d, n, h);
                            break;
                        }
                }
            }
        }
    }
}
