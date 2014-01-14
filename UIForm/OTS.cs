using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Newtonsoft.Json.Linq;
using System.Threading;
using Model;

namespace UIForm
{
    public partial class OTS : Form
    {
        private OtsAuto ots;
        private bool isAutoOrder = false;
        private bool ajustTime = false;
        private int timerTime = 0;
        private int inteval = 5;
        private bool refresh = false;
        private static string AUTO = "auto";
        private static string STOP = "stop";
        private int vcodeLength = 4;
        private List<Station> allStation;
        private List<Station> hotStation;
        private JArray allTrain; //得到的
        private JArray showTrain; //显示的
        private string fromName;
        //private string fromCode;
        private string toName;
        //private string toCode;
        private string date;
        public static readonly string ORDER_INFO = @"{0}——>{1} 【{2}】 共计{3}个车次";

        /// <summary>
        /// 构造Form
        /// </summary>
        /// <param name="ots"></param>
        public OTS(OtsAuto ots)
        {
            this.ots = ots;
            InitializeComponent();
        }

        /// <summary>
        /// Form载入前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OTS_Load(object sender, EventArgs e)
        {
            Log("加载程序........");
            InitUI();
            InitData();
            Log("程序加载完成........");
        }

        /// <summary>
        /// 初始化界面UI
        /// </summary>
        private void InitUI()
        {
            Log("加载UI........");
            txt_inteval.Text = this.inteval.ToString();
            Log("UI加载完成........");
        }

        /// <summary>
        /// 设置ListBox是选中
        /// </summary>
        /// <param name="clb"></param>
        /// <param name="allOrEmpty"></param>
        private void SetListChecked(CheckedListBox clb,bool allOrEmpty)
        {
            int itemCount = clb.Items.Count;
            if (itemCount > 0)
            {
                for (int i = 0; i < itemCount;i++)
                {
                    clb.SetItemChecked(i, allOrEmpty);
                }        
            } 
        }

