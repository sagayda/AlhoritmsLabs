using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorithmsLab10_WinForms
{
    public partial class FormFleetGeneration : Form
    {
        private Form1 formMain;

        public FormFleetGeneration(Form1 form)
        {
            formMain = form;

            InitializeComponent();
        }

        private int[] CreateFleet(int shipsCount, int floor, int ceil, double uniqueness, double sortingFactor)
        {
            Random rnd = new Random();

            int uniqueCount = (int)Math.Floor(shipsCount / 100f * uniqueness);
            int unUniqueCount = shipsCount - uniqueCount;

            if (uniqueCount > ceil - floor)
                throw new ArgumentException("Invalid uniqueness!");

            if (uniqueCount <= 0)
            {
                uniqueCount = 1;
                unUniqueCount = shipsCount - uniqueCount;
            }

            HashSet<int> uniqueSet = new(uniqueCount);

            int j = 0;
            while (j < uniqueCount)
            {
                uniqueSet.Add(rnd.Next(floor, ceil));

                if (uniqueSet.Count <= j)
                    continue;

                j++;
            }

            int[] uniquePart = uniqueSet.ToArray();
            int[] unUniquePart = new int[unUniqueCount];

            if (unUniqueCount > 0)
            {
                for (int i = 0; i < unUniqueCount; i++)
                {
                    unUniquePart[i] = uniquePart[rnd.Next(0, uniquePart.Length - 1)];
                }
            }

            List<int> result = new(uniquePart);
            result.AddRange(unUniquePart);

            int desortedCount = (int)Math.Floor(result.Count / 100f * (100f - sortingFactor));

            if (desortedCount >= 100)
                return result.ToArray();

            result.Sort();

            for (int i = 0; i < desortedCount; i++)
            {
                int firstIndx = rnd.Next(0, result.Count - 1);
                int secondIndx = rnd.Next(0, result.Count - 1);

                (result[secondIndx], result[firstIndx]) = (result[firstIndx], result[secondIndx]);
            }

            return result.ToArray();
        }

        private void buttonCreateMultiple_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < numericFleetsCount.Value; i++)
            {
                formMain.FleetsCount++;

                try
                {
                    var fleet = CreateFleet((int)numericShipsCount.Value,
                        (int)numericCrewFloor.Value,
                        (int)numericCrewCeil.Value,
                        (double)numericUniqueness.Value,
                        (double)numericSortingFactor.Value);

                    int fleetNumber = formMain.FleetsCount;

                    while(formMain.FleetsList.ContainsKey($"Fleet №{fleetNumber} ({fleet.Length}) - {textBoxName.Text}"))
                    {
                        fleetNumber++;
                    }

                    formMain.FleetsList.Add($"Fleet №{fleetNumber} ({fleet.Length}) - {textBoxName.Text}", fleet);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return;
                }

            }
        }

        private void buttonClearFleets_Click(object sender, EventArgs e)
        {
            formMain.FleetsList.Clear();
        }
    }
}
