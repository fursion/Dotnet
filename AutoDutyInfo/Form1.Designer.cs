﻿namespace AutoDutyInfo
{
    partial class Form1
    {
        private int DefW=1068;
        private int DeH=800;
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.button_Create = new System.Windows.Forms.Button();
            this.button_copy = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(806, 37);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(250, 27);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // box
            // 
            this.box.Location = new System.Drawing.Point(12, 253);
            this.box.Name = "box";
            this.box.Size = new System.Drawing.Size(125, 27);
            this.box.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "生成结果";
            this.label1.BackColor=System.Drawing.Color.Transparent;
            this.label1.BorderStyle=System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 311);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 27);
            this.textBox1.TabIndex = 4;
            // 
            // textBox_result
            // 
            this.textBox_result.Location = new System.Drawing.Point(0, 427);
            this.textBox_result.Multiline = true;
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.Size = new System.Drawing.Size(1068, 373);
            this.textBox_result.TabIndex = 0;
            // 
            // button
            // 
            this.button_Create.Size = new System.Drawing.Size(94, 29);
            this.button_Create.Location = new System.Drawing.Point(828, 399);
            this.button_Create.Name = "button-create";            
            this.button_Create.TabIndex = 2;
            this.button_Create.Text = "Create";
            this.button_Create.UseVisualStyleBackColor = true;
            this.button_Create.Click += new System.EventHandler(this.button_Create_Click);
            // 
            // button-copy
            // 
            
            this.button_copy.Name = "button-copy";
            this.button_copy.Size = new System.Drawing.Size(94, 30);
            this.button_copy.Location = new System.Drawing.Point(948, 399);
            this.button_copy.TabIndex = 6;
            this.button_copy.Text = "Copy";
            this.button_copy.UseVisualStyleBackColor = true;
            this.button_copy.Click += new System.EventHandler(this.button_copy_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AutoDutyInfo.Properties.Resources.Help_Desk;
            this.pictureBox1.Location = new System.Drawing.Point(0, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(global::AutoDutyInfo.Properties.Resources.Help_Desk.Width, global::AutoDutyInfo.Properties.Resources.Help_Desk.Height);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 800);
            this.Controls.Add(this.button_Create);
            this.Controls.Add(this.button_copy);
            this.Controls.Add(this.box);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox_result);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "AutoDutyInfo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.Button button_Create;
        private System.Windows.Forms.Button button_copy;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

