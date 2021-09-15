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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();       
        }

        private void button_copy_Click(object sender, EventArgs e)
        {
            System.Console.WriteLine(pictureBox1.Height);
            System.Console.WriteLine(button_copy.Size);
        }
        private void button_Create_Click(object sender,EventArgs e){

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
