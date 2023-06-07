using System;
using System.ComponentModel;
using System.Diagnostics;

namespace AlgorithmsLab10_WinForms
{
    public partial class Form1 : Form
    {
        public Dictionary<string, List<int>> FleetsList { get; set; } = new();

        public List<int>? SortedFleet;

        public List<int>? FinalQueue;

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
            BindingSource source = new()
            {
                DataSource = FleetsList,
            };

            comboBoxFleet.DataSource = source;

            if (comboBoxFleet.Items.Count > 0)
                comboBoxFleet.SelectedItem = comboBoxFleet.Items[0];
        }

        private void comboBoxFleet_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewFleet.Rows.Clear();

            if (comboBoxFleet.Items.Count <= 0)
                return;

            if (comboBoxFleet.SelectedItem is not KeyValuePair<string, List<int>> selected)
                return;

            List<int> selectedFleet = selected.Value;

            if (checkBoxOptimize.Checked)
            {
                for (int i = 0; i < selectedFleet.Count; i++)
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

            switch (comboBoxSortingAlgoritm.SelectedIndex)
            {
                case 0:
                    SortSelectedFleet(new QuickSort(), times);
                    break;
                case 1:
                    SortSelectedFleet(new QuickSortDutchFlag(), times);
                    break;
                case 2:
                    SortSelectedFleet(new QuickSortEarlyExit(), times);
                    break;
                case 3:
                    SortSelectedFleet(new Heapsort(), times);
                    break;
                case 4:
                    SortSelectedFleet(new SmoothSort(), times);
                    break;
                default:
                    break;
            }
        }

        private void SortSelectedFleet(ISorter sorter, int times)
        {
            if (comboBoxFleet.SelectedItem is not KeyValuePair<string, List<int>> selected)
                return;

            List<double> spans = new();

            for (int i = 0; i < times; i++)
            {
                List<int> listToSort = selected.Value;

                Stopwatch stopwatch = new();

                try
                {
                    stopwatch.Start();
                    sorter.Sort(listToSort);
                    stopwatch.Stop();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return;
                }

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

            SortedFleet = new(((KeyValuePair<string, List<int>>)comboBoxFleet.SelectedItem).Value);

            sorter.Sort(SortedFleet);

            DisplaySortedFleet();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBoxFleet.SelectedItem is not KeyValuePair<string, List<int>> selected)
                return;

            FleetsList[selected.Key] = SortedFleet;

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
                for (int i = 0; i < SortedFleet.Count; i++)
                {
                    dataGridViewSortedFleet.Rows.Add($"{SortedFleet[i]}");

                    if (i > 100)
                        return;
                }
            }

            foreach (var num in SortedFleet)
            {
                dataGridViewSortedFleet.Rows.Add($"{num}");
            }
        }
    }
}