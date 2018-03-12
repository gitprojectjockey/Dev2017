using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EmployeeContractPolymorphism
{
    public class HourlyContractor : EmployeeBase
    {
        private readonly double _hourlyPay;
        private readonly int _hoursWorked;

        public HourlyContractor(string firstName, string lastName, int age, char gender,string employeeId,double hourlyPay,int hoursWorked)
            : base(firstName, lastName, age, gender,employeeId)
        {
            _hourlyPay = hourlyPay;
            _hoursWorked = hoursWorked;
        }

        public override double CalculateWeeklyPay()
        {
            //if hours are greater the 40 get overtime
            return _hoursWorked * _hourlyPay; 
        }
        public override string ToString()
        {
            return $"Contract Hourly: {base.FirstName},{base.LastName},{base.Age},{base.Gender}";
        }

        //Func<string, string> selector = (x => string.Format(, ));
        public Func<string,string> GetFormattedName()
        {
            return (x => $"{FirstName.ToUpper()} {LastName.ToUpper()}");
        }

        IEnumerable<int> numbers = new[] { 3, 4, 7, 1, 8, 10, 21, 5, 9, 11, 14, 19 };
        Func<IEnumerable<int>, IEnumerable<int>> getGreaterThanTen = nums =>
        {
            var array = new List<int>();
            nums.ToList().ForEach(x =>
            {
                if (x > 10)
                    array.Add(x);
            });
            return array;
        };

        

    }
}
