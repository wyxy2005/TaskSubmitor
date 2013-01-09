﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using Model;
using System.Drawing;

namespace BLL
{
    /// <summary>
    /// 任务相关的业务操作
    /// 
    /// 作者：程宁
    /// 日期：2013-01-06
    /// </summary>
    public class TaskBLL
    {
        /// <summary>
        /// 根据任务编号获得任务
        /// </summary>
        /// <param name="taskNo"></param>
        /// <returns></returns>
        public Task GetTask(int taskNo)
        {
            TaskDAL dal = new TaskDAL();
            return dal.GetTask(taskNo);
        }

        /// <summary>
        /// 所有任务的一个列表
        /// eg
        /// ABREQUEST-1111-说明说明
        /// </summary>
        /// <returns></returns>
        public IList<string> TaskList()
        {
            IList<string> tasks = new List<string>();
            TaskDAL dal = new TaskDAL();
            DataTable dtb = dal.GetTaskTable();
            foreach (DataRow dr in dtb.Rows)
            {
                tasks.Add(dr[1].ToString());
            }
            return tasks;
        }

        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <returns></returns>
        public IList<Task> GetTaskList()
        {
            TaskDAL dal = new TaskDAL();
            return dal.GetTaskList();

        }

        /// <summary>
        /// 定义任务的颜色显示
        /// </summary>
        /// <param name="taskid"></param>
        /// <returns></returns>
        public static Color GetTaskColor(Task task)
        {
            Color color = Color.Black;//默认颜色
            if (task == null || task.Phase == null)
                return color;
            switch (task.Phase)
            {
                case Model.Enum.PhaseEnum.RUN://上线绿色显示
                    {
                        color = Color.Green;
                        break;
                    }
                case Model.Enum.PhaseEnum.DEV://开发中的红色显示
                    {
                        color = Color.Red;
                        break;
                    }
                default:
                    {
                        break;
                    }

            }
            return color;
        }

        /// <summary>
        /// 更新Task对象到数据
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public int Update(Task task)
        {
            if (task == null)
                return 0;
            TaskDAL dal = new TaskDAL();
            int ire = dal.Update(task);
            return ire;
        }
    }
}