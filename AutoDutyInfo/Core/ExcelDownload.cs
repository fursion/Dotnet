using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AutoDutyInfo.Core
{
   public static class ExcelDownload
   {

        public static void Test()
        {
            string feishufileUrl = "https://open.feishu.cn/open-apis/drive/v1/files/:{0}/download";
            var fileurl = string.Format(feishufileUrl, "boxcnabCdefg12345");
            Console.WriteLine(fileurl);
            try
            {
                HttpWebRequest feishu = (HttpWebRequest)WebRequest.Create(fileurl);
                feishu.Method = "GET";
                feishu.PreAuthenticate=true;
                WebHeaderCollection webHeader=feishu.Headers;
                webHeader.Add("Authorization: Bearer u-7f1bcd13fc57d46bac21793a18e560");
                System.Console.WriteLine(feishu.Headers);
                //feishu.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)feishu.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                Console.WriteLine(responseFromServer);
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        

    }
}
