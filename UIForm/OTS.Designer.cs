namespace UIForm
{
    partial class OTS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Timer timer1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_query = new System.Windows.Forms.Button();
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.lbl_refreshTime = new System.Windows.Forms.Label();
            this.gv_train = new System.Windows.Forms.DataGridView();
            this.train = new System.Windows.Forms.DataGridViewLinkColumn();
            this.from = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.to = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrive_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lishi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yw_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yz_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rw_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rz_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ze_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gr_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tz_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wz_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zy_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.swz_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qt_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trainNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonTextInfo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_from = new System.Windows.Forms.ComboBox();
            this.cbx_To = new System.Windows.Forms.ComboBox();
            this.cbx_time = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.clb_passger = new System.Windows.Forms.CheckedListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.clb_trainType = new System.Windows.Forms.CheckedListBox();
            this.clb_seatType = new System.Windows.Forms.CheckedListBox();
            this.cbx_autoQuery = new System.Windows.Forms.CheckBox();
            this.cbx_autoOrder = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_inteval = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_allSeatType = new System.Windows.Forms.CheckBox();
            this.cb_allTrainType = new System.Windows.Forms.CheckBox();
            this.dtp_date = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.pic_OrderRandCode = new System.Windows.Forms.PictureBox();
            this.txt_OrderRandCode = new System.Windows.Forms.TextBox();
            this.lbl_serverTime = new System.Windows.Forms.Label();
            this.lbl_queryTimes = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbx_showCanOrder = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_orderInfo = new System.Windows.Forms.Label();
            this.lbl_passagerMsg = new System.Windows.Forms.Label();
            timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gv_train)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inteval)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_OrderRandCode)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_query
            // 
            this.btn_query.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_query.Font = new System.Drawing.Font("黑体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.ForeColor = System.Drawing.Color.Red;
            this.btn_query.Location = new System.Drawing.Point(148, 13);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(138, 46);
            this.btn_query.TabIndex = 4;
            this.btn_query.Text = "查 询";
            this.btn_query.UseVisualStyleBackColor = false;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // rtb_log
            // 
            this.rtb_log.BackColor = System.Drawing.Color.Black;
            this.rtb_log.ForeColor = System.Drawing.Color.Lime;
            this.rtb_log.Location = new System.Drawing.Point(11, 543);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.ReadOnly = true;
            this.rtb_log.Size = new System.Drawing.Size(1085, 193);
            this.rtb_log.TabIndex = 6;
            this.rtb_log.Text = "";
            // 
            // lbl_refreshTime
            // 
            this.lbl_refreshTime.AutoSize = true;
            this.lbl_refreshTime.Location = new System.Drawing.Point(589, 147);
            this.lbl_refreshTime.Name = "lbl_refreshTime";
            this.lbl_refreshTime.Size = new System.Drawing.Size(11, 12);
            this.lbl_refreshTime.TabIndex = 9;
            this.lbl_refreshTime.Text = "0";
            // 
            // gv_train
            // 
            this.gv_train.AllowUserToAddRows = false;
            this.gv_train.AllowUserToDeleteRows = false;
            this.gv_train.AllowUserToResizeRows = false;
            this.gv_train.BackgroundColor = System.Drawing.Color.Gray;
            this.gv_train.ColumnHeadersHeight = 30;
            this.gv_train.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gv_train.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.train,
            this.from,
            this.to,
            this.start_time,
            this.arrive_time,
            this.lishi,
            this.yw_num,
            this.yz_num,
            this.rw_num,
            this.rz_num,
            this.ze_num,
            this.gr_num,
            this.tz_num,
            this.wz_num,
            this.zy_num,
            this.swz_num,
            this.qt_num,
            this.trainNo,
            this.fromCode,
            this.toCode,
            this.buttonTextInfo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gv_train.DefaultCellStyle = dataGridViewCellStyle2;
            this.gv_train.Location = new System.Drawing.Point(12, 181);
            this.gv_train.Name = "gv_train";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv_train.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gv_train.RowTemplate.Height = 23;
            this.gv_train.Size = new System.Drawing.Size(1085, 355);
            this.gv_train.TabIndex = 12;
            this.gv_train.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_train_CellContentClick);
            // 
            // train
            // 
            this.train.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.train.DataPropertyName = "station_train_code";
            this.train.Frozen = true;
            this.train.HeaderText = "车次";
            this.train.Name = "train";
            this.train.Width = 46;
            // 
            // from
            // 
            this.from.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.from.DataPropertyName = "from_station_name";
            this.from.FillWeight = 100.5256F;
            this.from.HeaderText = "发站";
            this.from.Name = "from";
            this.from.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // to
            // 
            this.to.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.to.DataPropertyName = "to_station_name";
            this.to.FillWeight = 103.776F;
            this.to.HeaderText = "到站";
            this.to.Name = "to";
            // 
            // start_time
            // 
            this.start_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.start_time.DataPropertyName = "start_time";
            this.start_time.HeaderText = "出发时间";
            this.start_time.MinimumWidth = 50;
            this.start_time.Name = "start_time";
            this.start_time.Width = 60;
            // 
            // arrive_time
            // 
            this.arrive_time.DataPropertyName = "arrive_time";
            this.arrive_time.FillWeight = 117.9993F;
            this.arrive_time.HeaderText = "到达时间";
            this.arrive_time.MinimumWidth = 50;
            this.arrive_time.Name = "arrive_time";
            this.arrive_time.Width = 59;
            // 
            // lishi
            // 
            this.lishi.DataPropertyName = "lishi";
            this.lishi.FillWeight = 97.18053F;
            this.lishi.HeaderText = "历时";
            this.lishi.MinimumWidth = 50;
            this.lishi.Name = "lishi";
            this.lishi.Width = 50;
            // 
            // yw_num
            // 
            this.yw_num.DataPropertyName = "yw_num";
            this.yw_num.FillWeight = 97.39622F;
            this.yw_num.HeaderText = "硬卧";
            this.yw_num.MinimumWidth = 50;
            this.yw_num.Name = "yw_num";
            this.yw_num.Width = 50;
            // 
            // yz_num
            // 
            this.yz_num.DataPropertyName = "yz_num";
            this.yz_num.FillWeight = 97.5977F;
            this.yz_num.HeaderText = "硬座";
            this.yz_num.MinimumWidth = 50;
            this.yz_num.Name = "yz_num";
            this.yz_num.Width = 50;
            // 
            // rw_num
            // 
            this.rw_num.DataPropertyName = "rw_num";
            this.rw_num.FillWeight = 97.78597F;
            this.rw_num.HeaderText = "软卧";
            this.rw_num.MinimumWidth = 50;
            this.rw_num.Name = "rw_num";
            this.rw_num.Width = 50;
            // 
            // rz_num
            // 
            this.rz_num.DataPropertyName = "rz_num";
            this.rz_num.FillWeight = 97.96186F;
            this.rz_num.HeaderText = "软座";
            this.rz_num.MinimumWidth = 50;
            this.rz_num.Name = "rz_num";
            this.rz_num.Width = 50;
            // 
            // ze_num
            // 
            this.ze_num.DataPropertyName = "ze_num";
            this.ze_num.FillWeight = 98.12619F;
            this.ze_num.HeaderText = "二等座";
            this.ze_num.MinimumWidth = 50;
            this.ze_num.Name = "ze_num";
            this.ze_num.Width = 50;
            // 
            // gr_num
            // 
            this.gr_num.DataPropertyName = "gr_num";
            this.gr_num.FillWeight = 98.27971F;
            this.gr_num.HeaderText = "高软";
            this.gr_num.MinimumWidth = 50;
            this.gr_num.Name = "gr_num";
            this.gr_num.Width = 50;
            // 
            // tz_num
            // 
            this.tz_num.DataPropertyName = "tz_num";
            this.tz_num.FillWeight = 98.55718F;
            this.tz_num.HeaderText = "特等座";
            this.tz_num.MinimumWidth = 50;
            this.tz_num.Name = "tz_num";
            this.tz_num.Width = 50;
            // 
            // wz_num
            // 
            this.wz_num.DataPropertyName = "wz_num";
            this.wz_num.FillWeight = 98.6824F;
            this.wz_num.HeaderText = "无座";
            this.wz_num.MinimumWidth = 50;
            this.wz_num.Name = "wz_num";
            this.wz_num.Width = 50;
            // 
            // zy_num
            // 
            this.zy_num.DataPropertyName = "zy_num";
            this.zy_num.FillWeight = 98.79942F;
            this.zy_num.HeaderText = "一等座";
            this.zy_num.MinimumWidth = 50;
            this.zy_num.Name = "zy_num";
            this.zy_num.Width = 50;
            // 
            // swz_num
            // 
            this.swz_num.DataPropertyName = "swz_num";
            this.swz_num.FillWeight = 98.9087F;
            this.swz_num.HeaderText = "商务座";
            this.swz_num.MinimumWidth = 50;
            this.swz_num.Name = "swz_num";
            this.swz_num.Width = 50;
            // 
            // qt_num
            // 
            this.qt_num.DataPropertyName = "qt_num";
            this.qt_num.FillWeight = 98.42317F;
            this.qt_num.HeaderText = "其他";
            this.qt_num.MinimumWidth = 50;
            this.qt_num.Name = "qt_num";
            this.qt_num.Width = 50;
            // 
            // trainNo
            // 
            this.trainNo.DataPropertyName = "train_no";
            this.trainNo.HeaderText = "trainNo";
            this.trainNo.Name = "trainNo";
            this.trainNo.Visible = false;
            this.trainNo.Width = 5;
            // 
            // fromCode
            // 
            this.fromCode.DataPropertyName = "from_station_telecode";
            this.fromCode.HeaderText = "fromCode";
            this.fromCode.Name = "fromCode";
            this.fromCode.Visible = false;
            this.fromCode.Width = 5;
            // 
            // toCode
            // 
            this.toCode.DataPropertyName = "to_station_telecode";
            this.toCode.HeaderText = "toCode";
            this.toCode.Name = "toCode";
            this.toCode.Visible = false;
            this.toCode.Width = 5;
            // 
            // buttonTextInfo
            // 
            this.buttonTextInfo.DataPropertyName = "buttonTextInfo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            this.buttonTextInfo.DefaultCellStyle = dataGridViewCellStyle1;
            this.buttonTextInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonTextInfo.HeaderText = "预订";
            this.buttonTextInfo.Name = "buttonTextInfo";
            this.buttonTextInfo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "目的地";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "出发地";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "出发日期";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(487, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "时间";
            // 
            // cbx_from
            // 
            this.cbx_from.DropDownHeight = 200;
            this.cbx_from.FormattingEnabled = true;
            this.cbx_from.IntegralHeight = false;
            this.cbx_from.Location = new System.Drawing.Point(47, 14);
            this.cbx_from.Name = "cbx_from";
            this.cbx_from.Size = new System.Drawing.Size(100, 20);
            this.cbx_from.TabIndex = 24;
            this.cbx_from.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbx_from_KeyUp);
            // 
            // cbx_To
            // 
            this.cbx_To.DropDownHeight = 200;
            this.cbx_To.FormattingEnabled = true;
            this.cbx_To.IntegralHeight = false;
            this.cbx_To.Location = new System.Drawing.Point(197, 14);
            this.cbx_To.Name = "cbx_To";
            this.cbx_To.Size = new System.Drawing.Size(100, 20);
            this.cbx_To.TabIndex = 25;
            // 
            // cbx_time
            // 
            this.cbx_time.FormattingEnabled = true;
            this.cbx_time.Items.AddRange(new object[] {
            "00:00——6:00",
            "06:00——12:00",
            "12:00——18:00",
            "18:00——24:00"});
            this.cbx_time.Location = new System.Drawing.Point(521, 14);
            this.cbx_time.Name = "cbx_time";
            this.cbx_time.Size = new System.Drawing.Size(127, 20);
            this.cbx_time.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(125, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 28;
            this.label8.Text = "秒";
            // 
            // clb_passger
            // 
            this.clb_passger.BackColor = System.Drawing.Color.Silver;
            this.clb_passger.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clb_passger.CheckOnClick = true;
            this.clb_passger.ColumnWidth = 60;
            this.clb_passger.FormattingEnabled = true;
            this.clb_passger.Location = new System.Drawing.Point(53, 100);
            this.clb_passger.MultiColumn = true;
            this.clb_passger.Name = "clb_passger";
            this.clb_passger.Size = new System.Drawing.Size(737, 16);
            this.clb_passger.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 30;
            this.label9.Text = "车型";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 31;
            this.label10.Text = "席别";
            // 
            // clb_trainType
            // 
            this.clb_trainType.BackColor = System.Drawing.Color.Silver;
            this.clb_trainType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clb_trainType.CheckOnClick = true;
            this.clb_trainType.ColumnWidth = 60;
            this.clb_trainType.FormattingEnabled = true;
            this.clb_trainType.Location = new System.Drawing.Point(101, 40);
            this.clb_trainType.MultiColumn = true;
            this.clb_trainType.Name = "clb_trainType";
            this.clb_trainType.Size = new System.Drawing.Size(671, 16);
            this.clb_trainType.TabIndex = 32;
            // 
            // clb_seatType
            // 
            this.clb_seatType.BackColor = System.Drawing.Color.Silver;
            this.clb_seatType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clb_seatType.CheckOnClick = true;
            this.clb_seatType.ColumnWidth = 60;
            this.clb_seatType.FormattingEnabled = true;
            this.clb_seatType.Location = new System.Drawing.Point(100, 66);
            this.clb_seatType.MultiColumn = true;
            this.clb_seatType.Name = "clb_seatType";
            this.clb_seatType.Size = new System.Drawing.Size(672, 16);
            this.clb_seatType.TabIndex = 33;
            // 
            // cbx_autoQuery
            // 
            this.cbx_autoQuery.AutoSize = true;
            this.cbx_autoQuery.ForeColor = System.Drawing.Color.Red;
            this.cbx_autoQuery.Location = new System.Drawing.Point(7, 17);
            this.cbx_autoQuery.Name = "cbx_autoQuery";
            this.cbx_autoQuery.Size = new System.Drawing.Size(72, 16);
            this.cbx_autoQuery.TabIndex = 34;
            this.cbx_autoQuery.Text = "自动查询";
            this.cbx_autoQuery.UseVisualStyleBackColor = true;
            // 
            // cbx_autoOrder
            // 
            this.cbx_autoOrder.AutoSize = true;
            this.cbx_autoOrder.ForeColor = System.Drawing.Color.Red;
            this.cbx_autoOrder.Location = new System.Drawing.Point(7, 42);
            this.cbx_autoOrder.Name = "cbx_autoOrder";
            this.cbx_autoOrder.Size = new System.Drawing.Size(72, 16);
            this.cbx_autoOrder.TabIndex = 35;
            this.cbx_autoOrder.Text = "自动提交";
            this.cbx_autoOrder.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "车次优先",
            "座位优先"});
            this.comboBox1.Location = new System.Drawing.Point(81, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(61, 20);
            this.comboBox1.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 36;
            this.label6.Text = "乘客";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(279, 21);
            this.textBox1.TabIndex = 37;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_inteval);
            this.groupBox1.Controls.Add(this.cbx_autoQuery);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btn_query);
            this.groupBox1.Controls.Add(this.cbx_autoOrder);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(805, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 91);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作功能";
            // 
            // txt_inteval
            // 
            this.txt_inteval.Location = new System.Drawing.Point(81, 14);
            this.txt_inteval.Name = "txt_inteval";
            this.txt_inteval.Size = new System.Drawing.Size(46, 21);
            this.txt_inteval.TabIndex = 38;
            this.txt_inteval.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_allSeatType);
            this.groupBox2.Controls.Add(this.cb_allTrainType);
            this.groupBox2.Controls.Add(this.dtp_date);
            this.groupBox2.Controls.Add(this.clb_trainType);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.clb_seatType);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cbx_from);
            this.groupBox2.Controls.Add(this.cbx_To);
            this.groupBox2.Controls.Add(this.cbx_time);
            this.groupBox2.Location = new System.Drawing.Point(12, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(778, 91);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询条件";
            // 
            // cb_allSeatType
            // 
            this.cb_allSeatType.AutoSize = true;
            this.cb_allSeatType.Checked = true;
            this.cb_allSeatType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allSeatType.Location = new System.Drawing.Point(41, 66);
            this.cb_allSeatType.Name = "cb_allSeatType";
            this.cb_allSeatType.Size = new System.Drawing.Size(48, 16);
            this.cb_allSeatType.TabIndex = 36;
            this.cb_allSeatType.Text = "全部";
            this.cb_allSeatType.UseVisualStyleBackColor = true;
            this.cb_allSeatType.Click += new System.EventHandler(this.cb_allSeatType_Click);
            // 
            // cb_allTrainType
            // 
            this.cb_allTrainType.AutoSize = true;
            this.cb_allTrainType.Checked = true;
            this.cb_allTrainType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_allTrainType.Location = new System.Drawing.Point(42, 40);
            this.cb_allTrainType.Name = "cb_allTrainType";
            this.cb_allTrainType.Size = new System.Drawing.Size(48, 16);
            this.cb_allTrainType.TabIndex = 35;
            this.cb_allTrainType.Text = "全部";
            this.cb_allTrainType.UseVisualStyleBackColor = true;
            this.cb_allTrainType.Click += new System.EventHandler(this.cb_allTrainType_Click);
            // 
            // dtp_date
            // 
            this.dtp_date.CustomFormat = "yyyy-MM-dd";
            this.dtp_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_date.Location = new System.Drawing.Point(368, 14);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.Size = new System.Drawing.Size(113, 21);
            this.dtp_date.TabIndex = 34;
            this.dtp_date.Value = new System.DateTime(2014, 1, 11, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(892, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "验证码";
            // 
            // pic_OrderRandCode
            // 
            this.pic_OrderRandCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_OrderRandCode.Location = new System.Drawing.Point(1000, 23);
            this.pic_OrderRandCode.Name = "pic_OrderRandCode";
            this.pic_OrderRandCode.Size = new System.Drawing.Size(72, 25);
            this.pic_OrderRandCode.TabIndex = 11;
            this.pic_OrderRandCode.TabStop = false;
            // 
            // txt_OrderRandCode
            // 
            this.txt_OrderRandCode.Location = new System.Drawing.Point(932, 25);
            this.txt_OrderRandCode.Name = "txt_OrderRandCode";
            this.txt_OrderRandCode.Size = new System.Drawing.Size(64, 21);
            this.txt_OrderRandCode.TabIndex = 10;
            this.txt_OrderRandCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_OrderRandCode_KeyUp);
            // 
            // lbl_serverTime
            // 
            this.lbl_serverTime.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_serverTime.ForeColor = System.Drawing.Color.Red;
            this.lbl_serverTime.Location = new System.Drawing.Point(714, 17);
            this.lbl_serverTime.Name = "lbl_serverTime";
            this.lbl_serverTime.Size = new System.Drawing.Size(179, 39);
            this.lbl_serverTime.TabIndex = 28;
            this.lbl_serverTime.Text = "00:00:00";
            // 
            // lbl_queryTimes
            // 
            this.lbl_queryTimes.AutoSize = true;
            this.lbl_queryTimes.Location = new System.Drawing.Point(646, 40);
            this.lbl_queryTimes.Name = "lbl_queryTimes";
            this.lbl_queryTimes.Size = new System.Drawing.Size(53, 12);
            this.lbl_queryTimes.TabIndex = 30;
            this.lbl_queryTimes.Text = "查询次数";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Silver;
            this.groupBox3.Controls.Add(this.cbx_showCanOrder);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lbl_orderInfo);
            this.groupBox3.Controls.Add(this.lbl_queryTimes);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.lbl_serverTime);
            this.groupBox3.Controls.Add(this.pic_OrderRandCode);
            this.groupBox3.Controls.Add(this.txt_OrderRandCode);
            this.groupBox3.Location = new System.Drawing.Point(14, 120);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1083, 60);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "预订信息";
            // 
            // cbx_showCanOrder
            // 
            this.cbx_showCanOrder.AutoSize = true;
            this.cbx_showCanOrder.Location = new System.Drawing.Point(7, 41);
            this.cbx_showCanOrder.Name = "cbx_showCanOrder";
            this.cbx_showCanOrder.Size = new System.Drawing.Size(108, 16);
            this.cbx_showCanOrder.TabIndex = 35;
            this.cbx_showCanOrder.Text = "显示可预订车次";
            this.cbx_showCanOrder.UseVisualStyleBackColor = true;
            this.cbx_showCanOrder.CheckedChanged += new System.EventHandler(this.cbx_showCanOrder_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(646, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 34;
            this.label7.Text = "12306时间";
            // 
            // lbl_orderInfo
            // 
            this.lbl_orderInfo.AutoSize = true;
            this.lbl_orderInfo.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_orderInfo.ForeColor = System.Drawing.Color.Red;
            this.lbl_orderInfo.Location = new System.Drawing.Point(2, 17);
            this.lbl_orderInfo.Name = "lbl_orderInfo";
            this.lbl_orderInfo.Size = new System.Drawing.Size(89, 19);
            this.lbl_orderInfo.TabIndex = 33;
            this.lbl_orderInfo.Text = "00:00:00";
            // 
            // lbl_passagerMsg
            // 
            this.lbl_passagerMsg.AutoSize = true;
            this.lbl_passagerMsg.ForeColor = System.Drawing.Color.Red;
            this.lbl_passagerMsg.Location = new System.Drawing.Point(803, 105);
            this.lbl_passagerMsg.Name = "lbl_passagerMsg";
            this.lbl_passagerMsg.Size = new System.Drawing.Size(23, 12);
            this.lbl_passagerMsg.TabIndex = 42;
            this.lbl_passagerMsg.Text = "msg";
            // 
            // OTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1108, 748);
            this.Controls.Add(this.lbl_passagerMsg);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.clb_passger);
            this.Controls.Add(this.gv_train);
            this.Controls.Add(this.lbl_refreshTime);
            this.Controls.Add(this.rtb_log);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "OTS";
            this.Text = "OTS";
            this.Load += new System.EventHandler(this.OTS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_train)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inteval)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_OrderRandCode)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.RichTextBox rtb_log;
        private System.Windows.Forms.Label lbl_refreshTime;
        private System.Windows.Forms.DataGridView gv_train;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbx_from;
        private System.Windows.Forms.ComboBox cbx_To;
        private System.Windows.Forms.ComboBox cbx_time;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox clb_passger;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckedListBox clb_trainType;
        private System.Windows.Forms.CheckedListBox clb_seatType;
        private System.Windows.Forms.CheckBox cbx_autoQuery;
        private System.Windows.Forms.CheckBox cbx_autoOrder;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pic_OrderRandCode;
        private System.Windows.Forms.TextBox txt_OrderRandCode;
        private System.Windows.Forms.Label lbl_serverTime;
        private System.Windows.Forms.Label lbl_queryTimes;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_orderInfo;
        private System.Windows.Forms.NumericUpDown txt_inteval;
        private System.Windows.Forms.DateTimePicker dtp_date;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbx_showCanOrder;
        private System.Windows.Forms.Label lbl_passagerMsg;
        private System.Windows.Forms.CheckBox cb_allTrainType;
        private System.Windows.Forms.CheckBox cb_allSeatType;
        private System.Windows.Forms.DataGridViewLinkColumn train;
        private System.Windows.Forms.DataGridViewTextBoxColumn from;
        private System.Windows.Forms.DataGridViewTextBoxColumn to;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrive_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn lishi;
        private System.Windows.Forms.DataGridViewTextBoxColumn yw_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn yz_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn rw_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn rz_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn ze_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn gr_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn tz_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn wz_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn zy_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn swz_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn qt_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn trainNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn toCode;
        private System.Windows.Forms.DataGridViewButtonColumn buttonTextInfo;
    }
}