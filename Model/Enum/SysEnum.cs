using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Enum
{
    /// <summary>
    /// 系统类型，核心，销售,官网等
    /// </summary>
    public enum SysEnum
    {
        /**/
        PGI = 1,
        WS = 2   /**/
    }

    /// <summary>
    /// 渠道，团险，个险
    /// </summary>
    public enum ChannelEnum
    { 
        /// <summary>
        /// 团
        /// </summary>
        G,
        /// <summary>
        /// 个
        /// </summary>
        P
    }

    /// <summary>
    /// 系统模块，新契约，保全，理赔
    /// </summary>
    public enum ModuleEnum
    { 
        /// <summary>
        /// 新契约
        /// </summary>
        CONT = 1,
        /// <summary>
        /// 保全
        /// </summary>
        EDOR = 2,
        /// <summary>
        /// 理赔
        /// </summary>
        CLM  = 3
    }

    public enum PhaseEnum
    {
        /// <summary>
        /// 需求
        /// </summary>
        ANA = 1,
        DEV = 2,
        DAT = 3,
        UAT = 4,
        /// <summary>
        /// 上线
        /// </summary>
        RUN = 5,
        /// <summary>
        /// 废弃，关闭，不在跟踪
        /// </summary>
        CLOSE = 9
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
