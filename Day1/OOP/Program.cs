using System;
using System.Collections.Generic;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {

            Employee one = new FullTimeEmployee();
            one.FirstName = "Ime";
            one.LastName = "Prezime";
            one.Age = 25;

            Employee two = new ContractEmployee();
            two.FirstName = "Name";
            two.LastName = "Lastname";
            two.Age = 30;

            Employee three = new FullTimeEmployee();
            three.FirstName = "Ime";
            three.LastName = "Lastname";
            three.Age = 20;
            
            one.PrintData();
            one.CalculateSalary(100);

            two.PrintData();
            two.CalculateSalary(150);

            List<Employee> employees = new List<Employee>();

            employees.Add(one);
            employees.Add(two);
            employees.Add(three);

            for (int i = 0; i < employees.Count; i++)
            {
                Employee employee = employees[i];
                Console.WriteLine("First Name = {0}, Last Name = {1}, Age = {2}",
                         employee.FirstName, employee.LastName, employee.Age);
            }
            Console.WriteLine();

        }
    }
}
