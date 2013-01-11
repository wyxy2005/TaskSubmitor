using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Enum;

namespace Model
{
    /// <summary>
    /// 任务所属文件的属性
    /// </summary>
    public class TaskFile
    {
        private string name;
        private string fullName;
        private DateTime createDate;
        private TaskFileEnum type;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }

        public DateTime CreateDate
        {
            get { return this.createDate; }
            set { this.createDate = value; }
        }

        public TaskFileEnum Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
    }
}
