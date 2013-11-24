using System;
using System.Collections.Generic;

namespace TestView
{
    public class StudentManagementSystem
    {
        private readonly Dictionary<int, Action> gotoWhen;

        private readonly DepartmentView departmentView;

        private readonly StudentView studentView;

        public StudentManagementSystem(DepartmentView departmentView, StudentView studentView)
        {
            this.departmentView = departmentView;
            this.studentView = studentView;
            this.gotoWhen = new Dictionary<int, Action>
                           {
                               { 1, this.ListDepartments },
                               { 2, this.ListStudents },
                               { 3, this.ExitSystem }
                           };
        }

        public void Index()
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
                this.gotoWhen[int.Parse(Console.ReadLine())]();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Argument.. Exiting the system");
            }

            Console.ReadKey();
        }

        private void ListDepartments()
        {
            departmentView.ShouldGetAllDepartments();
            ExitSystem();
        }

        private void ListStudents()
        {
            studentView.ShouldGetAllStudents();
            ExitSystem();
        }

        private void ExitSystem()
        {
            Console.WriteLine("\n\nExiting the system.. See you soon..");
        }
    }
}