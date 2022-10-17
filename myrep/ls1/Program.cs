/*int n = 3, m = 3;
Random r = new Random();
int[,] matr = new int[n, m];

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        matr[i, j] = r.Next(100);
        
    }
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {

        Console.Write($"{matr[i, j]} ");
    }
    Console.WriteLine();
}
Console.WriteLine();
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {

        Console.Write($"{matr[m-1-j, i]} ");
    }
    Console.WriteLine();
}




int n = 3, m = 3, summa = 0;
Random r = new Random();
int[,] matr = new int[n, m];
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        matr[i, j] = r.Next(100);
        if (i == 0 || j == 0 || i == (n - 1) || j == (m - 1))
        {
            summa += matr[i, j];
        }
    }
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        Console.Write($"{matr[i, j]} ");
    }
    Console.WriteLine();
}

Console.WriteLine(summa);

int n = 3, m = 3;
int[,] matr = new int[n, m];
Random r = new Random();

int summ = 0;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        matr[i, j] = r.Next(100);
        if (i == j || (i == n - j - 1))
        {
            summ += matr[i, j];
        }
    }
}
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        Console.Write($"{matr[i, j]} ");
    }
    Console.WriteLine();
}


int n = 3, m = 5;
int f = 5, k = 2;
int[,] matr = new int[n, m];
int[,] matr2 = new int[f, k];
int[,] matr3 = new int[n, k];
Random r = new Random();
for(int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        matr[i, j] = r.Next(10);
    }
}

for(int i = 0; i < f; i++)
{
    for (int j = 0; j < k; j++)
    {
        matr2[i, j] = r.Next(10);
    }
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < k; j++)
    {
        for (int a = 0; a < m; a++)
        {
            matr3[i, j] += matr[i, a] * matr2[a, j];
        }
    }
}
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        Console.Write($"{matr[i, j]} ");
    }
    Console.WriteLine();
}

Console.WriteLine();

for (int i = 0; i < f; i++)
{
    for (int j = 0; j < k; j++)
    {
        Console.Write($"{matr2[i, j]} ");
    }
    Console.WriteLine();
}

Console.WriteLine();

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < k; j++)
    {
        Console.Write($"{matr3[i, j]} ");
    }
    Console.WriteLine();
}


int n = 7, m = 5, c;
int[,] matr = new int[n, m];
Random r = new Random();
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        matr[i, j] = r.Next(10);
    }
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        Console.Write($"{matr[i, j]} ");
    }
    Console.WriteLine();
}

Console.WriteLine();

for (int i = 0; i < n-1; i=i+2)
{
    for(int j = 0; j < m; j++)
    {
        
        c = matr[i, j];
        matr[i, j] = matr[i + 1, j];
        matr[i + 1, j] = c;
        
    }
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        Console.Write($"{matr[i, j]} ");
    }
    Console.WriteLine();
}

Console.WriteLine();

*/


Random r = new Random();

int[] mass = new int[r.Next(10,20)];
for (int i = 0; i < mass.Length; i++)
{
    mass[i] = r.Next(100);

}

int cnt = 0;
for (int i = 1; i < mass.Length-1; i++)
{
    if (mass[i] > mass[i-1] && mass[i] > mass[i + 1])
    {
        cnt++;
        Console.Write($"{mass[i]} ");
    }

}
Console.WriteLine();
for (int i = 0; i < mass.Length; i++)
{
    Console.Write($"{mass[i]} ");
}
Console.WriteLine();
Console.WriteLine($"Ответ: {cnt}");