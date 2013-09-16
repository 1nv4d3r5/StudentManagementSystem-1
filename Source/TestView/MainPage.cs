using System;

namespace TestView
{
    public class MainPage
    {
        public static void Main(string[] args)
        {
            new StudentView().ShouldGetAllStudents();
            Console.ReadKey();
        }
    }
}
