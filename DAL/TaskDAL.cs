using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Xml;
using System.Data;

namespace DAL
{
    public class TaskDAL
    {

        //需要重构，此处出现多出定义同样数据的代码坏味
        private string dataFilePath = "data/data.xml";
        private XmlDocument data = new XmlDocument();

        private const string ROOT = "Tasks";
        private const string TASK = "task";
        private const string CNT = "count";
        public TaskDAL()
        {
            data.Load(dataFilePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskNo"></param>
        /// <returns></returns>
        public Task GetTask(int taskNo)
        {
            string xpath = "/Tasks/task[@no='" + taskNo + "']";
            XmlNode taskNode = data.SelectSingleNode(xpath);
            Task task = Data.ToTask(taskNode);
            return task;
        }

        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetTaskTable()
        { 
            DataTable dtb = new DataTable("task");
            DataColumn dc = new DataColumn("no",Type.GetType("System.Int32"));
            DataColumn dc1 = new DataColumn("descrb",Type.GetType("System.String"));
            dtb.Columns.Add(dc);
            dtb.Columns.Add(dc1);

            XmlNodeList tasklist = data.SelectNodes("/Tasks/task");
            foreach (XmlNode task in tasklist)
            {
                DataRow dr = dtb.NewRow();
                dr[0] = task.Attributes["no"].Value;
                dr[1] = task.Attributes["name"].Value;
                dtb.Rows.Add(dr);
            }
            return dtb;
        }

        public IList<Task> GetTaskList()
        {
            IList<Task> taskList = new List<Task>();
            XmlNodeList taskNodelist = data.SelectNodes("/Tasks/task");
            foreach (XmlNode taskXml in taskNodelist)
            {
                Task task = Data.ToTask(taskXml);
                taskList.Add(task);
            }
            return taskList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public int Insert(Task task)
        {
            XmlNode root = data.SelectSingleNode(ROOT);
            task.Id = NextId();
            XmlNode taskNode = Data.ToNode(task, data);
            root.AppendChild(taskNode);
            data.Save(dataFilePath);
            return 0;
        }

        private int NextId()
        {
            XmlNode root = data.SelectSingleNode(ROOT);
            int count = 0;
            string cnt = root.Attributes[CNT].Value;
            if (string.IsNullOrEmpty(cnt))
            {
                count = root.ChildNodes.Count + 1;
            }
            else
                count = int.Parse(cnt) + 1;

            root.Attributes[CNT].Value = count.ToString();

            return count;
        }

        private void SetNextId()
        { 
        }

        public int Update(Task task)
        {
            if (task == null)
                return 0;
            try
            {
                string xpath = "/Tasks/task[@no='" + task.No + "']";
                XmlNode root = data.SelectSingleNode(ROOT);
                XmlNode taskEle = root.SelectSingleNode(xpath);
                Data.UpdateNode(task, ref taskEle);
                data.Save(dataFilePath);
                return 1;
            }
            catch (Exception ex) { 
                //日志显示

            }
            return 0;
        }

        public int Delete(int taskNo)
        {
            return 0;
        }
    }
}
