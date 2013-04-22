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
        private int id;
        private int no;
        private string name;
        private string description;
        private string dir;
        private string seq;

        public string Dir
        {
            get { return dir; }
            set { dir = value; }
        }

        private PhaseEnum phase;

        public PhaseEnum Phase
        {
            get { return phase; }
            set { phase = value; }
        }
        private ModuleEnum module;

        public ModuleEnum Module
        {
            get { return module; }
            set { module = value; }
        }
        private SysEnum sys;

        public SysEnum Sys
        {
            get { return sys; }
            set { sys = value; }
        }
        
        private ChannelEnum channel;

        public ChannelEnum Channel
        {
            get { return channel; }
            set { channel = value; }
        }
        private string state;
        private IList<TaskFile> files;

        /// <summary>
        /// 任务所拥有的文档类型列表
        /// </summary>
        public IList<TaskFile> Files
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
        }

        /// <summary>
        /// 任务序号，前缀+编号
        /// </summary>
        public string Seq
        {
            get 
            {
                return this.prefix + "-" + this.no.ToString();
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
        /// 主键编号
        /// </summary>
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
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
