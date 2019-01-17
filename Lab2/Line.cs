using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab2
{
    class Line : Figura
    {
        int d;
        
        public Line()
        { d = 0; }

        public Line(int a1)
        { d = a1; }

        public Line(int a, int b, int d1, string n, Color co, double om, double sk) : base(a, b, n, co, om, sk)
        { d = d1; }

        public int D
        {
            get
            { return d; }
            set
            { d = value; }
        }

        override public void Draw(Graphics g, double t)
        {
            Pen myP = new Pen(col);
            g.DrawLine(myP, x, y, x, Convert.ToInt32(y + d ));
            myP.Dispose();
        }

    }
}
