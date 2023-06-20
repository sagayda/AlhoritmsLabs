using System;
using System.ComponentModel;
using System.Diagnostics;

namespace AlgorithmsLab10_WinForms
{
    public partial class Form1 : Form
    {
        public int UnitedFleetsCount { get; set; } = 0;
        public int FleetsCount { get; set; } = 0;

        public Dictionary<string, int[]> FleetsList { get; set; } = new();

        //public List<int> SortedFleetList;
        //public int[]? SortedFleet;

        public IEnumerable<int> SortedFleet;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAddFleet_Click(object sender, EventArgs e)
        {
            dataGridViewFleet.DataSource = null;

            FormFleetGeneration formFleetGeneration = new FormFleetGeneration(this);
            formFleetGeneration.ShowDialog();

            if (FleetsList.Count > 0)
            {
                comboBoxFleet.DisplayMember = "Key";
            }

            FleetsUpdated();
        }

        private void FleetsUpdated()
        {
            checkedListBoxFleet.Items.Clear();
            if (FleetsList != null)
            {
                foreach (KeyValuePair<string, int[]> fleet in FleetsList)
                {
                    checkedListBoxFleet.Items.Add(fleet.Key);
                }
            }

            BindingSource source = new()
            {
                DataSource = FleetsList,
            };

            comboBoxFleet.DataSource = source;
            comboBoxFleet.DisplayMember = "Key";


            if (comboBoxFleet.Items.Count > 0)
                comboBoxFleet.SelectedItem = comboBoxFleet.Items[0];
        }

        private void comboBoxFleet_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewFleet.Rows.Clear();

            if (comboBoxFleet.Items.Count <= 0)
                return;

            if (comboBoxFleet.SelectedItem is not KeyValuePair<string, int[]> selected)
                return;

            int[] selectedFleet = selected.Value;

            if (checkBoxOptimize.Checked)
            {
                for (int i = 0; i < selectedFleet.Length; i++)
                {
                    dataGridViewFleet.Rows.Add($"{selectedFleet[i]}");

                    if (i > 100)
                        return;
                }
            }

            foreach (var num in selectedFleet)
            {
                dataGridViewFleet.Rows.Add($"{num}");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridViewSortedFleet.Rows.Clear();

            int times = (int)numericTimesToSort.Value;

            switch (checkBoxUseList.Checked)
            {
                case false:
                    switch (comboBoxSortingAlgoritm.SelectedIndex)
                    {
                        case 0:
                            //MessageBox.Show(comboBoxSortingAlgoritm.SelectedText, "QuickSort");
                            SortSelectedFleet(new QuickSortArray(), times);
                            break;
                        case 1:
                            //MessageBox.Show(comboBoxSortingAlgoritm.SelectedText, "QuickSortDutchFlag");
                            SortSelectedFleet(new QuickSortDutchFlagArray(), times);
                            break;
                        case 2:
                            //MessageBox.Show(comboBoxSortingAlgoritm.SelectedText, "QuickSortEarlyExit");
                            SortSelectedFleet(new QuickSortEarlyExitArray(), times);
                            break;
                        case 3:
                            //MessageBox.Show(comboBoxSortingAlgoritm.SelectedText, "Heapsort");
                            SortSelectedFleet(new HeapsortArray(), times);
                            break;
                        case 4:
                            //MessageBox.Show(comboBoxSortingAlgoritm.SelectedText, "SmoothSort");
                            SortSelectedFleet(new SmoothSortArray(), times);
                            break;
                        case 5:
                            //MessageBox.Show(comboBoxSortingAlgoritm.SelectedText, "CocktailSort");
                            SortSelectedFleet(new CocktailSortArray(), times);
                            break;
                        case 6:
                            //MessageBox.Show(comboBoxSortingAlgoritm.SelectedText, "InsertionSort");
                            SortSelectedFleet(new InsertionSortArray(), times);
                            break;
                        case 7:
                            //MessageBox.Show(comboBoxSortingAlgoritm.SelectedText, "QuiclSortAll");
                            SortSelectedFleet(new QuiclSortComplexArray(), times);
                            break;
                        default:
                            break;
                    }
                    break;
                case true:
                    switch (comboBoxSortingAlgoritm.SelectedIndex)
                    {
                        case 0:
                            //MessageBox.Show(comboBoxSortingAlgoritm.SelectedText, "LQuickSort");
                            SortSelectedFleet(new QuickSortList(), times);
                            break;
                        case 1:
                            //MessageBox.Show(comboBoxSortingAlgoritm.SelectedText, "LQuickSortDutchFlag");
                            SortSelectedFleet(new QuickSortDutchFlagList(), times);
                            break;
                        case 2:
                            //MessageBox.Show(comboBoxSortingAlgoritm.SelectedText, "LQuickSortEarlyExit");
                            SortSelectedFleet(new QuickSortEarlyExitList(), times);
                            break;
                        case 3:
                            //MessageBox.Show(comboBoxSortingAlgoritm.SelectedText, "LHeapsort");
                            SortSelectedFleet(new HeapsortList(), times);
                            break;
                        case 4:
                            //MessageBox.Show(comboBoxSortingAlgoritm.SelectedText, "LSmoothSort");
                            SortSelectedFleet(new SmoothSortList(), times);
                            break;
                        case 5:
                            //MessageBox.Show(comboBoxSortingAlgoritm.SelectedText, "LCocktailSort");
                            SortSelectedFleet(new CocktailSortList(), times);
                            break;
                        case 6:
                            //MessageBox.Show(comboBoxSortingAlgoritm.SelectedText, "LInsertionSort");
                            SortSelectedFleet(new InsertionSortList(), times);
                            break;
                        case 7:
                            //MessageBox.Show(comboBoxSortingAlgoritm.SelectedText, "LQuiclSortAll");
                            SortSelectedFleet(new QuiclSortComplexList(), times);
                            break;
                        default:
                            break;
                    }
                    break;
            }

        }

