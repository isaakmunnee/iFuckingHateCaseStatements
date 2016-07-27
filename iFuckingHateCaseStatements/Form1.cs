using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iFuckingHateCaseStatements
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Generic_Case gc = new Generic_Case();
            gc.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CCPriceCase ccpc = new CCPriceCase();
            ccpc.ShowDialog();
        }
    }
}
