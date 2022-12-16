namespace MyVehicle
{
    public class Program
    {
        public static void Main()
        {
            var list = new List<Vehicle>()
            {
                   new Car(120,10,"Казани","Нижнекамск"),
                   new Ship(60,5,"Москвы","Казань"),
                   new Plane(1000,555, "Рязани", "Краснодар"),
            };
            foreach (var f in list)
                Console.WriteLine(f);
            foreach (var f in list)
                f.SpeedUp();
            foreach (var f in list)
                Console.WriteLine(f);
            foreach (var f in list)
                f.SpeedDown();
            foreach (var f in list)
                Console.WriteLine(f);
        }
    }
}