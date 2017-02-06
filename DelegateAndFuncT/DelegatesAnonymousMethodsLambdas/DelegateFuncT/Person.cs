using System;

namespace DelegatesAnonymousMethodsLambdas.DelegateFuncT
{

    public class Person
    {
        // Type a new delegate
        // Instead of using a custom Named delegate type we can use the Microsoft's Anoymous generic delagate FuncT
        // public delegate string PersonFormat         (Person p);

        //public delegate TResult Func<in T, out TResult>(T args);

        private readonly string _firstName;
        private readonly string _lastName;
        public Person(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public string FirstName { get { return _firstName; }}
        public string LastName { get { return _lastName; } }

        public override string ToString()
        {
            return $"{_firstName} : {_lastName}"; 
        }

        // Instead of using our custom named delegate we can now use .Net's FuncT.
        // public string ToString(PersonFormat personFormat) 

        public string ToString(Func<Person, string> personFormat)
        {
            return personFormat(this);
        }
    }

}
