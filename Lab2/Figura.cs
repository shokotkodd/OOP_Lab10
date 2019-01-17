using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab2
{
    abstract class Figura
    {
        protected Color col;
        protected string name;
        protected int x;
        protected int y;
        protected double omega;
        protected double skor;

        public Figura()
        {
            col = Color.Black;
            x = 5;
            y = 5;
            name = "";
            omega = 0;
            skor = 0;
        }
        public Figura(int k1, int k2, string n, Color c, double om, double sk)
        {
            col = c;
            x = k1;
            y = k2;
            name = n;
            omega = om;
            skor = sk;
        }

        public Color Colorer
        {
            get
            { return col; }
            set
            { col = value; }
        }

        public string Name
        {
            get
            { return name; }
            set
            { name = value; }
        }

        public int X
        {
            get
            { return x; }
            set
            { x = value; }
        }

        public int Y
        {
            get
            { return y; }
            set
            { y = value; }
        }

        public double Omega
        {
            get
            { return omega; }
            set
            { omega = value; }
        }

        public double Skorost
        {
            get
            { return skor; }
            set
            { skor = value; }
        }

        abstract public void Draw(Graphics g , double t);
    }
}
