using System.Collections.Generic;

namespace DelegatesAndEvents.Classes
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public double Salary { get; set; }
        public int CompanyID { get; set; }
        public double RaisePercentage { get; set; }

        public static IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> listEmployees = new List<Employee>();

            Employee employee1 = new Employee
            {
                ID = 101,
                Name = "Mark",
                Gender = "Male",
                Salary = 55000,
                CompanyID = 302,
                RaisePercentage = .25
            };
            listEmployees.Add(employee1);

            Employee employee2 = new Employee
            {
                ID = 102,
                Name = "Mary",
                Gender = "Female",
                Salary = 80000,
                CompanyID = 302,
                RaisePercentage = .23
            };
            listEmployees.Add(employee2);

            Employee employee3 = new Employee
            {
                ID = 103,
                Name = "John",
                Gender = "Male",
                Salary = 96500.80,
                CompanyID = 301,
                RaisePercentage = .25
            };
            listEmployees.Add(employee3);

            Employee employee4 = new Employee
            {
                ID = 104,
                Name = "steve",
                Gender = "Male",
                Salary = 22000,
                CompanyID = 301,
                RaisePercentage = .25
            };
            listEmployees.Add(employee4);

            Employee employee5 = new Employee
            {
                ID = 105,
                Name = "Terry",
                Gender = "Female",
                Salary = 95300.66,
                CompanyID = 301,
                RaisePercentage = .25
            };
            listEmployees.Add(employee5);

            Employee employee6 = new Employee
            {
                ID = 106,
                Name = "locust",
                Gender = "Male",
                Salary = 90300,
                CompanyID = 303,
                RaisePercentage = .1
            };
            listEmployees.Add(employee6);

            Employee employee7 = new Employee
            {
                ID = 107,
                Name = "Sampson",
                Gender = "Male",
                Salary = 45300.99,
                CompanyID = 303,
                RaisePercentage = .15
            };
            listEmployees.Add(employee7);

            Employee employee8 = new Employee
            {
                ID = 108,
                Name = "taco",
                Gender = "Female",
                Salary = 30000,
                CompanyID = 303,
                RaisePercentage = .25
            };
            listEmployees.Add(employee8);

            Employee employee9 = new Employee
            {
                ID = 109,
                Name = "Adam",
                Gender = "Male",
                Salary = 100000.22,
                CompanyID = 301,
                RaisePercentage = .25
            };
            listEmployees.Add(employee9);

            Employee employee10 = new Employee
            {
                ID = 110,
                Name = "Zelda",
                Gender = "Female",
                Salary = 10000,
                CompanyID = 301,
                RaisePercentage = .25
            };
            listEmployees.Add(employee10);

            Employee employee11 = new Employee
            {
                ID = 111,
                Name = "Apple",
                Gender = "Female",
                Salary = 10000.1,
                CompanyID = 302,
                RaisePercentage = .25
            };
            listEmployees.Add(employee11);

            return listEmployees;
        }
    }
}
