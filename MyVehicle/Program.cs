using System.Reflection;

namespace MyVehicle
{
    public class Program
    {
        public static void Main()
        {
            Car lada = new(100, 40, "Kazan", "Cheboksary");

            Type typelada = lada.GetType();
            Console.WriteLine(typelada);

            Type typecar = typeof(Car);
            Console.WriteLine(typecar);

            
            MethodInfo[] methods = typecar.GetMethods();
            foreach (var method in methods)
            {
                Console.Write($"{method.ReturnType}, {method.Name}(");
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write($"{parameters[i].ParameterType}, {parameters[i].Name}");
                    if (i < parameters.Length - 1) Console.Write(", ");
                }
                Console.WriteLine(")");
            }

            FieldInfo[] fields = typecar.GetFields(BindingFlags.NonPublic | BindingFlags.Public 
                                            | BindingFlags.Instance | BindingFlags.Static);
            foreach(var field in fields)
            {
                Console.WriteLine($"{field.FieldType}, {field.Name}");
            }

            PropertyInfo[] properties = typecar.GetProperties();
            foreach(var property in properties)
            {
                Console.WriteLine($"{property.PropertyType}, {property.Name}");
            }

            //typecar.GetField("townFrom", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(lada, "Moscow");

            //typecar.GetField("currspeed").SetValue(lada, 50);

            //typecar.GetProperty("MaxSpeed").SetValue(lada, 150);

            ConstructorInfo ctor = typecar.GetConstructor(new Type[] { typeof(int), typeof(int), typeof(string), typeof(string) });


            var vesta = ctor.Invoke(new object[] { 150, 60, "Astana", "London" }) as Car;
            Console.WriteLine(vesta.currSpeed);
            var speedup = typecar.GetMethod("SpeedUp");
            var go = typecar.GetMethod("Go", BindingFlags.Static | BindingFlags.Public);
            var setupspeed = typecar.GetMethod("SetupSpeed", BindingFlags.Public | BindingFlags.Instance);

            speedup.Invoke(vesta, new object[] { });

            go.Invoke(vesta, new object[] { });

            Console.WriteLine(setupspeed.Invoke(vesta, new object[] { 150 }));
        }
    }
}