using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;
using System.Data;

namespace VssTask
{
    /// <summary>
    /// SubmitVssTemplate模板方法的具体实现
    /// 用户提交任务到vss
    /// 作者：ChengNing
    /// 日期：2012-12-03
    /// </summary>
    public class SubmitVssConcrete : SubmitVssTemplate
    {
        private char[] pathSplit = @"\/".ToCharArray();
        public static readonly string LOCAL_SLASH = @"\";
        public static readonly string VSS_SLASH = @"/";

        private string srcUrl = @"\\10.10.134.71\lisvss_src\srcsafe.ini";
        private string docUrl = @"\\10.10.134.71\lisvss_doc\srcsafe.ini";
        private string username = "chengning";
        private string password = "chengning";
        private VssOperator vssOperator;

        //后期引入log4net记录日志
        //private LogManager logger;

        public SubmitVssConcrete()
        {
            this.vssOperator = new VssOperator();
            this.vssOperator.Username = this.username;
            this.vssOperator.Password = this.password;
        }
       
        /// <summary>
        /// 上传自测报告，设计报告（研发文档）
        /// 模板方法中实际执行的具体方法
        /// </summary>
        protected override void AddDoc()
        {
            this.vssOperator.SrcSafeIni = this.docUrl;
            //$/LIS－CM－AB/05-项目任务/B-契约模块
            //vssFolder = @"$/LIS－CM－AB/05-项目任务/B-契约模块";
            if (this.vssOperator == null)
                return;
            if (!this.vssOperator.ExistFolder(base.DocVssFolder))
                this.vssOperator.NewProject(base.DocVssFolder, "");
            //设计文档
            this.vssOperator.AddFile(base.DocVssFolder, base.DesignDocLocalPath);
            //自测文档
            this.vssOperator.AddFile(base.DocVssFolder, base.TestDocLocalPath);
        }

        /// <summary>
        /// 上传SQL数据文档
        /// 如果不存在，则不用上传
        /// 如果存在多个，则都需要上传
        /// </summary>
        protected override void AddSqlFile()
        {
            //此步骤指定的vss
            this.vssOperator.SrcSafeIni = this.srcUrl;
            //从修改列表中读取一个文件列表，然后上传
            IList<string> sqlFiles = FileList(SysEnum.FileType.SQL);
            foreach (string file in sqlFiles)
            {
                //上传SQL文档
                this.vssOperator.AddFile(base.SqlDocVssFolder, file);
            }
        }

