namespace DelegatesAnonymousMethodsLambdas.NamedDelegate
{

    public class Person
    {
        // Type a new delegate
        public delegate string PersonFormat(Person p);

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

        public string ToString(PersonFormat personFormat)
        {
           return personFormat(this);
        }
    }

}
