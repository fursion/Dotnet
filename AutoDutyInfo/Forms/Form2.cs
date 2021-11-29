using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoDutyInfo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
          public void test()
        {
            string url=string.Format("file:{0}","/Core/JS/PullToken.html");
            webBrowser.Navigate(url);
        }
    }
}
