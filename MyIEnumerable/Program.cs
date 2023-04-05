using System.Numerics;

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
            //    Console.WriteLine($"{debtorG.Key} {debtorG.Count()} {Math.Round(debtorG.Average(x => x.Debt), 2)}");
            //}

            //...

            //46

            //List<GAS_station> stations = new()
            //{
            //    new GAS_station {Street = "1", FuelType = 92, Item = 4550, Company = "TatNeft"},
            //    new GAS_station {Street = "2", FuelType = 92, Item = 4490, Company = "RosNeft"},
            //    new GAS_station {Street = "2", FuelType = 98, Item = 5010, Company = "Irbis"},
            //    new GAS_station {Street = "3", FuelType = 98, Item = 5030, Company = "TatNeft"},
            //    new GAS_station {Street = "1", FuelType = 95, Item = 4750, Company = "Irbis"},
            //    new GAS_station {Street = "2", FuelType = 95, Item = 4850, Company = "TatNeft"},
            //    new GAS_station {Street = "3", FuelType = 95, Item = 4490, Company = "RosNeft"},
            //    new GAS_station {Street = "3", FuelType = 92, Item = 4400, Company = "Irbis"},
            //    new GAS_station {Street = "1", FuelType = 98, Item = 5500, Company = "RosNeft"},
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

            //36

            //List<Debtor> debtors = new()
            //{
            //    new Debtor {Flat = 13, Surname = "Likhachov", Debt = 1543.32},
            //    new Debtor {Flat = 56, Surname = "Lisenkova", Debt = 43009.44},
            //    new Debtor {Flat = 70, Surname = "Mohova", Debt = 544.21},
            //    new Debtor {Flat = 109, Surname = "Golovin", Debt = 666.66},
            //    new Debtor {Flat = 143, Surname = "Mayakovskii", Debt = 95.79},
            //};


            //var debtorsFl = from debtor in debtors
            //                group debtor by debtor.Flat / 4 % 9 + 1 into groupFloor
            //                let avgfl = groupFloor.Where(x => x.Debt > 0 ).Average(x => x.Debt)
            //                from item in groupFloor
            //                orderby item.Flat / 4 % 9 + 1, item.Debt
            //                where item.Debt <= avgfl
            //                select new
            //                {
            //                    Floor = groupFloor.Key,
            //                    Debt = item.Debt,
            //                    Surname = item.Surname,
            //                    Flat = item.Flat
            //                };
            //foreach (var debtor in debtorsFl)
            //{
            //    Console.WriteLine($"{debtor.Floor} {Math.Round(debtor.Debt, 2)} {debtor.Surname} {debtor.Flat}");
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
            //var result = scores
            //     .Where(x => x.Mark != 2)
            //     .GroupBy(x => x.Class)
            //     .OrderBy(x => x.Key)
            //     .Select(x => new { Class = x.Key, Count = x.Count(y => y.Subject == subjectread && y.Mark >= 3.5) });



            //foreach (var _class in result)
            //{
            //    Console.WriteLine($"{_class.Class} {_class.Count}");
            //}

            //76

            //List<Product> products = new()
            //{
            //    new Product { Id = "MI343-9874", Category = "Milk", Country = "Russia"},
            //    new Product { Id = "BR954-7564", Category = "Bread", Country = "USA"},
            //    new Product { Id = "ME111-3645", Category = "Meat", Country = "USA"},
            //    new Product { Id = "VE254-8645", Category = "Vegetables", Country = "Russia"},
            //    new Product { Id = "FR987-1345", Category = "Fruits", Country = "Turkey"},
            //    new Product { Id = "DE246-5342", Category = "Dessert", Country = "France"},
            //    new Product { Id = "EG5875-5325", Category = "Eggs", Country = "Russia"},
            //    new Product { Id = "SS785-9874", Category = "Seasonings", Country = "Italy"},
            //    new Product { Id = "TE543-9274" , Category = "Tea", Country = "China"},
            //    new Product { Id = "AL452-9543", Category = "Alcohol", Country = "Germany"},
            //};

            //List<Item> items = new()
            //{
            //    new Item { Id = products[0].Id, Price = 100, Shop = "Pyaterka"},
            //    new Item { Id = products[1].Id, Price = 45, Shop = "Magnit"},
            //    new Item { Id = products[2].Id, Price = 120, Shop = "Eurospar"},
            //    new Item { Id = products[3].Id, Price = 30, Shop = "Pyaterka"},
            //    new Item { Id = products[4].Id, Price = 40, Shop = "Eurospar"},
            //    new Item { Id = products[5].Id, Price = 75, Shop = "Pyaterka"},
            //    new Item { Id = products[6].Id, Price = 20, Shop = "Magnit"},
            //    new Item { Id = products[7].Id, Price = 80, Shop = "Magnit"},
            //    new Item { Id = products[8].Id, Price = 70, Shop = "Eurospar"},
            //    new Item { Id = products[9].Id, Price = 150, Shop = "Pyaterka"},
            //};

            //var prodprice = from item in items
            //                join prod in products on item.Id equals prod.Id
            //                select new
            //                {
            //                    Id = item.Id,
            //                    Item = item.Price,
            //                    Shop = item.Shop,
            //                    Country = prod.Country,
            //                };
            //var prodpricecountry = from prod in prodprice
            //                       group prod by prod.Country into prodcountrygroup
            //                       orderby prodcountrygroup.Count(), prodcountrygroup.Key
            //                       let minprice = prodcountrygroup.Select(x => x.Item).Min()
            //                       select new
            //                       {
            //                           Count = prodcountrygroup.Count(),
            //                           Country = prodcountrygroup.Key,
            //                           MinPrice = minprice,
            //                       };

            //foreach (var country in prodpricecountry)
            //{
            //    Console.WriteLine($"{country.Count} {country.Country} {country.MinPrice}");
            //}

            //86

            //List<Discount> discounts = new()
            //{
            //    new Discount { DiscountPercent = 5, Code = 0, Shop = "Pyaterka" },
            //    new Discount { DiscountPercent = 3, Code = 0, Shop = "Magnit" },
            //    new Discount { DiscountPercent = 10, Code = 1, Shop = "Eurospar" },
            //    new Discount { DiscountPercent = 7, Code = 2, Shop = "Pyaterka" },
            //    new Discount { DiscountPercent = 8, Code = 3, Shop = "Magnit" },
            //    new Discount { DiscountPercent = 2, Code = 3, Shop = "Eutospar" },
            //    new Discount { DiscountPercent = 1, Code = 4, Shop = "Magnit" },
            //    new Discount { DiscountPercent = 2, Code = 5, Shop = "Pyaterka" },
            //};

            //List<Item> items = new()
            //{
            //    new Item { Id = "MI343-9874", Price = 100, Shop = "Pyaterka"},
            //    new Item { Id = "VE254-8645", Price = 30, Shop = "Pyaterka"},
            //    new Item { Id = "DE246-5342", Price = 75, Shop = "Pyaterka"},
            //    new Item { Id = "AL452-9543", Price = 150, Shop = "Pyaterka"},
            //    new Item { Id = "BR954-7564", Price = 40, Shop = "Pyaterka"},
            //    new Item { Id = "EG5875-5325", Price = 15, Shop = "Pyaterka"},
            //    new Item { Id = "SS785-9874", Price = 70, Shop = "Pyaterka"},
            //    new Item { Id = "ME111-3645", Price = 105, Shop = "Pyaterka"},
            //    new Item { Id = "FR987-1345", Price = 35, Shop = "Pyaterka"},
            //    new Item { Id = "TE543-9274", Price = 60, Shop = "Pyaterka"},



            //    new Item { Id = "BR954-7564", Price = 45, Shop = "Magnit"},
            //    new Item { Id = "EG5875-5325", Price = 20, Shop = "Magnit"},
            //    new Item { Id = "SS785-9874", Price = 80, Shop = "Magnit"},



            //    new Item { Id = "ME111-3645", Price = 120, Shop = "Eurospar"},
            //    new Item { Id = "FR987-1345", Price = 40, Shop = "Eurospar"},
            //    new Item { Id = "TE543-9274", Price = 70, Shop = "Eurospar"},

            //};

            //List<Purchase> purchases = new()
            //{
            //    new Purchase { Id = "VE254-8645", Code = 0, Shop = "Pyaterka"},
            //    new Purchase { Id = "SS785-9874", Code = 4, Shop = "Magnit"},
            //    new Purchase { Id = "BR954-7564", Code = 2, Shop = "Magnit"},
            //    new Purchase { Id = "TE543-9274", Code = 1, Shop = "Eurospar"}, 
            //    new Purchase { Id = "MI343-9874", Code = 3, Shop = "Pyaterka"},
            //    new Purchase { Id = "ME111-3645", Code = 5, Shop = "Eurospar"},
            //};

            //var disc_shop = from discount in discounts
            //                join purchase in purchases on new { discount.Shop } equals new { purchase.Shop }
            //                select new
            //                {
            //                    Id = purchase.Id,
            //                    Shop = discount.Shop,
            //                    MaxDiscount = discount.DiscountPercent,
            //                };

            //foreach (var item in disc_shop.OrderBy(x => x.Id).ThenBy(x => x.Shop))
            //{
            //    Console.WriteLine($"{item.Id} {item.Shop} {item.MaxDiscount}%");
            //}

            //var discountsS =
            //    from e in purchases
            //    join c in discounts on new { e.Code, e.Shop } equals new { c.Code, c.Shop }
            //    orderby e.Id, c.Shop
            //    select new
            //    {
            //        e.Id,
            //        c.Shop,
            //        c.DiscountPercent,
            //    };

            //foreach (var item in discountsS)
            //{
            //    Console.WriteLine($"{item.Id} {item.DiscountPercent} {item.Shop}");
            //}
            //join d in items on new { e.Shop, e.Id } equals new { d.Shop, d.Id }
            //    group new { c.DiscountPercent, d.Price } by new { e.Id, e.Shop } into g
            //    select new
            //    {
            //        g.Key.Id,
            //        g.Key.Shop,
            //        MaxDiscount = g.Max(x => x.DiscountPercent > 0 ?
            //            Convert.ToInt32(x.Price * x.DiscountPercent / 100) : 0)
            //    };

            //foreach (var discount in discountsS.OrderBy(d => d.Id).ThenBy(d => d.Shop))
            //{
            //    Console.WriteLine($"{discount.Id} {discount.Shop} {discount.MaxDiscount}");
            //}

            //96

            List
        }
    }
}