        /// <summary>
        /// check in 代码文件
        /// </summary>
        protected override void CheckIn()
        {
            //从修改列表中读取一个文件列表，然后checkin
            IList<string> files = FileList(SysEnum.FileType.Code);
            string localFullPath = null;
            string vssFullPath = null;
            foreach (string file in files)
            {
                localFullPath = this.CodeRootPathLocal.TrimEnd(pathSplit) + 
                    LOCAL_SLASH + file.Trim(pathSplit);
                vssFullPath = base.CodeRootPathVss.TrimEnd(pathSplit) + VSS_SLASH + 
                    file.Trim(pathSplit).Replace(LOCAL_SLASH,VSS_SLASH);
                //this.vssOperator.CheckIn(localFullPath,vssFullPath, base.Comment);
                Console.WriteLine(localFullPath);
                Console.WriteLine(vssFullPath);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 应用程序更新记录表,日表，每天的记录,11点，17点
        /// </summary>
        protected override void UpdateDayRecordFile()
        {
            /*应用更新记录表名称*/
            string file = @"201212/20121206/个险/个险代码更新_17点.xls";
            string dayRecordVssPath = base.RecordVssRoot.TrimEnd(pathSplit) + VSS_SLASH + file;                
            if (this.vssOperator.IsCheckOut(dayRecordVssPath))
            {
                Console.WriteLine("被checkout，无法修改");
            }
            else
            {
                string localTempFile = base.RecordTempRoot.TrimEnd(pathSplit) + LOCAL_SLASH + file;
                //使用vss get checkout，然后修改xls文件，然后check in
                this.vssOperator.CheckOut(dayRecordVssPath, localTempFile, "");
                ModifyRecordFile(localTempFile);
                this.vssOperator.CheckIn(localTempFile, dayRecordVssPath, "");

            }
        }

        /// <summary>
        /// 应用程序更新记录表,总表
        /// </summary>
        protected override void UpdateRecordFile()
        {
            //需要考虑如果已经被checkout的时候，如何处理
            string localTempFile = @"../temp/update" + DateTime.Today.ToLongTimeString() + ".xls";
            //使用vss get checkout，然后修改xls文件，然后check in
            //base.VssOperator.CheckOut(this.updateRecordFileVssPath, localTempFile, "");
            //ModifyRecordFile(localTempFile);
            //base.VssOperator.CheckIn(localTempFile, this.updateRecordFileVssPath, "");
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void GitUpdate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获得指定类型的需要提交的文件类别
        /// </summary>
        /// <param name="fileType"></param>
        /// <returns></returns>
        private IList<string> FileList(SysEnum.FileType fileType)
        {
            IList<string> files = new List<string>();
            //通过操作excel获得数据
            switch (fileType)
            {
                case SysEnum.FileType.SQL:
                    files = ExtractSqlFiles();
                    break;
                case SysEnum.FileType.Code:
                    files = ExtractCodeFiles();
                    break;
                default:
                    break;

            }
            return files;
        }

        /// <summary>
        /// 抽取SQL类型的数据文件列表
        /// </summary>
        /// <returns></returns>
        private IList<string> ExtractSqlFiles()
        {
            ExcelOperator excelOp = new ExcelOperator();
            excelOp.ReadFilePath = base.RecordLocalPath;
            DataTable dtb = excelOp.ReadSQL();
            IList<string> relativePath = new List<string>();
            string fullPath = null;
            string name = null;
            foreach (DataRow dr in dtb.Rows)
            {
                name = dr[ExcelOperator.SQL_FILENAME_COLUMN].ToString();
                if (string.IsNullOrEmpty(name))
                    continue;
                fullPath = this.SqlDocLocalFolder.TrimEnd(pathSplit) + @"\" + name;
                relativePath.Add(fullPath);
            }
            return relativePath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IList<string> ExtractCodeFiles()
        {
            ExcelOperator excelOp = new ExcelOperator();
            excelOp.ReadFilePath = base.RecordLocalPath;
            DataTable dtbJava = excelOp.ReadJava();
            DataTable dtbUi = excelOp.ReadUI();

            IList<string> relativePath = new List<string>();
            string fullPath = null;
            string path = null;
            string name = null;
            char[] pathSplit = @"\/".ToCharArray();
            if (dtbJava != null && dtbJava.Rows.Count > 0)
            {
                //获得java文件的完整路径
                foreach (DataRow dr in dtbJava.Rows)
                {
                    path = dr[ExcelOperator.JAVA_PATH_COLUMN].ToString();
                    name = dr[ExcelOperator.JAVA_FILENAME_COLUMN].ToString();
                    if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(name))
                        continue;
                    fullPath = path.Trim(pathSplit) + @"\" + name;
                    relativePath.Add(fullPath);
                }
            }
            if (dtbUi != null && dtbUi.Rows.Count > 0)
            {
                //获得UI文件的完整路径
                foreach (DataRow dr in dtbUi.Rows)
                {
                    path = dr[ExcelOperator.UI_PATH_COLUMN].ToString();
                    name = dr[ExcelOperator.UI_FILENAME_COLUMN].ToString();
                    if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(name))
                        continue;
                    fullPath = path.Trim(pathSplit) + @"\" + name;
                    relativePath.Add(fullPath);
                }
            }
            return relativePath;
        }

        /// <summary>
        /// 填写应用程序更新记录表
        /// </summary>
        /// <param name="fileName"></param>
        private void ModifyRecordFile(string fileName)
        {
            //TODO:程序修改应用更新记录表文件
            //从本地的修改列表文件读取内容
            //写入需要更新的文件末尾
            //excel文件的读写操作
        }






    } //end class
}//end namespace
