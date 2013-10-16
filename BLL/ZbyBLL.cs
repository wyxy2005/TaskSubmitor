using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;
using HtmlAgilityPack;

namespace BLL
{
    /// <summary>
    /// 监视工行白银
    /// </summary>
    public class ZbyBLL
    {
        private string watchData;
        private string watchUrl;

        /// <summary>
        /// 监视数据源xpath
        /// </summary>
        private static string DATA_XPATH = @"//*[@id='cell1']";

        /// <summary>
        /// 构造子
        /// </summary>
        /// <param name="url">监视数据源url</param>
        public ZbyBLL(string url)
        {
            this.watchUrl = url;
        }

        /// <summary>
        /// 进行数据监视
        /// </summary>
        public void Watch()
        {
            WebUtil webUtil = new WebUtil(this.watchUrl);
            string response = webUtil.Browser("text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8",
                "text/html;charset=UTF-8", null);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(response);
            HtmlNode node = htmlDoc.DocumentNode.SelectSingleNode(DATA_XPATH);
            this.watchData = node.InnerHtml.Replace("\r\n", "").Replace(" ", "");
        }

        /// <summary>
        /// 监视的数据,外部程序直接显示
        /// </summary>
        public string WatchData
        {
            get { return this.watchData; }
        }
    }
}
