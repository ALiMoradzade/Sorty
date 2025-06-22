using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Sorty
{
    public partial class SortForm : Form
    {
        private string path = "array.txt";
        private int[] array = new int[100];

        public SortForm()
        {
            InitializeComponent();
        }

        private void SortForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                try
                {
                    string s = File.ReadAllText(path);
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
                buttonGenerateNumbers.PerformClick();
            }
        }

        private void SortForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string s = string.Join("\r\n", array);
            File.WriteAllText(path, s);
        }

        private void buttonArray_Click(object sender, EventArgs e)
        {
            using (ArrayCountForm f = new ArrayCountForm(array.Length))
            {
                f.ShowDialog();
                if (f.isOkPressed)
                {
                    array = new int[(int)f.numericUpDown1.Value];
                    buttonGenerateNumbers.PerformClick();
                }
            }
        }

        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            array = Shuffle.Chaos(array);
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            Sort sort = new Sort();
            DateTime now = DateTime.Now;
            switch (comboBoxSort.Text)
            {
                case "Bead Sort":
                    array = sort.Bead(array);
                    break;
                case "Bubble Sort":
                    array = sort.Bubble(array);
                    break;
                case "Cocktail Sort":
                    array = sort.Cocktail(array);
                    break;
                case "Cycle Sort":
                    array = sort.Cycle(array);
                    break;
                case "Gnome Sort":
                    array = sort.Gnome(array);
                    break;
                case "Heap Sort":
                    array = sort.Heap(array);
                    break;
                case "Insertion Sort":
                    array = sort.Insertion(array);
                    break;
                case "Merge Sort":
                    array = sort.Merge(array);
                    break;
                case "Odd Even Sort":
                    array = sort.OddEven(array);
                    break;
                case "Quick Sort":
                    array = sort.Quick(array);
                    break;
                case "Radix Sort":
                    array = sort.Radix(array);
                    break;
                case "Selection Sort":
                    array = sort.Selection(array);
                    break;
                case "Shell Sort":
                    array = sort.Shell(array);
                    break;
            }
            DateTime then = DateTime.Now;

            TimeSpan duration = then - now;
            label1.Text = $"{duration.TotalMilliseconds:N2}ms";
        }

        private void buttonGenerateNumbers_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next();
            }
        }
    }
}
