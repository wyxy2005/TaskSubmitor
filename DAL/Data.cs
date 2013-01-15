using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Xml;

namespace DAL
{
    public class Data
    {
        //private string dataFilePath = "data/data.xml";
        //private XmlDocument data = new XmlDocument();

        public const string ROOT = "Tasks";
        public const string TASK = "task";

        public static Task ToTask(XmlNode taskNode)
        {
            Task task = new Task();
            try
            {
                task.No = int.Parse(taskNode.Attributes["id"].Value);
                task.Description = taskNode.Attributes["name"].Value;
                task.Sys = (Model.Enum.SysEnum)int.Parse(taskNode.Attributes["sys"].Value);
                task.Phase = (Model.Enum.PhaseEnum)int.Parse(taskNode.Attributes["phase"].Value);
                task.Module = (Model.Enum.ModuleEnum)int.Parse(taskNode.Attributes["module"].Value);
                task.Channel = (Model.Enum.ChannelEnum)int.Parse(taskNode.Attributes["chanl"].Value);
                task.Dir = taskNode.SelectSingleNode("dir").InnerText;
                task.Name = taskNode.SelectSingleNode("content").InnerText;

            }
            catch (Exception ex)
            { 
            }
            return task;
        }

        public static XmlNode ToNode(Task task, XmlDocument xmlDoc)
        {
            XmlElement taskNode = xmlDoc.CreateElement(TASK);

            taskNode.SetAttribute("id", ((int)task.No).ToString());
            taskNode.SetAttribute("chanl", ((int)task.Channel).ToString());
            taskNode.SetAttribute("sys", ((int)task.Sys).ToString());
            taskNode.SetAttribute("phase", ((int)task.Phase).ToString());
            taskNode.SetAttribute("module", ((int)task.Module).ToString());
            taskNode.SetAttribute("name", task.Description);

            XmlElement name = xmlDoc.CreateElement("content");
            name.InnerText = task.Name;
            taskNode.AppendChild(name);

            XmlElement dir = xmlDoc.CreateElement("dir");
            dir.InnerText = task.Dir;
            taskNode.AppendChild(dir);

            XmlElement files = xmlDoc.CreateElement("files");
            foreach (TaskFile file in task.Files)
            {
                XmlElement xmlfile = xmlDoc.CreateElement("file");
                xmlfile.SetAttribute("type", file.Type.ToString());
                xmlfile.InnerText = file.Name;// "ABLREQUEST-1103-工行网银出单功能设计说明书20120918.doc";
                files.AppendChild(xmlfile);
            }
            taskNode.AppendChild(files);

            return taskNode;
        }


        public static void UpdateNode(Task task,ref XmlNode taskNode)
        {
            XmlElement xmlNode = (XmlElement)taskNode;
            xmlNode.SetAttribute("chanl", ((int)task.Channel).ToString());
            xmlNode.SetAttribute("sys", ((int)task.Sys).ToString());
            xmlNode.SetAttribute("phase", ((int)task.Phase).ToString());
            xmlNode.SetAttribute("module", ((int)task.Module).ToString());
            xmlNode.SetAttribute("name", task.Description);

            //xmlNode.GetElementsByTagName("content")[0].InnerText = task.Name;
            //xmlNode.GetElementsByTagName("dir")[0].InnerText = task.Dir;

            //XmlElement files = xmlDoc.CreateElement("files");
            //foreach (TaskFile file in task.Files)
            //{
            //    XmlElement xmlfile = xmlDoc.CreateElement("file");
            //    xmlfile.SetAttribute("type", file.Type.ToString());
            //    xmlfile.InnerText = file.Name;// "ABLREQUEST-1103-工行网银出单功能设计说明书20120918.doc";
            //    files.AppendChild(xmlfile);
            //}
            //taskNode.AppendChild(files);

            //return xmlNode;
        }
        
    }
}
