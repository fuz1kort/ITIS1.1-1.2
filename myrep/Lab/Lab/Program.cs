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
                Console.WriteLine("1. Просмотреть всех сотрудников");
                Console.WriteLine("2. Просмотреть табель рабочего времени");                 //Хз как реализовать пока что...
                Console.WriteLine("3. Заполнить табель рабочего времени");
                Console.WriteLine("4. Посчитать зарплату сотрудику");

                var k = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (k)
                {
                    case 1:
                        {
                            Console.WriteLine("Список сотрудников:");
                            foreach (var a in company.PrintEmployees())
                            {
                                Console.WriteLine(a);
                            }
                            break;
                        }
                    case 2:
                        {
                            var dict = timeboard.WriteTimesheet();
                            foreach (var day in dict)
                            {
                                Console.WriteLine($"Дата: {day}, работник - {}");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Введите год");
                            var y = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите месяц");
                            var m = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите день");
                            var d = int.Parse(Console.ReadLine());
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
