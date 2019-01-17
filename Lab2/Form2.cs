using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form2 : Form
    {
        int r1, r2, r3;
        public Form2()
        {
            InitializeComponent();
        }

        private void numericUpDown2_Click(object sender, EventArgs e)
        {
            r2 = Convert.ToInt32(numericUpDown2.Value);
            r1 = 2 * r2;
            r3 = 3 * r2 / 2;
            numericUpDown1.Value = r1;
            numericUpDown3.Value = r3;
        }

        private void numericUpDown3_Click(object sender, EventArgs e)
        {
            r3 = Convert.ToInt32(numericUpDown3.Value);
            r1 = 4 * r3 / 3;
            r2 = 2 * r3 / 3;
            numericUpDown1.Value = r1;
            numericUpDown2.Value = r2;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK) Form1.r = r1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            r1 = Form1.r;
            r2 = r1 / 2;
            r3 = 3 * r1 / 4;
            numericUpDown1.Value = r1;
            numericUpDown2.Value = r2;
            numericUpDown3.Value = r3;
        }


        private void numericUpDown1_Click(object sender, EventArgs e)
        {
            r1 = Convert.ToInt32(numericUpDown1.Value);
            r2 = r1 / 2;
            r3 = 3 * r1 / 4;
            numericUpDown2.Value = r2;
            numericUpDown3.Value = r3;
        }

    }
}
