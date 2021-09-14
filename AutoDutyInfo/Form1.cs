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
        public void CreateControl()
        {

        }
        public Label label1 = new Label()
        {
            Text = "AutoCreateString",
            Location = new Point(10, 10),
            TabIndex = 10
        };
        public TextBox textBox = new TextBox()
        {
            Location = new Point(10,10+20)
        };
        public Form1()
        {
            Controls.Add(label1);
            Controls.Add(textBox);
            InitializeComponent();
            FormLayout();
            System.Console.WriteLine("test");
        }
        public void FormLayout()
        {
            this.Name = "Auto";
            this.Size = new System.Drawing.Size(900, 500);
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
        }
    }
}
