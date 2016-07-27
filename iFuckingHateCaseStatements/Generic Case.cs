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
    public partial class Generic_Case : Form
    {
        public Generic_Case()
        {
            InitializeComponent();
        }

        public int chosenList;
        public int howManyVars;

        public string path;

        public string varName;

        public string[] variableList; //list of .Text from all the textbox's
        public string[][] formatList;
        /*
         * for(i<string[].length)
         *     String.Format(case,string[i][allofthese]
         */

        public void ChangeHowManyVars(int l)
        {
            howManyVars = l;
            string[] local;
            local = variableList;
            variableList = new string[l];
            if(local != null)
            {
                for (int i = 0; i < local.Length; i++)
                {
                    if (variableList.Length < i) //if the created one was smaller, delete the variables you don't need.
                        return;

                    variableList[i] = local[i];
                }
            }
            Refresh();
        }

        public void ChangeWhichList(int a)
        {
            variableList[chosenList] = textBoxVariables.Text;
            chosenList = a;
            textBoxVariables.Text = variableList[chosenList];
            Refresh();
        }

        private void Generic_Case_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Build();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int local = howManyVars;

            if (String.IsNullOrWhiteSpace(textBox3.Text))
                return;

            if (!int.TryParse(textBox3.Text, out local))
                textBox3.Text = howManyVars.ToString();

            howManyVars = local;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (howManyVars == 0 || howManyVars < 0)
                return;

            ChangeHowManyVars(howManyVars);
            comboBox1.Items.Clear();
            for (int i = 0; i < howManyVars; i++)
            {
                comboBox1.Items.Add(String.Format("Variable {0}", i));
            }
            comboBox1.SelectedIndex = 0;
        }

        public void Build()
        {
            ChangeWhichList(0);

            formatList = new string[variableList[0].Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Length][];

            for (int i = 0; i < variableList[0].Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Length; i++)
            {
                formatList[i] = new string[howManyVars];
                for (int x = 0; x < howManyVars; x++)
                {
                    formatList[i][x] = variableList[x].Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[i];
                }
            }

            string result = "";
            result += "switch (" + varName + ") {\r\n";
            
            for(int i = 0; i < (variableList[0].Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Length); i++)
            {
                result += String.Format(textBox1.Text, formatList[i]);
                result += "\r\n";
            }
            result += "}";

            System.IO.File.WriteAllText(path, result);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeWhichList(comboBox1.SelectedIndex);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;

            openFileDialog1.ShowDialog();

            if (!string.IsNullOrWhiteSpace(openFileDialog1.FileName))
            {
                path = openFileDialog1.FileName;
                button4.Text = path;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }
    }
}