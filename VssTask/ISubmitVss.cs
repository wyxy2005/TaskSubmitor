using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VssTask
{
    /// <summary>
    /// vss提交器接口，操作
    /// 作为Proxy设计模式中的subject
    /// 
    /// 作者：程宁
    /// 日期：2012-12-04
    /// </summary>
    public interface ISubmitVss
    {
        void Submit();
    }
}
