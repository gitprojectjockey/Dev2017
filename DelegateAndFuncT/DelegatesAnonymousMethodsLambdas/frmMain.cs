using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
