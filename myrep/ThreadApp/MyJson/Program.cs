namespace MyJson
{
    class Program
    {
        private static readonly string path1 = Directory.GetCurrentDirectory() + @"/path1.txt";
        private static readonly string path2 = Directory.GetCurrentDirectory() + @"/path2.txt";
        static async Task Main()
        {
            var cars = new List<Car>()
            {
                new Car{ Name = "Citroen", MaxSpeed = 120, Colour = "White" },
                new Car{ Name = "BMW", MaxSpeed = 300, Colour = "Black" },
                new Car{ Name = "Mercedes-Benz", MaxSpeed = 250, Colour = "Green"}
            };

            var lada = new Car()
            {
                Name = "Vesta",
                MaxSpeed = 150,
                Colour = "Silver"
            };


            var json = MyJson.SerializeObject(lada);
            var task1 = Task.Run(() => MyJson.WriteJsonInFile(json, path1));
            await task1;
            Console.WriteLine(json);
            var obje = MyJson.DeserializeObject<Car>(path1);
            Console.WriteLine($"Name: {obje.Name}\nMaxSpeed: {obje.MaxSpeed}\nColour: {obje.Colour}");



            var jsons = MyJson.SerializeList(cars);
            var task2 = Task.Run(() => MyJson.WriteJsonInFile(jsons, path2));
            await task2;
            Console.WriteLine(jsons);
            var objs = MyJson.DeserializeList<Car>(path2);
            foreach (var obj in objs)
            {
                Console.WriteLine($"Name: {obj.Name}\nMaxSpeed: {obj.MaxSpeed}\nColour: {obj.Colour}");
            }


        }
    }

    public class Car
    {
        public string? Name { get; set; }
        public int MaxSpeed { get; set; }
        public string? Colour { get; set; }
    }
}