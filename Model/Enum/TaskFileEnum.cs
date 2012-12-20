using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Enum
{
    /// <summary>
    /// 一个任务所需要的文件种类
    /// </summary>
    public enum TaskFileEnum
    {
        /// <summary>
        /// /*设计文档*/
        /// </summary>
        Design,  
        /// <summary>
        /// /*自测报告*/
        /// </summary>
        Test,       
        /// <summary>
        /// /*更新列表*/
        /// </summary>
        Xls,        
        /// <summary>
        /// /*开发SQL*/
        /// </summary>
        DevSql,
        /// <summary>
        /// /*修改的DML，用于提交*/
        /// </summary>
        DML,   
        /// <summary>
        /// /*修改的DDL，用于提交*/
        /// </summary>
        DDL,            
        /// <summary>
        /// /*修改的PDM，用于提交*/
        /// </summary>
        PDM         
    }
}
