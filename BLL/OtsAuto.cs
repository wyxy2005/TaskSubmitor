using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO;
using System.Drawing;

namespace BLL
{
    /// <summary>
    /// 2014-01-06
    /// </summary>
    public class OtsAuto
    {
        public static readonly string FROM = "BJP";
        public static readonly string TO = "SJP";
        public static readonly string DATE = "2014-01-20";

        public static readonly string HOST = @"kyfw.12306.cn";
        public static readonly string ROOT_URL = @"http://kyfw.12306.cn/";
        public static readonly string OTN_URL = @"http://kyfw.12306.cn/otn";
        public static readonly string OTN_URL_1 = @"http://kyfw.12306.cn/otn/";
        public static readonly string LOGIN_URI = @"http://kyfw.12306.cn/otn/login/loginAysnSuggest";
        public static readonly string LOGIN_RAND = @"https://kyfw.12306.cn/otn/passcodeNew/getPassCodeNew.do?module=login&rand=sjrand&";
        public static readonly string QUERY_URL = @"https://kyfw.12306.cn/otn/leftTicket/query?leftTicketDTO.train_date="
            + DATE +@"&leftTicketDTO.from_station="
            + FROM +"&leftTicketDTO.to_station="
            + TO +"&purpose_codes=ADULT";
        public static readonly string ORDER_RAND = @"https://kyfw.12306.cn/otn/passcodeNew/getPassCodeNew.do?module=passenger&rand=randp&";
        public static readonly string PASSENGER_RUL = @"https://kyfw.12306.cn/otn/confirmPassenger/initDc";
        public static readonly string CHECK_ORDER_URL = @"https://kyfw.12306.cn/otn/confirmPassenger/checkOrderInfo";
        public static readonly string PASSER = @"";
        public static readonly string SUBMIT_TOKEN_STR = "globalRepeatSubmitToken";

        public static readonly int SUBMIT_TOKEN_MAX_LENTH = 100;//token的上限


        public static readonly string ACCEPT = @"image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, */*";
        public static readonly string USER_AGENT = @"Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; InfoPath.3; .NET4.0C; .NET4.0E)";
        private CookieContainer cookies = null;
        public static string[] cookiesName = { "BIGipServerportal", "BIGipServerotn", "JSESSIONID" };
        public static string[] tickets = { "",""};

        public string submit_token = "";

        


        public static void Test(){
            OtsAuto ots = new OtsAuto();
            ots.SetSession();
            ots.Login("truecn","pwd","zhw8");
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <param name="rcode"></param>
        public bool Login(string username,string pwd,string rcode) {
            //WebUtil web = new WebUtil(LOGIN_URI);
            //web.Ajax("*/*", "application/x-www-form-urlencoded; charset=UTF-8", cookiesName);
            HttpWebResponse response = null;
            HttpWebRequest request = CreateRequest(LOGIN_URI);
            request.Method = WebUtil.RequestMethod.POST;
            request.Accept = "*/*";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            byte[] data = Encoding.UTF8.GetBytes("loginUserDTO.user_name=" + username + "&userDTO.password=" + pwd + "&randCode=" + rcode);
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }  
            //request.Connection = "Keep-Alive";
            //request.CookieContainer = new CookieContainer();
            //cookies = new CookieContainer();
            response = (HttpWebResponse)request.GetResponse();
            string html = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8")))
            {
                html = reader.ReadToEnd();
            }
            if (html.Contains("Y"))
                return true;
            else
                return false;

        }

        public Image GetRandImage() 
        {
            Image img = null;
            HttpWebResponse response = null;
            Random rand = new Random();
            HttpWebRequest request = CreateRequest(LOGIN_RAND + "&" + rand.NextDouble());
            request.Accept = "image/webp,*/*;q=0.8";

            response = (HttpWebResponse)request.GetResponse();
            return new Bitmap(response.GetResponseStream());
        }

        public Image GetOrderRandImage()
        {
            Image img = null;
            HttpWebResponse response = null;
            Random rand = new Random();
            HttpWebRequest request = CreateRequest(ORDER_RAND + "&" + rand.NextDouble());
            request.Accept = "image/webp,*/*;q=0.8";

            response = (HttpWebResponse)request.GetResponse();
            return new Bitmap(response.GetResponseStream());
        }

