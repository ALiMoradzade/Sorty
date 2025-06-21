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
            Shuffle();
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

        private void Shuffle()
        {
            int half = array.Length / 2;
            int remainingHalf = array.Length - half;

            int[] halfArray = new int[half];
            Array.Copy(array, halfArray, half);

            int[] rHalfArray = new int[remainingHalf];
            Array.Copy(array, half, rHalfArray, 0, remainingHalf);

            Stack<int> halfStack = new Stack<int>(halfArray.Reverse());
            Stack<int> rHalfStack = new Stack<int>(rHalfArray.Reverse());

            List<int> l = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                int n;
                if (i % 2 == 0)
                {
                    n = rHalfStack.Pop();
                }
                else
                {
                    n = halfStack.Pop();
                }
                l.Add(n);
            }

            array = l.ToArray();
        }

        private void ShuffleRandomize()
        {
            Random r = new Random();
            List<int> indexs = new List<int>();
            while (indexs.Count < array.Length)
            {
                int index = r.Next(array.Length);
                if (!indexs.Contains(index))
                {
                    indexs.Add(index);
                }
            }

            List<int> l = new List<int>();
            foreach (var index in indexs)
            {
                l.Add(array[index]);
            }
            array = l.ToArray();
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
            ShuffleRandomize();
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            Sort sort = new Sort();
            DateTime now = DateTime.Now;
            array = sort.Quick(array, 0, array.Length - 1);
            DateTime then = DateTime.Now;

            TimeSpan duration = then - now;
            label1.Text = duration.Milliseconds.ToString();
        }
    }
}
