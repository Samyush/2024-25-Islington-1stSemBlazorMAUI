namespace ClassLibrary1
{
    internal abstract class Class1
    {
        public static dynamic name = "raju";
        //var name = "raju";
    }

    public class Class2
    {
        public static void printer()
        {

            Console.WriteLine(Class1.name);

            //Console.WriteLine("sth");
        }
    }
}
