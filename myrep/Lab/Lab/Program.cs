namespace Lab
{
    class Program
    {
        public static void Main()
        {
            MyCompany company = new MyCompany();
            company.Init();
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
                    //case 2:
                    //    {
                    //        Console.WriteLine();
                    //    }
                    case
                }
            }
        }
    }
}
