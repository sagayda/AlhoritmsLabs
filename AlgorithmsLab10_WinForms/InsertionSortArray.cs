using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLab10_WinForms
{
    public class InsertionSortArray : IArraySorter
    {
        public void Sort(int[] data)
        {
            for (int i = 1; i < data.Length; i++)
            {
                int key = data[i];
                int j = i - 1;

                while (j >= 0 && data[j] > key)
                {
                    data[j + 1] = data[j];
                    j--;
                }

                data[j + 1] = key;
            }
        }
    }

    public class InsertionSortList : IListSorter
    {
        public void Sort(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int key = list[i];
                int j = i - 1;

                while (j >= 0 && list[j] > key)
                {
                    list[j + 1] = list[j];
                    j--;
                }

                list[j + 1] = key;
            }
        }
    }
}
