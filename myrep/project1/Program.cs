//using System.Security.Cryptography;

//int[] GetArray(int n)
//{
//    int[] array = new int[n];
//    Random r = new Random();
//    for (int i = 0; i < n; i++)
//        array[i] = r.Next(-100, 100);
//    return array;
//}

//int[] SortArray(int[] array, int leftIndex, int rightIndex)
//{
//    var i = leftIndex;
//    var j = rightIndex;
//    var pivot = array[leftIndex];
//    while (i <= j)
//    {
//        while (array[i] < pivot)
//        {
//            i++;
//        }

//        while (array[j] > pivot)
//        {
//            j--;
//        }
//        if (i <= j)
//        {
//            int temp = array[i];
//            array[i] = array[j];
//            array[j] = temp;
//            i++;
//            j--;
//        }
//    }

//    if (leftIndex < j)
//        SortArray(array, leftIndex, j);
//    if (i < rightIndex)
//        SortArray(array, i, rightIndex);
//    return array;
//}

//void PrintArray(int[] array,int n)
//{
//    for (int i = 0; i < n; i++)
//        Console.Write($"{array[i]} ");
//    Console.WriteLine();
//}

//int n = 30;
//int[] a = GetArray(n);
//PrintArray(a, n);
//SortArray(a,0, n-1);
//PrintArray(a, n);

//void MergeSort(int[] numbers, int left, int right)
//{
//    int[] temp = new int[25];
//    int i, left_end, num_elements, tmp_pos;
//    int mid = (left + right) / 2;
//    left_end = (mid - 1);
//    tmp_pos = left;
//    num_elements = (right - left + 1);
//    while ((left <= left_end) && (mid <= right))
//    {
//        if (numbers[left] <= numbers[mid])
//            temp[tmp_pos++] = numbers[left++];
//        else
//            temp[tmp_pos++] = numbers[mid++];
//    }
//    while (left <= left_end)
//        temp[tmp_pos++] = numbers[left++];
//    while (mid <= right)
//        temp[tmp_pos++] = numbers[mid++];
//    for (i = 0; i < num_elements; i++)
//    {
//        numbers[right] = temp[right];
//        right--;
//    }
//}
//Console.WriteLine();
//int s = 20;
//int[] b = GetArray(s);
//PrintArray(b, s);
//SortArray(b, 0, s - 1);
//PrintArray(b, s);
