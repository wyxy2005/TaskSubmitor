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
        public static readonly string AUTO_ORDER_URL = @"https://kyfw.12306.cn/otn/confirmPassenger/autoSubmitOrderRequest";
        public static readonly string QUERY_COUNT_URL = @"https://kyfw.12306.cn/otn/confirmPassenger/getQueueCount";
        public static readonly string QUERY_COUNT_ASYNC_URL = @"https://kyfw.12306.cn/otn/confirmPassenger/getQueueCountAsync";
        public static readonly string CONFIRM_SINGLE_FOR_QUEUE_ASYNC_URL = @"https://kyfw.12306.cn/otn/confirmPassenger/confirmSingleForQueueAsys";
        public static readonly string QUERY_ORDER_WAIT = @"https://kyfw.12306.cn/otn/confirmPassenger/queryOrderWaitTime?";
        public static readonly string ORDER_PAY_URL = @"https://kyfw.12306.cn/otn/payOrder/init?";
        public static readonly string ORDER_RESULT_URL = @"https://kyfw.12306.cn/otn/confirmPassenger/resultOrderForDcQueue";
        //public static readonly string PASSAGER_QUERY_URL = @"https://kyfw.12306.cn/otn/passengers/init";
        public static readonly string PASSAGER_QUERY_URL = @"https://kyfw.12306.cn/otn/confirmPassenger/getPassengerDTOs";
        public static readonly string STATION_URL = @"https://kyfw.12306.cn/otn/resources/js/framework/station_name.js";
        public static readonly string PASSER = @"";
        public static readonly string SUBMIT_TOKEN_STR = "globalRepeatSubmitToken";
        public static readonly string LEFT_TICKETS = "leftTicketStr";
        public static readonly string PASSAGER_STR = "var passengers";
        public static readonly string TOUR_FLAG = "dc";
        public static readonly string HOT_STATION = @"@bji|北京|BJP|0@sha|上海|SHH|1@tji|天津|TJP|2@cqi|重庆|CQW|3@csh|长沙|CSQ|4@cch|长春|CCT|5@cdu|成都|CDW|6@fzh|福州|FZS|7@gzh|广州|GZQ|8@gya|贵阳|GIW|9@hht|呼和浩特|HHC|10@heb|哈尔滨|HBB|11@hfe|合肥|HFH|12@hzh|杭州|HZH|13@hko|海口|VUQ|14@jna|济南|JNK|15@kmi|昆明|KMM|16@lsa|拉萨|LSO|17@lzh|兰州|LZJ|18@nni|南宁|NNZ|19@nji|南京|NJH|20@nch|南昌|NCG|21@sya|沈阳|SYT|22@sjz|石家庄|SJP|23@tyu|太原|TYV|24@wlq|乌鲁木齐|WMR|25@wha|武汉|WHN|26@xnx|西宁西|XXO|27@xan|西安|XAY|28@ych|银川|YIJ|29@zzh|郑州|ZZF|30@szh|深圳|SZQ|shenzhen|sz|31";

        public static readonly int SUBMIT_TOKEN_MAX_LENTH = 100;//token的上限
        public static readonly int FORE_DAYS = 19;//提前20天


        public static readonly string ACCEPT = @"image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, */*";
        public static readonly string USER_AGENT = @"Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.63 Safari/537.36";
        private CookieContainer cookies = null;
        public static string[] cookiesName = { "BIGipServerportal", "BIGipServerotn", "JSESSIONID" };
        public static string[] tickets = { "",""};
        public static string[] passage = { "1,0,1,****,1,*****,*****,N" };
        public static string[] oldpassage = { "***,1,***********,1_" };
        public static string train_date = "Sat Jan 25 2014 00:00:00 GMT+0800 (中国标准时间)";
        public string submit_token = "";
        public string leftTickets = "";
        public string trainLocation = "";

        public string OrderId { get; set; }
        //页面输入缓存
        private Dictionary<string, string> cache = new Dictionary<string, string>();
        public Dictionary<string, string> Cache { get; set; }
        public List<Passager> Passagers { get; set; }
        public Train trains { get; set; }
        public TrainOrder OrderInfo { get; set; }

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
            if (jObj["data"]["loginCheck"] != null && jObj["data"]["loginCheck"].ToString() == "Y")
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
            cookies.Add(web.GetCookie(HOST, "_jc_save_fromStation"));
            cookies.Add(web.GetCookie(HOST, "_jc_save_toStation"));
            cookies.Add(web.GetCookie(HOST, "_jc_save_fromDate"));
            cookies.Add(web.GetCookie(HOST, "_jc_save_toDate"));
            cookies.Add(web.GetCookie(HOST, "_jc_save_wfdc_flag"));
 
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
            //if (!CheckOrderInfo(rcode, out msg))
            //    return msg;

            //GetQueueCount();

            //QueryOrderWaitTime();

            //PayOrder();

            //ResultOrderForDcQueue();

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
            request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, */*";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Referer = "https://kyfw.12306.cn/otn/leftTicket/init";
            //request.Connection = "Keep-Alive";
            //request.CookieContainer = new CookieContainer();
            //cookies = new CookieContainer();
            byte[] data = Encoding.UTF8.GetBytes("_json_att=");
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
            int i = html.IndexOf(SUBMIT_TOKEN_STR, 0);
            //获取token
            string token = html.Substring(i, SUBMIT_TOKEN_STR.Length + SUBMIT_TOKEN_MAX_LENTH).Split('\'')[1].ToString();
            this.submit_token = token;
            ////获取leftTickets
            //i = html.IndexOf(LEFT_TICKETS,0);
            //string leftTicketsStr = html.Substring(i,LEFT_TICKETS.Length + SUBMIT_TOKEN_MAX_LENTH).Split('\'')[2].ToString();
            //this.leftTickets = leftTicketsStr;

        }

        /// <summary>
        /// 组织乘客字符串
        /// </summary>
        /// <param name="passengerTicketStr"></param>
        /// <param name="oldPassengerStr"></param>
        private void GerPassengerStr(out string passengerTicketStr, out string oldPassengerStr)
        {
            passengerTicketStr = "";
            oldPassengerStr = "";
            string str = "";
            string oldStr = "";
            foreach (Passager p in this.Passagers)
            {
                str = "1,0,1,{0},1,{1},{2},N";
                str = string.Format(str, p.Name, p.IdNo, p.Mobile);
                passengerTicketStr += str + "_";

                oldStr = "{0},1,{1},1_";
                oldStr = string.Format(oldStr, p.Name, p.IdNo);
                oldPassengerStr += oldStr + "_";
            }
            passengerTicketStr = passengerTicketStr.Trim('_');
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool AutoSubmitOrder(out string msg)
        {
            HttpWebResponse response = null;
            HttpWebRequest request = CreateRequest(AUTO_ORDER_URL);
            request.Method = WebUtil.RequestMethod.POST;
            request.Accept = "*/*";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

            Dictionary<string, string> formData = new Dictionary<string, string>();
            formData.Add("secretStr", this.OrderInfo.SecretStr);
            formData.Add("train_date", this.OrderInfo.TrainDate);
            formData.Add("tour_flag", "dc");
            formData.Add("purpose_codes", "ADULT");
            formData.Add("query_from_station_name", this.OrderInfo.FromName);
            formData.Add("query_to_station_name", this.OrderInfo.ToName);
            formData.Add("cancel_flag", "2");
            formData.Add("bed_level_order_num", "000000000000000000000000000000");
            string passengerTicketStr = "";
            string oldPassengerStr = "";
            GerPassengerStr(out passengerTicketStr, out oldPassengerStr);
            formData.Add("passengerTicketStr", passengerTicketStr);
            formData.Add("oldPassengerStr", oldPassengerStr);

            SetRequestData(ref request, formData);

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
            if (jobj["data"] != null && jobj["data"]["result"] != null && jobj["data"]["result"].ToString() != "")
            {
                string token = jobj["data"]["result"].ToString();
                this.trainLocation = token.Split('#')[0].ToString();
                this.submit_token = token.Split('#')[1].ToString();
                this.leftTickets = token.Split('#')[2].ToString();
                return true;
            }
            else
            {
                msg = jobj["messages"].ToString();
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rcode"></param>
        public bool CheckOrderInfo(string rcode,out string msg)
        {
            HttpWebResponse response = null;
            HttpWebRequest request = CreateRequest(CHECK_ORDER_URL);
            request.Method = WebUtil.RequestMethod.POST;
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

            Dictionary<string,string> formData = new Dictionary<string,string>();
            formData.Add("cancel_flag","2");
            formData.Add("bed_level_order_num", "000000000000000000000000000000");
            string passengerTicketStr = "";
            string oldPassengerStr = "";
            GerPassengerStr(out passengerTicketStr, out oldPassengerStr);
            formData.Add("passengerTicketStr", passengerTicketStr);
            formData.Add("oldPassengerStr", oldPassengerStr);

            formData.Add("tour_flag", "dc");
            formData.Add("randCode", rcode);
            formData.Add("_json_att", "");
            formData.Add("REPEAT_SUBMIT_TOKEN", this.submit_token);
            SetRequestData(ref request, formData);

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
                msg += jobj["data"]["errMsg"].ToString() + jobj["messages"].ToString();
                return false;
            }
        }

        private void SetRequestData(ref HttpWebRequest request,Dictionary<string,string> formData)
        {
            string dataString = @"";
            foreach (string name in formData.Keys)
            {
                dataString += (name + "=" + formData[name] + "&");
            }
            dataString = dataString.Trim('&');       
            byte[] data = Encoding.UTF8.GetBytes(dataString);
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }  
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainNo"></param>
        /// <param name="trainCode"></param>
        /// <param name="seatType"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool QueueCountAsync(out string msg)
        {
            HttpWebResponse response = null;
            HttpWebRequest request = CreateRequest(QUERY_COUNT_ASYNC_URL);
            request.Method = WebUtil.RequestMethod.POST;
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Referer = "https://kyfw.12306.cn/otn/leftTicket/init";

            Dictionary<string, string> formData = new Dictionary<string, string>();
            //DateTime trainDate = Convert.ToDateTime(this.OrderInfo.TrainDate + " " + DateTime.Now.ToLongTimeString());
            //string trainDateStr = trainDate.ToString("ddd MMM dd HH:mm:ss UTC+0800  yyyy", CultureInfo.InvariantCulture);
            string trainDateStr = (Convert.ToDateTime(this.OrderInfo.TrainDate).ToString("ddd MMM dd yyy ", DateTimeFormatInfo.InvariantInfo) +
  DateTime.Now.ToString("HH:mm:ss").Replace(":", "%3A") + " GMT%2B0800 (China Standard Time)").Replace(' ', '+');
            formData.Add("train_date", trainDateStr);
            formData.Add("train_no", this.OrderInfo.TrainNo);
            formData.Add("stationTrainCode", this.OrderInfo.TrainCode);
            formData.Add("seatType", this.OrderInfo.SeatType);

            formData.Add("fromStationTelecode", this.OrderInfo.FromCode);
            formData.Add("toStationTelecode", this.OrderInfo.ToCode);
            formData.Add("leftTicket", this.leftTickets);
            formData.Add("purpose_codes", "ADULT");
            formData.Add("_json_att", "");

            SetRequestData(ref request, formData);

            response = (HttpWebResponse)request.GetResponse();
            string html = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8")))
            {
                html = reader.ReadToEnd();
                reader.Close();
            }
            response.Close();
            msg = "GetQueueCountAsync success";
            JObject jobj = JObject.Parse(html);
            if (jobj["data"]!=null && jobj["data"]["ticket"] != null)
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
        /// 自动提交订单
        /// </summary>
        /// <param name="randCode"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool ConfirmSingleForQueueAsync(string randCode,out string msg)
        {
            HttpWebResponse response = null;
            HttpWebRequest request = CreateRequest(CONFIRM_SINGLE_FOR_QUEUE_ASYNC_URL);
            request.Method = WebUtil.RequestMethod.POST;
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

            string passengerTicketStr = "";
            string oldPassengerStr = "";
            GerPassengerStr(out passengerTicketStr, out oldPassengerStr);

            Dictionary<string, string> formData = new Dictionary<string, string>();
            formData.Add("passengerTicketStr", passengerTicketStr);
            formData.Add("oldPassengerStr", oldPassengerStr);
            formData.Add("randCode", randCode);
            formData.Add("purpose_codes", "ADULT");

            formData.Add("key_check_isChange", this.submit_token);
            formData.Add("leftTicketStr", this.leftTickets);
            formData.Add("train_location", this.trainLocation);
            formData.Add("_json_att", "");
            //formData.Add("REPEAT_SUBMIT_TOKEN", this.submit_token);

            SetRequestData(ref request, formData);

            response = (HttpWebResponse)request.GetResponse();
            string html = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8")))
            {
                html = reader.ReadToEnd();
                reader.Close();
            }
            response.Close();
            msg = "ConfirmSingleForQueueAsync success";
            JObject jobj = JObject.Parse(html);
            if (jobj["data"]["submitStatus"] != null && jobj["data"]["submitStatus"].ToString() == "true")
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
        public bool QueueCount(out string msg)
        {
            HttpWebResponse response = null;
            HttpWebRequest request = CreateRequest(QUERY_COUNT_URL);
            request.Method = WebUtil.RequestMethod.POST;
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

            Dictionary<string, string> formData = new Dictionary<string, string>();
            formData.Add("train_date", Convert.ToDateTime(this.OrderInfo.TrainDate).ToString("ddd MMM dd yyyy 00:00:00 GMT+0800 (中国标准时间)"));
            formData.Add("train_no", this.OrderInfo.TrainNo);
            formData.Add("stationTrainCode", this.OrderInfo.TrainCode);
            formData.Add("seatType", this.OrderInfo.SeatType);

            formData.Add("fromStationTelecode", this.OrderInfo.FromCode);
            formData.Add("toStationTelecode", this.OrderInfo.ToCode);
            formData.Add("leftTicket", this.leftTickets);
            formData.Add("purpose_codes", "00");
            formData.Add("_json_att", "");
            formData.Add("REPEAT_SUBMIT_TOKEN", this.submit_token);

            SetRequestData(ref request, formData);

            response = (HttpWebResponse)request.GetResponse();
            string html = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8")))
            {
                html = reader.ReadToEnd();
                reader.Close();
            }
            response.Close();
            msg = "QueueCount success";
            JObject jobj = JObject.Parse(html);
            if (jobj["data"]["ticket"] != null && jobj["data"]["ticket"].ToString() == this.leftTickets)
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
        public bool QueryOrderWaitTime(out string msg)
        {
            //random=1389080385831&tourFlag=dc&_json_att=&REPEAT_SUBMIT_TOKEN=8e75c1cb041b14b29770ac59b46f34b4
            HttpWebResponse response = null;
            HttpWebRequest request = CreateRequest(QUERY_ORDER_WAIT);
            request.Method = WebUtil.RequestMethod.GET;
            request.Accept = "application/json, text/javascript, */*; q=0.01";

            Dictionary<string, string> formData = new Dictionary<string, string>();
            formData.Add("random", this.leftTickets);
            formData.Add("tourFlag", TOUR_FLAG);
            formData.Add("_json_att", "");
            formData.Add("REPEAT_SUBMIT_TOKEN", this.submit_token);

            SetRequestData(ref request, formData);

            response = (HttpWebResponse)request.GetResponse();
            string html = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8")))
            {
                html = reader.ReadToEnd();
                reader.Close();
            }
            response.Close();

            msg = "QueryOrderWaitTime success";
            JObject jobj = JObject.Parse(html);
            if (jobj["data"]["queryOrderWaitTimeStatus"] != null && jobj["data"]["queryOrderWaitTimeStatus"].ToString() == "true")
            {
                this.OrderId = jobj["data"]["orderId"].ToString();
                return true;
            }
            else
            {
                msg = jobj["messages"].ToString();
                return false;
            }
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
