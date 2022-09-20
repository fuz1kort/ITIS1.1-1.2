double x = double.Parse(Console.ReadLine()), y = 0;
int k = int.Parse(Console.ReadLine());
double p = x;
while (k > 0)
{
    y += Math.Sin(p);
    k--;
    p = Math.Sin(p);
}
Console.WriteLine(y);
//Корни 