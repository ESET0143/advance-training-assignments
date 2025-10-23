using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s1_oops
{
    internal class Student: Person
    {
        public int rollno;
        public void  Sdetails(int rno)
        {
            rollno=rno;
        }
        public  void Display()
        {
            Console.WriteLine($"name:{name},rollno:{rollno}");
        }

    }
}
