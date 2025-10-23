namespace s1_oops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //base class
            Console.WriteLine("Hello, World!");
            Student s1 = new Student();
            s1.Sdetails(55);
            s1.SetName("sure");
            //s1.Display();


            //derived class
            Sports sp1 = new Sports();
            sp1.SetName("surendra");
            sp1.Sdetails(18);
            sp1.SetTeam("PP");
            sp1.Display();

            //Student polymorphicStudent = new Sports();

            //polymorphicStudent.Display();
            /*You are creating a derived class object (Sports) but storing        
            its reference in a base class variable(Student).
            This is allowed because Sports inherits from Student —
            meaning every Sports object is also a Student.
            */





        }
    }
}
