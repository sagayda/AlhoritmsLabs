using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLab10_WinForms
{
    public class QuickSort : ISorter
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
    public class QuickSortEarlyExit : ISorter
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
    public class QuickSortDutchFlag : ISorter
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
}
