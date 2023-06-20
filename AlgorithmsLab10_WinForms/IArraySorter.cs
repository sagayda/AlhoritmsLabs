using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLab10_WinForms
{
    public interface IArraySorter
    {
        public void Sort(int[] data);
    }

    public interface IListSorter
    {
        public void Sort(List<int> data);
    }
}
