using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp12
{
    class Class1
    {
        public Action<string> ShowEvent;
        public void test()
        {

            ShowEvent("123456789");


        }

        public delegate void SWTDelegate(string AddStr);
 
        public void ShowlbDevTem(string AddStr)
        {
            Form1 f1 = new Form1();
          


            if (f1.textBox1.InvokeRequired)
            {
                SWTDelegate pd = new SWTDelegate(ShowlbDevTem);
                f1.textBox1.Invoke(pd, new object[] { AddStr });
            }
            else
            {
                f1.textBox1.Text = AddStr;
                //richTextBox1.AppendText(AddStr);
            }
          

        }

        
    }
}
