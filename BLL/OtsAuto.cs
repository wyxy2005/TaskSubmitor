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
using Newtonsoft.Json.Linq;
using System.Globalization;
using Model;

namespace BLL
{
    /// <summary>
    /// 2014-01-06
    /// </summary>
    public class OtsAuto
    {

        public static readonly string HOST = @"kyfw.12306.cn";
        //跟目录
        public static readonly string ROOT_URL = @"http://kyfw.12306.cn/";
        public static readonly string OTN_URL = @"http://kyfw.12306.cn/otn";
        public static readonly string OTN_URL_1 = @"http://kyfw.12306.cn/otn/";
        public static readonly string LOGIN_URI = @"http://kyfw.12306.cn/otn/login/loginAysnSuggest";
        public static readonly string LOGIN_RAND = @"https://kyfw.12306.cn/otn/passcodeNew/getPassCodeNew.do?module=login&rand=sjrand&";
        public static readonly string QUERY_URL = @"https://kyfw.12306.cn/otn/leftTicket/query?leftTicketDTO.train_date={0}&leftTicketDTO.from_station={1}&leftTicketDTO.to_station={2}&purpose_codes=ADULT";
        public static readonly string ORDER_RAND = @"https://kyfw.12306.cn/otn/passcodeNew/getPassCodeNew.do?module=passenger&rand=randp&";
        public static readonly string TOKEN_RUL = @"https://kyfw.12306.cn/otn/confirmPassenger/initDc";
        public static readonly string CHECK_ORDER_URL = @"https://kyfw.12306.cn/otn/confirmPassenger/checkOrderInfo";
        public static readonly string QUERY_COUNT_URL = @"https://kyfw.12306.cn/otn/confirmPassenger/getQueueCount";
        public static readonly string QUERY_ORDER_WAIT = @"https://kyfw.12306.cn/otn/confirmPassenger/queryOrderWaitTime?";
        public static readonly string ORDER_PAY_URL = @"https://kyfw.12306.cn/otn/payOrder/init?";
        public static readonly string ORDER_RESULT_URL = @"https://kyfw.12306.cn/otn/confirmPassenger/resultOrderForDcQueue";
        //public static readonly string PASSAGER_QUERY_URL = @"https://kyfw.12306.cn/otn/passengers/init";
        public static readonly string PASSAGER_QUERY_URL = @"https://kyfw.12306.cn/otn/confirmPassenger/getPassengerDTOs";
        public static readonly string STATION_URL = @"https://kyfw.12306.cn/otn/resources/js/framework/station_name.js";
        public static readonly string PASSER = @"";
        public static readonly string SUBMIT_TOKEN_STR = "globalRepeatSubmitToken";
        public static readonly string PASSAGER_STR = "var passengers";
        public static readonly string HOT_STATION = @"@bji|北京|BJP|0@sha|上海|SHH|1@tji|天津|TJP|2@cqi|重庆|CQW|3@csh|长沙|CSQ|4@cch|长春|CCT|5@cdu|成都|CDW|6@fzh|福州|FZS|7@gzh|广州|GZQ|8@gya|贵阳|GIW|9@hht|呼和浩特|HHC|10@heb|哈尔滨|HBB|11@hfe|合肥|HFH|12@hzh|杭州|HZH|13@hko|海口|VUQ|14@jna|济南|JNK|15@kmi|昆明|KMM|16@lsa|拉萨|LSO|17@lzh|兰州|LZJ|18@nni|南宁|NNZ|19@nji|南京|NJH|20@nch|南昌|NCG|21@sya|沈阳|SYT|22@sjz|石家庄|SJP|23@tyu|太原|TYV|24@wlq|乌鲁木齐|WMR|25@wha|武汉|WHN|26@xnx|西宁西|XXO|27@xan|西安|XAY|28@ych|银川|YIJ|29@zzh|郑州|ZZF|30@szh|深圳|SZQ|shenzhen|sz|31";

        public static readonly int SUBMIT_TOKEN_MAX_LENTH = 100;//token的上限
        public static readonly int FORE_DAYS = 19;//提前20天


