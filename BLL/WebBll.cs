using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

using HtmlAgilityPack;

using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Util;

namespace BLL
{
    public class WebBll
    {
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetGetCookie(string lpszUrlName, string lbszCookieName, StringBuilder lpszCookieData, ref int lpdwSize);
        
        private string url;

        public WebBll(string url)
        {
            this.url = url;
        }

        /// <summary>
        /// 得到指定页面的url
        /// </summary>
        /// <returns></returns>
        public string Browser()
        {
            WebUtil webUtil = new WebUtil(this.url);
            string[] cookiesName = {"seraph.os.cookie"};
            return webUtil.Browser("text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8",
                "text/html;charset=UTF-8", cookiesName);
        }

        /// <summary>
        /// 通过ajax调用监视接口，实现对任务的监视
        /// </summary>
        /// <param name="watchUrl">监视的ajax url</param>
        /// <param name="taskUID">监视的任务在jira系统中的统一编号，需要通过浏览任务然后从网页中得到</param>
        /// <returns></returns>
        public bool Watch(string watchUrl)
        {
            WebUtil webUtil = new WebUtil(watchUrl);
            string[] cookiesName = { "seraph.os.cookie", "JSESSIONID", "ASESSIONID" };
            webUtil.Ajax("application/json, text/javascript, */*",
                "application/json", cookiesName);
            return webUtil.Success();
        }
        /// <summary>
        /// 删除监视
        /// </summary>
        /// <param name="watchUrl"></param>
        /// <param name="taskUID"></param>
        /// <returns></returns>
        public bool UnWatch(string watchUrl)
        {
            WebUtil webUtil = new WebUtil(watchUrl);
            string[] cookiesName = { "seraph.os.cookie", "JSESSIONID", "ASESSIONID" };
            webUtil.Ajax("DELETE", "application/json, text/javascript, */*",
                "application/json", cookiesName);
            return webUtil.Success();
        }

        /// <summary>
        /// 获得input的value，取得任务的统一id
        /// </summary>
        /// <param name="html"></param>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public string HtmlInputValue(string html, string xpath)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            HtmlNode node = htmlDoc.DocumentNode.SelectSingleNode(xpath);
            return node.Attributes["value"].Value;
        
         }


    }
}