        private void SortSelectedFleet(IArraySorter sorter, int times)
        {
            if (comboBoxFleet.SelectedItem is not KeyValuePair<string, int[]> selected)
                return;

            List<double> spans = new();

            for (int i = 0; i < times; i++)
            {
                int[] fleet = (int[])selected.Value.Clone();

                Stopwatch stopwatch = new();

                stopwatch.Start();
                sorter.Sort(fleet.ToArray());
                stopwatch.Stop();

                spans.Add(stopwatch.Elapsed.TotalNanoseconds);
            }

            double time = spans.Average();

            if (time < 1000000)
            {
                labelTime.Text = $"av - {time} ns";
            }
            else if (time >= 1000000 && time <= 1000000000)
            {
                labelTime.Text = $"av - {time / 1000000} ms";
            }
            else if (time > 1000000000)
            {
                labelTime.Text = $"av - {time / 1000000000} s";
            }

            SortedFleet = (int[])selected.Value.Clone();

            sorter.Sort((int[])SortedFleet);

            DisplaySortedFleet();
        }

        private void SortSelectedFleet(IListSorter sorter, int times)
        {
            if (comboBoxFleet.SelectedItem is not KeyValuePair<string, int[]> selected)
                return;

            List<double> spans = new();

            for (int i = 0; i < times; i++)
            {
                int[] fleet = (int[])selected.Value.Clone();

                Stopwatch stopwatch = new();

                stopwatch.Start();
                sorter.Sort(fleet.ToList());
                stopwatch.Stop();

                spans.Add(stopwatch.Elapsed.TotalNanoseconds);
            }

            double time = spans.Average();

            if (time < 1000000)
            {
                labelTime.Text = $"av - {time} ns";
            }
            else if (time >= 1000000 && time <= 1000000000)
            {
                labelTime.Text = $"av - {time / 1000000} ms";
            }
            else if (time > 1000000000)
            {
                labelTime.Text = $"av - {time / 1000000000} s";
            }

            SortedFleet = selected.Value.ToList();

            sorter.Sort((List<int>)SortedFleet);

            DisplaySortedFleet();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBoxFleet.SelectedItem is not KeyValuePair<string, int[]> selected)
                return;

            FleetsList[selected.Key] = SortedFleet.ToArray();

            SortedFleet = null;

            dataGridViewSortedFleet.Rows.Clear();

            FleetsUpdated();
        }

        private void DisplaySortedFleet()
        {
            dataGridViewSortedFleet.Rows.Clear();

            if (SortedFleet == null)
                return;

            if (checkBoxOptimize.Checked)
            {
                for (int i = 0; i < SortedFleet.ToArray().Length; i++)
                {
                    dataGridViewSortedFleet.Rows.Add($"{SortedFleet.ToArray()[i]}");

                    if (i > 100)
                        return;
                }
            }

            foreach (var num in SortedFleet)
            {
                dataGridViewSortedFleet.Rows.Add($"{num}");
            }
        }

        private void buttonFleetsUnit_Click(object sender, EventArgs e)
        {
            List<int> unitedFleet = new();

            foreach (string item in checkedListBoxFleet.CheckedItems)
            {
                if (FleetsCount > 0)
                    FleetsCount--;

                unitedFleet.AddRange(FleetsList[item]);
                FleetsList.Remove(item);
            }

            UnitedFleetsCount++;
            FleetsList.Add($"United fleet ¹{UnitedFleetsCount} ({unitedFleet.Count})", unitedFleet.ToArray());

            FleetsUpdated();
        }
    }
}