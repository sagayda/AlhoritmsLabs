using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLab10_WinForms
{
    public class CocktailSortArray : IArraySorter
    {
        public void Sort(int[] data)
        {
            bool swapped;
            do
            {
                swapped = false;

                for (int i = 0; i < data.Length - 1; i++)
                {
                    if (data[i] > data[i + 1])
                    {
                        Swap(data, i, i + 1);
                        swapped = true;
                    }
                }

                if (!swapped)
                    break;

                swapped = false;

                for (int i = data.Length - 2; i >= 0; i--)
                {
                    if (data[i] > data[i + 1])
                    {
                        Swap(data, i, i + 1);
                        swapped = true;
                    }
                }

            } while (swapped);
        }

        private void Swap(int[] data, int i, int j)
        {
            (data[j], data[i]) = (data[i], data[j]);
        }
    }

    public class CocktailSortList : IListSorter
    {
        public void Sort(List<int> list)
        {
            bool swapped;
            do
            {
                swapped = false;

                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        Swap(list, i, i + 1);
                        swapped = true;
                    }
                }

                if (!swapped)
                    break;

                swapped = false;

                for (int i = list.Count - 2; i >= 0; i--)
                {
                    if (list[i] > list[i + 1])
                    {
                        Swap(list, i, i + 1);
                        swapped = true;
                    }
                }

            } while (swapped);
        }

        private void Swap(List<int> list, int i, int j)
        {
            (list[j], list[i]) = (list[i], list[j]);
        }
    }

}
