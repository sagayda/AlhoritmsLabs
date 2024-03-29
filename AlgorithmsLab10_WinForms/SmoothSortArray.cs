﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLab10_WinForms
{
    public class SmoothSortArray : IArraySorter
    {
        public void Sort(int[] data)
        {
            int n = data.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                SiftDown(data, n, i);
            }

            int m = n;

            while (m > 1)
            {
                m--;
                Swap(data, 0, m);
                SiftDown(data, m, 0);
            }
        }

        private void SiftDown(int[] data, int n, int i)
        {
            while (true)
            {
                int child = 2 * i + 1;

                if (child >= n)
                {
                    break;
                }

                if (child + 1 < n && data[child] < data[child + 1])
                {
                    child++;
                }

                if (data[i] >= data[child])
                {
                    break;
                }

                Swap(data, i, child);
                i = child;
            }
        }

        private void Swap(int[] data, int i, int j)
        {
            (data[j], data[i]) = (data[i], data[j]);
        }
    }

    public class SmoothSortList : IListSorter
    {
        public void Sort(List<int> list)
        {
            int n = list.Count;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                SiftDown(list, n, i);
            }

            int m = n;

            while (m > 1)
            {
                m--;
                Swap(list, 0, m);
                SiftDown(list, m, 0);
            }
        }

        private void SiftDown(List<int> list, int n, int i)
        {
            while (true)
            {
                int child = 2 * i + 1;

                if (child >= n)
                {
                    break;
                }

                if (child + 1 < n && list[child] < list[child + 1])
                {
                    child++;
                }

                if (list[i] >= list[child])
                {
                    break;
                }

                Swap(list, i, child);
                i = child;
            }
        }

        private void Swap(List<int> list, int i, int j)
        {
            (list[j], list[i]) = (list[i], list[j]);
        }
    }
}
