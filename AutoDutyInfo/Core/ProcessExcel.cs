using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using NPOI;
using NPOI.SS.UserModel;
using System.Data;

namespace AutoDutyInfo.Core
{
    public static class ExcelTools
    {
        /// <summary>
        /// 读取班表
        /// </summary>
        /// <param name="Excelfilepath"></param>
        /// <param name="sheetName"></param>
        /// <param name="IsFirstRowColumnName"></param>
        /// <returns></returns>
        public static DataTable ReadExcel(string Excelfilepath, string sheetName = null, bool IsFirstRowColumnName = true)
        {
            DataTable dataTable = new DataTable();
            FileStream ExcelSr = new FileStream(Excelfilepath, FileMode.Open, FileAccess.Read);
            ISheet sheet = null;
            int startRow = 0;
            try
            {
                IWorkbook workbook = WorkbookFactory.Create(ExcelSr);
                if (!string.IsNullOrEmpty(sheetName))
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (null == sheet)
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                    sheet = workbook.GetSheetAt(0);
                if (null != sheet)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum;
                    if (IsFirstRowColumnName)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (null != cell)
                            {
                                cell.SetCellType(CellType.String);
                                string cellvalue = cell.StringCellValue;
                                if (null != cellvalue)
                                {
                                    DataColumn column = new DataColumn(cellvalue);
                                    dataTable.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (null == row)
                            continue;
                        DataRow dataRow = dataTable.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (null != row.GetCell(j))
                            {
                                dataRow[j] = row.GetCell(j).ToString();
                            }
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }
                return dataTable;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                return null;
            }
        }
        /// <summary>
        /// 遍历班表，查询当天值班人员，生成在班信息
        /// </summary>
        /// <param name="table"></param>
        public static IEnumerable<string> Traversal_duty_Table(DataTable table, DateTime dateTime)
        {
            int year = dateTime.Year;
            int month = dateTime.Month;
            int day = dateTime.Day;
            int count = table.Rows.Count;
            List<string> TodayDutyinfo = new List<string>();
            /// <summary>
            /// 姓名，班次，在班表中所在行，日期
            /// </summary>
            List<Tuple<string, string, int, int>> tuple_duty = new List<Tuple<string, string, int, int>>();
            for (int index = 1; index < count; index++)
            {
                var user = table.Rows[index][0].ToString();
                var item = table.Rows[index][day].ToString();
                string Temp = DutyInfo.Templatedict["班次信息"];
                if (DutyInfo.Dutyinfo_dict.ContainsKey(item))
                {

                    //

                    if (IsMask_Item(item))
                        continue;
                    var tuple = new Tuple<string, string, int, int>(user, item, index, day);
                    tuple_duty.Add(tuple);

                    //Temp = string.Format(Temp, DutyInfo.Dutyinfo_dict[item].icon, tempname, DutyInfo.Dutyinfo_dict[item].Place, DutyInfo.Dutyinfo_dict[item].Timeslot, user, DutyInfo.link_dict[user]);
                    //TodayDutyinfo.Add(Temp);
                }
            }
            Sortdyty(table, ref tuple_duty);
            return Createinfo(table, tuple_duty, dateTime);
        }
        public static string ProcessDutyName(string duty)
        {
            duty = duty.Substring(0, 1);
            return duty + "班";
        }
        /// <summary>
        /// 判断是否是屏蔽项
        /// </summary>
        /// <param name="duty"></param>
        /// <returns></returns>
        public static bool IsMask_Item(string duty)
        {
            if (duty.Contains('初') && duty.Contains('白'))
                return true;
            return false;
        }
        public static IEnumerable<string> Createinfo(DataTable dataTable, List<Tuple<string, string, int, int>> tuples, DateTime dateTime)
        {
            List<string> TodayDutyinfo = new List<string>();
            List<Tuple<string, string, int, int>> tuple_duty = new List<Tuple<string, string, int, int>>();
            int NowMouthDays = System.Threading.Thread.CurrentThread.CurrentUICulture.Calendar.GetDaysInMonth(dateTime.Year, dateTime.Month);
            foreach (var item in tuples)
            {
                System.Console.WriteLine(item.Item1);
                string Temp = DutyInfo.Templatedict["班次信息"];
                var tempname = ProcessDutyName(item.Item2);
                if (!DutyInfo.link_dict.ContainsKey(item.Item1))
                {
                    string str=string.Format("在 linkinfo.json 中没有找到:{0}的链接！",item.Item1);
                    System.Windows.Forms.MessageBox.Show(str,"提示",System.Windows.Forms.MessageBoxButtons.OK);
                    continue;
                }
                if (item.Item2.Contains('白'))
                {
                    if (item.Item4 + 1 > NowMouthDays)
                    {
                        if (!dataTable.Rows[item.Item3][item.Item4 - 1].ToString().Contains('白'))
                        {
                            formatinfo(ref Temp, item, "15F");
                            TodayDutyinfo.Insert(0, Temp);
                        }
                        else
                        {
                            formatinfo(ref Temp, item, "40F");
                            TodayDutyinfo.Add(Temp);
                        }
                    }
                    else if (item.Item4 - 1 < 1)
                    {
                        if (!dataTable.Rows[item.Item3][item.Item4 + 1].ToString().Contains('白'))
                        {
                            formatinfo(ref Temp, item, "40F");
                            TodayDutyinfo.Add(Temp);
                        }
                        else
                        {
                            formatinfo(ref Temp, item, "15F");
                            TodayDutyinfo.Insert(0, Temp);
                        }
                    }
                    else
                    {
                        if (!dataTable.Rows[item.Item3][item.Item4 + 1].ToString().Contains('白'))
                        {
                            formatinfo(ref Temp, item, "40F");
                            TodayDutyinfo.Add(Temp);
                        }
                        else
                        {
                            formatinfo(ref Temp, item, "15F");
                            TodayDutyinfo.Insert(0, Temp);
                        }
                    }
                }
                else
                {
                    formatinfo(ref Temp, item);
                    //Temp = string.Format(Temp, DutyInfo.Dutyinfo_dict[item.Item2].icon, tempname, DutyInfo.Dutyinfo_dict[item.Item2].Place, DutyInfo.Dutyinfo_dict[item.Item2].Timeslot, Nameformat(item.Item1), DutyInfo.link_dict[item.Item1]);
                    TodayDutyinfo.Add(Temp);
                }
            }
            return TodayDutyinfo.ToArray();
        }
        public static void formatinfo(ref string temp, Tuple<string, string, int, int> tuple, string location = null)
        {
            if (null != location)
                temp = string.Format(temp, DutyInfo.Dutyinfo_dict[tuple.Item2].icon, ProcessDutyName(tuple.Item2), location, DutyInfo.Dutyinfo_dict[tuple.Item2].Timeslot, Nameformat(tuple.Item1), DutyInfo.link_dict[tuple.Item1]);
            else
                temp = string.Format(temp, DutyInfo.Dutyinfo_dict[tuple.Item2].icon, ProcessDutyName(tuple.Item2), DutyInfo.Dutyinfo_dict[tuple.Item2].Place, DutyInfo.Dutyinfo_dict[tuple.Item2].Timeslot, Nameformat(tuple.Item1), DutyInfo.link_dict[tuple.Item1]);
        }
        public static void Sortdyty(DataTable table, ref List<Tuple<string, string, int, int>> tuples)
        {
            List<Tuple<string, string, int, int>> tuple_duty = new List<Tuple<string, string, int, int>>();
            foreach (var item in tuples)
            {
                if (item.Item2.Contains('白'))
                    tuple_duty.Insert(0, item);
                else tuple_duty.Add(item);

            }
            tuples = tuple_duty;
        }
        public static string Nameformat(string Name)
        {
            if (Name.Length == 2)
            {
                Name = Name[0] + "   " + Name[1];
            }
            return Name;
        }
    }
}