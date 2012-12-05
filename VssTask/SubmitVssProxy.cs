using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VssTask
{
    /// <summary>
    /// SubmitVss的代理类，proxy模式处理提交操作，方便添加更多的控制和额外操作
    /// 实际的提交操作使用模板方法模式来定义固定的提交处理（SubmitVssTemplate实现）
    /// 
    /// 作者：程宁
    /// 日期：20125-12-04
    /// </summary>
    public class SubmitVssProxy:ISubmitVss
    {
        private SubmitVssTemplate submitor;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vssOperator"></param>
        public SubmitVssProxy(SubmitVssTemplate realSubmitor)
        {
            this.submitor = realSubmitor;
        }

        /// <summary>
        /// 代理提交方法
        /// 
        /// </summary>
        public void Submit()
        {
            //预处理
            PreSubmit();
            if (this.submitor == null)
                Console.WriteLine("SubmitVssProxy没有指定代理类");
            //带来转发
            submitor.Submit();

            //事后收尾
            AfterSubmit();
        }

        private void PreSubmit()
        { }

        private void AfterSubmit()
        { }

    }
}
