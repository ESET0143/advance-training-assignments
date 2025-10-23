using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s1_oops
{
    internal class Sports:Student
    {
        public string team;
        public void SetTeam(string team)
        {
            this.team = team;
        }
        public  void Display()
        {
            base.Display();
            Console.WriteLine($"name:{name},rollno:{rollno},team: {team}");
        }
    }
}
