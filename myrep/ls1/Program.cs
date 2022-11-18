//int n = 10, m = 10;
//Random r = new Random();
//int[,] matr = new int[n, m];

//for (int i = 0; i < n; i++)
//{
//    for (int j = 0; j < m; j++)
//    {
//        matr[i, j] = r.Next(1000);

//    }
//}

//for (int i = 0; i < n; i++)
//{
//    for (int j = 0; j < m; j++)
//    {

//        Console.Write($"{matr[i, j]} ");
//    }
//    Console.WriteLine();
//}
//Console.WriteLine();
/*
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
Console.WriteLine(cnt);
*/

//String str;
//str = Console.ReadLine();
//bool ch = false;
//foreach (string word in str.Split())
//{
//    bool pol = true;
//    for (int i = 0; i < word.Length; i++)
//    {
//        if (word[i] != word[word.Length - 1 - i])
//        {
//            pol = false;
//            break;
//        }
//    }
//    if (pol)
//    {
//        Console.WriteLine(word);
//        ch = true;
//    }
//}
//if(!ch)
//{
//    Console.WriteLine("Палиндромов нет");
//}

//String str;
//str = Console.ReadLine();
//bool ch2 = false;
//foreach (string word in str.Split(" "))
//{
//    bool ch = false;
//    for (int i = 1; i < word.Length; i++)
//    {
//        if (word[0] == word[i])
//        {
//            ch = true;
//            break;
//        }
//    }
//    if (ch)
//    {
//        Console.WriteLine(word);
//        ch2 = true;
//    }
//}
//if (!ch2)
//{
//    Console.WriteLine("Таких слов нет");
//}


//String str, str2;
//str2 = Console.ReadLine();
//str = str2.ToLower();
//bool ch2 = true;
//foreach (string word in str.Split(" "))
//{
//    bool pol = true;
//    for (int i = 0; i < word.Length - 1; i++)
//    {
//        if (word[i + 1] < word[i])
//        {
//            pol = false;
//            break;
//        }
//    }
//    if (pol)
//    {
//        Console.WriteLine(word);
//        ch2 = false;
//    }
//}
//if (ch2)
//{
//    Console.WriteLine("Таких слов нет");
//}

//String str;
//str = Console.ReadLine();
//int maxlen = 0, minlen = 1000000000;
//String maxword = "", minword = "";
//foreach (String word in str.Split(" "))
//{
//    if (maxlen < word.Length)
//    {
//        maxlen = word.Length;
//        maxword = word;
//    }
//    if(minlen > word.Length)
//    {
//        minlen = word.Length;
//        minword = word;
//    }

//}

//Console.WriteLine(maxword);
//Console.WriteLine(minword);

//String str;
//str = Console.ReadLine();
//string[] arr = str.Split(new char[] {' '});
//for (int i = 0; i < arr.Length-1; i++)
//{
//    for (int j = i+1; j < arr.Length; j++)
//    {
//        if (arr[i] == arr[j])
//        {
//            str=str.Replace(arr[i], "");
//            break;
//        }
//    }
//}
//Console.WriteLine(str);

//string path = "note1.txt";
//string text = "Hello World!\nHello bro";

//// полная перезапись файла 
//using (StreamWriter writer = new StreamWriter(path, false))
//{
//    await writer.WriteLineAsync(text);
//}



/*using (StreamReader reader = new StreamReader(path))
{
    string words = await reader.ReadToEndAsync();
    string[] arr = words.Split(new char[] {' ', '\n', '\t'});
    for (int i = 0; i < arr.Length-1; i++) {
        for (int j = i+1; j < arr.Length; j++)
        {
            if (arr[i] == arr[j]) {
                arr[j] = "";
                
            }
        }
    }
    
    string res = $" {string.Join(" ", arr)}";
    Console.WriteLine(res);
}*/


/*bool CheakWord(string word, string[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] == word)
        {
            return true;
        }
    }
    return false;

}
using (StreamReader reader = new StreamReader(path))
{
    string words = await reader.ReadToEndAsync();
    string[] arr = words.Split(new char[] { ' ', '\n', '\t' });
    string word = Console.ReadLine();

    Console.WriteLine(CheakWord(word, arr));
    
}*/


