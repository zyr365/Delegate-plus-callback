using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

namespace WindowsFormsApp12
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Class1 cs = new Class1();
            cs.ShowEvent = test;
            Thread th = new Thread(cs.test);


            th.Start();
           
        }
        public void test(string str)
        {

            ShowlbDevTem(str);
        }


        public delegate void SWTDelegate(string AddStr);
         //public delegate void ComsumerTextDelegate(int Index, string AddStr);
         public  void ShowlbDevTem(string AddStr)
         {
             if (textBox1.InvokeRequired)
             {
                 SWTDelegate pd = new SWTDelegate(ShowlbDevTem);
                 textBox1.Invoke(pd, new object[] { AddStr });
             }
             else
             {
                 textBox1.Text = AddStr;
                 //richTextBox1.AppendText(AddStr);
             }
         }

         public void dataShow(int row, int column, string str)
         {
             row = row % 30;
             ShowMessage(dataGridViewX1, str, row, column);

         }


        delegate void ShowMessageDelegate(DataGridView dg, string message, int row, int column);
        private void ShowMessage(DataGridView dg, string message, int row, int column)
        {
            if (dg.InvokeRequired)
            {
                ShowMessageDelegate showMessageDelegate = ShowMessage;
                dg.Invoke(showMessageDelegate, new object[] { dg, message, row, column });
            }
            else
            {

                dg.Rows[row].Cells[column].Value = message;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Class1 cs = new Class1();
            // cs.test("123123");

            //  dataShow(1, 1, )
            ShowlbDevTem("112");

        }

    }
}
