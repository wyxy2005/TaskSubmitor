using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 系统数据
    /// </summary>
    public class SysData
    {
        /// <summary>
        /// 系统模板文件名称
        /// </summary>
        public struct FileName
        {
            public static readonly string TEMPLATE_PATH = "Template";
            public static readonly string DESIGN = "DESIGN";
            public static readonly string TEST = "TEST";
            public static readonly string XLS = "XLS";
            public static readonly string DEV = "DEV";
            public static readonly string DML = "DML";
            public static readonly string DDL = "DDL";
            public static readonly string PDM = "PDM";
        }
    }
}
