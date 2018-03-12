using System;

namespace EmployeeContractPolymorphism
{
    public abstract class EmployeeBase
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly int _age;
        private readonly char _gender;

        public EmployeeBase(string firstName, string lastName, int age, char gender, string employeeId)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
            _gender = gender;
        }

        protected string FirstName { get => _firstName; }

        protected string LastName { get => _lastName; }

        protected int Age { get => _age; }

        protected char Gender { get => _gender; }

        public abstract double CalculateWeeklyPay();

      
    }
}
