using System;
using System.Windows.Forms;

namespace DelegatesAnonymousMethodsLambdas
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new NamedDelegate.frmNamedDelegate().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new DelegateFuncT.frmFuncT().ShowDialog();
        }
    }
}