        /// <summary>
        /// 初始化界面数据
        /// </summary>
        private void InitData()
        {
            Log("初始化系统数据........");
            dtp_date.Text = DateTime.Now.AddDays(OtsAuto.FORE_DAYS).ToLongDateString();
            Log("加载12306服务器时间........");
            InitServerTime();
            Log("12306服务器时间加载完成........");
            Log("加载车站数据........");
            InitStation();
            Log("加载车次........");
            InitTrainType();
            Log("加载席别........");
            InitSeatType();
            Log("加载乘客........");
            InitPassager();
            Log("系统数据加载完成........");
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitTrainType()
        {
            clb_trainType.DisplayMember = "Text";
            clb_trainType.ValueMember = "Value";
            clb_trainType.Items.Add(new ListItem("高铁", "GC"), true);
            clb_trainType.Items.Add(new ListItem("动车", "D"), true);
            clb_trainType.Items.Add(new ListItem("Z字头", "Z"), true);
            clb_trainType.Items.Add(new ListItem("T字头", "T"), true);
            clb_trainType.Items.Add(new ListItem("K字头", "K"), true);
            clb_trainType.Items.Add(new ListItem("其他", "0"), true);

            //SetListChecked(clb_trainType, true);
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitSeatType()
        {
            clb_seatType.DisplayMember = "Text";
            clb_seatType.ValueMember = "Value";
            clb_seatType.Items.Add(new ListItem("商务座", "swz_num"), true);
            clb_seatType.Items.Add(new ListItem("特等座", "tz_num"), true);
            clb_seatType.Items.Add(new ListItem("一等座", "zy_num"), true);
            clb_seatType.Items.Add(new ListItem("二等座", "ze_num"), true);
            clb_seatType.Items.Add(new ListItem("高软", "gr_num"), true);
            clb_seatType.Items.Add(new ListItem("软卧", "rw_num"), true);
            clb_seatType.Items.Add(new ListItem("硬卧", "yw_num"), true);
            clb_seatType.Items.Add(new ListItem("软座", "rz_num"), true);
            clb_seatType.Items.Add(new ListItem("硬座", "yz_num"), true);
            clb_seatType.Items.Add(new ListItem("无座", "wz_num"), true);
            //SetListChecked(clb_seatType, true);
        }

        /// <summary>
        /// 初始化车站
        /// </summary>
        private void InitStation()
        {
            this.hotStation = this.ots.GetHotStation();
            this.allStation = this.ots.GetStation();
            cbx_from.DataSource = hotStation;
            cbx_from.DisplayMember = "Name";
            cbx_from.ValueMember = "Id";

            List<Station> h1 = new List<Station>(hotStation);
            //hotStation.CopyTo(hotStation1);

            cbx_To.DataSource = h1;
            cbx_To.DisplayMember = "Name";
            cbx_To.ValueMember = "Id";
        }

        /// <summary>
        /// 初始化服务器时间
        /// </summary>
        private void InitServerTime()
        {
            Log("连接12306对时.....");
            DateTime serverTime = this.ots.ServerTime();
            lbl_serverTime.Text = serverTime.ToLongTimeString();
            Log("对时成功，12306时间" + serverTime.ToLongTimeString() + ",本地时间 "+ DateTime.Now.ToString() +".....");
        }

        /// <summary>
        /// 初始化乘客
        /// </summary>
        private void InitPassager()
        {
            string msg = "";
            List<Passager> passagerList = this.ots.GetPassager(out msg);
            if (passagerList == null)
                this.lbl_passagerMsg.Text = "获取乘客失败：" + msg;
            else
            {
                this.lbl_passagerMsg.Text = "";
                clb_passger.DataSource = passagerList;
                clb_passger.DisplayMember = "Name";
                clb_passger.ValueMember = "Code";
            }
        }

        /// <summary>
        /// 显示车辆信息
        /// </summary>
        /// <param name="jTrain"></param>
        private void BindTrain(JArray jTrain)
        {
            Log("显示车次...........");
            string orderInfo = string.Format(ORDER_INFO, this.fromName, this.toName, DateTime.Parse(this.date).ToString("yyyy-MM-dd ddd"), jTrain.Count);
            lbl_orderInfo.Text = orderInfo;

            this.gv_train.AutoGenerateColumns = false;
            this.gv_train.DataSource = jTrain;
            Log("车次显示完成........");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jtrain"></param>
        /// <returns></returns>
        private JArray AdapateTrainData(JArray jtrain)
        {
            Log("处理查询结果，本地化查询数据.......");
            JArray trainList = new JArray();
            foreach (JObject jobj in jtrain)
            {
                JObject o = (JObject)jobj["queryLeftNewDTO"];
                o.Last.AddAfterSelf(jobj.Last);
                trainList.Add(o);
            }
            Log("本地化数据结束.......");
            return trainList;
        }

        private string ValidInput()
        {
            string msg = "";
            return msg;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {

            Log("查询开始........");
            Log("输入条件验证........");
            string msg = ValidInput();
            Log("输入条件验证通过........");
            if (!string.IsNullOrEmpty(msg))
            {
                Log(msg);
                MessageBox.Show(msg);
                return;
            }
            this.date = dtp_date.Text;
            string fromCode = cbx_from.SelectedValue.ToString();
            this.fromName = cbx_from.Text;
            string toCode = cbx_To.SelectedValue.ToString();
            this.toName = cbx_To.Text;
            JArray jData = query(this.date, fromCode, toCode);
            jData = AdapateTrainData(jData);
            this.allTrain = jData;
            ShowTrainList();
            //CheckCanOrder();
        }

        /// <summary>
        /// 根据界面条件过滤
        /// </summary>
        private void ShowTrainList()
        {
            Log("开始本地条件过滤.........");
            JArray showList = new JArray();
            foreach (JObject jobj in this.allTrain)
            {
                if (IsShow(jobj))
                {
                    showList.Add(jobj);
                }
            }
            this.showTrain = showList;
            BindTrain(showList);
        }

        /// <summary>
        /// 根据条件是否显示指定的车次
        /// </summary>
        /// <param name="jobj"></param>
        /// <returns></returns>
        private bool IsShow(JObject jobj)
        {
            bool isShow = false;
            if (cb_allTrainType.Checked && cb_allSeatType.Checked)
                return true;
            else
            {
                string trainType = jobj["station_train_code"].ToString().Substring(0,1).ToUpper();
                if (CheckedTrain(trainType, clb_trainType))
                {
                    if (CheckedSeat(jobj, clb_seatType))
                    {
                        isShow = true;
                    }
                }
            }
            return isShow;
        }

        /// <summary>
        /// 检查车次的座次是否合乎条件
        /// </summary>
        /// <param name="jobj"></param>
        /// <param name="clb"></param>
        /// <returns></returns>
        private bool CheckedSeat(JObject jobj,CheckedListBox clb)
        {
            for (int i = 0; i < clb.CheckedItems.Count; i++)
            {
                ListItem item = (ListItem)clb.CheckedItems[i];
                string seatValue = jobj[item.Value].ToString();
                int seat = 0;
                if (seatValue == "有" ||  (int.TryParse(seatValue,out seat) && seat > 0))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 检查车次是否是否条件
        /// </summary>
        /// <param name="trainType"></param>
        /// <returns></returns>
        private bool CheckedTrain(string value,CheckedListBox clb)
        {
            for (int i = 0; i < clb.CheckedItems.Count; i++)
            {
                ListItem item = (ListItem)clb.CheckedItems[i];
                if (item.Value.Contains(value))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="train"></param>
        /// <returns></returns>
        private bool isOrder(JObject item,string train)
        {
            if (train == item["queryLeftNewDTO"]["station_train_code"].ToString())
            {
                //yw_num,yz_num 
                int count= 0;
                //硬卧优先
                if (int.TryParse(item["queryLeftNewDTO"]["yw_num"].ToString(), out count) && count > 0)
                {
                    return true;
                }
                if (int.TryParse(item["queryLeftNewDTO"]["yz_num"].ToString(), out count) && count > 0) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 查询
        /// </summary>
        private JArray query(string date,string from,string to) 
        {
            Log("查询数据........");
            String json = ots.Query(date,from,to);
            Log("查询数据成功........" + Environment.NewLine + json);
            json = json.Replace("<br/>","");
            JObject jObj = JObject.Parse(json);
            StringBuilder result = new StringBuilder();
            JArray jData = JArray.Parse(jObj["data"].ToString());
            return jData;

        }

        private void btn_autoQuery_Click(object sender, EventArgs e)
        {
        }

        private void Refresh()
        {
            int time = 0;
            while (this.refresh)
            {
                time++;
                //query();
                SetRefresh(time.ToString());
                Thread.Sleep(this.inteval * 1000);
            }
        }




        /// <summary>
        /// 线程间调用设置的委托
        /// </summary>
        /// <param name="text"></param>
        private delegate void SetRefreshCallBack(string text);

        private void SetRefresh(string text)
        {
            if (this.lbl_refreshTime.InvokeRequired)
            {
                this.Invoke(new SetRefreshCallBack(this.SetRefresh), new object[] { text });
            }
            else
            {
                this.lbl_refreshTime.Text = text;
            }
        }

        /// <summary>
        /// 监听订单验证码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_OrderRandCode_KeyUp(object sender, KeyEventArgs e)
        {
            string vcode = txt_OrderRandCode.Text.Trim();
            if (vcode.Length == vcodeLength) 
            {
                string result = "";
                //result = this.Order(vcode);
                //MessageBox.Show(result);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //10分钟通过服务器校准一次时间
            DateTime serverTime = DateTime.Parse(lbl_serverTime.Text);
            //防止同一分钟内多次校准，使用ajustTime来标记是否同步过，一分钟之后恢复ajusttime
            if (serverTime.Minute % 10 == 0 && !ajustTime)
            {
                InitServerTime();
                ajustTime = true;
                timerTime = 0;
            }
            else
            {
                if (serverTime.Minute % 10 == 1)
                    ajustTime = false;
                lbl_serverTime.Text = serverTime.AddSeconds(1).ToLongTimeString();
            }


        }

        private void cbx_from_KeyUp(object sender, KeyEventArgs e)
        {
            string str = cbx_from.Text;
            //List<Station> result = allStation.Select(s=>s.ShortName = str).ToList<Station>();
            List<Station> result = allStation.Where(s => s.ShortName.Contains(str)).ToList<Station>();
            //cbx_from.DataSource = result;
            cbx_from.AutoCompleteMode = AutoCompleteMode.Append;
            cbx_from.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbx_from.DisplayMember = "Name";
            cbx_from.ValueMember = "Id";
            cbx_from.Text = str;
            cbx_from.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_showCanOrder_CheckedChanged(object sender, EventArgs e)
        {
            Log("只显示可预订车次........");
            CheckCanOrder();
        }

        /// <summary>
        /// 只显示可预订的
        /// </summary>
        private void CheckCanOrder()
        {
            if (cbx_showCanOrder.Checked)
            {
                Log("只显示可预订车次........");
                BindTrain(GetCanOrder(this.allTrain));
            }
            else
            {
                Log("显示全部车次........");
                BindTrain(this.allTrain);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainList"></param>
        /// <returns></returns>
        private JArray GetCanOrder(JArray trainList)
        {
            JArray orderTrain = new JArray();
            foreach (JObject jobj in trainList)
            {
                if (jobj["buttonTextInfo"].ToString() == "预订")
                {
                    orderTrain.Add(jobj);
                }
            }
            return orderTrain;
        }

        private void cb_allTrainType_Click(object sender, EventArgs e)
        {
            Log("点击全部车次........");
            SetListChecked(clb_trainType, cb_allTrainType.Checked);
        }

        private void cb_allSeatType_Click(object sender, EventArgs e)
        {
            Log("点击全部席别.......");
            SetListChecked(clb_seatType, cb_allSeatType.Checked);
        }



        /// <summary>
        /// 线程间调用设置SetZbyText的委托
        /// </summary>
        /// <param name="text"></param>
        private delegate void SetLog(string text);

        private void SetLogText(string text)
        {
            if (this.rtb_log.InvokeRequired)
            {
                this.Invoke(new SetLog(this.SetLogText), new object[] { text });
            }
            else
            {
                string cDateTime = DateTime.Now.ToLongTimeString();

                rtb_log.SelectionStart = rtb_log.Text.Length;
                if (rtb_log.Lines.Length == 0)
                {
                    rtb_log.AppendText(cDateTime + " " + text);
                    rtb_log.ScrollToCaret();
                    rtb_log.AppendText(Environment.NewLine);
                }
                else
                {
                    rtb_log.AppendText(cDateTime + " " + text + Environment.NewLine);
                    rtb_log.ScrollToCaret();
                }
            }
        }

        public void Log(string msg)
        {
            SetLogText(msg);

        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_train_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Log("点击行列:" + e.RowIndex + "" + e.ColumnIndex);
            if (e.ColumnIndex == gv_train.Columns["buttonTextInfo"].Index && e.RowIndex >= 0)
            {
                string trainCode = gv_train.Rows[e.RowIndex].Cells["train"].Value.ToString();
                Log("开始预订车票" + trainCode + ".......");
                string name = "";
                List<Passager> pList = new List<Passager>();
                if (!GetSelectedPassager(out pList,out name))
                {
                    Log("乘客信息提取失败........");
                    MessageBox.Show("请选择乘车人");
                    return;
                }
                string orderInfo = name;
                if (MessageBox.Show("订票确认", "车次信息", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    PreOrder();
                }
                Log("取消订票..........");
            }
        }

        private bool GetSelectedPassager(out List<Passager> pList, out string name)
        {
            Log("提取乘客信息........");
            name = "";
            pList = null;
            if (clb_passger.SelectedItems.Count == 0)
                return false;
            foreach (Passager p in clb_passger.SelectedItems)
            {
                pList.Add(p);
                name += (p.Name + ",");
            }
            name.Trim(',');
            return true;
        }

        private void PreOrder()
        {
            Log("预订试算........");
            Log("Token获取........");
            this.ots.SetSubmitToken();
            Log("验证码获取........");
            Image img = this.ots.GetOrderRandImage();
            pic_OrderRandCode.Image = img;
            txt_OrderRandCode.Focus();
        }

        /// <summary>
        /// Template
        /// </summary>
        public string Order(string rcode)
        {
            Log("开始订票，强势插入>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            //没有消息是最好的消息
            string msg = "";
            Log("====1/5====提交订单.........");
            if (!this.ots.CheckOrderInfo(rcode, out msg))
            {
                Log(msg);
                return msg;
            }

            Log("====2/5====进入订单队列.........");
            this.ots.GetQueueCount();

            Log("====3/5====开始订单生成.........");
            this.ots.QueryOrderWaitTime();

            Log("====4/5====开始支付.........");
            this.ots.PayOrder();

            Log("====5/5====订单结果.........");
            this.ots.ResultOrderForDcQueue();

            Log("恭喜，完成订单<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            return "";
        }




    }
}
