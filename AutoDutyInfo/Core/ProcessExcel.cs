using System;
using System.IO;
using System.Data.OleDb;
using NPOI;
using NPOI.SS.UserModel;
using System.Data;

namespace AutoDutyInfo.Core
{
    public static class ExcelTools
    {
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
        public static void Traversal_duty_Table(DataTable table)
        {
            int count = table.Rows.Count;
            for (int index = 0; index < count; index++)
            {
                System.Console.WriteLine(table.Rows[index][0]);
                var item = table.Rows[index][0].ToString();
                if (DutyInfo.link_dict.ContainsKey(item)){
                    System.Console.WriteLine( DutyInfo.link_dict[item]);                
                }

            }
        }
    }
}