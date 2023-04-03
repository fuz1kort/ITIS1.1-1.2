namespace LINQ
{
    class Program
    {
        public static void Main()
        {
            //LinQBegin
            //Console.WriteLine("№6 Введите строковую последовательность");

            //Console.WriteLine(Console.ReadLine().Split(" ").Sum(x => x.Length));

            //Console.WriteLine("-------------------");

            //Console.WriteLine("№16 Введите целочисленную последовательность");

            //foreach (int num in Console.ReadLine().Split(" ").Select(x => Convert.ToInt32(x)).Where(x => x > 0).ToArray())
            //    Console.Write($"{num} ");

            //Console.WriteLine("-------------------");

            //Console.WriteLine("№26 Введите целые числа K1 и K2 и последовательность непустых строк");

            //var k1 = Convert.ToInt32(Console.ReadLine());
            //var k2 = Convert.ToInt32(Console.ReadLine());
            //var pos = Console.ReadLine().Split(" ").Select(x => Convert.ToInt32(x)).ToList();
            //Console.WriteLine(pos.Where(x => pos.IndexOf(x) < k1 - 1 || pos.IndexOf(x) > k2 - 1).Average());

            //Console.WriteLine("-------------------");

            //Console.WriteLine("№36 Введите последовательность непустых строк");

            //var str = Console.ReadLine().Split(" ");
            //List<char> chars = new();
            //chars.AddRange(str.Where(x => x.Length % 2 == 1).Select(x => x[0]));
            //chars.AddRange(str.Where(x => x.Length % 2 == 0).Select(x => x[x.Length - 1]));
            //foreach (var _char in chars.OrderByDescending(x => x.GetHashCode()))
            //    Console.Write(_char);

            //Console.WriteLine("-------------------");

            //Console.WriteLine("№46 Введите последовательность A и B");

            //var A = Console.ReadLine().Split(" ").Select(x => Convert.ToInt32(x));
            //var B = Console.ReadLine().Split(" ").Select(x => Convert.ToInt32(x));
            //var pairs = from a in A
            //            from b in B
            //            where a % 10 == b % 10
            //            orderby a, b
            //            select $"{a}-{b}";

            //foreach (var pair in pairs)
            //{
            //    Console.Write($"{pair} ");
            //}

            //Console.WriteLine("-------------------");

            //Console.WriteLine("№56 Введите целочисленную последовательность");

            //var A = Console.ReadLine().Split(" ");




            //LinQObj

            //6

            //List<Client> clients = new()
            //{
            //    new Client { Code = 1, Hours = 20, Year = 2020, Month = 2 },
            //    new Client { Code = 2, Hours = 100, Year = 2021, Month = 3 },
            //    new Client { Code = 3, Hours = 7, Year = 2022, Month = 1 },
            //    new Client { Code = 4, Hours = 10, Year = 2019, Month = 6},
            //    new Client { Code = 5, Hours = 20, Year = 2000, Month = 4}
            //};

            //var results = clients.GroupBy(x => x.Month).OrderByDescending(x => x.Sum(y => y.Hours)).ThenBy(x => x.Key);
            //foreach (var result in results)
            //{
            //    Console.WriteLine($"{result.Sum(x => x.Hours)}\t{result.Key}");
            //}


            //for (int i = 1; i < 13; i++)
            //{
            //    if (!results.Select(x => x.Key).Contains(i))
            //        Console.WriteLine($"0\t{i}");
            //}

            //16

            //List<Entrant> entrants = new()
            //{
            //    new Entrant{ Year = 2021, SchoolNumber = 1, Surname = "Bulkin" },
            //    new Entrant{ Year = 2021, SchoolNumber= 2, Surname = "Lastochkina"},
            //    new Entrant{ Year = 2022, SchoolNumber = 1, Surname = "Popov"},
            //    new Entrant{ Year = 2020, SchoolNumber = 3, Surname = "Zotov"},
            //    new Entrant{ Year = 2019, SchoolNumber = 4, Surname = "Molotova"},
            //    new Entrant{ Year = 2022, SchoolNumber = 3, Surname = "Kuplinov"},
            //    new Entrant{Year = 2015, SchoolNumber = 10, Surname = "Zaitcev"},
            //};

            //foreach (var year in entrants.GroupBy(x => x.Year).OrderByDescending(x => x.Count()).ThenBy(x => x.Key))
            //{
            //    Console.WriteLine($"{year.Count()}\t{year.Key}");
            //}

            //26

            //List<Debtor> debtors = new()
            //{
            //    new Debtor {Flat = 13, Surname = "Likhachov", Debt = 1543.32},
            //    new Debtor {Flat = 56, Surname = "Lisenkova", Debt = 43009.44},
            //    new Debtor {Flat = 70, Surname = "Mohova", Debt = 544.21},
            //    new Debtor {Flat = 109, Surname = "Golovin", Debt = 666.66},
            //    new Debtor {Flat = 143, Surname = "Mayakovskii", Debt = 95.79},
            //};

            //foreach (var debtorG in debtors.OrderBy(x => x.Flat).GroupBy(x => x.Flat / 36 + 1))
            //{
            //    Console.WriteLine($"{debtorG.Key} {debtorG.Count()} {Examiner.Round(debtorG.Average(x => x.Debt),2)}");
            //}

            //36

            //List<Debtor> debtors = new()
            //{
            //    new Debtor {Flat = 13, Surname = "Likhachov", Debt = 1543.32},
            //    new Debtor {Flat = 56, Surname = "Lisenkova", Debt = 43009.44},
            //    new Debtor {Flat = 70, Surname = "Mohova", Debt = 544.21},
            //    new Debtor {Flat = 109, Surname = "Golovin", Debt = 666.66},
            //    new Debtor {Flat = 143, Surname = "Mayakovskii", Debt = 95.79},
            //};

            //foreach (var debtor in debtors.OrderBy(x => (x.Flat / 4) % 9 + 1).ThenBy(x => x.Flat))
            //{
            //    Console.WriteLine($"{(debtor.Flat / 4) % 9 + 1} {Examiner.Round(debtor.Debt, 2)} {debtor.Surname} {debtor.Flat}");
            //}

            //46

            //List<GAS_station> stations = new()
            //{ 
            //    new GAS_station {Street = "1", FuelType = 92, Price = 4550, Company = "TatNeft"},
            //    new GAS_station {Street = "2", FuelType = 92, Price = 4490, Company = "RosNeft"},
            //    new GAS_station {Street = "2", FuelType = 98, Price = 5010, Company = "Irbis"},
            //    new GAS_station {Street = "3", FuelType = 98, Price = 5030, Company = "TatNeft"},
            //    new GAS_station {Street = "1", FuelType = 95, Price = 4750, Company = "Irbis"},
            //    new GAS_station {Street = "2", FuelType = 95, Price = 4850, Company = "TatNeft"},
            //    new GAS_station {Street = "3", FuelType = 95, Price = 4490, Company = "RosNeft"},
            //    new GAS_station {Street = "3", FuelType = 92, Price = 4400, Company = "Irbis"},
            //    new GAS_station {Street = "1", FuelType = 98, Price = 5500, Company = "RosNeft"},
            //};


            //var stationsByCompany = from station in stations
            //                        group station by station.Company into companyGroup
            //                        let countAll = companyGroup.Count()
            //                        let count92 = companyGroup.Count(s => s.FuelType == 92)
            //                        let count95 = companyGroup.Count(s => s.FuelType == 95)
            //                        let count98 = companyGroup.Count(s => s.FuelType == 98)
            //                        where count92 > 0 && count95 > 0 && count98 > 0
            //                        orderby countAll descending, companyGroup.Key
            //                        select new
            //                        {
            //                            Company = companyGroup.Key,
            //                            CountAll = countAll,
            //                            Count92 = count92,
            //                            Count95 = count95,
            //                            Count98 = count98
            //                        };

            //foreach (var company in stationsByCompany)
            //{
            //    Console.WriteLine($"{company.CountAll} {company.Company}");
            //}

            //56

            //List<Examiner> examiners = new()
            //{
            //    new Examiner{ SchoolNumber = 1, Surname = "Bulkin" , Initials = "A A", Scores = "93 56 34"},
            //    new Examiner{ SchoolNumber= 2, Surname = "Lastochkina", Initials = "B N", Scores = "60 64 76"},
            //    new Examiner{ SchoolNumber = 1, Surname = "Popov", Initials = "R K" , Scores = "90 92 100"},
            //    new Examiner{ SchoolNumber = 3, Surname = "Zotov", Initials = "D V", Scores = "72 86 95"},
            //    new Examiner{ SchoolNumber = 4, Surname = "Molotova", Initials = "S C", Scores = "100 100 100"},
            //    new Examiner{ SchoolNumber = 3, Surname = "Kuplinov", Initials = "F F", Scores = "43 20 50"},
            //    new Examiner{ SchoolNumber = 10, Surname = "Zaitcev", Initials = "K A", Scores = "63 25 65"},
            //};


            //var examiners90 = from examiner in examiners
            //                  let scores = examiner.Scores.Split(" ").ToList()
            //                  where scores.Any(x => Convert.ToInt32(x) > 90)
            //                  orderby examiner.Surname, examiner.Initials, examiner.SchoolNumber
            //                  select examiner;


            //foreach(var examiner in examiners90)
            //{
            //    Console.WriteLine($"{examiner.Surname} {examiner.Initials} {examiner.SchoolNumber}");
            //}

            //66

            //List<Score> scores = new()
            //{
            //    new Score{ Mark = 3, Surname = "Bulkin" , Initials = "A A", Class = 4, Subject = "Informatics"},
            //    new Score{ Mark= 2, Surname = "Lastochkina", Initials = "B N", Class = 2, Subject = "Geometry"},
            //    new Score{ Mark = 5, Surname = "Popov", Initials = "R K" , Class = 1, Subject = "Algebra"},
            //    new Score{ Mark = 5, Surname = "Zotov", Initials = "D V", Class = 5, Subject = "Geometry"},
            //    new Score{ Mark = 4, Surname = "Molotova", Initials = "S C", Class = 3, Subject = "Algebra"},
            //    new Score{ Mark = 4, Surname = "Kuplinov", Initials = "F F", Class = 2, Subject = "Informatics"},
            //    new Score{ Mark = 5, Surname = "Zaitcev", Initials = "K A", Class = 1, Subject = "Informatics"},
            //};

            //var subjectread = Console.ReadLine();
            //var result = scores.GroupBy(m => m.Class).OrderBy(g => g.Key)
            //                  .Select(g => new { Class = g.Key, Count = g.Where(x => x.Subject == subjectread && x.Mark >= 3.5).Count() });


            //foreach (var _class in result)
            //{
            //    Console.WriteLine($"{_class.Class} {_class.Count}");
            //}


        }
    }
}