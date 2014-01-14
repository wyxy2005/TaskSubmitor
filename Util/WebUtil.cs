using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;

namespace Util
{
    /// <summary>
    /// web操作工具
    /// @author:chengn@github.com
    /// </summary>
    public class WebUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpszUrlName"></param>
        /// <param name="lbszCookieName"></param>
        /// <param name="lpszCookieData"></param>
        /// <param name="lpdwSize"></param>
        /// <returns></returns>
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetGetCookie(string lpszUrlName, string lbszCookieName, StringBuilder lpszCookieData, ref int lpdwSize);


        private string url;
        private HttpWebRequest request;
        private HttpWebResponse response;

        /// <summary>
        /// 
        /// </summary>
        public HttpWebResponse Response
        {
            get { return this.response; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public WebUtil(string url)
        {
            this.url = url;
        }

        /// <summary>
        /// 请求url
        /// </summary>
        /// <param name="method"></param>
        /// <param name="accept"></param>
        /// <param name="contentType"></param>
        /// <param name="cookiesName"></param>
        /// <returns></returns>
        public void Request(string method, string accept, string contentType, string[] cookiesName)
        {
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.Accept = accept;
            request.ContentType = contentType;
            request.CookieContainer = new CookieContainer();
            if (cookiesName != null && cookiesName.Length > 0)
            {
                //从浏览器中取得Cookie
                foreach (string cookieName in cookiesName)
                {
                    Cookie cookie = GetCookie(request.Host, cookieName);
                    request.CookieContainer.Add(cookie);
                }
            }
            try
            {
                this.response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex){ 
            }
        }

        /// <summary>
        /// 浏览网页内容，默认使用get方法
        /// </summary>
        /// <returns></returns>
        public string Browser(string accept, string contentType, string[] cookiesName)
        {
            return Get(accept, contentType, cookiesName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="accept"></param>
        /// <param name="contentType"></param>
        /// <param name="cookiesName"></param>
        /// <returns></returns>
        public string Browser(string method, string accept, string contentType, string[] cookiesName)
        {
            string html = "";
            Request(method, accept, contentType, cookiesName);
            using (StreamReader reader = new StreamReader(this.response.GetResponseStream(), Encoding.GetEncoding("UTF-8")))
            {
                html = reader.ReadToEnd();
            }
            return html;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Post(string accept, string contentType, string[] cookiesName)
        {
            return Browser(RequestMethod.POST, accept, contentType, cookiesName);
        }

        /// <summary>
        /// 使用get方法请求网页
        /// </summary>
        /// <returns></returns>
        public string Get(string accept, string contentType, string[] cookiesName)
        {
            return Browser(RequestMethod.GET, accept, contentType, cookiesName);
        }
        /// <summary>
        /// ajax访问，默认ajax访问为post，如果需要访问操作之后的数据，则使用response即可
        /// </summary>
        /// <param name="accept"></param>
        /// <param name="contentType"></param>
        /// <param name="cookiesName"></param>
        public void Ajax(string accept, string contentType, string[] cookiesName)
        {
            Ajax(RequestMethod.POST, accept, contentType, cookiesName);
        }
        /// <summary>
        /// ajax 访问
        /// </summary>
        /// <param name="method"></param>
        /// <param name="accept"></param>
        /// <param name="contentType"></param>
        /// <param name="cookiesName"></param>
        public void Ajax(string method, string accept, string contentType, string[] cookiesName)
        {
            Request(method, accept, contentType, cookiesName);
        }

        /// <summary>
        /// 访问是否成功
        /// </summary>
        /// <returns></returns>
        public bool Success()
        {
            if (this.response != null && this.response.StatusCode == HttpStatusCode.OK)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 得到cookie的值
        /// </summary>
        /// <param name="domain">保存cookie的域</param>
        /// <param name="cookieName">cookie name</param>
        /// <returns>cookie value</returns>
        public string GetCookieValue(string domain, string cookieName)
        {
            Cookie cookie = GetCookie(domain, cookieName);
            return cookie.Value;
        }

        /// <summary>
        /// 得到cookie的值
        /// </summary>
        /// <param name="domain">保存cookie的域</param>
        /// <param name="cookieName">cookie name</param>
        /// <returns>Cookie对象</returns>
        public Cookie GetCookie(string domain, string cookieName)
        {
            string url = this.url;
            Cookie cookie = new Cookie(cookieName, "", "/", domain);
            int size = 1000;
            StringBuilder cookieString = new StringBuilder(size);
            if (InternetGetCookie(url, cookieName, cookieString, ref size))
            {
                cookie.Value = cookieString.ToString().Split('=')[1];
            }
            return cookie;
        }


        /// <summary>
        /// http request method
        /// </summary>
        public struct RequestMethod
        {
            public static readonly string POST = "POST";
            public static readonly string GET = "GET";
            public static readonly string DELETE = "DELETE";
            public static readonly string PUT = "PUT";
            public static readonly string HEAD = "HEAD";
            public static readonly string TRACE = "TRACE";
        }
    }
}
