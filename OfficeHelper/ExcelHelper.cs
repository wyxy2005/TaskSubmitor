
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;

namespace OfficeHelper
{
    /// <summary>
    /// 操作Excel帮助类
    /// 
    /// 作者：ChengNing（cn2005nian@163.com）
    /// 日期：2012-12-03
    /// </summary>
    public class ExcelHelper
    {
        /// <summary>
        /// 默认的行数
        /// </summary>
        private const int ROW_COUNT_DEFAULT = 1000;

        /// <summary>
        /// 默认的列数
        /// </summary>
        private const int COL_COUNT_DEFAULT = 20;

        /// <summary>
        /// 加载Excel，
        /// 备注 1 此种方式读取的时间有问题
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static DataSet LoadDataFromExcel(string filePath, string sheetName)
        {
            try
            {
                string strConn;
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath +
                    ";Extended Properties='Excel 8.0;HDR=False;IMEX=1'";
                OleDbConnection OleConn = new OleDbConnection(strConn);
                OleConn.Open();
                String sql = "SELECT * FROM  [" + sheetName + "$]";//可是更改Sheet名称，比如sheet2，等等 

                OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);
                DataSet OleDsExcle = new DataSet();
                OleDaExcel.Fill(OleDsExcle, sheetName);
                OleConn.Close();
                return OleDsExcle;
            }
            catch (Exception err)
            {
                Console.WriteLine("数据绑定Excel失败!失败原因：" + err.Message);
                return null;
            }
        }

