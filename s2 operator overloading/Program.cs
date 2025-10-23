namespace s2_operator_overloading
{
    internal class Program
    {
        
        interface Animal
        {
            public void AnimalSound();
            
                    
            public void sleep()
            {
                Console.WriteLine("Zzz");
            }
        }

        class dog : Animal
        {
            public void AnimalSound()
            {
                Console.WriteLine("dog barks");
            }
           
        }


        static void Main(string[] args)
        {


            Animal myobj = new dog();
            myobj.AnimalSound();
            myobj.sleep();
        }
    }
}
