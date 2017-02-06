using System.Collections.Generic;

namespace DelegatesAnonymousMethodsLambdas.DelegateFuncT
{
    public class People
    {
        public static List<Person> GetPeople()
        {
            return new List<Person>()
            {
                new Person("Eric","Nordin"),
                new Person("Sam","Bosky"),
                new Person("Dave","Mullins"),
                new Person("Tammy","White"),
                new Person("John","Smith"),
                new Person("Sara","Patterson"),
                new Person("Laura","Lomas"),
            };
        }
    }
}
