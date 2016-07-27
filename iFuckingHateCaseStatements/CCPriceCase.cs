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
    public partial class CCPriceCase : Form
    {
        string intreturncase =  "    case {0}:\r\n" +
                                "        return {1};\r\n" +
                                "        break;\r\n";

        string begin = "switch ({0}) {{\r\n";
        string end = "}";

        string result;

        string path;

        public CCPriceCase()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = "";
            result += String.Format(begin, textBox3.Text);
            for(int i = 0; i < textBox1.Lines.Length; i++)
            {
                string block = String.Format(intreturncase, textBox1.Lines[i], textBox2.Lines[i]);
                result += block;
            }
            result += end;

            System.IO.File.WriteAllText(path, result);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;

            openFileDialog1.ShowDialog();

            if (!string.IsNullOrWhiteSpace(openFileDialog1.FileName))
            {
                path = openFileDialog1.FileName;
                button2.Text = path;
            }
        }

        private void CCPriceCase_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 100; i++)
            {
                textBox1.Text += String.Format("{0}\r\n",i.ToString());
            }
        }
    }
}
