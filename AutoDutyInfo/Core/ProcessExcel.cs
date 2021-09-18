using System;
using System.IO;
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
            System.Console.WriteLine(day);
            int count = table.Rows.Count;
            List<string> TodayDutyinfo = new List<string>();
            for (int index = 1; index < count; index++)
            {
                var user = table.Rows[index][0].ToString();
                var item = table.Rows[index][day].ToString();
                string Temp = DutyInfo.Templatedict["班次信息"];
                if (DutyInfo.Dutyinfo_dict.ContainsKey(item))
                {
                    var tempname = ProcessDutyName(item);
                    if (IsMask_Item(item))
                        continue;
                    Temp = string.Format(Temp, DutyInfo.Dutyinfo_dict[item].icon, tempname, DutyInfo.Dutyinfo_dict[item].Place, DutyInfo.Dutyinfo_dict[item].Timeslot, user, DutyInfo.link_dict[user]);
                    TodayDutyinfo.Add(Temp);
                }
            }
            return TodayDutyinfo.ToArray();
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
        public static void Schedulingrules(){

        }
    }
}