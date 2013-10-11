using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIForm
{
    /// <summary>
    /// 得到系统模板变量
    /// @author: chengn@github.com
    /// </summary>
    public class Template
    {
        public static string JiraWatchUrl(string value)
        {
            return sys.Default.JiraWatchUrl.Replace("#taskUID#", value);
        }
    }
}