//using (StreamReader reader = new StreamReader(path))
//{
//    string words = await reader.ReadToEndAsync();
//    string[] arr = words.Split(new char[] { ' ', '\n', '\t' });
//    Console.WriteLine("Введите подстроку");
//    string substring = Console.ReadLine();
//    int lenghtsubstring = substring.Length;
//    for(int i=0; i<words.Length; i++)
//    {
//        var substr1=words.Substring(i,i+lenghtsubstring);
//        if (substr1 == substring)
//        {
//            Console.WriteLine(true);
//            break;
//        }
//    }
//}

//using System.Diagnostics.Tracing;

//string path = "note1.txt";
//string text = "Veeeeery coool days";

//// полная перезапись файла 
//using (StreamWriter writer = new StreamWriter(path, false))
//{
//    await writer.WriteLineAsync(text);
//}
//using (StreamReader reader = new StreamReader(path))
//{
//    string line = await reader.ReadToEndAsync();
//    string[] words = line.Split(new char[] { ' ', '\r' });
//    for (int i = 0; i < words.Length; i++)
//    {
//        string word = words[i];
//        if (word.Length == 4)
//        {
//            word = word.Substring(1, 3) + word[0];
//            words[i] = word;
//        }
//    }
//    for(int i = 0; i < words.Length; i++)
//    {
//        Console.WriteLine(words[i]);
//    }
//}

//bool FindInt(int[] mas, int x, int a, int b) //обязательно отсорченный массив
//{
//    while(a<=b)
//    {
//        int c = (a + b) / 2;
//        if (mas[c] == x) return true;
//        if (mas[c] < x) a = c+1;
//        else b = c-1;
//        Console.WriteLine($"{a} {b}");
//    }
//    return false;
//}



//bool FindIntRec(int[] mas, int x, int a, int b) //обязательно отсорченный массив
//{
//    int c = (a + b) / 2;
//    if (mas[c] == x) return true;
//    if (a > b) return false;
//    if (mas[c] < x) return FindIntRec(mas,x,c+1,b);
//    return FindIntRec(mas, x, a, c - 1);
//    return false;
//}

//int SumMass(int[] arr, int k)
//{
//   return (k == 0) ? arr[0] : arr[k] + SumMass(arr, k - 1);
//}

//int MaxMass(int[] mas, int k)
//{
//    if (k == 0)
//        return mas[0];
//    var oldMax = MaxMass(mas, k);
//    return (oldMax < mas[k]) ? mas[k] : oldMax;
//}


//bool Symmetr(int[] arr, int l, int r)
//{

//    return (arr[l] == arr[r-1]) ? Symmetr(arr, l + 1, r - 1) : false;
//}

//double FastPow(double x, int p)
//{
//    if (p == 0) return 1;
//    if (p < 0) return FastPow(1 / x, -p);
//    if (p == 1) return x;
//    return x * FastPow(x, p - 1);
//}
//Console.WriteLine(FastPow(2, -2));

//void MergeSort(int[] arr, int a, int b)
//{
//    if(b-a<1) return;
//    int c = (a + b) / 2;
//    MergeSort(arr, a, c);
//    MergeSort(arr, c+1, b);
//    int[] mergeArr=new int[b-a+1];
//    int i = a, j = c + 1;
//    for (int k = 0; k < mergeArr.Length; k++)
//    {
//        if(i>c) mergeArr[k] = arr[j++]; //закончился 1 массив
//        else if (j>b) mergeArr[k] = arr[i++]; //закончился 2 массив
//        else if (arr[i] < arr[j]) mergeArr[k] = arr[i++];
//        else mergeArr[k] = arr[j++];
//    }
//    i = a;
//    for(int k = 0; k < mergeArr.Length; k++)
//        arr[i++]=mergeArr[k];
//}

double FastPow(double x, int p)
{
    if (p == 0) return 1;
    if (p < 0) return FastPow(1 / x, -p);
    return (p % 2 == 0) ? (FastPow(x * x, p / 2)) : x * (FastPow(x, p - 1));
}
Console.WriteLine(FastPow(3, 4));