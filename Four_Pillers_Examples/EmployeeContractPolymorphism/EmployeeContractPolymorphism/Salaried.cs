namespace EmployeeContractPolymorphism
{
    public class Salaried : EmployeeBase
    {
        private readonly double _salary;
        public Salaried(string firstName, string lastName, int age, char gender, string employeeId, double salary) 
            : base(firstName, lastName, age, gender, employeeId)
        {
            _salary = salary;
        }

        public override double CalculateWeeklyPay()
        {
            return _salary / 52;
        }

        public override string ToString()
        {
            return $"Salaried: {base.FirstName},{base.LastName},{base.Age},{base.Gender}";
        }
    }
}
