using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public abstract class Employee : IPrintData
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private int age;

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public abstract void CalculateSalary(int hoursWorked);

        
        public void PrintData()
        {
            Console.WriteLine("First Name = " + FirstName);
            Console.WriteLine("Last Name = " + LastName);
            Console.WriteLine("Age = " + Age);
        }
        
        
    }
}
