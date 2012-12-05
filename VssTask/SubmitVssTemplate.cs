using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VssTask
{
    /// <summary>
    /// 提交测试的模板
    /// 作者：ChengNing
    /// 日期：2012-12-03
    /// </summary>
    public abstract class SubmitVssTemplate:ISubmitVss
    {

        private string docLocalPath;
        private string docVssFolder;

        private string designDocLocalPath;       //设计文档的本地路径
        private string designDocVssFolder;       //设计文档的vss目录
        private string testDocLocalPath;         //测试文档的本地路径
        private string testDocVssFolder;         //测试文档的vss目录
        private string sqlDocLocalPath;          //数据SQL文档的本地路径


        private VssOperator vssOperator;


        public string DocLocalPath { get; set; }
        public string DocVssFolder { get; set; }
        public string DesignDocLocalPath { get; set; }
        public string TestDocLocalPath { get; set; }
        protected VssOperator VssOperator { get; set; }

        public SubmitVssTemplate() { }

        public SubmitVssTemplate(VssOperator vssOperator)
        {
            this.vssOperator = vssOperator;
        }

        /// <summary>
        /// 完成任务，提交修改的模板方法
        /// 1 上传自测报告，设计报告（研发文档）
        /// 2 上传sql文件等（$/B-更新目录/03-数据更新/01核心/年月/）
        /// 3 check in文件到vss(对应文件目录)
        /// 4 填写vss应用更新记录表（$/B-更新目录/01-应用更新/年月/年月日/11点，17点）
        /// 5 填写vss应用更新的更新记录表($/B-更新目录/01-应用更新/)
        /// 6 扭转jira状态(【更多操作】——【上传附件】，添加自测报告，【提交DAT发布】)
        /// 7 附加，update git，并且commit git，保持更新
        /// </summary>
        public void Submit()
        {
            //上传自测报告，设计报告（研发文档）
            AddDoc();
            ////上传sql文件等（$/B-更新目录/03-数据更新/01核心/年月/）
            //AddSqlFile();
            ////check in文件到vss(对应文件目录)
            //CheckIn();
            ////填写vss应用更新记录表（$/B-更新目录/01-应用更新/年月/年月日/11点，17点）
            //UpdateDayRecordFile();
            ////填写vss应用更新的更新记录表($/B-更新目录/01-应用更新/)
            //UpdateRecordFile();
        }

        protected abstract void AddDoc();

        //protected abstract void AddDesignDoc(string vssFolder, string localFilePath);

        protected abstract void AddSqlFile();

        protected abstract void CheckIn();

        protected abstract void UpdateDayRecordFile();

        protected abstract void UpdateRecordFile();

        protected abstract void GitUpdate();

        /// <summary>
        /// 判断是否存在文档目录
        /// </summary>
        /// <returns></returns>
        public bool ExistVssDocFolder()
        {
            return true;
        }

        public bool CreateVssFolder()
        {
            return true;
        }
    }
}
