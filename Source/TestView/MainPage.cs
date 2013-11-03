using System;
using System.Collections.Generic;

namespace TestView
{
    public class MainPage
    {
        private static readonly Dictionary<int, Action> GotoWhen = new Dictionary<int, Action>
                                                                       {
                                                                           { 1, ListDepartments },
                                                                           { 2, ListStudents },
                                                                           { 3, ExitSystem }
                                                                       };

        public static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine();
            Console.SetCursorPosition(50, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Beep();

            Console.WriteLine("Welcome to Student Management System");

            Console.ResetColor();
            Console.SetCursorPosition(1, 7);
            Console.WriteLine("The UI for this site is under maintanence. Sorry for the inconvience caused.");

            Console.SetCursorPosition(1, 12);

            Console.WriteLine("Select from the following options:");
            Console.WriteLine("\n\t1. About the Departments");
            Console.WriteLine("\n\t2. About the Students");
            Console.WriteLine("\n\t3. Exit");

            try
            {
                GotoWhen[int.Parse(Console.ReadLine())]();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Argument.. Exiting the system");
            }

            Console.ReadKey();
        }

        private static void ListDepartments()
        {
            new DepartmentView().ShouldGetAllDepartments();
            ExitSystem();
        }

        private static void ListStudents()
        {
            new StudentView().ShouldGetAllStudents();
            ExitSystem();
        }

        private static void ExitSystem()
        {
            Console.WriteLine("\n\nExiting the system.. See you soon..");
        }
    }
}