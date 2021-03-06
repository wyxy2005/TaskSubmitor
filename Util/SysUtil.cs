﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using System.Xml;
using System.IO;

namespace Util
{
    /// <summary>
    /// 系统工具，针对系统级操作
    /// 
    /// 作者:ChengNing
    /// 日期：2012-12-14
    /// 
    /// </summary>
    public static class SysUtil
    {
        /// <summary>
        /// 打开目录
        /// </summary>
        /// <param name="path"></param>
        public static void OpenDir(string path)
        {
            System.Diagnostics.Process.Start("explorer.exe", path);
        }

        public static void OpenFile(string fileName)
        {
            System.Diagnostics.Process.Start(fileName);
        }

        /// <summary>
        /// 使用浏览器打开指定的链接
        /// </summary>
        /// <param name="url"></param>
        public static void BrowseURL(string url)
        {
            //默认浏览器
            Process browser = new Process();
            try
            {
                browser.StartInfo.Arguments = url;
                browser.Start();
                //Process.Start(url);//调用系统打开
            }
            catch (Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    Console.WriteLine("没有默认浏览器");
                //MessageBox.Show(noBrowser.Message); 
            }
            catch (Exception ex)
            {//使用IE打开
                Process ie = new Process();
                ie.StartInfo.FileName = "iexplore.exe";
                ie.StartInfo.Arguments = url;
                ie.Start();
                ie.Close();
            }
            finally
            {
                browser.Close();
            }
        }

        /// <summary>
        /// 创建系统数据文件
        /// </summary>
        public static void CreateDataFile()
        {
            XmlDocument xmldoc = new XmlDocument();
            //加入XML的声明段落,<?xml version="1.0" encoding="gb2312"?>
            XmlDeclaration xmldecl;
            xmldecl = xmldoc.CreateXmlDeclaration("1.0", "gb2312", null);
            xmldoc.AppendChild(xmldecl);

            //加入一个根元素
            XmlElement xmlelem = xmldoc.CreateElement("", "Tasks", "");
            xmldoc.AppendChild(xmlelem);
            Directory.CreateDirectory(@".\data");
            xmldoc.Save(@".\data\data.xml");
        }
    }
}
