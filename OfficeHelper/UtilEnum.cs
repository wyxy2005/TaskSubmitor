using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeHelper
{
    #region Common Excel Enum Properties
    /// <summary>
    /// HTML，CSV，TEXT，EXCEL，XML
    /// </summary>
    enum SaveAsFileFormat
    {
        HTML,
        CSV,
        TEXT, 
        EXCEL,
        XML
    }
    /// <summary>
    /// 常用颜色定义,对就Excel中颜色名
    /// </summary>
    public enum ColorIndex
    {
        无色 = -4142,
        自动 = -4105,
        黑色 = 1,
        褐色 = 53,
        橄榄 = 52,
        深绿 = 51,
        深青 = 49,
        深蓝 = 11,
        靛蓝 = 55,
        灰色80 = 56,
        深红 = 9,
        橙色 = 46, 
        深黄 = 12,
        绿色 = 10,
        青色 = 14,
        蓝色 = 5,
        蓝灰 = 47,
        灰色50 = 16,
        红色 = 3,
        浅橙色 = 45,
        酸橙色 = 43,
        海绿 = 50,
        水绿色 = 42,
        浅蓝 = 41,
        紫罗兰 = 13,
        灰色40 = 48,
        粉红 = 7,
        金色 = 44,
        黄色 = 6,
        鲜绿 = 4, 
        青绿 = 8,
        天蓝 = 33,
        梅红 = 54,
        灰色25 = 15,
        玫瑰红 = 38,
        茶色 = 40,
        浅黄 = 36,
        浅绿 = 35,
        浅青绿 = 34,
        淡蓝 = 37,
        淡紫 = 39,
        白色 = 2
    }
    /// <summary>
    /// 水平对齐方式
    /// </summary>
    public enum ExcelHAlign
    {
        常规 = 1,
        靠左, 
        居中,
        靠右,
        填充,
        两端对齐,
        跨列居中,
        分散对齐
    }

    /// <summary>
    /// 垂直对齐方式
    /// </summary>
    public enum ExcelVAlign
    {
        靠上 = 1,
        居中,
        靠下,
        两端对齐,
        分散对齐
    }

    /// <summary>
    /// 线粗
    /// </summary>
    public enum BorderWeight 
    {
        极细 = 1,
        细 = 2,
        粗 = -4138,
        极粗 = 4
    }

    /// <summary>
    /// 线样式
    /// </summary>
    public enum LineStyle
    {
        连续直线 = 1,
        短线 = -4115,
        线点相间 = 4,
        短线间两点 = 5,
        点 = -4118,
        双线 = -4119,
        无 = -4142,
        少量倾斜点 = 13
    }

    /// <summary> 
    /// 下划线方式
    /// </summary>
    public enum UnderlineStyle
    {
        无下划线 = -4142,
        双线 = -4119,
        双线充满全格 = 5,
        单线 = 2,
        单线充满全格 = 4
    }

    /// <summary>
    /// 单元格填充方式
    /// </summary>
    public enum Pattern
    {
        Automatic = -4105,
        Checker = 9,
        CrissCross = 16,
        Down = -4121,
        Gray16 = 17, //软件开发网 
        Gray25 = -4124,
        Gray50 = -4125,
        Gray75 = -4126,
        Gray8 = 18,
        Grid = 15,
        Horizontal = -4128,
        LightDown = 13,
        LightHorizontal = 11,
        LightUp = 14,
        LightVertical = 12,
        None = -4142,
        SemiGray75 = 10,
        Solid = 1,
        Up = -4162,
        Vertical = -4166
    }
    #endregion
}
