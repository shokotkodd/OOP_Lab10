using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab2
{
    class Circle : Figura
    {
        int r;

        public Circle()
        { r = 0; }

        public Circle(int c)
        { r = c; }

        public Circle(int a, int b, int c, string n, Color co, double om, double sk) : base(a, b, n, co, om, sk)
        { r = c; }

        public int R
        {
            get
            { return r; }
            set
            { r = value; }
        }

        override public void Draw(Graphics g, double t)
        {
            Pen p = new Pen(col);
            //p.Width = 2;
            Rectangle Rect = new Rectangle(x, Convert.ToInt32(y - skor * t), 2 * r, 2 * r);
            g.DrawEllipse(p, Rect);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            Point t1 = new Point(Convert.ToInt32(x+r - r * Math.Sin(omega * t)),
                Convert.ToInt32(y - skor * t + r - r * Math.Cos(omega * t)));
            Point t2 = new Point(Convert.ToInt32(x + r + r *
                Math.Sin(omega * t)), Convert.ToInt32(y - skor * t + r + r * Math.Cos(omega * t)));
            g.DrawLine(p, t1, t2);
            t1.X = Convert.ToInt32(x + r - r * Math.Cos(omega * t));
            t1.Y = Convert.ToInt32(y - skor * t + r + r * Math.Sin(omega * t));
            t2.X = Convert.ToInt32(x + r + r * Math.Cos(omega * t));
            t2.Y = Convert.ToInt32(y - skor * t + r - r * Math.Sin(omega * t));
            g.DrawLine(p, t1, t2);

            p.Dispose();
        }
    }
}
