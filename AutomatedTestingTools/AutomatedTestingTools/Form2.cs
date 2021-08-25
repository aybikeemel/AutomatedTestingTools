using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutomatedTestingTools
{
    public partial class Form2 : Form
    {       
     
        public Form2()
        {
            InitializeComponent();
        }     



        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { 
          //  textBox1.Text =  textBox1.Text + "  Hz";
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
