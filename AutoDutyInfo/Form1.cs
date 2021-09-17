using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoDutyInfo.Core;

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
            var str = textBox_result.Text;
            Clipboard.SetDataObject(str);
        }
        private void button_Create_Click(object sender, EventArgs e)
        {
            DutyInfo.Init();
            DataTable table = ExcelTools.ReadExcel("./Config/班表.xlsx", "IFS班表", true);
            ExcelTools.Traversal_duty_Table(table);
         
        }
        private void button_update_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
