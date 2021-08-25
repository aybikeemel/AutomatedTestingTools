using Agilent.CommandExpert.ScpiNet.Ag90x0_SA_A_17_05;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomatedTestingTools
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        Form2 frm = new Form2();

        double freq = 0D;
        float[] chPower = null;
        float[] oBwidth = null;

        Ag90x0_SA N9020A;

        public void Form1_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Connect Device
            try
            {
            N9020A = new Ag90x0_SA("TCPIP0::10.0.1.148::hislip0::INSTR");
            System.Threading.Thread.Sleep(1000);
                label2.ForeColor = Color.Green;
                label2.Text = "Connection Successful";
                label2.Visible = true;
            }
            catch
            {
                label2.ForeColor = Color.Red;
                label2.Text= "Connection Failed"; 
                label2.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Set Center Frequency
            try { 
               frm.f2button1.Text = "Set frequency";
               frm.ShowDialog();
               double c= Convert.ToDouble(frm.textBox1.Text);
            N9020A.SCPI.SENSe.FREQuency.CENTer.Command(c);
            System.Threading.Thread.Sleep(1000);
                label3.ForeColor = Color.Green;
                label3.Text = "Center Frequency Is Set";
                label3.Visible = true;

            }
           catch
            {
                label3.ForeColor =Color.Red;
                label3.Text = "Center Frequency Could Not Set";
                label3.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try //first try catch for connect device and set center frequency 
            {
                try //second try catch for connect device
                {
                    N9020A = new Ag90x0_SA("TCPIP0::10.0.1.148::hislip0::INSTR");
                    System.Threading.Thread.Sleep(1000);
                       label2.ForeColor = Color.Green;
                       label2.Text = "Connection Successful";
                       label2.Visible = true;
                }
                catch
                {
                       label2.ForeColor = Color.Red;
                       label2.Text = "Connection Failed";
                       label2.Visible = true;
                }

                N9020A.SCPI.SENSe.FREQuency.CENTer.Command(14800000000D);
                System.Threading.Thread.Sleep(1000);
                   label3.ForeColor = Color.Green;
                   label3.Text = "Center Frequency Is Set";
                   label3.Visible = true;
            }
            catch
            {
                   label3.ForeColor = Color.Red;
                   label3.Text = "Center Frequency Could Not Set";
                   label3.Visible = true;
            }
        } 

        private void button4_Click(object sender, EventArgs e)
        {
            // Read Center Frequency
            try { 
            N9020A.SCPI.SENSe.FREQuency.CENTer.Query(out freq);
            System.Threading.Thread.Sleep(1000);
                label4.ForeColor = Color.Green;
                label4.Text = freq.ToString()+ "Hz";
                label4.Visible = true;
            }
            catch
            {
                label4.ForeColor = Color.Red;
                label4.Text = "Center Frequency Could Not Be Read";
                label4.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Set Channel Power Format
              try { 
            N9020A.SCPI.FORMat.TRACe.DATA.Command("REAL",32);
            System.Threading.Thread.Sleep(1000);
            N9020A.SCPI.FORMat.BORDer.Command("SWAPped");
            System.Threading.Thread.Sleep(1000);
                label5.ForeColor = Color.Green;
                label5.Text = "Channel Power Format Set";
                label5.Visible = true;
               }

           catch
            {
                label5.ForeColor = Color.Red;
                label5.Text = "Channel Power Format Could Not Set";
                label5.Visible = true;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            // Read Channel Power
            try{
            N9020A.SCPI.MEASure.CHPower.QueryBlockReal32(null, out chPower);
            System.Threading.Thread.Sleep(1000);
                label6.ForeColor = Color.Green;
                label6.Text = chPower + "";
                label6.Visible = true;
              }
            catch
            {
                label6.ForeColor = Color.Red;
                label6.Text = "Channel Power Could Not Read";
                label6.Visible = true;
            }
        }
         private void button7_Click(object sender, EventArgs e)
        {
            // Set Occupied Bandwith
            try
            { 
            N9020A.SCPI.SENSe.OBWidth.FREQuency.SPAN.Command(200000000D);
            System.Threading.Thread.Sleep(1000);
            N9020A.SCPI.FORMat.TRACe.DATA.Command("REAL");
            System.Threading.Thread.Sleep(1000);
                label7.ForeColor = Color.Green;
                label7.Text = "Occupied Bandwith Set";
                label7.Visible = true;
            }
            catch
            {
                label7.ForeColor = Color.Red;
                label7.Text = "Occupied Bandwith Could Not Set";
                label7.Visible = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
             // Read Occupied Bandwith
            try
            {
            N9020A.SCPI.FORMat.BORDer.Command("SWAPped");///Controls whether binary data is transferred in normal or swapped byte order.  
            System.Threading.Thread.Sleep(1000);
            N9020A.SCPI.READ.OBWidth.QueryBlockReal32(1u, out oBwidth);
                label8.ForeColor = Color.Green;
                label8.Text =oBwidth + "" ; 
                label8.Visible = true;
            }
            catch
            {
                label8.ForeColor = Color.Red;
                label8.Text = "Occupied Bandwith Could Not Read";
                label8.Visible = true;
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        }
}
