namespace MyJson
{
    class Program
    {
        private static readonly string path = Directory.GetCurrentDirectory() + @"/path.txt";
        static async Task Main()
        {
            var citroen = new Car()
            {
                Name = "C4",
                MaxSpeed = 150,
                Colour = "White"
            };

            var json = MyJson.SerializeObject(citroen);
            var task = Task.Run(() => MyJson.WriteJsonInFile(json, path));
            await task;
            Console.WriteLine(json);

            var obj = MyJson.DeserializeObject<Car>(path);
            Console.WriteLine($"Name: {obj.Name}\nMaxSpeed: {obj.MaxSpeed}\nColour: {obj.Colour}");

        }
    }

    class Car
    {
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public string Colour { get; set; }
    }
}