        /// <summary>
        /// 包含开始行，结束行数据，列同样（闭区间）
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheets"></param>
        /// <param name="startRow"></param>
        /// <param name="endRow"></param>
        /// <param name="startColumn"></param>
        /// <param name="endColumn"></param>
        /// <returns></returns>
        public static System.Data.DataTable LoadExcelDataToTable(string filePath, int sheets,
            int startRow,int endRow,int startColumn,int endColumn)
        {
            if (startRow <= 0)
                startRow = 1;
            if (startColumn <= 0)
                startColumn = 1;
            System.Data.DataTable excelTable = new System.Data.DataTable();
            for (int i = 0; i < endColumn - startColumn + 1; i++)
            {
                DataColumn dc = new DataColumn();
                excelTable.Columns.Add(dc);
            }

            Microsoft.Office.Interop.Excel.Application app =
                new Microsoft.Office.Interop.Excel.Application();
            app.Visible = false;
            Workbook wBook = app.Workbooks.Open(filePath);
            Worksheet wSheet = wBook.Worksheets[sheets] as Worksheet;
            try
            {

                for (int i = startRow; i <= endRow; i++)
                {
                    DataRow dr = excelTable.NewRow();
                    bool hasDataRow = false;
                    for (int j = startColumn; j <= endColumn; j++)
                    {
                        Range range = (Range)wSheet.Cells[i, j];
                        if (range.Value2 != null)
                        {
                            string text = ((object)range.Value2).ToString();
                            if (!string.IsNullOrEmpty(text))
                            {
                                dr[j - startColumn] = text;
                                hasDataRow = true;
                            }
                        }
                    }
                    if (hasDataRow)
                    {
                        excelTable.Rows.Add(dr);
                    }

                }
                //设置禁止弹出保存和覆盖的询问提示框 
                app.DisplayAlerts = false;
                app.AlertBeforeOverwriting = false;
                //wSheet = null;
                wBook.Close();
                wBook = null;

            }
            catch (Exception err)
            {
                Console.WriteLine("导出Excel出错！错误原因：" + err.Message);
                //return false;
            }
            finally
            {
                app.Quit();
                app = null;

                // 9.释放资源
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wSheet);
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(wBook);
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                // 10.调用GC的垃圾收集方法
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            //return result;
            return excelTable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheets"></param>
        /// <returns></returns>
        public static System.Data.DataTable LoadExcelDataToTable(string filePath, int sheets)
        {
            //默认范围
            return LoadExcelDataToTable(filePath, sheets, 0, 20, 0, 15);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">文件名称</param>
        /// <param name="sheets">sheets编号，从1开始</param>
        /// <param name="rowCount">总行数，从0开始</param>
        /// <param name="columnCount">总列数，从0开始</param>
        /// <returns></returns>
        public static System.Data.DataTable LoadExcelDataToTable(string filePath, int sheets,int rowCount,int columnCount)
        {
            //默认范围
            return LoadExcelDataToTable(filePath, sheets, 0, rowCount, 0, columnCount);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="excelTable"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool SaveDataTableToExcel(System.Data.DataTable excelTable, string filePath,
            int startRow,int startColumn,int sheets)
        {
            Microsoft.Office.Interop.Excel.Application app =
                new Microsoft.Office.Interop.Excel.Application();
            app.Visible = false;
            Workbook wBook = app.Workbooks.Add(true);
            Worksheet wSheet = wBook.Worksheets[sheets] as Worksheet;
            try
            {
                if (excelTable.Rows.Count > 0)
                {
                    int row = 0;
                    row = excelTable.Rows.Count;
                    int col = excelTable.Columns.Count;
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            string str = excelTable.Rows[i][j].ToString();
                            wSheet.Cells[i + startRow, j + startColumn] = str;
                        }
                    }
                }
                int size = excelTable.Columns.Count;
                for (int i = 0; i < size; i++)
                {
                    wSheet.Cells[1, 1 + i] = excelTable.Columns[i].ColumnName;
                }
                //设置禁止弹出保存和覆盖的询问提示框 
                app.DisplayAlerts = false;
                app.AlertBeforeOverwriting = false;
                //保存工作簿 
                wBook.Save();
                //保存excel文件 
                app.Save(filePath);
                app.SaveWorkspace(filePath);
                //app.Quit();
                //app = null;
            }
            catch (Exception err)
            {
                Console.WriteLine("导出Excel出错！错误原因：" + err.Message);
                return false;
            }
            finally
            {
                app.Quit();
                app = null;

                // 9.释放资源
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                // 10.调用GC的垃圾收集方法
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="excelTable"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool SaveDataTableToExcel(System.Data.DataTable excelTable, string filePath)
        {
            //默认开始的行列，excel从1开始
            return SaveDataTableToExcel(excelTable, filePath, 2, 1,1);
        }

        /// <summary>
        /// 将数据添加到excel数据末尾
        /// </summary>
        /// <param name="excelTable"></param>
        /// <param name="filePath"></param>
        /// <param name="sheets"></param>
        /// <returns></returns>
        public static void AddDataToExcel(System.Data.DataTable excelTable, string filePath, int sheets)
        {
            Application app = new Application();
            try
            {
                app.Visible = false;
                Workbook wBook = app.Workbooks.Open(filePath);
                Worksheet wSheet = wBook.Worksheets[sheets] as Worksheet;
                int sheetRow = 1;
                if (excelTable.Rows.Count > 0)
                {
                    int row = 0;
                    row = excelTable.Rows.Count;
                    int col = excelTable.Columns.Count;
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            //用第一列来判断某行是否有值，无知则填入,存在隐患，如果本行第一列没有值，则本行之后的值会被覆盖，有待改进
                            if (j == 0)
                            {
                                Range range = (Range)wSheet.Cells[sheetRow, 1];
                                //移到没有数据的行
                                while (range.Value2 != null)
                                {
                                    sheetRow++;
                                    range = (Range)wSheet.Cells[sheetRow, 1];
                                }
                            }
                            string str = excelTable.Rows[i][j].ToString();
                            wSheet.Cells[sheetRow, j+1] = str;
                        }
                    }
                }

                //设置禁止弹出保存和覆盖的询问提示框 
                app.DisplayAlerts = false;
                app.AlertBeforeOverwriting = false;
                //保存工作簿 
                wBook.Save();
                ////保存excel文件 
                //app.Save(filePath);
                //app.sa
                
                //app.SaveWorkspace(filePath);
                //app.Quit();
                //app = null;
            }
            catch (Exception err)
            {
                Console.WriteLine("导出Excel出错！错误原因：" + err.Message);
                //return false;
            }
            finally
            {
                app.Quit();
                app = null;
            }
        }



    }
}