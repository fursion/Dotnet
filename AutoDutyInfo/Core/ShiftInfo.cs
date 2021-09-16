using System;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
namespace AutoDutyInfo.Core
{
    public enum Shift{
        Day_shift,
        Middle_shift,
        Primary_Day_shift,
        Primary_Night_shift,
    }
    public static class ShiftInfo
    {
        public static string  ReadJsonText(){
            
            var jsonstr=File.ReadAllText(System.Configuration.ConfigurationManager.AppSettings["linklistURl"]);
           return jsonstr;
        
        }
    }
}     