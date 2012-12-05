using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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



        private string localCodeRoot;
        private string vssCodeRoot;
        //
        private string checkInComment;
        //更新记录表的vss路径
        private string updateRecordFileVssPath;
        //当天的更新记录表的vss路径
        private string updateRecordFileDayVssPath;

        //后期引入log4net记录日志
        //private LogManager logger;

        public SubmitVssConcrete(VssOperator vssOperator)
            : base(vssOperator)
        { }
       
        /// <summary>
        /// 上传自测报告，设计报告（研发文档）
        /// 模板方法中实际执行的具体方法
        /// </summary>
        protected override void AddDoc()
        {
            //$/LIS－CM－AB/05-项目任务/B-契约模块
            //vssFolder = @"$/LIS－CM－AB/05-项目任务/B-契约模块";
            if (VssOperator == null)
                return;
            if (!base.VssOperator.ExistFolder(base.DocVssFolder))
                base.VssOperator.NewProject(base.DocVssFolder, "");
            //设计文档
            base.VssOperator.AddFile(base.DocVssFolder, base.DesignDocLocalPath);
            //自测文档
            base.VssOperator.AddFile(base.DocVssFolder, base.TestDocLocalPath);
        }

        /// <summary>
        /// 上传SQL数据文档
        /// 如果不存在，则不用上传
        /// 如果存在多个，则都需要上传
        /// </summary>
        protected void AddSqlFile(string vssSQLFolder)
        {
            //从修改列表中读取一个文件列表，然后上传
            IList<string> sqlFiles = FileList(SysEnum.FileType.SQL);
            foreach (string file in sqlFiles)
            {
                //上传SQL文档
                base.VssOperator.AddFile(vssSQLFolder, file);
            }
        }

        /// <summary>
        /// check in 代码文件
        /// </summary>
        protected void CheckIn(string vssCodePath)
        {
            //从修改列表中读取一个文件列表，然后checkin
            IList<string> sqlFiles = FileList(SysEnum.FileType.Code);
            foreach (string file in sqlFiles)
            {

                base.VssOperator.CheckIn(this.localCodeRoot + file,
                    this.vssCodeRoot + file, this.checkInComment);
            }
        }

        /// <summary>
        /// 应用程序更新记录表,日表，每天的记录,11点，17点
        /// </summary>
        protected override void UpdateDayRecordFile()
        {
            //需要考虑如果已经被checkout的时候，如何处理
            string localTempFile = @"../temp/update" + DateTime.Today.ToLongTimeString() + ".xls";
            //使用vss get checkout，然后修改xls文件，然后check in
            base.VssOperator.CheckOut(this.updateRecordFileDayVssPath, localTempFile, "");
            ModifyRecordFile(localTempFile);
            base.VssOperator.CheckIn(localTempFile, this.updateRecordFileDayVssPath, "");
        }

        /// <summary>
        /// 应用程序更新记录表,总表
        /// </summary>
        protected override void UpdateRecordFile()
        {
            //需要考虑如果已经被checkout的时候，如何处理
            string localTempFile = @"../temp/update" + DateTime.Today.ToLongTimeString() + ".xls";
            //使用vss get checkout，然后修改xls文件，然后check in
            base.VssOperator.CheckOut(this.updateRecordFileVssPath, localTempFile, "");
            ModifyRecordFile(localTempFile);
            base.VssOperator.CheckIn(localTempFile, this.updateRecordFileVssPath, "");
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void GitUpdate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileType"></param>
        /// <returns></returns>
        private IList<string> FileList(SysEnum.FileType fileType)
        {
            IList<string> files = new List<string>();
            //通过操作excel获得数据
            //......
            return files;
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

        protected override void AddSqlFile()
        {
            throw new NotImplementedException();
        }

        protected override void CheckIn()
        {
            throw new NotImplementedException();
        }






    } //end class
}//end namespace
