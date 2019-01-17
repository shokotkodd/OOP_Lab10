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
    public partial class Form1 : Form
    {
        static public Point Center;
        static public int r = 50;
        Graphics g = null;
        static public double omega = 0.5;
        double t = 0;
        Figura[] Meh;
        bool fl;
        List<Point> myListA = null;

        public Form1()
        {
            InitializeComponent();
            myListA = new List<Point>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(0, menuStrip1.ClientSize.Height);
            pictureBox1.Width = this.ClientSize.Width;
            pictureBox1.Height = this.ClientSize.Height - panel1.Height - menuStrip1.ClientSize.Height;
            Center.X = pictureBox1.Width / 2;
            Center.Y = pictureBox1.Height / 4;
            g = pictureBox1.CreateGraphics();
            Meh = new Figura[7];
            fl = true;
            timer1.Interval = (int)(100 / omega);
            label2.Text = Convert.ToString(omega) + " рад/с";
            label4.Text = Convert.ToString(r);
            label5.Text = Convert.ToString(r / 2);
            label7.Text = Convert.ToString(3 * r / 4);
            нарисоватьToolStripMenuItem.Enabled = true;
            стеретьToolStripMenuItem.Enabled = false;
            начатьToolStripMenuItem.Enabled = false;
            остановитьToolStripMenuItem.Enabled = false;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Dispose();
            this.Close();
        }

        private void Picture(Graphics g)
        {

            Meh[0] = new Circle(Center.X - r, Center.Y - r, r, "Val1", Color.Black, omega, 0.0);
            Meh[1] = new Circle(Center.X - r / 2, Center.Y - r / 2, r / 2, "Val2", Color.Black, omega, 0.0);
            Meh[2] = new Line(Center.X - r, Center.Y, Convert.ToInt32(3 * r / 2 + omega * r * t), "Line1", Color.Black, 0, omega * r);
            Meh[3] = new Line(Center.X - r / 2, Center.Y, Convert.ToInt32(4 * r - omega * r * t / 4), "Line2", Color.Black, 0, omega * r / 4);
            Meh[4] = new Line(Center.X + r, Center.Y, Convert.ToInt32(4 * r - omega * r * t / 4), "Line3", Color.Black, 0, omega * r / 4);
            Meh[5] = new Prim(Center.X - r - 5, Convert.ToInt32(Center.Y + 3.0 * r / 2.0 + omega * r * t), 10, 10, "Gruz", Color.Black, 0, omega * r);
            Meh[6] = new Circle(Center.X + r / 4 - 3 * r / 4, Convert.ToInt32(Center.Y + 4.0 * r - 3.0 * r / 4.0), 3* r / 4, "Val3", Color.Black, 3.0 * omega * r / 4.0, omega * r / 4.0);

            for (int i = 0; i < 7; i++) Meh[i].Draw(g, t);
        }

        private void нарисоватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t = 0;
            Picture(g);
            нарисоватьToolStripMenuItem.Enabled = false;
            стеретьToolStripMenuItem.Enabled = true;
            начатьToolStripMenuItem.Enabled = true;
        }

        private void стеретьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            нарисоватьToolStripMenuItem.Enabled = true;
            стеретьToolStripMenuItem.Enabled = false;
            начатьToolStripMenuItem.Enabled = false;
            остановитьToolStripMenuItem.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            if (((Line)Meh[2]).D <= r / 2)
                fl = true;
            if (((Line)Meh[3]).D <= 1.75 * r)
                fl = false;

            if (omega > 0)
            {
                if (fl) t += 0.1;
                if (!fl) t -= 0.1;
            }
            if (omega < 0)
            {
                if (fl) t-= 0.1;
                if (!fl) t += 0.1;
            }

            Picture(g);
            Traek();
        }

        private void начатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            Point A = new Point();
            A.X = Convert.ToInt32(Center.X + r / 4 - 3 * r / 4 + 3 * r / 4 - 3 * r / 4 * Math.Sin(omega * t));
            A.Y = Convert.ToInt32(Center.Y + 4 * r - 3 * r / 4 - omega * r / 4 * t + 3 * r / 4 - 3 * r / 4 * Math.Cos(omega * t));
            myListA.Clear();
            myListA.Add(A);
            нарисоватьToolStripMenuItem.Enabled = false;
            стеретьToolStripMenuItem.Enabled = false;
            начатьToolStripMenuItem.Enabled = false;
            остановитьToolStripMenuItem.Enabled = true;
            геометриескиеToolStripMenuItem.Enabled = false;
            кинематическиеToolStripMenuItem.Enabled = false;
        }

        private void остановитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            нарисоватьToolStripMenuItem.Enabled = false;
            стеретьToolStripMenuItem.Enabled = true;
            начатьToolStripMenuItem.Enabled = true;
            остановитьToolStripMenuItem.Enabled = false;
            геометриескиеToolStripMenuItem.Enabled = true;
            кинематическиеToolStripMenuItem.Enabled = true;
        }

        private void геометриескиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 myF = new Form2();
            myF.ShowDialog();
            if (myF.DialogResult == DialogResult.OK)
            {
                g.Clear(Color.White); Picture(g);
                label4.Text = Convert.ToString(r);
                label5.Text = Convert.ToString(r / 2);
                label7.Text = Convert.ToString(3 * r / 4);
            }
        }

        private void кинематическиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 myF = new Form3();
            myF.ShowDialog();
            if (myF.DialogResult == DialogResult.OK)
            {
                if (omega == 0)
                    MessageBox.Show("Вы задали угловую скорость равной 0");
                else
                    timer1.Interval = Convert.ToInt32(100 / Math.Abs(omega));
                label2.Text = Convert.ToString(omega) + " рад/с";
            }
            t = 0;
            g.Clear(Color.White); Picture(g);

        }


        private void Traek()
        {
            Point A = new Point();
            A.X = Convert.ToInt32(Center.X + r / 4.0 - 3.0 * r / 4.0 + 3.0 * r / 4.0 - 3.0 * r / 4.0 * Math.Sin(omega * t));
            A.Y = Convert.ToInt32(Center.Y + 4.0 * r - 3.0 * r / 4.0 - omega * r / 4.0 * t + 3.0 * r / 4.0 - 3.0 * r / 4.0 * Math.Cos(omega * t));
            myListA.Add(A);
            Pen p = null;
            if (aToolStripMenuItem.Checked)
            {
                p = new Pen(Color.Red);
                Point[] myMas = myListA.ToArray();
                g.DrawCurve(p, myMas);
            }
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Checked = !(((ToolStripMenuItem)sender).Checked);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
