namespace SimplePerfChart
{
    partial class FrmTestingForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            SpPerfChart.ChartPen chartPen1 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen2 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen3 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen4 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen5 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen6 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen7 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen8 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen9 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen10 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen11 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen12 = new SpPerfChart.ChartPen();
            this.grpBxChart = new System.Windows.Forms.GroupBox();
            this.perfChart = new SpPerfChart.PerfChart();
            this.grpBxRandVal = new System.Windows.Forms.GroupBox();
            this.chkBxTimerEnabled = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numUpDnToInterval = new System.Windows.Forms.NumericUpDown();
            this.numUpDnFromInterval = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpBxValueGen = new System.Windows.Forms.GroupBox();
            this.numUpDnValTo = new System.Windows.Forms.NumericUpDown();
            this.numUpDnValFrom = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numUpDnTimerInterval = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbBxTimerMode = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbBxScaleMode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBxBorder = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.propGrid = new System.Windows.Forms.PropertyGrid();
            this.bgWrkTimer = new System.ComponentModel.BackgroundWorker();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.perfChart1 = new SpPerfChart.PerfChart();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.perfChart2 = new SpPerfChart.PerfChart();
            this.grpBxChart.SuspendLayout();
            this.grpBxRandVal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnToInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnFromInterval)).BeginInit();
            this.grpBxValueGen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnValTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnValFrom)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnTimerInterval)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBxChart
            // 
            this.grpBxChart.Controls.Add(this.perfChart);
            this.grpBxChart.Location = new System.Drawing.Point(12, 12);
            this.grpBxChart.Name = "grpBxChart";
            this.grpBxChart.Padding = new System.Windows.Forms.Padding(6);
            this.grpBxChart.Size = new System.Drawing.Size(259, 141);
            this.grpBxChart.TabIndex = 0;
            this.grpBxChart.TabStop = false;
            this.grpBxChart.Text = "X Axis";
            // 
            // perfChart
            // 
            this.perfChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.perfChart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.perfChart.Location = new System.Drawing.Point(6, 19);
            this.perfChart.Name = "perfChart";
            this.perfChart.PerfChartStyle.AntiAliasing = true;
            chartPen1.Color = System.Drawing.Color.LightGreen;
            chartPen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            chartPen1.Width = 1F;
            this.perfChart.PerfChartStyle.AvgLinePen = chartPen1;
            this.perfChart.PerfChartStyle.BackgroundColorBottom = System.Drawing.Color.DarkOliveGreen;
            this.perfChart.PerfChartStyle.BackgroundColorTop = System.Drawing.Color.YellowGreen;
            chartPen2.Color = System.Drawing.Color.Gold;
            chartPen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen2.Width = 1F;
            this.perfChart.PerfChartStyle.ChartLinePen = chartPen2;
            chartPen3.Color = System.Drawing.Color.DarkOliveGreen;
            chartPen3.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartPen3.Width = 1F;
            this.perfChart.PerfChartStyle.HorizontalGridPen = chartPen3;
            this.perfChart.PerfChartStyle.ShowAverageLine = true;
            this.perfChart.PerfChartStyle.ShowHorizontalGridLines = true;
            this.perfChart.PerfChartStyle.ShowVerticalGridLines = true;
            chartPen4.Color = System.Drawing.Color.DarkOliveGreen;
            chartPen4.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartPen4.Width = 1F;
            this.perfChart.PerfChartStyle.VerticalGridPen = chartPen4;
            this.perfChart.ScaleMode = SpPerfChart.ScaleMode.Relative;
            this.perfChart.Size = new System.Drawing.Size(247, 116);
            this.perfChart.TabIndex = 0;
            this.perfChart.TimerInterval = 100;
            this.perfChart.TimerMode = SpPerfChart.TimerMode.Disabled;
            this.perfChart.Load += new System.EventHandler(this.perfChart_Load);
            // 
            // grpBxRandVal
            // 
            this.grpBxRandVal.Controls.Add(this.chkBxTimerEnabled);
            this.grpBxRandVal.Controls.Add(this.label5);
            this.grpBxRandVal.Controls.Add(this.numUpDnToInterval);
            this.grpBxRandVal.Controls.Add(this.numUpDnFromInterval);
            this.grpBxRandVal.Controls.Add(this.label3);
            this.grpBxRandVal.Controls.Add(this.label2);
            this.grpBxRandVal.Location = new System.Drawing.Point(542, 237);
            this.grpBxRandVal.Name = "grpBxRandVal";
            this.grpBxRandVal.Size = new System.Drawing.Size(259, 90);
            this.grpBxRandVal.TabIndex = 1;
            this.grpBxRandVal.TabStop = false;
            this.grpBxRandVal.Text = "Value Generator Timer";
            // 
            // chkBxTimerEnabled
            // 
            this.chkBxTimerEnabled.AutoSize = true;
            this.chkBxTimerEnabled.Location = new System.Drawing.Point(16, 55);
            this.chkBxTimerEnabled.Name = "chkBxTimerEnabled";
            this.chkBxTimerEnabled.Size = new System.Drawing.Size(94, 17);
            this.chkBxTimerEnabled.TabIndex = 7;
            this.chkBxTimerEnabled.Text = "Timer Enabled";
            this.chkBxTimerEnabled.UseVisualStyleBackColor = true;
            this.chkBxTimerEnabled.CheckedChanged += new System.EventHandler(this.chkBxTimerEnabled_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(210, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "ms";
            // 
            // numUpDnToInterval
            // 
            this.numUpDnToInterval.Location = new System.Drawing.Point(139, 22);
            this.numUpDnToInterval.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numUpDnToInterval.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numUpDnToInterval.Name = "numUpDnToInterval";
            this.numUpDnToInterval.Size = new System.Drawing.Size(65, 20);
            this.numUpDnToInterval.TabIndex = 5;
            this.numUpDnToInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numUpDnFromInterval
            // 
            this.numUpDnFromInterval.Location = new System.Drawing.Point(46, 22);
            this.numUpDnFromInterval.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numUpDnFromInterval.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numUpDnFromInterval.Name = "numUpDnFromInterval";
            this.numUpDnFromInterval.Size = new System.Drawing.Size(65, 20);
            this.numUpDnFromInterval.TabIndex = 3;
            this.numUpDnFromInterval.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "to";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "from";
            // 
            // grpBxValueGen
            // 
            this.grpBxValueGen.Controls.Add(this.numUpDnValTo);
            this.grpBxValueGen.Controls.Add(this.numUpDnValFrom);
            this.grpBxValueGen.Controls.Add(this.label4);
            this.grpBxValueGen.Controls.Add(this.label6);
            this.grpBxValueGen.Location = new System.Drawing.Point(542, 333);
            this.grpBxValueGen.Name = "grpBxValueGen";
            this.grpBxValueGen.Size = new System.Drawing.Size(259, 68);
            this.grpBxValueGen.TabIndex = 2;
            this.grpBxValueGen.TabStop = false;
            this.grpBxValueGen.Text = "Generated Values";
            // 
            // numUpDnValTo
            // 
            this.numUpDnValTo.Location = new System.Drawing.Point(139, 22);
            this.numUpDnValTo.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numUpDnValTo.Name = "numUpDnValTo";
            this.numUpDnValTo.Size = new System.Drawing.Size(65, 20);
            this.numUpDnValTo.TabIndex = 10;
            this.numUpDnValTo.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numUpDnValFrom
            // 
            this.numUpDnValFrom.Location = new System.Drawing.Point(46, 22);
            this.numUpDnValFrom.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numUpDnValFrom.Name = "numUpDnValFrom";
            this.numUpDnValFrom.Size = new System.Drawing.Size(65, 20);
            this.numUpDnValFrom.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "to";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "from";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.numUpDnTimerInterval);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbBxTimerMode);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbBxScaleMode);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbBxBorder);
            this.groupBox1.Location = new System.Drawing.Point(277, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 141);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Engine Properties";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(162, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "ms";
            // 
            // numUpDnTimerInterval
            // 
            this.numUpDnTimerInterval.Location = new System.Drawing.Point(91, 99);
            this.numUpDnTimerInterval.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numUpDnTimerInterval.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numUpDnTimerInterval.Name = "numUpDnTimerInterval";
            this.numUpDnTimerInterval.Size = new System.Drawing.Size(65, 20);
            this.numUpDnTimerInterval.TabIndex = 7;
            this.numUpDnTimerInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpDnTimerInterval.ValueChanged += new System.EventHandler(this.numUpDnTimerInterval_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "TimerInterval";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "TimerMode";
            // 
            // cmbBxTimerMode
            // 
            this.cmbBxTimerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxTimerMode.FormattingEnabled = true;
            this.cmbBxTimerMode.Location = new System.Drawing.Point(91, 72);
            this.cmbBxTimerMode.Name = "cmbBxTimerMode";
            this.cmbBxTimerMode.Size = new System.Drawing.Size(162, 21);
            this.cmbBxTimerMode.TabIndex = 4;
            this.cmbBxTimerMode.SelectedIndexChanged += new System.EventHandler(this.cmbBxTimerMode_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "ScaleMode";
            // 
            // cmbBxScaleMode
            // 
            this.cmbBxScaleMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxScaleMode.FormattingEnabled = true;
            this.cmbBxScaleMode.Location = new System.Drawing.Point(91, 45);
            this.cmbBxScaleMode.Name = "cmbBxScaleMode";
            this.cmbBxScaleMode.Size = new System.Drawing.Size(162, 21);
            this.cmbBxScaleMode.TabIndex = 2;
            this.cmbBxScaleMode.SelectedIndexChanged += new System.EventHandler(this.cmbBxScaleMode_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "BorderStyle";
            // 
            // cmbBxBorder
            // 
            this.cmbBxBorder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxBorder.FormattingEnabled = true;
            this.cmbBxBorder.Location = new System.Drawing.Point(91, 18);
            this.cmbBxBorder.Name = "cmbBxBorder";
            this.cmbBxBorder.Size = new System.Drawing.Size(162, 21);
            this.cmbBxBorder.TabIndex = 0;
            this.cmbBxBorder.SelectedIndexChanged += new System.EventHandler(this.cmbBxBorder_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.propGrid);
            this.groupBox2.Location = new System.Drawing.Point(277, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(259, 164);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Style Properties";
            // 
            // propGrid
            // 
            this.propGrid.CommandsVisibleIfAvailable = false;
            this.propGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propGrid.HelpVisible = false;
            this.propGrid.Location = new System.Drawing.Point(6, 19);
            this.propGrid.Name = "propGrid";
            this.propGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propGrid.SelectedObject = this.perfChart;
            this.propGrid.Size = new System.Drawing.Size(247, 139);
            this.propGrid.TabIndex = 0;
            this.propGrid.ToolbarVisible = false;
            // 
            // bgWrkTimer
            // 
            this.bgWrkTimer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWrkTimer_DoWork);
            this.bgWrkTimer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWrkTimer_RunWorkerCompleted);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(461, 329);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "&Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(384, 329);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(591, 30);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 18;
            this.gMapControl1.MinZoom = 0;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(197, 201);
            this.gMapControl1.TabIndex = 7;
            this.gMapControl1.Zoom = 15D;
            this.gMapControl1.Load += new System.EventHandler(this.gMapControl1_Load);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.perfChart1);
            this.groupBox3.Location = new System.Drawing.Point(12, 153);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(259, 141);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Y Axis";
            // 
            // perfChart1
            // 
            this.perfChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.perfChart1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.perfChart1.Location = new System.Drawing.Point(6, 19);
            this.perfChart1.Name = "perfChart1";
            this.perfChart1.PerfChartStyle.AntiAliasing = true;
            chartPen5.Color = System.Drawing.Color.LightGreen;
            chartPen5.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            chartPen5.Width = 1F;
            this.perfChart1.PerfChartStyle.AvgLinePen = chartPen5;
            this.perfChart1.PerfChartStyle.BackgroundColorBottom = System.Drawing.Color.DarkOliveGreen;
            this.perfChart1.PerfChartStyle.BackgroundColorTop = System.Drawing.Color.YellowGreen;
            chartPen6.Color = System.Drawing.Color.Gold;
            chartPen6.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen6.Width = 1F;
            this.perfChart1.PerfChartStyle.ChartLinePen = chartPen6;
            chartPen7.Color = System.Drawing.Color.DarkOliveGreen;
            chartPen7.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartPen7.Width = 1F;
            this.perfChart1.PerfChartStyle.HorizontalGridPen = chartPen7;
            this.perfChart1.PerfChartStyle.ShowAverageLine = true;
            this.perfChart1.PerfChartStyle.ShowHorizontalGridLines = true;
            this.perfChart1.PerfChartStyle.ShowVerticalGridLines = true;
            chartPen8.Color = System.Drawing.Color.DarkOliveGreen;
            chartPen8.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartPen8.Width = 1F;
            this.perfChart1.PerfChartStyle.VerticalGridPen = chartPen8;
            this.perfChart1.ScaleMode = SpPerfChart.ScaleMode.Relative;
            this.perfChart1.Size = new System.Drawing.Size(247, 116);
            this.perfChart1.TabIndex = 0;
            this.perfChart1.TimerInterval = 100;
            this.perfChart1.TimerMode = SpPerfChart.TimerMode.Disabled;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.perfChart2);
            this.groupBox4.Location = new System.Drawing.Point(12, 300);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox4.Size = new System.Drawing.Size(259, 141);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Z Axis";
            // 
            // perfChart2
            // 
            this.perfChart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.perfChart2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.perfChart2.Location = new System.Drawing.Point(6, 19);
            this.perfChart2.Name = "perfChart2";
            this.perfChart2.PerfChartStyle.AntiAliasing = true;
            chartPen9.Color = System.Drawing.Color.LightGreen;
            chartPen9.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            chartPen9.Width = 1F;
            this.perfChart2.PerfChartStyle.AvgLinePen = chartPen9;
            this.perfChart2.PerfChartStyle.BackgroundColorBottom = System.Drawing.Color.DarkOliveGreen;
            this.perfChart2.PerfChartStyle.BackgroundColorTop = System.Drawing.Color.YellowGreen;
            chartPen10.Color = System.Drawing.Color.Gold;
            chartPen10.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen10.Width = 1F;
            this.perfChart2.PerfChartStyle.ChartLinePen = chartPen10;
            chartPen11.Color = System.Drawing.Color.DarkOliveGreen;
            chartPen11.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartPen11.Width = 1F;
            this.perfChart2.PerfChartStyle.HorizontalGridPen = chartPen11;
            this.perfChart2.PerfChartStyle.ShowAverageLine = true;
            this.perfChart2.PerfChartStyle.ShowHorizontalGridLines = true;
            this.perfChart2.PerfChartStyle.ShowVerticalGridLines = true;
            chartPen12.Color = System.Drawing.Color.DarkOliveGreen;
            chartPen12.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartPen12.Width = 1F;
            this.perfChart2.PerfChartStyle.VerticalGridPen = chartPen12;
            this.perfChart2.ScaleMode = SpPerfChart.ScaleMode.Relative;
            this.perfChart2.Size = new System.Drawing.Size(247, 116);
            this.perfChart2.TabIndex = 0;
            this.perfChart2.TimerInterval = 100;
            this.perfChart2.TimerMode = SpPerfChart.TimerMode.Disabled;
            // 
            // FrmTestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 526);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gMapControl1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpBxValueGen);
            this.Controls.Add(this.grpBxRandVal);
            this.Controls.Add(this.grpBxChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmTestingForm";
            this.Text = "Earthquake Catcher Network";
            this.Load += new System.EventHandler(this.FrmTestingForm_Load);
            this.grpBxChart.ResumeLayout(false);
            this.grpBxRandVal.ResumeLayout(false);
            this.grpBxRandVal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnToInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnFromInterval)).EndInit();
            this.grpBxValueGen.ResumeLayout(false);
            this.grpBxValueGen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnValTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnValFrom)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnTimerInterval)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBxChart;
        private SpPerfChart.PerfChart perfChart;
        private System.Windows.Forms.GroupBox grpBxRandVal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numUpDnToInterval;
        private System.Windows.Forms.NumericUpDown numUpDnFromInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpBxValueGen;
        private System.Windows.Forms.NumericUpDown numUpDnValTo;
        private System.Windows.Forms.NumericUpDown numUpDnValFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PropertyGrid propGrid;
        private System.Windows.Forms.CheckBox chkBxTimerEnabled;
        private System.ComponentModel.BackgroundWorker bgWrkTimer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numUpDnTimerInterval;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbBxTimerMode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbBxScaleMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbBxBorder;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnClear;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.GroupBox groupBox3;
        private SpPerfChart.PerfChart perfChart1;
        private System.Windows.Forms.GroupBox groupBox4;
        private SpPerfChart.PerfChart perfChart2;
    }
}