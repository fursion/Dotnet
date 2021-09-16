using System;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Collections.Generic;

namespace AutoDutyInfo.Core
{
    public enum Shift
    {
        Day_shift,
        Middle_shift,
        Primary_Day_shift,
        Primary_Night_shift,
    }
    public static class ShiftInfo
    {
        public static string ReadJsonText()
        {

            var str1 = File.ReadAllText(System.Configuration.ConfigurationManager.AppSettings["linklistURl"]);
            var jsonstr = File.ReadAllText(System.Configuration.ConfigurationManager.AppSettings["TemplateURL"]);
            var str = File.ReadAllText("./Config/ShiftInfo.json");
            Dictionary<string, string> dic = new Dictionary<string, string>();
            var dic1 = JsonSerializer.Deserialize<Dictionary<string, string>>(str1);
            foreach(string term in dic1.Keys){
                if(null!=term){
                    System.Console.WriteLine(  term+""+dic1[term] );
                }
            }
            var dic2=JsonSerializer.Deserialize<Dictionary<string,shiftinfo>>(str);
            if(dic2.ContainsKey("Middle_shift")){
                System.Console.WriteLine(dic2["Middle_shift"].icon);
                System.Console.WriteLine(dic2["Middle_shift"].Place);
                System.Console.WriteLine(dic2["Middle_shift"].Timeslot);
            }
            return jsonstr;

        }
    }
    public class shiftinfo
    {
        public string icon;
        public string Place;
        public string Timeslot;
    }
}