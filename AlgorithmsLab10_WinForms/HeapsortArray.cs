using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLab10_WinForms
{
    public class HeapsortArray : IArraySorter
    {
        public void Sort(int[] data)
        {
            int n = data.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(data, n, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                Swap(data, 0, i);
                Heapify(data, i, 0);
            }
        }

        private void Heapify(int[] data, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && data[left] > data[largest])
            {
                largest = left;
            }

            if (right < n && data[right] > data[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                Swap(data, i, largest);
                Heapify(data, n, largest);
            }
        }

        private void Swap(int[] data, int i, int j)
        {
            (data[j], data[i]) = (data[i], data[j]);
        }
    }

    public class HeapsortList : IListSorter
    {
        public void Sort(List<int> list)
        {
            int n = list.Count;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(list, n, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                Swap(list, 0, i);
                Heapify(list, i, 0);
            }
        }

        private void Heapify(List<int> list, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && list[left] > list[largest])
            {
                largest = left;
            }

            if (right < n && list[right] > list[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                Swap(list, i, largest);
                Heapify(list, n, largest);
            }
        }

        private void Swap(List<int> list, int i, int j)
        {
            (list[j], list[i]) = (list[i], list[j]);
        }
    }
}
