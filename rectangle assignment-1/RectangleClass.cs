using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s1_Rectangle
{
    internal class RectangleClass
    {
        int length, breadth,area;
        static int totalarea=0;
        public RectangleClass(int l,int b)
        {
            length = l;
            breadth = b;
        }
        public void   calcarea(RectangleClass r)
        {
            area = length * breadth;
            totalarea += r.area;
        }


       
        public void  DisplayTotalArea()
        {
            Console.WriteLine($"total area is : {totalarea}");
        }

        public RectangleClass returnobj(int l,int b) {
            RectangleClass r= new RectangleClass(l,b);
            return r;

        }

    }
}
