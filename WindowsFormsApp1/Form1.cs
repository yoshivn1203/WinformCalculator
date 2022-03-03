using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private double first, second;
        private char op;
        private bool equalFlag;
        private byte opCount = 0;
        
        public Form1()
        {
            InitializeComponent();
        }
        private void number_Click(object sender, EventArgs e)
        {
            if (equalFlag == true)
            {
                lbl.Text = "";
                equalFlag = false;
            }

            var b = (Button)sender;
            lbl.Text += b.Text;
            second = Convert.ToDouble(lbl.Text);
        }
        private void SubBtn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lbl.Text))
            {
                if (opCount == 0)
                    first = Convert.ToDouble(lbl.Text);
                else
                    first = Convert.ToDouble(Calculate());
                lbl.Text = "";
                equalFlag = false;
                op = '-';
                opCount++;

            }
        }
        private void RemainClick_Click(object sender, EventArgs e)
        {
            SubBtn_Click(sender, e);
            op = '%';
        }

        private void PlusBtn_Click(object sender, EventArgs e)
        {
            SubBtn_Click(sender, e);
            op = '+';
        }

        private void MulBtn_Click(object sender, EventArgs e)
        {
            SubBtn_Click(sender, e);
            op = 'x';
        }

        private void DivBtn_Click(object sender, EventArgs e)
        {
            SubBtn_Click(sender, e);
            op = '/';
        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            lbl.Text = "";
            op = '!';
            equalFlag = false;
        }
        private void BackBtn_Click(object sender, EventArgs e)
        {
            if(lbl.Text != "")
            lbl.Text = lbl.Text.Remove(lbl.Text.Length - 1);
        }
        
        private void SignBtn_Click(object sender, EventArgs e)
        {
            if (lbl.Text.StartsWith("-"))
                lbl.Text = lbl.Text.Remove(0, 1);
            else
                lbl.Text = lbl.Text.Insert(0, "-");

            if(lbl.Text.Length>1 || (!lbl.Text.StartsWith("-")&lbl.Text != ""))
            second = Convert.ToDouble(lbl.Text);
        }

        private void EqualBtn_Click(object sender, EventArgs e)
        {
            Calculate();
            opCount = 0;
            equalFlag = true;
            op = '!';
        }

       
        private string Calculate()
        {
            if (op == '+')
                lbl.Text = (first + second).ToString();
            else if (op == '-')
                lbl.Text = (first - second).ToString();
            else if (op == 'x')
                lbl.Text = (first * second).ToString();
            else if (op == '/')
                lbl.Text = (first / second).ToString();
            else if (op == '%')
                lbl.Text = (first % second).ToString();
            return lbl.Text;
        }
    }
}