        public static readonly string ACCEPT = @"image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, */*";
        public static readonly string USER_AGENT = @"Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; InfoPath.3; .NET4.0C; .NET4.0E)";
        private CookieContainer cookies = null;
        public static string[] cookiesName = { "BIGipServerportal", "BIGipServerotn", "JSESSIONID" };
        public static string[] tickets = { "",""};
        public static string[] passage = { "1,0,1,****,1,*****,*****,N" };
        public static string[] oldpassage = { "***,1,***********,1_" };
        public static string train_date = "Sat Jan 25 2014 00:00:00 GMT+0800 (中国标准时间)";
        public string submit_token = "";

        //页面输入缓存
        private Dictionary<string, string> cache = new Dictionary<string, string>();
        public Dictionary<string, string> Cache { get; set; }
        


        public static void Test(){

        }

        private string from;
        private string to;
        private string date;

        public string From { get; set; }
        public string To { get; set; }
        public string Date { get; set; }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <param name="rcode"></param>
        public bool Login(string username,string pwd,string rcode,out string msg) {
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
            msg = "登录成功";
            
            JObject jObj = JObject.Parse(html);
            if (jObj["data"]["loginCheck"].ToString() =="Y")
                return true;
            else
            {
                msg = jObj["messages"].ToString();
                return false;
            }

        }

        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public DateTime ServerTime()
        {

            HttpWebRequest request = CreateRequest(ROOT_URL);

           HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string time = response.Headers["Date"].ToString();
            //Sat, 11 Jan 2014 04:48:12 GMT
            DateTime serverTime = DateTime.ParseExact(time, "ddd, d MMM yyyy HH:mm:ss GMT", CultureInfo.InvariantCulture);
            return serverTime.ToLocalTime(); 
        }

