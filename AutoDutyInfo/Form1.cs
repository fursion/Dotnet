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
            textBox_result.Text = ShiftInfo.ReadJsonText();
            DataTable table = ExcelTools.ReadExcel("./Config/班表.xlsx", "IFS班表", true);
            int count = table.Rows.Count;
            for (int index = 0; index < count; index++)
            {
                System.Console.WriteLine(table.Rows[index][0]);
                if (table.Rows[index][0].ToString() == "杜洁")
                    System.Console.WriteLine(index);

            }
        }
        private void button_update_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
