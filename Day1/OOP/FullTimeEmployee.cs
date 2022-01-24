using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class FullTimeEmployee : Employee
    {
        private double bonus = 1.05;

        public override void CalculateSalary(int hoursWorked)
        {
            Console.WriteLine("Fulltime employee");
            Console.WriteLine((hoursWorked * 60.00 * bonus) + "\n");
        }
    }
}