        /// <summary>
        /// 获取所有车站信息
        /// </summary>
        /// <returns></returns>
        public List<Station> GetStation()
        {
            HttpWebRequest request = CreateRequest(STATION_URL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string html = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8")))
            {
                html = reader.ReadToEnd();
                reader.Close();
            }
            response.Close();
            string stationString = html.Split('\'')[1];

            return ParseStation(stationString);
        }

        /// <summary>
        /// 热门车站
        /// </summary>
        /// <returns></returns>
        public List<Station> GetHotStation()
        {
            return ParseStation(HOT_STATION);
        }

        /// <summary>
        /// 解析车站字符串
        /// </summary>
        /// <param name="stationString"></param>
        /// <returns></returns>
        private List<Station> ParseStation(string stationString)
        {
            List<Station> list = new List<Station>();
            string[] stArray = stationString.Split('@');
            foreach (string station in stArray)
            {
                if (string.IsNullOrEmpty(station))
                    continue;
                string[] s = station.Split('|');
                Station sObj;
                if(s.Length == 6)
                    sObj = new Station(s[0], s[1], s[2], s[3], s[4], s[5]);
                else
                    sObj = new Station(s[0], s[1], s[2], null, null, s[3]);
                list.Add(sObj);
            }
            return list;
        }

        /// <summary>
        /// 用户登录验证码
        /// </summary>
        /// <returns></returns>
        public Image GetRandImage() 
        {
            HttpWebResponse response = null;
            Random rand = new Random();
            HttpWebRequest request = CreateRequest(LOGIN_RAND + "&" + rand.NextDouble());
            request.Accept = "image/webp,*/*;q=0.8";

            response = (HttpWebResponse)request.GetResponse();
            return new Bitmap(response.GetResponseStream());
        }

        /// <summary>
        /// 订单提交验证码
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 获取用户乘车人
        /// </summary>
        /// <returns></returns>
        public List<Passager> GetPassager(out string msg)
        {
            HttpWebResponse response = null;
            HttpWebRequest request = CreateRequest(PASSAGER_QUERY_URL);
            request.Method = WebUtil.RequestMethod.GET;
            request.Accept = "*/*";
            request.ContentType = "";

            response = (HttpWebResponse)request.GetResponse();
            string html = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8")))
            {
                html = reader.ReadToEnd();
                reader.Close();
            }
            response.Close();
            //html.Substring(html.IndexOf(PASSAGER_STR));
            //html.
            return ParsePassager(html, out msg);
        }

        /// <summary>
        /// 解析乘客信息
        /// </summary>
        /// <param name="passagerJson"></param>
        /// <returns></returns>
        private List<Passager> ParsePassager(string json,out string msg)
        {
            msg = "";
            List<Passager> passagerList = new List<Passager>();
            JObject jobj = JObject.Parse(json);
            string pJson = jobj["data"]["normal_passengers"].ToString();
            if (string.IsNullOrEmpty(pJson))
            {
                msg = jobj["data"]["exMsg"].ToString();
                return null;
            }
            JArray pArray = JArray.Parse(jobj["data"]["normal_passengers"].ToString());
            foreach (JObject o in pArray)
            {
                Passager p = new Passager();
                p.Code = o["code"].ToString(); 
                p.Name = o["passenger_name"].ToString();
                p.SexCode = o["sex_code"].ToString();
                p.SexName = ExistGetValue(o, "sex_name");
                p.BornDate = o["born_date"].ToString();
                p.CountryCode = o["country_code"].ToString();
                p.IdType = o["passenger_id_type_code"].ToString();
                p.IdName = o["passenger_id_type_name"].ToString();
                p.IdNo = o["passenger_id_no"].ToString();
                p.Type = o["passenger_type"].ToString();
                p.Flag = o["passenger_flag"].ToString();
                p.TypeName = o["passenger_type_name"].ToString();
                p.Mobile = o["mobile_no"].ToString();
                p.Phone = o["phone_no"].ToString();
                p.Email = o["email"].ToString();
                p.Address = o["address"].ToString();
                p.PostalCode = o["postalcode"].ToString();

                passagerList.Add(p);
            }

            return passagerList;
        }

        private string ExistGetValue(JObject jobj, string key)
        {
            string value = string.Empty;
            if (jobj[key] != null)
                value = jobj[key].ToString();
            return value;
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


        public String Query(string date,string from,string to)
        {
            HttpWebResponse response = null;
            string url = string.Format(QUERY_URL, date, from, to);
            HttpWebRequest request = CreateRequest(url);
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

        /// <summary>
        /// 
        /// </summary>
        public void PreOrder()
        {
            //
            SetSubmitToken();
        }

        /// <summary>
        /// Template
        /// </summary>
        public string Order(string rcode)
        {
            //没有消息是最好的消息
            string msg = "";
            if (!CheckOrderInfo(rcode, out msg))
                return msg;

            GetQueueCount();

            QueryOrderWaitTime();

            PayOrder();

            ResultOrderForDcQueue();

            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetSubmitToken()
        {
            HttpWebResponse response = null;
            HttpWebRequest request = CreateRequest(TOKEN_RUL);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rcode"></param>
        public bool CheckOrderInfo(string rcode,out string msg)
        {
            HttpWebResponse response = null;
            HttpWebRequest request = CreateRequest(QUERY_URL);
            request.Method = WebUtil.RequestMethod.POST;
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

            //request.Connection = "Keep-Alive";
            //request.CookieContainer = new CookieContainer();
            //cookies = new CookieContainer();
            string dataString = @"cancel_flag=2&bed_level_order_num=000000000000000000000000000000&passengerTicketStr={0}&oldPassengerStr={1}&tour_flag={2}&randCode={3}&_json_att={4}&REPEAT_SUBMIT_TOKEN="+ this.submit_token;
            string.Format(dataString, passage[0], oldpassage[0], "dc", rcode, "");
            byte[] data = Encoding.UTF8.GetBytes(dataString);
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
            msg = "";
            JObject jobj = JObject.Parse(html);
            if (jobj["data"]["submitStatus"].ToString() == "true")
            {
                return true;
            }
            else
            {
                msg = jobj["messages"].ToString();
                return false;
            }
        }

        /// <summary>
        /// 进入排队队列
        /// </summary>
        public void GetQueueCount()
        {
            HttpWebResponse response = null;
            HttpWebRequest request = CreateRequest(QUERY_COUNT_URL);
            request.Method = WebUtil.RequestMethod.POST;
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            string[] dataName = { "train_date", "train_no", "stationTrainCode", "seatType", "fromStationTelecode", "toStationTelecode", "leftTicket", "purpose_codes", "_json_att", "REPEAT_SUBMIT_TOKEN" };

            string dataString = @"train_date={0}&train_no={1}&stationTrainCode={2}&seatType={3}&fromStationTelecode={4}&toStationTelecode={5}&_json_att={4}&REPEAT_SUBMIT_TOKEN=" + this.submit_token;
            string.Format(dataString);
            byte[] data = Encoding.UTF8.GetBytes(dataString);
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
        }

        /// <summary>
        /// 订单生成，返回订单号
        /// 4个参数
        /// 
        /// param:
        /// random=1389080385831&tourFlag=dc&_json_att=&REPEAT_SUBMIT_TOKEN=8e75c1cb041b14b29770ac59b46f34b4
        /// 
        /// result:
        /// {"validateMessagesShowId":"_validatorMessage","status":true,"httpstatus":200,"data":{"queryOrderWaitTimeStatus":true,"count":0,"waitTime":-1,"requestId":5826225423698547651,"waitCount":0,"tourFlag":"dc","orderId":"E304355504"},"messages":[],"validateMessages":{}}
        /// 
        /// </summary>
        public void QueryOrderWaitTime()
        {
            //random=1389080385831&tourFlag=dc&_json_att=&REPEAT_SUBMIT_TOKEN=8e75c1cb041b14b29770ac59b46f34b4
            HttpWebResponse response = null;
            HttpWebRequest request = CreateRequest(QUERY_ORDER_WAIT);
            request.Method = WebUtil.RequestMethod.GET;
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

            string dataString = @"random={0}&tourFlag={1}&_json_att={2}&REPEAT_SUBMIT_TOKEN={3}";
            string.Format(dataString,"","dc","","");
            byte[] data = Encoding.UTF8.GetBytes(dataString);
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
        }

        /// <summary>
        /// 订单支付
        /// 
        /// </summary>
        public void PayOrder()
        {     
            HttpWebResponse response = null;
            HttpWebRequest request = CreateRequest(ORDER_PAY_URL);
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.ContentType = "application/x-www-form-urlencoded";

            string dataString = @"random={0}&_json_att={1}&REPEAT_SUBMIT_TOKEN={2}";
            string.Format(dataString, "", "dc", "");
            byte[] data = Encoding.UTF8.GetBytes(dataString);
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
        }

        /// <summary>
        /// 订单结果
        /// param:
        /// orderSequence_no:E304355504
        /// _json_att:
        /// REPEAT_SUBMIT_TOKEN:8e75c1cb041b14b29770ac59b46f34b4
        /// 
        /// result:
        /// {"validateMessagesShowId":"_validatorMessage","status":true,"httpstatus":200,"data":{"submitStatus":true},"messages":[],"validateMessages":{}}
        /// 
        /// 表示成功
        /// "submitStatus":true
        /// else
        /// "messages":[]
        /// </summary>
        public void ResultOrderForDcQueue()
        {
            HttpWebResponse response = null;
            HttpWebRequest request = CreateRequest(ORDER_RESULT_URL);
            request.Method = WebUtil.RequestMethod.POST;
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

            string dataString = @"orderSequence_no={0}&_json_att={1}&REPEAT_SUBMIT_TOKEN={2}";
            string.Format(dataString, "", "dc", "");
            byte[] data = Encoding.UTF8.GetBytes(dataString);
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
        }



        /// <summary>
        /// 通过ie获取
        /// </summary>
        /// <param name="cookieString"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private Cookie GetCookie(string cookieString,string path)
        {
            string[] cookie = cookieString.Split('=');
            Cookie c = new Cookie(cookie[0], cookie[1], path, HOST);
            return c;
        }
        
        /// <summary>
        /// 公共方法
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
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
