using System;
using System.Text;
using System.IO;
using System.Text.Json;
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
    public static class DutyInfo
    {
        public static Dictionary<string, string> link_dict;
        public static Dictionary<string, string> Templatedict;
        public static Dictionary<string, Dutyinfos> Dutyinfo_dict;
        public static string ReadJsonText()
        {

            var str1 = File.ReadAllText("/Config/");
            var jsonstr = File.ReadAllText("/Config/Template.json");
            return "1";
        }
        public static void Init()
        {
            Read_Dutyinfo_Dict();
            Read_Linkinfo_Dict();
            Read_Templatedict();
        }
        public static void Read_Linkinfo_Dict()
        {
            try
            {
                var linkinfo = File.ReadAllText("/Config/linklist.json");
                link_dict = JsonSerializer.Deserialize<Dictionary<string, string>>(linkinfo);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        public static void Read_Dutyinfo_Dict()
        {
            try
            {
                var Dutyinfo = File.ReadAllText("/Config/DutyInfo.json");
                Dutyinfo_dict = JsonSerializer.Deserialize<Dictionary<string, Dutyinfos>>(Dutyinfo);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }
        public static void Read_Templatedict()
        {
            try
            {
                var Templateinfo = File.ReadAllText("Template.json");
                Templatedict = JsonSerializer.Deserialize<Dictionary<string, string>>(@Templateinfo);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
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