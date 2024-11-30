using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string _Op = "+";
        private double _Result = 0;

        private void button_Click(object sender, EventArgs e)
        {
            Button but = (Button) sender;

            if (textBox1.Text == "0") textBox1.Clear();

            if (but.Text == ".")
            { 
                if (!textBox1.Text.Contains(".")) textBox1.Text = textBox1.Text + but.Text;
            }
            else
            { 
                textBox1.Text = textBox1.Text + but.Text;
            }
        }

        private void Operation_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && _Op != "")
            {
                MessageBox.Show("The Operation Is Already Exist Waiting For The Second Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Button but = (Button)sender;

            button14.PerformClick();
            _Op = but.Text;
            _Result = double.Parse(textBox1.Text);
            textBox1.Clear();         
        }

        private void OperationResult_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") 
            { 
                MessageBox.Show("The Second Number Is Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (_Op) 
            {
                case "+" : textBox1.Text = (_Result + double.Parse(textBox1.Text)).ToString(); break;
                case "-" : textBox1.Text = (_Result - double.Parse(textBox1.Text)).ToString(); break;
                case "/" : textBox1.Text = (_Result / double.Parse(textBox1.Text)).ToString(); break;
                case "*" : textBox1.Text = (_Result * double.Parse(textBox1.Text)).ToString(); break;
                default : MessageBox.Show("Invalid Input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
            }
            label1.Text = textBox1.Text;
            _Result = 0;
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "0";
            label1.Text = textBox1.Text;
            _Result = 0;
            _Op = "+";
        }

        private void butCancle_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button_KeyPress(object sender, KeyPressEventArgs e)
        {                    
            button14.Focus();

            switch (e.KeyChar)
            {
                case '=': button14.PerformClick(); break;
                case '+': button13.PerformClick(); break;
                case '-': button12.PerformClick(); break;
                case '*': button10.PerformClick(); break;
                case '/': button11.PerformClick(); break;
                case '1': button1.PerformClick(); break;
                case '2': button2.PerformClick(); break;
                case '3': button3.PerformClick(); break;
                case '4': button4.PerformClick(); break;
                case '5': button5.PerformClick(); break;
                case '6': button6.PerformClick(); break;
                case '7': button7.PerformClick(); break;
                case '8': button8.PerformClick(); break;
                case '9': button9.PerformClick(); break;
                case '0': button16.PerformClick(); break;
                case '.': button15.PerformClick(); break;
                case 'c': butClear.PerformClick(); break;
                case ((char)Keys.Back): butCancle.PerformClick(); break;
                    default: break;
                    
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Focused) 
            {
                button14.Focus();
            }
        }
    }
}
