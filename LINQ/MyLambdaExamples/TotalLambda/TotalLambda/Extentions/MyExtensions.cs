using System.Collections.Generic;
using System.Linq;
using TotalLambda;


namespace TotalLambda.Extentions
{
    public static class StringHelper
    {
        public static string ChangeFirstLetterCaseToUpper(this string inputString)
        {
            if (inputString.Length > 0)
            {
                char[] charArray = inputString.ToCharArray();
                charArray[0] = char.IsLower(charArray[0]) ? char.ToUpper(charArray[0]) : charArray[0];
                return new string(charArray);
            }

            return inputString;
        }
    }
    public static class EmployeeHelper
    {
        public static double SumEmployeeSalariesWithAnnualPercentRaise(this double sumOfSalary,IEnumerable<Employee> employees, double percentRaise)
        {
           return employees.Sum(e => (e.Salary*percentRaise/100));
        }
    }
}



