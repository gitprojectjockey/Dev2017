using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DelegatesAnonymousMethodsLambdas.DelegateFuncT
{
    public partial class frmFuncT : Form
    {
        public frmFuncT()
        {
            InitializeComponent();

            radDefault.Checked = true;
            _people = People.GetPeople();
            listResult.DataSource = _people;
        }

        //Now we can get rid of our Named custom delegate and use generic func T
        //DON'T NEED THIS ANYMORE
        //Person.PersonFormat _formatPerson;
        Func<Person, string> _formatPerson;

        List<Person> _people;

        private void btnProcessFuncT_Click(object sender, EventArgs e)
        {
            ClearListBox(this.listResult);
            // Assign Lambdas to my Func<Person,String> delegate dynamically
            AssignDelagateFormatMethodDynamic();

            foreach (var p in _people)
            {
                listResult.Items.Add(p.ToString(_formatPerson));
            }
        }

        private void AssignDelagateFormatMethodDynamic()
        {
            // Assign anonymous delegate Format Method here instead of using the static formatter class like the last example

            if (radDefault.Checked)
            {
                //  We can do this now with an anonymous delegate...
                //  _formatPerson = delegate (Person input)
                //  {
                //       return input.FirstName.ToString();
                //  };
                //-------------------------------------------------------------------------------------------------------------------------------

                //  now we can get rid of the delegate key word completely and use a => instead
                //  _formatPerson = (Person input) =>
                //  {
                //      return input.FirstName.ToString();
                //  };

                //--------------------------------------------------------------------------------------------------------------------------------

                //  or even better do this and get rid of the brackets too...
                //  _formatPerson = (Person person) => person.ToString();

                //--------------------------------------------------------------------------------------------------------------------------------

                // or even better use implicity typed variables like this...
                _formatPerson = input => input.ToString();
            }

            else if (radFirstName.Checked)
            {
                _formatPerson = input => input.FirstName.ToUpper();
            }
            else if (radLastName.Checked)
            {
                _formatPerson = input => input.LastName.ToUpper(); ;
            }
            else if (radFullName.Checked)
            {
                _formatPerson = i => $"{i.LastName.ToLower()}, {i.FirstName.ToLower()}";
            }
        }

        private void ClearListBox(ListBox listBox)
        {
            if (listBox.DataSource != null)
            {
                listBox.DataSource = null;
            }
            else
            {
                listBox.Items.Clear();
            }
        }


    }

}

