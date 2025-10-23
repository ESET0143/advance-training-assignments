namespace s1_Rectangle
{   
   
    internal class Program
    {
        static void Main(string[] args)
        {

            RectangleClass r1 = new RectangleClass(5,2);


            r1.calcarea(r1);

           

            RectangleClass r3 = r1.returnobj(5, 6);

            r3.calcarea(r3);


            r3.DisplayTotalArea();

        }
    }
}
