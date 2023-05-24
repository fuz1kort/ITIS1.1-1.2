using System.Text.Json;

namespace Lab
{
    public class Program
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
                Console.WriteLine("3. Заполнить табель рабочего времени");
                Console.WriteLine("4. Просмотреть табель рабочего времени");
                Console.WriteLine("5. Добавить контракт");
                Console.WriteLine("6. Просмотреть заключенные контракты");
                Console.WriteLine("7. Посчитать зарплату сотрудику");
                Console.WriteLine("8. Сохранить и выйти");

                var enter = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                int countE = 0;
                int countC = 0;
                switch (enter)
                {
                    case 1:
                        {
                            countE++;
                            var number = countE;
                            Console.WriteLine("Введите ФИО сотрудника");
                            var name = Console.ReadLine() ?? string.Empty;
                            Console.WriteLine("Введите разряд");
                            var rate = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите дату приёма на должность(год, месяц, день через Enter)");
                            var year = Convert.ToInt32(Console.ReadLine());
                            var month = Convert.ToInt32(Console.ReadLine());
                            var day = Convert.ToInt32(Console.ReadLine());
                            DateOnly date = new(year, month, day);
                            bool ismemberoflaborunion;
                            Console.WriteLine("Является ли сотрудник членом профсоюза?(Да, Нет)");
                            if (Console.ReadLine() == "Да")
                                ismemberoflaborunion = true;
                            else
                                ismemberoflaborunion = false;
                            Console.WriteLine("Введите номер схемы начисления заработной платы:");
                            Console.WriteLine("1. Сумма базовой почасовой ставки, определяемой должностью, и надбавкой за разряд (по 10% за каждый разряд)" +
                                            "\nПереработки (т.е. превышение 8-часового рабочего дня), а также работу в выходные дни (субботу и воскресенье) компания оплачивает по двойному тарифу." +
                                            "\nИтоговая  сумма, выплачиваемая сотруднику на руки, складывается из оплаты отработанного им времени, из которой удерживается 13% подоходного налога, а также 2% профсоюзных отчислений (если сотрудник является членом профсоюза);");
                            Console.WriteLine("2. Сумма базовой заработной платы (п.1) с учетом переработок и работы в выходные, а так же за заключенные контракты 5% комиссионныхот суммы контрактов;");
                            Console.WriteLine("3. Заработная плата начисляется за фактически отработанное время (вне зависимости оттого, превышена ли норма рабочего времени в день,и былали  работа  в  выходные  дни) с  учетом  должности  и  разряда  сотрудника;профсоюзные отчисления составляют 1,5%;");
                            Console.WriteLine("4. Заработная плата начисляется за фактически отработанное время с учетом только должности сотрудника; профсоюзные отчисления составляют 0,5%;");
                            Console.WriteLine("5. Заработная плата начисляется за фактически отработанное время с учетом только должности сотрудника, за заключенные контракты 7% комиссионныхот суммы контрактов; профсоюзные отчисления составляют 1%;;");
                            Console.WriteLine("6. Сотрудник получает только комиссионные в размере 10% от суммы заключенных контрактов; профсоюзные отчисления не производятся;");
                            var num = Convert.ToInt32(Console.ReadLine());
                            Employee employee = new(number, name, rate, date, ismemberoflaborunion, num);
                            Console.WriteLine("0. Электрик\n1. Плотник\n2. Резчик по дереву");
                            Console.WriteLine("3. Столяр\n4. Маляр\n5. Каменщик");
                            Console.WriteLine("Введите номер должности");
                            var code = Convert.ToInt32(Console.ReadLine());
                            foreach (var position in company.GetAllPositions())
                            {
                                if (position.GetCode() == code)
                                {
                                    employee.SetPosition(position);
                                    employee.SetHourlyRate();
                                    break;
                                }
                            }

                            company.AddEmployee(employee);
                            Console.Clear();
                            //SaveEmp(employee);
                            string json = JsonSerializer.Serialize(employee, typeof(Employee));
                            StreamWriter file = File.CreateText("Employees.json");
                            file.WriteLine(json);
                            Console.WriteLine("Данные были сохранены");

                            Console.WriteLine("\nДобавить еще одного сотрудника?(Да, Нет)");
                            if (Console.ReadLine() == "Да")
                            {
                                Console.Clear();
                                goto case 1;
                            }

                            else
                                Console.Clear();
                            break;
                        }

                    case 2:
                        {
                            PrintEmp();
                            break;
                        }

                    case 3:
                        {
                            PrintEmplNum();
                            var number = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите дату рабочего дня(год, месяц, день через Enter)");
                            var year = Convert.ToInt32(Console.ReadLine());
                            var month = Convert.ToInt32(Console.ReadLine());
                            var day = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите количество отработанных часов");
                            var hours = Convert.ToInt32(Console.ReadLine());
                            timeboard.ReadTimesheet(year, month, day, number, hours);
                            break;
                        }

                    case 4:
                        {
                            var timesheet = timeboard.GetTimesheet();
                            foreach (KeyValuePair<DateOnly, SortedDictionary<int, int>> day in timesheet)
                            {
                                foreach (KeyValuePair<int, int> code_hours in day.Value)
                                {
                                    var employee = company.GetEmploymentByCode(code_hours);
                                    if (day.Key >= employee.GetEmploymentDate())
                                        Console.WriteLine($"Дата: {day.Key} - {day.Key.DayOfWeek}," +
                                                          $"\nРаботник - {employee.GetFullName()}," +
                                                          $"\nВремя работы в часах: {code_hours.Value}");
                                }

                                Console.WriteLine("***********************************");
                            }

                            break;
                        }

                    case 5:
                        {
                            countC++;
                            var number = countC;
                            Console.WriteLine("Введите дату заключения контракта(год, месяц, день через Enter)");
                            var year = Convert.ToInt32(Console.ReadLine());
                            var month = Convert.ToInt32(Console.ReadLine());
                            var day = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите ФИО клиента");
                            var name = Console.ReadLine() ?? string.Empty;
                            Console.WriteLine("Введите сумму");
                            var amount = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите комментарий клиента");
                            var comment = Console.ReadLine() ?? string.Empty;
                            DateOnly date = new(year, month, day);
                            Contract contract = new(number, date, name, amount, comment);
                            company.AddContract(contract);
                            break;
                        }

                    case 6:
                        {
                            PrintContr();
                            break;
                        }

                    case 7:
                        {
                            PrintEmplNum();
                            var number = Convert.ToInt32(Console.ReadLine());
                            Employee currentemployee = new();
                            foreach (var employee in company.GetAllEmployees())
                            {
                                if (employee.GetNumber() == number)
                                    currentemployee = employee;
                                else
                                {
                                    Console.WriteLine("Нет такого сотрудника");
                                    goto case 5;
                                }
                            }

                            Console.WriteLine("Введите дату начальной даты(год, месяц, день через Enter)");
                            var startyear = Convert.ToInt32(Console.ReadLine());
                            var startmonth = Convert.ToInt32(Console.ReadLine());
                            var startday = Convert.ToInt32(Console.ReadLine());
                            timeboard.ReadStartDate(startyear, startmonth, startday);
                            Console.WriteLine("Введите дату конечной даты(год, месяц, день через Enter)");
                            var endyear = Convert.ToInt32(Console.ReadLine());
                            var endmonth = Convert.ToInt32(Console.ReadLine());
                            var endday = Convert.ToInt32(Console.ReadLine());
                            timeboard.ReadEndDate(endyear, endmonth, endday);
                            Console.Write($"Заработная плата сотрудника равна - {currentemployee.GetSalary(timeboard, company)} рублей");
                            break;
                        }

                    case 8: 
                        { 
                            Console.Clear();



                            exit = true;
                            break; 
                        }
                }
            }

            void PrintEmplNum()
            {
                var employees = company.GetAllEmployees();
                var number = 0;
                foreach (var employee in employees)
                {
                    number++;
                    Console.WriteLine($"{number}. {employee.GetFullName()}, {employee.GetPosition().GetName()}");
                }

                Console.WriteLine("Введите табельный номер работника");
            }

            void PrintEmp()
            {
                Console.WriteLine("Список сотрудников:");
                foreach (var employee in company.GetAllEmployees())
                    Console.WriteLine(employee);
            }

            void PrintContr()
            {
                Console.WriteLine("Список контрактов:");
                foreach (var contract in company.GetAllContracts())
                    Console.WriteLine(contract);
            }

            void SaveEmp(Employee emp)
            {
                string json = JsonSerializer.Serialize(emp);
                File.WriteAllText(@"C:\Файлы компании\employees.json", json);
                Console.WriteLine("Данные были сохранены");
            }

            //async void Read(Timeboard tb)
            //{
            //    using (FileStream fs = new("MyCompany.json", FileMode.OpenOrCreate))
            //    {
            //        Timeboard? timeboard = await JsonSerializer.DeserializeAsync<Timeboard>(fs);
            //        var timesheet = timeboard.GetTimesheet();
            //        foreach (KeyValuePair<DateOnly, SortedDictionary<int, int>> day in timesheet)
            //        {
            //            foreach (KeyValuePair<int, int> code_hours in day.Value)
            //            {
            //                var employee = company.GetEmploymentByCode(code_hours);
            //                if (day.Key >= employee.GetEmploymentDate())
            //                    Console.WriteLine($"Дата: {day.Key} - {day.Key.DayOfWeek}," +
            //                                      $"\nРаботник - {employee.GetFullName()}," +
            //                                      $"\nВремя работы в часах: {code_hours.Value}");
            //            }

            //            Console.WriteLine("***********************************");
            //        }

            //    }
            //}
        }
    }
}
