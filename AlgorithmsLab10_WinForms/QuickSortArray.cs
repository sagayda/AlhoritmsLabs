using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlgorithmsLab10_WinForms
{
    public class QuickSortArray : IArraySorter
    {
        public void Sort(int[] data)
        {
            Sort(data, 0, data.Length - 1);
        }

        private void Sort(int[] data, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(data, low, high);
                Sort(data, low, pivotIndex - 1);
                Sort(data, pivotIndex + 1, high);
            }
        }

        private int Partition(int[] data, int low, int high)
        {
            int pivot = data[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (data[j] < pivot)
                {
                    i++;
                    Swap(data, i, j);
                }
            }

            Swap(data, i + 1, high);
            return i + 1;
        }

        private void Swap(int[] data, int i, int j)
        {
            (data[j], data[i]) = (data[i], data[j]);
        }
    }

    //particaly sorted
    public class QuickSortEarlyExitArray : IArraySorter
    {
        public void Sort(int[] data)
        {
            Sort(data, 0, data.Length - 1);
        }

        private void Sort(int[] data, int low, int high)
        {
            if (low < high)
            {
                if (high - low + 1 <= 10)
                {
                    InsertionSort(data, low, high);
                    return;
                }

                int pivotIndex = Partition(data, low, high);
                Sort(data, low, pivotIndex - 1);
                Sort(data, pivotIndex + 1, high);
            }
        }

        private void Swap(int[] data, int i, int j)
        {
            (data[j], data[i]) = (data[i], data[j]);
        }

        private int Partition(int[] data, int low, int high)
        {
            int pivot = data[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (data[j] < pivot)
                {
                    i++;
                    Swap(data, i, j);
                }
            }

            Swap(data, i + 1, high);
            return i + 1;
        }

        private static void InsertionSort(int[] data, int low, int high)
        {
            for (int i = low + 1; i <= high; i++)
            {
                int current = data[i];
                int j = i - 1;

                while (j >= low && data[j] > current)
                {
                    data[j + 1] = data[j];
                    j--;
                }

                data[j + 1] = current;
            }
        }
    }

    //repeats
    public class QuickSortDutchFlagArray : IArraySorter
    {
        public void Sort(int[] data)
        {
            QuickSort(data, 0, data.Length - 1);
        }

        private void QuickSort(int[] data, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(data, left, right);
                QuickSort(data, left, pivotIndex - 1);
                QuickSort(data, pivotIndex + 1, right);
            }
        }

        private int Partition(int[] data, int left, int right)
        {
            int pivotIndex = ChoosePivot(data, left, right);
            int pivotValue = data[pivotIndex];
            Swap(data, pivotIndex, right);

            int storeIndex = left;
            for (int i = left; i < right; i++)
            {
                if (data[i] < pivotValue)
                {
                    Swap(data, i, storeIndex);
                    storeIndex++;
                }
            }

            Swap(data, storeIndex, right);
            return storeIndex;
        }

        private int ChoosePivot(int[] data, int left, int right)
        {
            int mid = (left + right) / 2;

            int first = data[left];
            int middle = data[mid];
            int last = data[right];

            int median = first;
            if ((middle < first && first < last) || (last < first && first < middle))
                median = first;
            else if ((first < middle && middle < last) || (last < middle && middle < first))
                median = middle;
            else
                median = last;

            if (median == first)
                return left;
            else if (median == middle)
                return mid;
            else
                return right;
        }

        private void Swap(int[] data, int i, int j)
        {
            (data[j], data[i]) = (data[i], data[j]);
        }
    }

    public class QuiclSortComplexArray : IArraySorter
    {
        private const int InsertionSortThreshold = 30;
        private const int MergeSortThreshold = 1000000;

        public void Sort(int[] data)
        {
            if (data == null || data.Length <= 1)
                return;

            Sort(data, 0, data.Length - 1);
        }

        private void Sort(int[] data, int left, int right)
        {
            if (left < right)
            {
                if (right - left + 1 <= InsertionSortThreshold)
                {
                    InsertionSort(data, left, right);
                }
                else if (right - left + 1 <= MergeSortThreshold)
                {
                    int pivotIndex = Partition(data, left, right);
                    Sort(data, left, pivotIndex - 1);
                    Sort(data, pivotIndex + 1, right);
                }
                else
                {
                    MergeSort(data, left, right);
                }
            }
        }

        private int Partition(int[] data, int left, int right)
        {
            int pivotIndex = ChoosePivot(data, left, right);
            Swap(data, pivotIndex, right);

            int pivot = data[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (data[j] <= pivot)
                {
                    i++;
                    Swap(data, i, j);
                }
            }

            Swap(data, i + 1, right);
            return i + 1;
        }

        private void InsertionSort(int[] data, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int current = data[i];
                int j = i - 1;

                while (j >= left && data[j] > current)
                {
                    data[j + 1] = data[j];
                    j--;
                }

                data[j + 1] = current;
            }
        }

        private void MergeSort(int[] data, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(data, left, mid);
                MergeSort(data, mid + 1, right);
                Merge(data, left, mid, right);
            }
        }

        private void Merge(int[] data, int left, int mid, int right)
        {
            int[] temp = new int[right - left + 1];
            int i = left;
            int j = mid + 1;
            int k = 0;

            while (i <= mid && j <= right)
            {
                if (data[i] <= data[j])
                {
                    temp[k] = data[i];
                    i++;
                }
                else
                {
                    temp[k] = data[j];
                    j++;
                }
                k++;
            }

            while (i <= mid)
            {
                temp[k] = data[i];
                i++;
                k++;
            }

            while (j <= right)
            {
                temp[k] = data[j];
                j++;
                k++;
            }

            for (int m = 0; m < temp.Length; m++)
            {
                data[left + m] = temp[m];
            }
        }

        private int ChoosePivot(int[] data, int left, int right)
        {
            int mid = (left + right) / 2;

            int first = data[left];
            int middle = data[mid];
            int last = data[right];

            int median;

            if ((middle < first && first < last) || (last < first && first < middle))
                median = first;
            else if ((first < middle && middle < last) || (last < middle && middle < first))
                median = middle;
            else
                median = last;

            if (median == first)
                return left;
            else if (median == middle)
                return mid;
            else
                return right;
        }

        private void Swap(int[] data, int i, int j)
        {
            (data[j], data[i]) = (data[i], data[j]);
        }
    }


    public class QuickSortList : IListSorter
    {
        public void Sort(List<int> list)
        {
            Sort(list, 0, list.Count - 1);
        }

        private void Sort(List<int> list, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(list, low, high);
                Sort(list, low, pivotIndex - 1);
                Sort(list, pivotIndex + 1, high);
            }
        }

        private int Partition(List<int> list, int low, int high)
        {
            int pivot = list[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (list[j] < pivot)
                {
                    i++;
                    Swap(list, i, j);
                }
            }

            Swap(list, i + 1, high);
            return i + 1;
        }

        private void Swap(List<int> list, int i, int j)
        {
            (list[j], list[i]) = (list[i], list[j]);
        }
    }

    //particaly sorted
    public class QuickSortEarlyExitList : IListSorter
    {
        public void Sort(List<int> list)
        {
            Sort(list, 0, list.Count - 1);
        }

        private void Sort(List<int> list, int low, int high)
        {
            if (low < high)
            {
                if (high - low + 1 <= 10)
                {
                    InsertionSort(list, low, high);
                    return;
                }

                int pivotIndex = Partition(list, low, high);
                Sort(list, low, pivotIndex - 1);
                Sort(list, pivotIndex + 1, high);
            }
        }

        private void Swap(List<int> list, int i, int j)
        {
            (list[j], list[i]) = (list[i], list[j]);
        }

        private int Partition(List<int> list, int low, int high)
        {
            int pivot = list[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (list[j] < pivot)
                {
                    i++;
                    Swap(list, i, j);
                }
            }

            Swap(list, i + 1, high);
            return i + 1;
        }

        private static void InsertionSort(List<int> list, int low, int high)
        {
            for (int i = low + 1; i <= high; i++)
            {
                int current = list[i];
                int j = i - 1;

                while (j >= low && list[j] > current)
                {
                    list[j + 1] = list[j];
                    j--;
                }

                list[j + 1] = current;
            }
        }
    }

    //repeats
    public class QuickSortDutchFlagList : IListSorter
    {
        public void Sort(List<int> list)
        {
            QuickSort(list, 0, list.Count - 1);
        }

        private void QuickSort(List<int> list, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(list, left, right);
                QuickSort(list, left, pivotIndex - 1);
                QuickSort(list, pivotIndex + 1, right);
            }
        }

        private int Partition(List<int> list, int left, int right)
        {
            int pivotIndex = ChoosePivot(list, left, right);
            int pivotValue = list[pivotIndex];
            Swap(list, pivotIndex, right);

            int storeIndex = left;
            for (int i = left; i < right; i++)
            {
                if (list[i] < pivotValue)
                {
                    Swap(list, i, storeIndex);
                    storeIndex++;
                }
            }

            Swap(list, storeIndex, right);
            return storeIndex;
        }

        //private int ChoosePivot(List<int> list, int left, int right)
        //{
        //    return (left + right) / 2;
        //}

        private int ChoosePivot(List<int> list, int left, int right)
        {
            int mid = (left + right) / 2;

            int first = list[left];
            int middle = list[mid];
            int last = list[right];

            int median = first;
            if ((middle < first && first < last) || (last < first && first < middle))
                median = first;
            else if ((first < middle && middle < last) || (last < middle && middle < first))
                median = middle;
            else
                median = last;

            if (median == first)
                return left;
            else if (median == middle)
                return mid;
            else
                return right;
        }

        private void Swap(List<int> list, int i, int j)
        {
            (list[j], list[i]) = (list[i], list[j]);
        }
    }

    public class QuiclSortComplexList : IListSorter
    {
        private const int InsertionSortThreshold = 30;
        private const int MergeSortThreshold = 1000000;

        public void Sort(List<int> numbers)
        {
            if (numbers == null || numbers.Count <= 1)
                return;

            QuickSortRecursive(numbers, 0, numbers.Count - 1);
        }

        private void QuickSortRecursive(List<int> numbers, int left, int right)
        {
            if (left < right)
            {
                if (right - left + 1 <= InsertionSortThreshold)
                {
                    InsertionSort(numbers, left, right);
                }
                else if (right - left + 1 <= MergeSortThreshold)
                {
                    int pivotIndex = Partition(numbers, left, right);
                    QuickSortRecursive(numbers, left, pivotIndex - 1);
                    QuickSortRecursive(numbers, pivotIndex + 1, right);
                }
                else
                {
                    MergeSort(numbers, left, right);
                }
            }
        }

        private int Partition(List<int> numbers, int left, int right)
        {
            int pivotIndex = ChoosePivot(numbers, left, right);
            Swap(numbers, pivotIndex, right);

            int pivot = numbers[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (numbers[j] <= pivot)
                {
                    i++;
                    Swap(numbers, i, j);
                }
            }

            Swap(numbers, i + 1, right);
            return i + 1;
        }

        private void InsertionSort(List<int> numbers, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int current = numbers[i];
                int j = i - 1;

                while (j >= left && numbers[j] > current)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }

                numbers[j + 1] = current;
            }
        }

        private void MergeSort(List<int> numbers, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(numbers, left, mid);
                MergeSort(numbers, mid + 1, right);
                Merge(numbers, left, mid, right);
            }
        }

        private void Merge(List<int> numbers, int left, int mid, int right)
        {
            int[] temp = new int[right - left + 1];
            int i = left;
            int j = mid + 1;
            int k = 0;

            while (i <= mid && j <= right)
            {
                if (numbers[i] <= numbers[j])
                {
                    temp[k] = numbers[i];
                    i++;
                }
                else
                {
                    temp[k] = numbers[j];
                    j++;
                }
                k++;
            }

            while (i <= mid)
            {
                temp[k] = numbers[i];
                i++;
                k++;
            }

            while (j <= right)
            {
                temp[k] = numbers[j];
                j++;
                k++;
            }

            for (int m = 0; m < temp.Length; m++)
            {
                numbers[left + m] = temp[m];
            }
        }

        private int ChoosePivot(List<int> list, int left, int right)
        {
            int mid = (left + right) / 2;

            int first = list[left];
            int middle = list[mid];
            int last = list[right];

            int median;

            if ((middle < first && first < last) || (last < first && first < middle))
                median = first;
            else if ((first < middle && middle < last) || (last < middle && middle < first))
                median = middle;
            else
                median = last;

            if (median == first)
                return left;
            else if (median == middle)
                return mid;
            else
                return right;
        }

        private void Swap(List<int> numbers, int i, int j)
        {
            (numbers[j], numbers[i]) = (numbers[i], numbers[j]);
        }
    }

}
