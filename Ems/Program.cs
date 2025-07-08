using System;
using System.Collections.Generic;

namespace Ems
{
    class Program
    {
        static void Main(string[] args)
        {
            EMSController controller = new EMSController();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Update Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. View All Employees");
                Console.WriteLine("5. View One Employee");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddEmployee(controller);
                        break;
                    case "2":
                        UpdateEmployee(controller);
                        break;
                    case "3":
                        DeleteEmployee(controller);
                        break;
                    case "4":
                        ViewAllEmployees(controller);
                        break;
                    case "5":
                        ViewOneEmployee(controller);
                        break;
                    case "6":
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddEmployee(EMSController controller)
        {
            EMS emp = new EMS();

            Console.Write("Enter Name: ");
            emp.Name = Console.ReadLine();

            Console.Write("Enter Salary: ");
            emp.Salary = Console.ReadLine();

            Console.Write("Enter Department: ");
            emp.Department = Console.ReadLine();

            controller.AddEmployee(emp);
        }

        static void UpdateEmployee(EMSController controller)
        {
            EMS emp = new EMS();

            Console.Write("Enter Employee ID to Update: ");
            emp.Id = int.Parse(Console.ReadLine());

            Console.Write("Enter New Name: ");
            emp.Name = Console.ReadLine();

            Console.Write("Enter New Salary: ");
            emp.Salary = Console.ReadLine();

            Console.Write("Enter New Department: ");
            emp.Department = Console.ReadLine();

            controller.UpdateEmployee(emp);
        }

        static void DeleteEmployee(EMSController controller)
        {
            EMS emp = new EMS();

            Console.Write("Enter Employee ID to Delete: ");
            emp.Id = int.Parse(Console.ReadLine());

            controller.DeleteEmployee(emp);
        }

        static void ViewAllEmployees(EMSController controller)
        {
            List<EMS> employees = controller.viewAll();

            Console.WriteLine("Employees");
            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Salary: {emp.Salary}, Department: {emp.Department}");
            }
        }

        static void ViewOneEmployee(EMSController controller)
        {
            Console.Write("Enter Employee ID to View: ");
            int id = int.Parse(Console.ReadLine());

            EMS emp = controller.ViewOne(id);

            if (emp != null)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Salary: {emp.Salary}, Department: {emp.Department}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
    }
}
