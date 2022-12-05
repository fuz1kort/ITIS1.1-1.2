static void Merge(int[] a, int l, int m, int r)
{
    int i, j, k;

    int n1 = m - l + 1;
    int n2 = r - m;

    int[] left = new int[n1 + 1];
    int[] right = new int[n2 + 1];

    for (i = 0; i < n1; i++)
    {
        left[i] = a[l + i];
    }

    for (j = 1; j <= n2; j++)
    {
        right[j - 1] = a[m + j];
    }

    left[n1] = int.MaxValue;
    right[n2] = int.MaxValue;

    i = 0;
    j = 0;

    for (k = l; k <= r; k++)
    {
        if (left[i] < right[j])
        {
            a[k] = left[i];
            i = i + 1;
        }
        else
        {
            a[k] = right[j];
            j = j + 1;
        }
    }
}

static void MergeSort(int[] a, int l, int r)
{
    int q;

    if (l < r)
    {
        q = (l + r) / 2;
        MergeSort(a, l, q);
        MergeSort(a, q + 1, r);
        Merge(a, l, q, r);
    }
}

Random r = new Random();
var n = 10;
int[] a = new int[n];
for(int i = 0; i < n; i++)
    a[i] = r.Next(100);
//MergeSort(a, 0, n - 1);
SortArray(a, 0, n - 1);
foreach (int i in a) Console.Write($"{i} ");

static int[] SortArray(int[] a, int l, int r)
{
    var i = l;
    var j = r;
    var p = a[l];
    while (i <= j)
    {
        while (a[i] < p)
        {
            i++;
        }

        while (a[j] > p)
        {
            j--;
        }
        if (i <= j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
            i++;
            j--;
        }
    }

    if (l < j)
        SortArray(a, l, j);
    if (i < r)
        SortArray(a, i, r);
    return a;
}