        public void SetSession()
        {
            //WebUtil webUtil = new WebUtil(ROOT_URL);
            cookies = new CookieContainer();
            WebUtil web = new WebUtil(ROOT_URL);

            cookies.Add(web.GetCookie(HOST, "BIGipServerotn"));
            cookies.Add(web.GetCookie(HOST, "BIGipServerportal"));
            cookies.Add(web.GetCookie(HOST, "JSESSIONID"));
            //HttpWebResponse response = null;

            //HttpWebRequest request = CreateRequest(ROOT_URL);
            ////request.Connection = "Keep-Alive";
            ////request.CookieContainer = new CookieContainer();
            ////cookies = new CookieContainer();
            //response = (HttpWebResponse)request.GetResponse();

            ////BIGipServerportal
            //string cookieString = response.Headers["Set-Cookie"].Split(';')[0];
            //cookies.Add(GetCookie(cookieString,"/"));

            ////BIGipServerotn
            ////request = CreateRequest(OTN_URL);
            //////request = (HttpWebRequest)WebRequest.Create(OTN_URL);
            ////request.CookieContainer = cookies;
            ////response = (HttpWebResponse)request.GetResponse();
            ////cookieString = response.Headers["Set-Cookie"].Split(';')[0];
            ////cookies.Add(GetCookie(cookieString, "/"));

            ////JSESSIONID
            //request = CreateRequest(OTN_URL_1);
            //request.CookieContainer = cookies;
            //response = (HttpWebResponse)request.GetResponse();
            //cookieString = response.Headers["Set-Cookie"].Split(';')[0];
            //cookies.Add(GetCookie(cookieString, "/otn"));
        }

        public String Query()
        {
            HttpWebResponse response = null;
            HttpWebRequest request = CreateRequest(QUERY_URL);
            request.Method = WebUtil.RequestMethod.GET;
            request.Accept = "*/*";
            request.ContentType = "application/json;charset=UTF-8";

            response = (HttpWebResponse)request.GetResponse();
            string html = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8")))
            {
                html = reader.ReadToEnd();
                reader.Close();
            }
            response.Close();
            return html;
        }

        public void Order()
        { 
        }

        public void SetSubmitToken()
        {
            HttpWebResponse response = null;
            HttpWebRequest request = CreateRequest(LOGIN_URI);
            request.Method = WebUtil.RequestMethod.POST;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.ContentType = "application/x-www-form-urlencoded";
            //request.Connection = "Keep-Alive";
            //request.CookieContainer = new CookieContainer();
            //cookies = new CookieContainer();
            response = (HttpWebResponse)request.GetResponse();
            string html = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8")))
            {
                html = reader.ReadToEnd();
            }
            int i = html.IndexOf(SUBMIT_TOKEN_STR, 0);
            //获取token
            string token = html.Substring(i, SUBMIT_TOKEN_STR.Length + SUBMIT_TOKEN_MAX_LENTH).Split('\'')[1].ToString();
            this.submit_token = token;

        }

        public void CheckOrderInfo()
        {
            HttpWebResponse response = null;
            HttpWebRequest request = CreateRequest(QUERY_URL);
            request.Method = WebUtil.RequestMethod.POST;
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

            //request.Connection = "Keep-Alive";
            //request.CookieContainer = new CookieContainer();
            //cookies = new CookieContainer();
            byte[] data = Encoding.UTF8.GetBytes("cancel_flag=2&bed_level_order_num=000000000000000000000000000000&passengerTicketStr=&oldPassengerStr=&tour_flag&randCode=" + rcode + "_json_att=&REPEAT_SUBMIT_TOKEN="+ this.submit_token);
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }  

            response = (HttpWebResponse)request.GetResponse();
            string html = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8")))
            {
                html = reader.ReadToEnd();
                reader.Close();
            }
            response.Close();
            //return html;
        }

        private Cookie GetCookie(string cookieString,string path)
        {
            string[] cookie = cookieString.Split('=');
            Cookie c = new Cookie(cookie[0], cookie[1], path, HOST);
            return c;
        }
        private HttpWebRequest CreateRequest(string url){
            ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
            HttpWebRequest request = null;
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = WebUtil.RequestMethod.GET;
            request.Accept = ACCEPT;
            request.UserAgent = USER_AGENT;
            request.Host = HOST;
            request.CookieContainer = this.cookies;
            return request;
        }

        private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
