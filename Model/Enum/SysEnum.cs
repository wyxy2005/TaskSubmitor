using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Enum
{
    /// <summary>
    /// 系统类型，核心，销售等
    /// </summary>
    public enum SysEnum
    {
        PGI
    }

    /// <summary>
    /// 渠道，团险，个险
    /// </summary>
    public enum ChannelEnum
    { 
        G,
        P
    }

    /// <summary>
    /// 系统模块，新契约，保全，理赔
    /// </summary>
    public enum ModuleEnum
    { 
    }

    public enum PhaseEnum
    {
        /// <summary>
        /// 需求
        /// </summary>
        ANA,
        DEV,
        DAT,
        UAT,
        /// <summary>
        /// 上线
        /// </summary>
        ON
    }

    /// <summary>
    /// 应用更新表对应的sheet
    /// </summary>
    public enum RecordSheetEnum
    {
        UI=1,
        JAVA=2,
        SQL=3
    }
}
