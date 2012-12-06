using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VssTask
{
    /// <summary>
    /// 问题创建器,在新接收到一个任务之后，通过此类创建接收一个任务
    /// 自动根据jira号来创建相关开发模板，和任务工作区
    /// 创建一个工作区，里面创建如下文件：
    /// 1、设计文档模板（ABLREQUEST-1322-团险系统扫描级别-设计说明书20121112.doc）
    /// 2、自测报告模板（ABLREQUEST-1322-团险系统扫描级别-自测试报告20121112.doc）
    /// 3、修改列表（ABLREQUEST-1322-团险系统扫描级别-修改列表.xls）
    /// 作者：ChengNing
    /// 日期：2012-12-06
    /// </summary>
    public class TaskCreator
    {
        //需要输入，jira号，问题描述，核心/销售， 个险/团险，
    }
}
