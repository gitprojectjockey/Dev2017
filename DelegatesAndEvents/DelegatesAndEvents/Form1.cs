using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DelegatesAndEvents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listResults.Items.Clear();
            //---------------------------------------------------------------------------------------------------------------------------------
            //Input is Employee and out put is string
            Func<Classes.Employee, string> selector = (x => string.Format("Name = {0}", x.Name));
            IEnumerable<string> values = Classes.Employee.GetAllEmployees().Select(selector);
            foreach (var val in values)
            {
                listResults.Items.Add(val);
            }

            //The obove is the same as...
            IEnumerable<string> values1 = Classes.Employee.GetAllEmployees().Select(x => "Name=" + x.Name);
            foreach (var val in values1)
            {
                listResults.Items.Add(val);
            }

            //------------------------------------------------------------------------------------------------------------------------------------------
            listResults.Items.Add("\n");
            char[] delimiters = new char[] { ' ' };
            string title = "The Scarlet Letter";
            string title2 = "This is the sentence I will parse out in the second flavor of extract";

            Func<string, int, string[]> extractMeth = delegate (string s, int i)
            {
                return i > 0 ? s.Split(delimiters, i) : s.Split(delimiters);
            };

            // Use Func instance to call ExtractWords method and display result
            foreach (string word in extractMeth(title, 5))
            {
                listResults.Items.Add(word);
            }

            //OR this which is the same as above just more sugary
            listResults.Items.Add("\n");

            Func<string, int, string[]> extract = ((s, i) => i > 0 ? s.Split(delimiters, i) : s.Split(delimiters));
            foreach (string word in extract(title2, 14))
            {
                listResults.Items.Add(word);
            }

            //Extract a range of employees using a Func delegate returning a string[] then looping through string[]
            //-----------------------------------------------------------------------------------------------------------------------------------------
            listResults.Items.Add("\n");
            Func<IEnumerable<Classes.Employee>, int, int, string[]> extractEmployeesByRange = delegate (IEnumerable<Classes.Employee> emps, int start, int count)
           {
               return emps.Select(x => x.Name).Skip(start).Take(count).ToArray<string>();
           };

            IEnumerable<Classes.Employee> es = Classes.Employee.GetAllEmployees();
            foreach (var name in extractEmployeesByRange(es, 3, 2))
            {
                listResults.Items.Add(name);
            }

            listResults.Items.Add("\n");
            //The same thing as above but more sugary
            Func<IEnumerable<Classes.Employee>, int, int, string[]> extractEmpsByRange = (x, start, count) => (x.Select(emp => emp.Name).Skip(start).Take(count).ToArray<string>());
            foreach (var name in extractEmpsByRange(es, 3, 2))
            {
                listResults.Items.Add(name);
            }

            listResults.Items.Add("\n");
            //OR The same thing as above but more even more sugary
            int startX = 3;
            int countX = 2;
            foreach (var name in es.Select(emp => emp.Name).Skip(startX).Take(countX))
            {
                listResults.Items.Add(name);
            }

            //-----------------------------------------------------------------------------------------------------------------------------------------
            listResults.Items.Add("\n");
            //Using func<T,TResult> as an input parameter for method 'CalculateNewAnnualSalaryAfterRaisePercentage' to callback and fill list
            List<string> valueResults = new List<string>();
            List<Classes.Employee> employees = Classes.Employee.GetAllEmployees().ToList();
            listResults.Items.Add("----------------------");
            var salariesTotal = Classes.Funky.CalculateNewAnnualSalaryAfterRaisePercentage((salary, name) => listResults.Items.Add(string.Format("{0:C} for {1}", salary, name)), employees);
            listResults.Items.Add("----------------------");
            listResults.Items.Add(string.Format("{0:C}", salariesTotal));
            listResults.Items.Add("----------------------");
        }
        //---------------------------------------------------------------------------------------------------
        public void MyActionTestFunction(string strParameter, int intParamater)
        {
            listResults.Items.Add("I just called my action test method with the following parameters.../n");
            listResults.Items.Add(string.Format("{0} and {1}", strParameter, intParamater));
        }

        public void SomeMethodWithNoInputParms()
        {
            listResults.Items.Add("I just called some method with no input parameters using action delegate.../n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listResults.Items.Clear();
            //Similar to Func delegate, the first two parameters are the method input parameters.
            //Since we do not have return object or type, all the parameters are considered as input parameters.
            Action<string, int> actionPointer = MyActionTestFunction;
            actionPointer("hello", 4);
            //Or....
            Action<string, int> actionDel = (x, y) => MyActionTestFunction(x, y);
            actionDel("Hello", 42);

            Action<string, string, string , int> sugaryActionPointer = delegate (string one,string two,string three, int i)
            {
                listResults.Items.Add(string.Format("{0} {1} {2} {3}",one,two,three,i));
            };
            sugaryActionPointer("Hello","Eric","you are",55);
  

            Action action = () => SomeMethodWithNoInputParms();
            action();
        }
    }
}

