using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents.Classes
{
    public class Funky
    {
        public static double CalculateNewAnnualSalaryAfterRaisePercentage(Func<double, string, double> callback, List<Classes.Employee> employees)
        {
            IEnumerable<Employee> sortedEmployees = employees.OrderBy(e => e.Salary);
            double total = 0;
            foreach (var emp in sortedEmployees)
            {
                total += (emp.Salary * emp.RaisePercentage / 100) + emp.Salary;
                callback((emp.Salary*emp.RaisePercentage/100) + emp.Salary, emp.Name);
            }
            return total;
        }
       
    }
}
