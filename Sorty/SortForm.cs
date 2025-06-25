using Sorty.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Sorty
{
    public partial class SortForm : Form
    {
        private string pathArray = "array.txt";
        private string pathArrayIsSorted = "isArraySort.txt";

        private string labelArrayLengthTest = "Array length: ";
        private string labelIsArraySortedText = "Is array sorted: ";

        private int[] array = new int[100];

        public SortForm()
        {
            InitializeComponent();
        }

        private void SortForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(pathArray))
            {
                try
                {
                    string s = File.ReadAllText(pathArray);
                    var arrayString = s.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    array = Array.ConvertAll(arrayString, Convert.ToInt32);
                }
                catch (Exception)
                {
                }
            }
            else
            {
                array = new int[1000];
                GenerateNumber();
            }
            labelArrayLength.Text = labelArrayLengthTest + array.Length;
            
            labelIsArraySorted.Text = labelIsArraySortedText;
            if (File.Exists(pathArrayIsSorted))
            {
                string s = File.ReadAllText(pathArrayIsSorted);
                labelIsArraySorted.Text += s;
                labelIsArraySorted.ForeColor = Color.Green;
            }
            else
            {
                labelIsArraySorted.Text += "false";
                labelIsArraySorted.ForeColor = Color.Red;
            }

            string[] sortNames = new string[13]
            {
                "Bead",
                "Bubble",
                "Cocktail",
                "Cycle",
                "Gnome",
                "Heap",
                "Insertion",
                "Merge",
                "OddEven",
                "Quick",
                "Radix",
                "Selection",
                "Shell",
            };


            foreach (string name in sortNames)
            {
                chart1.Series["Duration"].Points.AddXY(name, 0D);
                chart1.Series["Compare Count"].Points.AddXY(name, 0);
                chart1.Series["Swap Count"].Points.AddXY(name, 0);
                chart1.Series["Set Count"].Points.AddXY(name, 0);
            }
           
        }

        private void SortForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string s = string.Join("\r\n", array);
            File.WriteAllText(pathArray, s);
            File.WriteAllText(pathArrayIsSorted, labelIsArraySorted.Text.Replace(labelIsArraySortedText, ""));
        }

        private void SortForm_SizeChanged(object sender, EventArgs e)
        {
            buttonArray.Location = new Point(buttonArray.Location.X, Size.Height - 74);
            buttonShuffle.Location = new Point(buttonShuffle.Location.X, buttonArray.Location.Y);
            buttonSort.Location = new Point(buttonSort.Location.X, buttonArray.Location.Y);
            chart1.Size = new Size(chart1.Size.Width, buttonArray.Location.Y - 6);
        }

        private void buttonArray_Click(object sender, EventArgs e)
        {
            using (ArrayCountForm f = new ArrayCountForm(array.Length))
            {
                f.ShowDialog();
                if (f.isOkPressed)
                {
                    array = new int[(int)f.numericUpDown1.Value];
                    GenerateNumber();

                    labelArrayLength.Text = labelArrayLengthTest + f.numericUpDown1.Value;

                    labelIsArraySorted.Text = labelIsArraySortedText + "false";
                    labelIsArraySorted.ForeColor = Color.Red;

                    MessageBox.Show(
                        $"An array of {f.numericUpDown1.Value} elements\nwith random numbers has been created",
                        "✅ Creation Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void GenerateNumber()
        {
            Random r = new Random();
            // max elements in array is 2_621_439
            // according to max array count (15_000)
            // and
            // because of bead which is 2d array (15_000 * 174)
            // max number generated is 174
            // I put 175 so random generator selects 0 to 174
            int maxNumber = 175;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(maxNumber);
            }
        }

        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            Shuffle.Chaos(array);

            labelIsArraySorted.Text = labelIsArraySortedText + "false";
            labelIsArraySorted.ForeColor = Color.Red;
        }

        private void SortInit(List<Task> sorts, List<SortStat> sortStats)
        {
            sorts.Add(Task.Run(async () =>
            {
                Sort sort = new Sort(array);

                DateTime now = DateTime.Now;
                await sort.Bead();
                DateTime then = DateTime.Now;

                SortStat stat = new SortStat("Bead", then - now, sort.SetCount, sort.SwapCount, sort.CompareCount);
                sortStats.Add(stat);
            }));

            sorts.Add(Task.Run(async () =>
            {
                Sort sort = new Sort(array);

                DateTime now = DateTime.Now;
                await sort.Bubble();
                DateTime then = DateTime.Now;

                SortStat stat = new SortStat("Bubble", then - now, sort.SetCount, sort.SwapCount, sort.CompareCount);
                sortStats.Add(stat);
            }));

            sorts.Add(Task.Run(async () =>
            {
                Sort sort = new Sort(array);

                DateTime now = DateTime.Now;
                await sort.Cocktail();
                DateTime then = DateTime.Now;

                SortStat stat = new SortStat("Cocktail", then - now, sort.SetCount, sort.SwapCount, sort.CompareCount);
                sortStats.Add(stat);
            }));

            sorts.Add(Task.Run(async () =>
            {
                Sort sort = new Sort(array);

                DateTime now = DateTime.Now;
                await sort.Cycle();
                DateTime then = DateTime.Now;

                SortStat stat = new SortStat("Cycle", then - now, sort.SetCount, sort.SwapCount, sort.CompareCount);
                sortStats.Add(stat);
            }));

            sorts.Add(Task.Run(async () =>
            {
                Sort sort = new Sort(array);

                DateTime now = DateTime.Now;
                await sort.Gnome();
                DateTime then = DateTime.Now;

                SortStat stat = new SortStat("Gnome", then - now, sort.SetCount, sort.SwapCount, sort.CompareCount);
                sortStats.Add(stat);
            }));

            sorts.Add(Task.Run(async () =>
            {
                Sort sort = new Sort(array);

                DateTime now = DateTime.Now;
                await sort.Heap();
                DateTime then = DateTime.Now;

                SortStat stat = new SortStat("Heap", then - now, sort.SetCount, sort.SwapCount, sort.CompareCount);
                sortStats.Add(stat);
            }));

            sorts.Add(Task.Run(async () =>
            {
                Sort sort = new Sort(array);

                DateTime now = DateTime.Now;
                await sort.Insertion();
                DateTime then = DateTime.Now;

                SortStat stat = new SortStat("Insertion", then - now, sort.SetCount, sort.SwapCount, sort.CompareCount);
                sortStats.Add(stat);
            }));

            sorts.Add(Task.Run(async () =>
            {
                Sort sort = new Sort(array);

                DateTime now = DateTime.Now;
                await sort.Merge();
                DateTime then = DateTime.Now;

                SortStat stat = new SortStat("Merge", then - now, sort.SetCount, sort.SwapCount, sort.CompareCount);
                sortStats.Add(stat);
            }));

            sorts.Add(Task.Run(async () =>
            {
                Sort sort = new Sort(array);

                DateTime now = DateTime.Now;
                await sort.OddEven();
                DateTime then = DateTime.Now;

                SortStat stat = new SortStat("OddEven", then - now, sort.SetCount, sort.SwapCount, sort.CompareCount);
                sortStats.Add(stat);
            }));

            sorts.Add(Task.Run(async () =>
            {
                Sort sort = new Sort(array);

                DateTime now = DateTime.Now;
                await sort.Quick();
                DateTime then = DateTime.Now;

                SortStat stat = new SortStat("Quick", then - now, sort.SetCount, sort.SwapCount, sort.CompareCount);
                sortStats.Add(stat);
            }));

            sorts.Add(Task.Run(async () =>
            {
                Sort sort = new Sort(array);

                DateTime now = DateTime.Now;
                await sort.Radix();
                DateTime then = DateTime.Now;

                SortStat stat = new SortStat("Radix", then - now, sort.SetCount, sort.SwapCount, sort.CompareCount);
                sortStats.Add(stat);
            }));

            sorts.Add(Task.Run(async () =>
            {
                Sort sort = new Sort(array);

                DateTime now = DateTime.Now;
                await sort.Selection();
                DateTime then = DateTime.Now;

                SortStat stat = new SortStat("Selection", then - now, sort.SetCount, sort.SwapCount, sort.CompareCount);
                sortStats.Add(stat);
            }));

            sorts.Add(Task.Run(async () =>
            {
                Sort sort = new Sort(array);

                DateTime now = DateTime.Now;
                await sort.Shell();
                DateTime then = DateTime.Now;

                SortStat stat = new SortStat("Shell", then - now, sort.SetCount, sort.SwapCount, sort.CompareCount);
                sortStats.Add(stat);
            }));
        }

        private async void buttonSort_Click(object sender, EventArgs e)
        {
            List<Task> sorts = new List<Task>();
            List<SortStat> sortStats = new List<SortStat>();
            
            SortInit(sorts, sortStats);
            await Task.WhenAll(sorts);
            
            LoadChart(sortStats);

            labelIsArraySorted.Text = labelIsArraySortedText + "true";
            labelIsArraySorted.ForeColor = Color.Green;
        }

        private void LoadChart(List<SortStat> sortStats)
        {
            sortStats = sortStats.OrderBy(x=>x.Name).ToList();
            
            for (int i = 0; i < sortStats.Count; i++)
            {
                chart1.Series["Duration"].Points[i].SetValueY(sortStats[i].Duration.TotalMilliseconds);
                chart1.Series["Compare Count"].Points[i].SetValueY(sortStats[i].CompareCount);
                chart1.Series["Swap Count"].Points[i].SetValueY(sortStats[i].SwapCount);
                chart1.Series["Set Count"].Points[i].SetValueY(sortStats[i].SetCount);
            }
            chart1.ChartAreas["ChartAreaDuration"].RecalculateAxesScale();
            chart1.ChartAreas["ChartAreaOperation"].RecalculateAxesScale();
        }
    }
}
