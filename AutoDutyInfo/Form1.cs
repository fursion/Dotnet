using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net.Http;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        private async void button_update_Click(object sender, EventArgs e)
        {
            Form2 form=new Form2();
            form.test();
            form.Show();
        
          // var str=await GetAccess_Token();
           //textBox_result.NewLine(str);
          // System.Console.WriteLine(str);
        }
        public async Task<string> GetTask()
        {
            string feishufileUrl = "https://open.feishu.cn/open-apis/drive/v1/files/:{0}/download";
            var fileurl = string.Format(feishufileUrl, "MOF7ydyKaiUgJ7QDMhsMb");
            using (HttpClient request = new HttpClient())
            {
                try
                {
                    request.DefaultRequestHeaders.Add("Authorization", "Bearer t-87acec7f7f5f5e258ba9ef754bdcd8fb379372ef");
                    System.Console.WriteLine(request.DefaultRequestHeaders);
                    HttpResponseMessage response = await request.GetAsync(fileurl);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
                catch (HttpRequestException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    throw ex;
                }
            }
        }
        public async Task<string> GetAccess_Token()
        {
            using (HttpClient request = new HttpClient())
            {
                try
                {
                    var body = new
                    {
                        app_id = "cli_a1ca8d842878d00c",
                        app_secret = "RNT9QYI0FHGhpZQEvLhtmepxUD401NtT"
                    };
                    var Json = JsonSerializer.Serialize(body);
                    using (var stringcontent = new StringContent(Json, Encoding.UTF8, "application/json"))
                    {
                        var response=await request.PostAsync("https://open.feishu.cn/open-apis/auth/v3/app_access_token/internal",stringcontent);
                        var str=await response.Content.ReadAsStringAsync();
                        request.Dispose();
                        return str;
                    }
                }
                catch (HttpRequestException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    throw ex;
                }
            }
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
