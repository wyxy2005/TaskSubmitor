using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.IO;
using OfficeHelper;
using Model.Enum;
using DAL;
using log4net;
using System.Reflection;

namespace BLL
{
    /// <summary>
    /// 
    /// </summary>
    public class NewTaskBLL
    {
        private Task task;
        private string path;
        private string author;

        private ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="path"></param>
        public NewTaskBLL(Task task, string workspace, string author)
        {
            this.task = task;
            this.path = workspace;
            this.author = author;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            log.Info("开始创建任务");
            DirectoryInfo taskSpace = Directory.CreateDirectory(path);
            if (!taskSpace.Exists)
            {
                taskSpace.Create();
                log.Info("创建工作区目录");
            }
            //创建任务目录
            DirectoryInfo taskDir = taskSpace.CreateSubdirectory(this.task.Description);
            log.Info("创建任务目录");
            if (taskDir.Exists)
            {
                //创建任务目录
                //taskDir.Create();
                log.Info("创建任务文件");
                //创建任务文件
                CreateTemplate(taskDir);

                
                //写入数据文件
                TaskDAL taskDal = new TaskDAL();
                int  ire = taskDal.Insert(this.task);
                if (ire > 0)
                {
                    log.Info("写入数据文件成功");
                }
                else
                {
                    log.Info("写入数据文件失败");
                }

                return true;
            }
            return false;
        }

        private void CreateTaskSpace()
        {
        }

        /// <summary>
        /// 创建模板文件
        /// 
        /// </summary>
        private void CreateTemplate(DirectoryInfo taskDir)
        {
            //TODO：需要重构
            string templatePath = AppDomain.CurrentDomain.BaseDirectory + SysData.FileName.TEMPLATE_PATH + @"\";
            string destDirName = taskDir.FullName + @"\";
            string sourceFile = "";
            string destFile = "";
            try
            {
                foreach (TaskFile file in this.task.Files)
                {
                    //设计文档
                    if (file.Type == TaskFileEnum.Design)
                        CreateDesignFile(templatePath, destDirName);

                    //自测文档
                    if (file.Type == TaskFileEnum.Test)
                        CreateTestFile(templatePath, destDirName);

                    //修改列表
                    if (file.Type == TaskFileEnum.Xls)
                        CreateModifyFile(templatePath, destDirName);

                    //DEV-SQL
                    if (file.Type == TaskFileEnum.DevSql)
                    {
                        sourceFile = templatePath + SysData.FileName.DEV;
                        destFile = destDirName + @"DEV-SQL.sql";
                        File.Copy(sourceFile, destFile);
                        log.Info("DEV-SQL创建成功");
                    }
                }
            }
            catch (Exception ex)
            {
                log.Info("创建失败");
            }
            finally
            {
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templatePath"></param>
        /// <param name="destDirName"></param>
        private void CreateModifyFile(string templatePath, string destDirName)
        {

            string sourceFile = "";
            string destFile = "";
            sourceFile = templatePath + SysData.FileName.XLS;
            destFile = destDirName + this.task.Description + @"-修改列表.xls";
            File.Copy(sourceFile, destFile);
            log.Info("修改列表创建成功");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templatePath"></param>
        /// <param name="destDirName"></param>
        private void CreateTestFile(string templatePath, string destDirName)
        {
            string sourceFile = "";
            string destFile = "";
            sourceFile = templatePath + SysData.FileName.TEST;
            destFile = destDirName + this.task.Description + DateTime.Now.ToString(@"-自测报告yyyyMMdd") + ".doc";
            File.Copy(sourceFile, destFile);
            log.Info("自测文档创建成功");

            WordHelper wHelper = new WordHelper();
            Microsoft.Office.Interop.Word._Document oDoc = wHelper.Load(destFile);

            //获取模板中所有的书签 
            Microsoft.Office.Interop.Word.Bookmarks bookMarks = oDoc.Bookmarks;
            foreach (Microsoft.Office.Interop.Word.Bookmark bm in bookMarks)
            {
                bm.Select();
                switch (bm.Name)
                {
                    case "Date":
                        bm.Range.Text = DateTime.Now.ToString("yyyy-MM-dd");
                        break;
                    case "Name":
                    case "Name1":
                        bm.Range.Text = this.task.Name;
                        break;
                    case "TaskNo":
                    case "TaskNo1":
                    case "TaskNo2":
                        bm.Range.Text = this.task.No.ToString();
                        break;
                    case "Author":
                    case "Author1":
                        bm.Range.Text = this.author;
                        break;
                    default:
                        break;
                }
            }

            object filename = destFile;
            try
            {
                wHelper.Save(oDoc);
                wHelper.Close(oDoc);
            }
            catch (Exception ex)
            {
                wHelper.Close(oDoc);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templatePath"></param>
        /// <param name="destDirName"></param>
        private void CreateDesignFile(string templatePath, string destDirName)
        {
            string sourceFile = "";
            string destFile = "";
            sourceFile = templatePath + SysData.FileName.DESIGN;
            destFile = destDirName + this.task.Description + DateTime.Now.ToString(@"-设计说明书yyyyMMdd") + ".doc";
            File.Copy(sourceFile, destFile);
            log.Info("设计文档创建成功");

            WordHelper wHelper = new WordHelper();
            Microsoft.Office.Interop.Word._Document oDoc = wHelper.Load(destFile);

            //获取模板中所有的书签 
            Microsoft.Office.Interop.Word.Bookmarks bookMarks = oDoc.Bookmarks;
            foreach (Microsoft.Office.Interop.Word.Bookmark bm in bookMarks)
            {
                bm.Select();
                switch (bm.Name)
                {
                    case "Date":
                        bm.Range.Text = DateTime.Now.ToString("yyyy-MM-dd");
                        break;
                    case "Name":
                    case "Name1":
                        bm.Range.Text = this.task.Name;
                        break;
                    case "TaskNo":
                        bm.Range.Text = this.task.No.ToString();
                        break;
                    case "Author":
                        bm.Range.Text = this.author;
                        break;
                    default:
                        break;
                }
            }

            object filename = destFile;
            try
            {
                wHelper.Save(oDoc);
                wHelper.Close(oDoc);
            }
            catch (Exception ex)
            {
                wHelper.Close(oDoc);
            }
        }



    }
}
