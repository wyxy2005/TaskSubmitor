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
        private int no;
        private string name;
        private string description;
        private SysEnum sys;
        private string channel;
        private string state;

        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
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
    }
}
