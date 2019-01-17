using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab2
{
    class Prim: Figura
    {
        int a;
        int b;

        public Prim()
        { a = 0; b = 0; }

        public Prim(int d1, int d2)
        { a = d1; b = d2; }

        public Prim(int x1, int y1, int d1, int d2, string n, Color co, double om, double sk) : base(x1, y1, n, co, om, sk)
        { a = d1; b = d2; }

        public int A
        {
            get
            { return a; }
            set
            { a = value; }
        }

        public int B
        {
            get
            { return b; }
            set
            { b = value; }
        }

        override public void Draw(Graphics g, double t)
        {
            Pen myPen = new Pen(col);
            g.DrawRectangle(myPen, x, y , a, b);
            myPen.Dispose();
        }
    }
}
