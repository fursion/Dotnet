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
            textBox_result.Clear();
            DutyInfo.Init();
            DataTable table = ExcelTools.ReadExcel(System.Configuration.ConfigurationManager.AppSettings["班表"], "IFS班表", true);
            textBox_result.NewLine(DutyInfo.Templatedict["班次表头"]);
            var TodayDutyinfo = ExcelTools.Traversal_duty_Table(table, dateTimePicker1.Value);
            foreach (var item in TodayDutyinfo)
            {
                textBox_result.NewLine(item);
            }
            textBox_result.NewLine(DutyInfo.Templatedict["班次表尾"]);
        }
        private void button_update_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.test();
            ExcelDownload.Test();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox_result.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
