using System;

int[] GetArr(int n)
{
    Random r = new Random();

    int[] arr = new int[n];
    for (int i = 0; i < n; i++)
        arr[i] = r.Next(-100, 101);

    return arr;
}

void PrintArr(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
        Console.Write($" {arr[i]} ");
    Console.WriteLine();
}

int n = 20;
int[] arr = GetArr(n);
PrintArr(arr);

static int[] QuickSort(int[] arr, int left, int right)
{
    if (left >= right)
        return arr;
    int pivotIndex = GetPivotIndex(arr, left, right);
    QuickSort(arr, left, pivotIndex - 1);
    QuickSort(arr, pivotIndex + 1, right);
    return arr;
}

static int GetPivotIndex(int[] arr, int left, int right)
{
    int temp;
    int pivot = left - 1;

    for (int i = left; i <= right; i++)
        if (arr[i] < arr[right])
        {
            pivot++;
            temp = arr[pivot];
            arr[pivot] = arr[i];
            arr[i] = temp;
        }

    pivot++;
    temp = arr[pivot];
    arr[pivot] = arr[right];
    arr[right] = temp;

    return pivot;
}

Console.WriteLine("Применена быстрая сортировка");
int[] sortArr = QuickSort(arr, 0, n - 1);
PrintArr(sortArr);