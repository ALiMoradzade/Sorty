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
                    return;
                }
                catch (Exception)
                {
                }
            }

            SetArray();
            array = Shuffle.Chaos(array);
        }

        private void SortForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string s = string.Join("\r\n", array);
            File.WriteAllText(path, s);
        }


        private void SetArray(int count = 100)
        {
            array = new int[count];
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                array[i] = r.Next();
            }
        }

        

        private void buttonArray_Click(object sender, EventArgs e)
        {
            using (ArrayCountForm f = new ArrayCountForm(array.Length))
            {
                f.ShowDialog();
                if (f.isOkPressed)
                {
                    SetArray((int)f.numericUpDown1.Value);
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
            array = sort.Heap(array);
            DateTime then = DateTime.Now;

            TimeSpan duration = then - now;
            label1.Text = duration.Milliseconds.ToString();
        }
    }
}
