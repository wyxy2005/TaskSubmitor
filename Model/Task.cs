using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Enum;

namespace Model
{
    /// <summary>
    /// 任务属性
    /// </summary>
    public class Task
    {
        private string prefix;
        private int no;
        private string name;
        private string description;
        private SysEnum sys;
        private string channel;
        private string state;
        private IList<TaskFileEnum> files;

        /// <summary>
        /// 任务所拥有的文档类型列表
        /// </summary>
        public IList<TaskFileEnum> Files
        {
            get { return files; }
            set { files = value; }
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get
            {
                if (string.IsNullOrEmpty(this.description))
                    return this.prefix + "-" + this.no + "-" + this.name;
                else
                    return description;
            }
            set
            {
                description = value;
            }
        }
        /// <summary>
        /// 需求名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 需求编号
        /// </summary>
        public int No
        {
            get { return no; }
            set { no = value; }
        }

        /// <summary>
        /// 任务编号前缀
        /// </summary>
        public string Prefix
        {
            get { return this.prefix; }
            set { this.prefix = value; }
        }
    }
}
