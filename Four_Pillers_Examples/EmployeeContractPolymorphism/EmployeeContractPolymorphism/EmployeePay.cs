using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EmployeeContractPolymorphism
{
    public partial class EmployeePay : Form
    {
        public EmployeePay()
        {
            InitializeComponent();
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            List<EmployeeBase> employees = new List<EmployeeBase>()
            {
                new HourlyContractor("Sam","Bushing",34,'M',"emp4512",32.45,42),
                new HourlyContractor("Tammy","Kline",51,'M',"emp4500",32.00,42),
                new Salaried("Tammy","Kline",51,'F',"emp4522",90000.00),
                new HourlyContractor("Steve","Bishop",43,'M',"emp2212", 45.26, 40),
                new Salaried("Bill","Hemmer",44,'M',"emp3122",100000.34),
            };


            foreach (var emp in employees)
            {
                string pay = $"{emp.ToString()} --  {emp.CalculateWeeklyPay().ToString("C0")}";
                listPay.Items.Add(pay);
            }

            Func<IEnumerable<EmployeeBase>, IEnumerable<EmployeeBase>> getContractors = emp =>
            {
                var array = new List<EmployeeBase>();
                employees.ToList().ForEach(x =>
                {
                    if (typeof(HourlyContractor) == x.GetType())
                        array.Add(x);
                });
                return array;
            };

            var contrators = getContractors(employees);
        }
    }
}
