using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine.DependencyInversionPattern.PatternVersion;

namespace RunCSharpDesignPatters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPlayerDataMapper dataMapper = null;
            Player player = Player.CreateNewPlayer("Eric", dataMapper);
        }
    }
}
