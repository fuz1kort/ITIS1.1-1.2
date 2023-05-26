namespace MyJson
{
    class Program
    {
        private static readonly string path = Directory.GetCurrentDirectory() + @"/path.txt";
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
            var task = Task.Run(() => MyJson.WriteJsonInFile(json, path));
            await task;
            Console.WriteLine(json);

            var obj = MyJson.DeserializeObject<Car>(path);
            Console.WriteLine($"Name: {obj.Name}\nMaxSpeed: {obj.MaxSpeed}\nColour: {obj.Colour}");

        }
    }

    public class Car
    {
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public string Colour { get; set; }
    }
}