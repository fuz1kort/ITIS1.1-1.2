int[,] GetMatrOdd(int n)
    {
    int m = n;
    int[,] Matr = new int[n,m];
    Random r = new Random();
    for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
        {

            while (true)
            {
                int x = r.Next(-100, 100);
                if (x % 2 == 1)
                {
                    Matr[i, j] = x;
                    break;
                }
            }
        }
            

    return Matr;
}

void WriteFileMatr(int[,] Matr, int n)
{
    using (StreamWriter stream = new StreamWriter("matr.txt"))
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                stream.Write("{0} ", Matr[i, j]);
            stream.WriteLine();
        } 
        stream.Close();
    }   
}

int[,] ReadFileMatr(string file, int n)
{
    using StreamReader streamread = new StreamReader(file);
    int[,] matr = new int[n,n];
    for (int i = 0; i < n; i++)
    {
        string[] reader = streamread.ReadLine().Split(" ");
        for (int j = 0; j < n; j++)
            matr[i, j] = int.Parse(reader[j]);
    }
    streamread.Close();
    return matr;
}


void WriteMatr(int[,] Matr, int n)
{
    for(int i = 0; i < n;i++)
    {
        for (int j = 0; j < n; j++)
            Console.Write($"{Matr[i, j]} ");
        Console.WriteLine();
    }
    Console.WriteLine();
}
Console.WriteLine("Создать матрицу из нечётных и прочитать вторую матрицу");
Console.WriteLine();
int n = 5;
int[,] matr1 = GetMatrOdd(n);
WriteMatr(matr1, n);
WriteFileMatr(GetMatrOdd(n), n);
int[,] matr2 = ReadFileMatr("matr.txt", n);
WriteMatr(matr2, n);
Console.WriteLine();
Console.WriteLine("Найти сумму матриц");
Console.WriteLine();
int[,] matr3 = new int[n, n]; 

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        matr3[i, j] = matr1[i, j] + matr2[i, j];
    }
}

WriteMatr(matr3, n);
Console.WriteLine();
Console.WriteLine("Вывести столбец с наибольшим количеством простых чисел");
Console.WriteLine();
bool isPrime(int n)
{
    for(int i = 2; i < (n/2)+1; i++)
    {
        if (n%i==0)
            return false;
    }
    return true;
}

int[] primecnt = new int[5];
for (int i = 0; i < n; i++)
    for(int j =0;j < n; j++)
    {
        if (isPrime(matr1[i,j]))
            primecnt[i]++;
    }

int Maxcnt = -1;
int indexmax = -1;
for (int i = 0; i < n; i++)
    if (primecnt[i] > Maxcnt)
    {
        Maxcnt = primecnt[i];
        indexmax = i;
    }
if (indexmax == -1)
    Console.WriteLine("Простых чисел нет");

for (int i = 0; i < n; i++)
    Console.WriteLine(matr1[i, indexmax]);

Console.WriteLine();
Console.WriteLine("Является ли вторая матрица магическим квадратом?");
Console.WriteLine();

bool IsMagic(int[,] a, int n)
{
    int size = n;
    // массив для хранения опорных сумм
    int[] sum = new int[2 * (size + 1)];

    // заполнение сумм строк и столбцов
    int rowSum, colSum;
    for (int i = 0; i < size; i++)
    {
        rowSum = 0; colSum = 0;
        for (int j = 0; j < size; j++)
        {
            rowSum += matr2[i, j];
            colSum += matr2[j, i];
        }
        sum[i] = rowSum;
        sum[size + i] = colSum;
    }

    // записать суммы диагоналей
    int d1 = 0, d2 = 0;
    for (int i = 0; i < size; i++)
    {
        d1 += matr2[i, i];
        d2 += matr2[size - i - 1, i];
    }
    sum[size * 2] = d1;
    sum[size * 2 + 1] = d2;

    return IsConstantArray(sum);
}
// одинаковые ли числа в массиве
bool IsConstantArray(int[] a)
{
    for (int i = 1; i < a.Length; i++)
    {
        if (a[0] != a[i]) return false;
    }
    return true;
}
if (IsMagic(matr2, n)) Console.WriteLine("Вторая матрица - магический квадрат");
else Console.WriteLine("Вторая матрица НЕ магический квадрат");