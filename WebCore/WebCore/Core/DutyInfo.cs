using System;
using System.Text;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace WebCore.Core
{
    public enum Shift
    {
        Day_shift,
        Middle_shift,
        Primary_Day_shift,
        Primary_Night_shift,
    }
    public static class DutyInfo
    {
        public static string path = "/file/";
        public static Dictionary<string, string> link_dict;
        public static Dictionary<string, string> Templatedict;
        public static Dictionary<string, Dutyinfos> Dutyinfo_dict;
        public static void Init(string rootpath="")
        {
            Read_Dutyinfo_Dict(rootpath);
            Read_Linkinfo_Dict(rootpath);
            Read_Templatedict(rootpath);
        }
        public static void Read_Linkinfo_Dict(string rootpath="")
        {
            try
            {
                var linkinfo = File.ReadAllText(pathformat(rootpath, path, "linklist.json"));
                link_dict = JsonSerializer.Deserialize<Dictionary<string, string>>(linkinfo);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        public static void Read_Dutyinfo_Dict(string rootpath = "")
        {
            try
            {
                var Dutyinfo = File.ReadAllText(pathformat(rootpath, path, "DutyInfo.json"));
                Dutyinfo_dict = JsonSerializer.Deserialize<Dictionary<string, Dutyinfos>>(Dutyinfo);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }
        public static void Read_Templatedict(string rootpath = "")
        {
            try
            {
                var Templateinfo = File.ReadAllText(pathformat(rootpath,path, "Template.json"));
                Templatedict = JsonSerializer.Deserialize<Dictionary<string, string>>(@Templateinfo);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        public static string pathformat(string str1,string str2,string str3)
        {
            return str1 + str2+str3;
        }
    }
    [Serializable]
    public class Dutyinfos
    {
        public string icon { get; set; }
        public string Place { get; set; }
        public string Timeslot { get; set; }
    }
}