using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


using Microsoft.Office.Interop.Excel;
using OfficeHelper;
using Util;

namespace VssTask
{
    /// <summary>
    /// 针对指定的修改列表来读写数据
    /// 待改进，使用模板定义Excel数据。
    /// </summary>
    public class ExcelOperator
    {

        private static readonly int UI_HEADER_ROW = 2;   //表头行,数据开始行
        private static readonly int UI_DATA_ROW = 3;     //数据开始行
        private static readonly int JAVA_HEADER_ROW = 4;   //表头行,数据开始行
        private static readonly int JAVA_DATA_ROW = 5;     //数据开始行
        private static readonly int SQL_HEADER_ROW = 0;   //表头行,数据开始行
        private static readonly int SQL_DATA_ROW = 1;     //数据开始行,下表从零开始算起
        private readonly string SHEET_UI = "UI";
        private readonly string SHEET_JAVA = "JAVA";
        private readonly string SHEET_SQL = "sql";

        public static readonly int UI_PATH_COLUMN = 3;         //UI模板中文件路径列
        public static readonly int UI_FILENAME_COLUMN = 2;     //UI模板中文件名称列
        public static readonly int JAVA_PATH_COLUMN = 3;         //UI模板中文件路径列
        public static readonly int JAVA_FILENAME_COLUMN = 2;     //UI模板中文件名称列
        public static readonly int SQL_FILENAME_COLUMN = 2;     //UI模板中文件名称列


        private string readFilePath;
        private string writeFilePath;

        public string WriteFilePath
        {
            get { return writeFilePath; }
            set { writeFilePath = value; }
        }

        public string ReadFilePath 
        {
            get { return this.readFilePath; }
            set { this.readFilePath = value; } 
        }

        /// <summary>
        /// 复制文件的修改列表数据
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="destFile"></param>
        public void CopyData()
        {
            string sourceFile = this.readFilePath;
            string destFile = this.writeFilePath;
            //包括三个数据sheet,分别是UI,JAVA，sql
        }

        /// <summary>
        /// 读取“UI”sheet的数据
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable ReadUI()
        {
            System.Data.DataTable dtbSheet = ReadSheet(SHEET_UI);
            dtbSheet = Sys.RemoveSubTable(dtbSheet, 0, UI_DATA_ROW);
            return dtbSheet;
        }

        /// <summary>
        /// 读取“Java”sheet的数据
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable ReadJava()
        {
            System.Data.DataTable dtbSheet = ReadSheet(SHEET_JAVA);
            dtbSheet = Sys.RemoveSubTable(dtbSheet, 0, JAVA_DATA_ROW);
            return dtbSheet;
        }

        /// <summary>
        /// 读取"SQL" sheet的数据
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable ReadSQL()
        {
            System.Data.DataTable dtbSheet = ReadSheet(SHEET_SQL);
            dtbSheet = Sys.RemoveSubTable(dtbSheet, 0, SQL_DATA_ROW);
            return dtbSheet;
        }

        /// <summary>
        /// 读取指定Sheet的数据
        /// </summary>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        private System.Data.DataTable ReadSheet(string sheetName)
        {
            DataSet ds = ExcelHelper.LoadDataFromExcel(this.readFilePath, sheetName);
            if(ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }


    }
}
