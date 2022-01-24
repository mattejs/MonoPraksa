using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class ContractEmployee : Employee
    {
        public override void CalculateSalary(int hoursWorked)
        {
            Console.WriteLine("Contract employee");
            Console.WriteLine(hoursWorked * 50.00 + "\n");
        }
    }
}
