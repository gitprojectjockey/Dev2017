
using TotalLambda.Extentions;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TotalLambda
{
    class Program
    {
        public class ConsoleHelperEventArgs : EventArgs
        {
            public string Message { get; set; }
        }

        public class ConsoleHelper
        {
            // 1 Define a delegate
            // 2 Define an event based on that delegate
            // 3 Raise the event.
            public delegate void ConsoleWriteEventHandler(object sender, ConsoleHelperEventArgs e);
            public event ConsoleWriteEventHandler WritingMessage;

            public void WriteConsoleMessage(string message)
            {
                OnMessageWriting(message);
            }

            protected virtual void OnMessageWriting(string message)
            {
                if (WritingMessage != null)
                {
                    WritingMessage(this, new ConsoleHelperEventArgs() { Message = message });
                }
            }
        }

        public class RecieveAndWriteConsoleMessage
        {
            public void OnMessageWriting(object sender, ConsoleHelperEventArgs e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Main(string[] args)
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 200;
            Console.Title = "Lambda lambda lambda :>";
            Console.Clear();


            var consoleHelper = new ConsoleHelper();
            var consoleWriter = new RecieveAndWriteConsoleMessage();
            consoleHelper.WritingMessage += consoleWriter.OnMessageWriting;
            consoleHelper.WriteConsoleMessage("----------------------------------------------------------------------");
            //My Extension Methods 
            consoleHelper.WriteConsoleMessage("Upper first letter of any name that starts with lower case");
            foreach (var employee in Employee.GetAllEmployees())
            {
                string newEmployeeName = employee.Name.ChangeFirstLetterCaseToUpper();
                consoleHelper.WriteConsoleMessage(newEmployeeName);
            }

            IEnumerable<Employee> employees = Employee.GetAllEmployees();
            double totalEmployeeRaiseCost = 0;
            totalEmployeeRaiseCost = totalEmployeeRaiseCost.SumEmployeeSalariesWithAnnualPercentRaise(Employee.GetAllEmployees(), 2);
            consoleHelper.WriteConsoleMessage("-------------------------");
            consoleHelper.WriteConsoleMessage(string.Format("Total cost for all raises: {0:C}", totalEmployeeRaiseCost));

            //LINQ Aggregate Operators
            consoleHelper.WriteConsoleMessage("-------------------------");
            consoleHelper.WriteConsoleMessage("Max salary");
            consoleHelper.WriteConsoleMessage(employees.Max(e => e.Salary).ToString());

            consoleHelper.WriteConsoleMessage("-------------------------");
            consoleHelper.WriteConsoleMessage("Min salary");
            consoleHelper.WriteConsoleMessage(employees.Min(e => e.Salary).ToString());

            consoleHelper.WriteConsoleMessage("-------------------------");
            consoleHelper.WriteConsoleMessage("Average of all salaries");
            consoleHelper.WriteConsoleMessage(employees.Average(e => e.Salary).ToString());

            consoleHelper.WriteConsoleMessage("-------------------------");
            consoleHelper.WriteConsoleMessage("Sum of all salaries");
            consoleHelper.WriteConsoleMessage(employees.Sum(e => e.Salary).ToString());

            //Aggregate Function

            //How Aggregate() function works ?
            //Step 1.First "India" is concatenated with "US" to produce result "India, US"
            //Step 2.Result in Step 1 is then concatenated with "UK" to produce result "India, US, UK"
            //Step 3: Result in Step 2 is then concatenated with "Canada" to produce result "India, US, UK, Canada"

            consoleHelper.WriteConsoleMessage("-------------------------");
            consoleHelper.WriteConsoleMessage("Aggragate all employee names into a single comma seperated string");
            string nameList = employees.Select(e => e.Name)
                .ToArray<string>()
                .Aggregate((a, b) => a + ", " + b);

            consoleHelper.WriteConsoleMessage(nameList);

            consoleHelper.WriteConsoleMessage("-------------------------");
            consoleHelper.WriteConsoleMessage("Using modula in Where restriction operator predicate to get only even numbers\nthen aggregate to comma seperated string");
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> evenNumbers = numbers.Where(num => num % 2 == 0);
            string evenNumberString = evenNumbers.Select(n => n.ToString()).ToArray<string>().Aggregate((a, b) => a + ", " + b);
            consoleHelper.WriteConsoleMessage(evenNumberString);

            //Projection operator
            //Select Many--IEnumerable<string> sequences, which are then flattened to form a single sequence i.e a single IEnumerable<string> sequence.
            //Select many list<string> of AllStates a complany resides in and print a distinct list of the state codes
            consoleHelper.WriteConsoleMessage("-------------------------");
            consoleHelper.WriteConsoleMessage("Select Many");
            IEnumerable<string> statesList = Company.GetAllCompanies().SelectMany(c => c.AllStates).Distinct();
            foreach (var states in statesList)
            {
                consoleHelper.WriteConsoleMessage(states);
            }

            consoleHelper.WriteConsoleMessage("-------------------------");
            consoleHelper.WriteConsoleMessage("Select multiple columns from company list");
            var companies = Company.GetAllCompanies().Select(c => new { CompanyName = c.Name, CompanyId = c.ID, CompanyState = c.State }).Distinct();
            foreach (var company in companies)
            {
                consoleHelper.WriteConsoleMessage(string.Format("Company ID: {0} - Company Name {1} - Company State {2}", company.CompanyId, company.CompanyName, company.CompanyState));
            }

            //Ordering operators
            var esd = employees.OrderByDescending(e => e.Name);
            consoleHelper.WriteConsoleMessage("-------------------------");
            consoleHelper.WriteConsoleMessage("Order name descending");
            foreach (var e in esd)
            {
                consoleHelper.WriteConsoleMessage(string.Format("Emp Name: {0}", e.Name));
            }

            var esa = employees.OrderBy(e => e.Name);
            consoleHelper.WriteConsoleMessage("-------------------------");
            consoleHelper.WriteConsoleMessage("Order name ascending");
            foreach (var e in esa)
            {
                consoleHelper.WriteConsoleMessage(string.Format("Emp Name: {0}", e.Name));
            }

            var esb = employees.OrderBy(e => e.Name).ThenBy(e => e.ID);
            consoleHelper.WriteConsoleMessage("-------------------------");
            consoleHelper.WriteConsoleMessage("OrderBy name ThenBy ID");
            foreach (var e in esb)
            {
                consoleHelper.WriteConsoleMessage(string.Format("Name: {0} ID:{1}", e.Name, e.ID));
            }


            //Take,Skip,Take While,Skip While Partitioning Operators
            var est = employees.Take(4);
            consoleHelper.WriteConsoleMessage("-------------------------");
            consoleHelper.WriteConsoleMessage("Take the first 4 employees");
            foreach (var e in est)
            {
                consoleHelper.WriteConsoleMessage(string.Format("Name: {0} ID:{1}", e.Name, e.ID));
            }

            var ess = employees.Skip(4);
            consoleHelper.WriteConsoleMessage("-------------------------");
            consoleHelper.WriteConsoleMessage("Skip the first 4 employees");
            foreach (var e in ess)
            {
                consoleHelper.WriteConsoleMessage(string.Format("Name: {0} ID:{1}", e.Name, e.ID));
            }

            //SkipWhile must be sorted first
            consoleHelper.WriteConsoleMessage("-------------------------");
            consoleHelper.WriteConsoleMessage("Skip while salary is > 55000 -- Don't forget to sort before skipping while");
            var esw = employees.OrderByDescending(e => e.Salary).SkipWhile(e => e.Salary > 55000);
            foreach (var e in esw)
            {
                consoleHelper.WriteConsoleMessage(string.Format("Name: {0} Salary is <= 55000: {1}", e.Name, e.Salary));
            }
            //TakeWhile must be sorted first 
            consoleHelper.WriteConsoleMessage("-------------------------");
            consoleHelper.WriteConsoleMessage("Take while salary is > 55000 -- Don't forget to sort before taking while");
            var estake = employees.OrderByDescending(e => e.Salary).TakeWhile(e => e.Salary > 55000);
            foreach (var e in estake)
            {
                consoleHelper.WriteConsoleMessage(string.Format("Name: {0} Salary is > 55000: {1}", e.Name, e.Salary));
            }

            Console.ReadLine();
        }
    }
}
