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
    /// <summary>
    /// 
    /// </summary>
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
        private string fromTeleCode;
        private string toName;
        private string toTeleCode;
        private string date;
        private string trainCode;
        private ListItem seatItem;
        public static readonly string ORDER_INFO = @"{0}——>{1} 【{2}】 共计{3}个车次";
        private TrainOrder orderInfo;
        private int SUBMIT_TIMES = 10;
        List<Passager> pList;
        private Thread logThread;

        /// <summary>
        /// 构造Form
        /// </summary>
        /// <param name="ots"></param>
        public OTS(OtsAuto ots)
        {
            this.ots = ots;
            //this.seatItem = new ListItem("硬座", "yz_num", "1");
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
        /// 加载列车类型
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
        /// 加载座位类型
        /// </summary>
        private void InitSeatType()
        {
            clb_seatType.DisplayMember = "Text";
            clb_seatType.ValueMember = "Value";
            clb_seatType.Items.Add(new ListItem("硬座", "yz_num", "1"), true);
            clb_seatType.Items.Add(new ListItem("硬卧", "yw_num", "3"), true);
            clb_seatType.Items.Add(new ListItem("二等座", "ze_num", "9"), true);
            clb_seatType.Items.Add(new ListItem("商务座", "swz_num",""), false);
            clb_seatType.Items.Add(new ListItem("特等座", "tz_num", ""), false);
            clb_seatType.Items.Add(new ListItem("一等座", "zy_num", ""), false);
            clb_seatType.Items.Add(new ListItem("高软", "gr_num", ""), false);
            clb_seatType.Items.Add(new ListItem("软卧", "rw_num", ""), false);
            clb_seatType.Items.Add(new ListItem("软座", "rz_num", ""), false);
            clb_seatType.Items.Add(new ListItem("无座", "wz_num", ""), false);
            ////SetListChecked(clb_seatType, true);
            //cb_seatType.DisplayMember = "Text";
            //cb_seatType.ValueMember = "Value";
            //cb_seatType.Items.Add(new ListItem("硬座", "1"));
            //cb_seatType.Items.Add(new ListItem("硬卧", "3"));
            //cb_seatType.Items.Add(new ListItem("二等座", "9"));
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
        /// 适配服务器端数据成本地数据
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
        /// 设置需要预定的席别
        /// </summary>
        private void SetSeatType()
        {
            ListItem seat = (ListItem)clb_seatType.CheckedItems[0];
            if (seat != null)
            {
                this.seatItem = seat;
            }
        }

        /// <summary>
        /// 查询按钮触发
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
            this.fromTeleCode = cbx_from.SelectedValue.ToString();
            this.fromName = cbx_from.Text;
            this.toTeleCode = cbx_To.SelectedValue.ToString();
            this.toName = cbx_To.Text;
            SetSeatType();
            //this.seatType = cb_seatType.SelectedValue.ToString();
            //自动预订
            if (cbx_autoOrder.Checked)
            {
                this.trainCode = txt_trainNo.Text.Trim();
                //取得指定车次
                if (this.refresh)
                {
                    this.refresh = false;
                    this.btn_query.Text = "查询";
                    Log("停止自动查询线程..........");
                }
                else
                {
                    this.refresh = true;
                    this.btn_query.Text = "停止";
                    StartRefresh();
                }
            }
            else
            {
                JArray jData = query(this.date, this.fromTeleCode, this.toTeleCode);
                jData = AdapateTrainData(jData);
                this.allTrain = jData;
                ShowTrainList();
                //CheckCanOrder();
            }
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
        /// 指定车次是否可预定
        /// </summary>
        /// <param name="item">查询得到的车次信息</param>
        /// <param name="train">指定的车次</param>
        /// <returns></returns>
        private bool isOrder(JObject item,string train)
        {
            if (train == item["queryLeftNewDTO"]["station_train_code"].ToString())
            {
                //yw_num,yz_num 
                int count= 0;
                //判断需要预定的席别是否有票
                string yz = item["queryLeftNewDTO"][this.seatItem.Value].ToString();
                Log("判断信息:" + train + "==yz_num:" + yz);
                if (yz == "有" || int.TryParse(yz, out count) && count > 0)
                {
                    Log("可以预订...........");
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
            Log("查询数据成功........" + Environment.NewLine );
            json = json.Replace("<br/>","");
            JObject jObj = JObject.Parse(json);
            StringBuilder result = new StringBuilder();
            JArray jData = JArray.Parse(jObj["data"].ToString());
            return jData;

        }

        /// <summary>
        /// 启动自动查询预订
        /// </summary>
        private void StartRefresh()
        {
            Log("开启自动查询线程..........");
            Thread refreshT = new Thread(new ThreadStart(AutoRefresh));
            refreshT.Start();
        }

        /// <summary>
        /// 自动查询预订
        /// </summary>
        private void AutoRefresh()
        {
            Log("开始自动查询,时间间隔" + this.inteval);
            int time = 0;
            string fromCode = this.fromTeleCode;
            string toCode = this.toTeleCode;
            string trainNo = this.trainCode;
            while (this.refresh)
            {
                time++;
                Log("开始第" + time + "次查询=======================================================================================");
                JArray jData = query(this.date, fromCode, toCode);
                foreach (JObject jobj in jData)
                {
                    if (isOrder(jobj, trainNo))
                    {
                        Log("开始预订........");
                        this.orderInfo = new TrainOrder();
                        this.orderInfo.TrainDate = dtp_date.Text;
                        this.orderInfo.TrainNo = jobj["queryLeftNewDTO"]["train_no"].ToString();
                        this.orderInfo.TrainCode = jobj["queryLeftNewDTO"]["station_train_code"].ToString();
                        this.orderInfo.FromCode = jobj["queryLeftNewDTO"]["from_station_telecode"].ToString();
                        this.orderInfo.FromName = jobj["queryLeftNewDTO"]["from_station_name"].ToString();
                        this.orderInfo.ToCode = jobj["queryLeftNewDTO"]["to_station_telecode"].ToString();
                        this.orderInfo.ToName = jobj["queryLeftNewDTO"]["to_station_name"].ToString();
                        this.orderInfo.SeatType = this.seatItem.Code;//默认硬座
                        this.orderInfo.SecretStr = jobj["secretStr"].ToString();

                        string orderInfoStr = OrderInfoStr();
                        Log(orderInfoStr);
                        this.refresh = false;
                        //开始订票
                        PreAutoOrder();
                        break;
                    }
                }

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
                Log("验证码输入完成，输入验证码为" + txt_OrderRandCode.Text.Trim());
                Log("跳过验证码校验........");
                //string result = "";
                if (cbx_autoOrder.Checked)
                {
                    this.AutoOrder(vcode);
                }
                else
                {
                    string result = this.Order(vcode);
                    MessageBox.Show(result);
                }
            }
        }

        /// <summary>
        /// 界面时间显示器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 发站输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// 只显示可预订车次选择框触发
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
            if (this.allTrain == null || this.allTrain.Count == 0)
                return;
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
        /// 从查询结果中获取只能预订的车次
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

        /// <summary>
        /// 全部车次点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_allTrainType_Click(object sender, EventArgs e)
        {
            Log("点击全部车次........");
            SetListChecked(clb_trainType, cb_allTrainType.Checked);
        }

        /// <summary>
        /// 全部席别点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_allSeatType_Click(object sender, EventArgs e)
        {
            Log("点击全部席别.......");
            SetListChecked(clb_seatType, cb_allSeatType.Checked);
        }



        /// <summary>
        /// 线程间调用设置SetLogText的委托
        /// </summary>
        /// <param name="text"></param>
        private delegate void SetLog(string text);
        private void SetLogText(object text)
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

        /// <summary>
        /// 多线程验证码操作
        /// </summary>
        /// <param name="img"></param>
        private delegate void SetThreadRandCode(Image img);
        private void SetThreadRandCodeContent(Image img)
        {
            if (this.pic_OrderRandCode.InvokeRequired)
            {
                this.Invoke(new SetThreadRandCode(this.SetThreadRandCodeContent), new object[] { img });
            }
            else
            {
                pic_OrderRandCode.Image = img;
                txt_OrderRandCode.Focus();
            }
        }

        /// <summary>
        /// 日志记录
        /// </summary>
        /// <param name="msg"></param>
        public void Log(string msg)
        {
            //if (this.logThread == null)
            //{
            //    this.logThread = new Thread(new ParameterizedThreadStart(SetLogText));
            //    logThread.Start(msg);
            //}
            //else
            //    this.logThread.Start(msg);
           SetLogText(msg);
        }

        /// <summary>
        /// 
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
                if (!GetSelectedPassager())
                {
                    Log("乘客信息提取失败........");
                    MessageBox.Show("请选择乘车人");
                    return;
                }
                ots.Passagers = this.pList;
                //生成订单信息
                this.orderInfo = new TrainOrder();
                this.orderInfo.TrainDate = dtp_date.Text;
                this.orderInfo.TrainNo = gv_train.Rows[e.RowIndex].Cells["train"].Value.ToString();
                this.orderInfo.TrainCode = gv_train.Rows[e.RowIndex].Cells["trainNo"].Value.ToString();
                this.orderInfo.FromCode = gv_train.Rows[e.RowIndex].Cells["fromCode"].Value.ToString();
                this.orderInfo.FromName = gv_train.Rows[e.RowIndex].Cells["from"].Value.ToString();
                this.orderInfo.ToCode = gv_train.Rows[e.RowIndex].Cells["toCode"].Value.ToString();
                this.orderInfo.ToName = gv_train.Rows[e.RowIndex].Cells["to"].Value.ToString();
                this.orderInfo.SeatType = "1";//默认硬座

                string orderInfoStr = OrderInfoStr();
                if (MessageBox.Show(orderInfoStr,"订票确认", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    PreOrder();
                }
                Log("取消订票..........");
            }
        }

        /// <summary>
        /// 预订车票信息串 
        /// </summary>
        /// <returns></returns>
        private string OrderInfoStr()
        {
            return this.orderInfo.TrainCode + "  " + this.orderInfo.TrainDate + Environment.NewLine +
                this.orderInfo.FromName + "[" + this.orderInfo.FromCode + "]" + "====>>>>" + this.orderInfo.ToName + "[" + this.orderInfo.ToCode + "]" + Environment.NewLine +
                this.orderInfo.SeatType;
        }

        /// <summary>
        /// 设置选择的乘客
        /// </summary>
        /// <returns></returns>
        private bool GetSelectedPassager()
        {
            Log("提取乘客信息........");
            List<Passager> pList = new List<Passager>();
            if (clb_passger.CheckedItems.Count == 0)
                return false;
            foreach (Passager p in clb_passger.CheckedItems)
            {
                pList.Add(p);
            }
            this.pList = pList;
            return true;
        }

        /// <summary>
        /// 加载验证码
        /// </summary>
        private void LoadRandCode()
        {
            Log("加载验证码......");
            Image img = this.ots.GetRandImage();
            SetThreadRandCodeContent(img);
            Log("验证码加载完成");
        }

        /// <summary>
        /// 自动订票准备提交
        /// </summary>
        private void PreAutoOrder()
        {
            Log("预订试算........");
            this.ots.OrderInfo = this.orderInfo;
            this.ots.Passagers = this.pList;
            Log("Token获取........");
            string msg = "";
            if (!this.ots.AutoSubmitOrder(out msg))
            {
                Log("Token获取失败：" + msg);
                return;
            }
            Log("订单进入排队........");
            this.ots.OrderInfo = this.orderInfo;
            if (!this.ots.QueueCountAsync(out msg))
            {
                Log(msg);
                return;
            }
            Log("验证码获取........");
            LoadRandCode();
        }

        /// <summary>
        /// 自动提交订单
        /// </summary>
        /// <param name="randCode"></param>
        private void AutoOrder(string randCode)
        {
            Log("开始订票，强势插入>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            //没有消息是最好的消息
            string msg = "";
            Log("====1/1====提交订单.........");
            //此处如果失败则重复提交，线程等待
            if (this.ots.ConfirmSingleForQueueAsync(randCode,out msg))
            {
                Log(msg);
                return;
            }

            //Log("====2/2====开始订单生成.........");
            //if (!this.ots.QueryOrderWaitTime(out msg))
            //{
            //    Log(msg);
            //    return;
            //}
            //int times = 0;
            ////等待提交，获取订单编号
            //while (string.IsNullOrEmpty(this.ots.OrderId) && times < SUBMIT_TIMES)
            //{
            //    this.ots.QueryOrderWaitTime(out msg);
            //    Log(msg);
            //}

            Log("恭喜，完成订单,赶紧去支付吧<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");

        }

        /// <summary>
        /// 手动预订，准备动作
        /// </summary>
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
        /// 手动预订
        /// </summary>
        public string Order(string rcode)
        {
            Log("开始订票，强势插入>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            //没有消息是最好的消息
            string msg = "";
            Log("====1/3====提交订单.........");
            if (!this.ots.CheckOrderInfo(rcode, out msg))
            {
                Log(msg);
                return msg;
            }

            Log("====2/3====进入订单队列.........");
            if (!this.ots.QueueCount(out msg))
            {
                Log(msg);
                return msg;
            }

            Log("====3/3====开始订单生成.........");
            if (!this.ots.QueryOrderWaitTime(out msg))
            {
                Log(msg);
                return msg;
            }
            int times = 0;
            //等待提交，获取订单编号
            while(string.IsNullOrEmpty(this.ots.OrderId) && times < SUBMIT_TIMES)
            {
                this.ots.QueryOrderWaitTime(out msg);
                Log(msg);
            }

            //Log("====4/5====开始支付.........");
            //this.ots.PayOrder();

            //Log("====5/5====订单结果.........");
            //this.ots.ResultOrderForDcQueue();

            Log("恭喜，完成订单,赶紧去支付吧<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            return "";
        }

        /// <summary>
        /// 自动提交 选择框触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_autoOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_autoOrder.Checked)
            {
                if(string.IsNullOrEmpty(txt_trainNo.Text.Trim())){
                    cbx_autoOrder.Checked = false;
                    MessageBox.Show("请先输入车次");
                    return;
                }
                if (!GetSelectedPassager())
                {
                    Log("乘客信息提取失败........");
                    MessageBox.Show("请选择乘车人");
                    return;
                }
                Log("开启自动预订,预订车次为 " + txt_trainNo.Text.Trim());
            }
        }

        /// <summary>
        /// 重新加载验证码事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic_OrderRandCode_Click(object sender, EventArgs e)
        {
            LoadRandCode();
        }


    }
}
