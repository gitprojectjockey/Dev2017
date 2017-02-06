
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace DelegatesAnonymousMethodsLambdas.NamedDelegate
{
    public partial class frmNamedDelegate : Form
    {
        // Create a parameter of type PersonFormat Delagate.
        NamedDelegate.Person.PersonFormat _formatPerson;

        List<NamedDelegate.Person> _people;

        public frmNamedDelegate()
        {
            InitializeComponent();
            radDefault.Checked = true;
            _people = NamedDelegate.People.GetPeople();
            listResult.DataSource = _people;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            ClearListBox(this.listResult);
            // Assign Method to my delagate dynamically
            AssignDelagateFormatMethodDynamic();

            foreach (var p in _people)
            {
                listResult.Items.Add(p.ToString(_formatPerson));
            }
        }

        private void AssignDelagateFormatMethodDynamic()
        {
            // Assign Format Method to my delagate dynamically based on which radio button was picked
            if (radDefault.Checked)
            {
                _formatPerson = NamedDelegate.Formatters.Default;
            }
            else if (radFirstName.Checked)
            {
                _formatPerson = NamedDelegate.Formatters.FirstNameToUpper;
            }
            else if (radLastName.Checked)
            {
                _formatPerson = NamedDelegate.Formatters.LastNameToUpper;
            }
            else if (radFullName.Checked)
            {
                _formatPerson = NamedDelegate.Formatters.FullNameToLower;
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
