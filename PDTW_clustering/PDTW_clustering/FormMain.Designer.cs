namespace PDTW_clustering
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.gbxDimRed = new System.Windows.Forms.GroupBox();
            this.gbPaaParams = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudCompressionRate = new System.Windows.Forms.NumericUpDown();
            this.radDimRed_Paa = new System.Windows.Forms.RadioButton();
            this.radDimRed_Disabled = new System.Windows.Forms.RadioButton();
            this.gbxClusteringAlgo = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkAutoNoOfClusters = new System.Windows.Forms.CheckBox();
            this.gbDensityPeaksParams = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNeighborPercentage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudDPParams_Min = new System.Windows.Forms.NumericUpDown();
            this.nudDPParams_Max = new System.Windows.Forms.NumericUpDown();
            this.nudNoOfClusters = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.radClusterAlgo_DensityPeaks = new System.Windows.Forms.RadioButton();
            this.radClusterAlgo_ImpKMedoids = new System.Windows.Forms.RadioButton();
            this.gbxMultithreading = new System.Windows.Forms.GroupBox();
            this.radMultithreading_Disabled = new System.Windows.Forms.RadioButton();
            this.radMultithreading_Enabled = new System.Windows.Forms.RadioButton();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnViewResult = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblExeTimeLabel = new System.Windows.Forms.Label();
            this.lblExeTimeValue = new System.Windows.Forms.Label();
            this.pgbDoClustering = new System.Windows.Forms.ProgressBar();
            this.tmrExeTime = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radNormalization_ZeroMean = new System.Windows.Forms.RadioButton();
            this.radNormalization_MinMax = new System.Windows.Forms.RadioButton();
            this.radNormalization_None = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.gbxDimRed.SuspendLayout();
            this.gbPaaParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompressionRate)).BeginInit();
            this.gbxClusteringAlgo.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gbDensityPeaksParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDPParams_Min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDPParams_Max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoOfClusters)).BeginInit();
            this.gbxMultithreading.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(625, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "&Data";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadToolStripMenuItem.Image")));
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "&Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewToolStripMenuItem.Image")));
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.viewToolStripMenuItem.Text = "&View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(97, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guideToolStripMenuItem,
            this.toolStripMenuItem2,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // guideToolStripMenuItem
            // 
            this.guideToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("guideToolStripMenuItem.Image")));
            this.guideToolStripMenuItem.Name = "guideToolStripMenuItem";
            this.guideToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.guideToolStripMenuItem.Text = "&Guide";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(104, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // gbxDimRed
            // 
            this.gbxDimRed.Controls.Add(this.gbPaaParams);
            this.gbxDimRed.Controls.Add(this.radDimRed_Paa);
            this.gbxDimRed.Controls.Add(this.radDimRed_Disabled);
            this.gbxDimRed.Location = new System.Drawing.Point(20, 139);
            this.gbxDimRed.Name = "gbxDimRed";
            this.gbxDimRed.Size = new System.Drawing.Size(236, 115);
            this.gbxDimRed.TabIndex = 3;
            this.gbxDimRed.TabStop = false;
            this.gbxDimRed.Text = "Dimensionality Reduction";
            // 
            // gbPaaParams
            // 
            this.gbPaaParams.Controls.Add(this.label1);
            this.gbPaaParams.Controls.Add(this.nudCompressionRate);
            this.gbPaaParams.Location = new System.Drawing.Point(21, 42);
            this.gbPaaParams.Name = "gbPaaParams";
            this.gbPaaParams.Size = new System.Drawing.Size(194, 58);
            this.gbPaaParams.TabIndex = 2;
            this.gbPaaParams.TabStop = false;
            this.gbPaaParams.Text = "Parameters";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Compression rate";
            // 
            // nudCompressionRate
            // 
            this.nudCompressionRate.Location = new System.Drawing.Point(125, 23);
            this.nudCompressionRate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCompressionRate.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudCompressionRate.Name = "nudCompressionRate";
            this.nudCompressionRate.Size = new System.Drawing.Size(50, 20);
            this.nudCompressionRate.TabIndex = 1;
            this.nudCompressionRate.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // radDimRed_Paa
            // 
            this.radDimRed_Paa.AutoSize = true;
            this.radDimRed_Paa.Checked = true;
            this.radDimRed_Paa.Location = new System.Drawing.Point(137, 19);
            this.radDimRed_Paa.Name = "radDimRed_Paa";
            this.radDimRed_Paa.Size = new System.Drawing.Size(46, 17);
            this.radDimRed_Paa.TabIndex = 1;
            this.radDimRed_Paa.TabStop = true;
            this.radDimRed_Paa.Text = "PAA";
            this.radDimRed_Paa.UseVisualStyleBackColor = true;
            this.radDimRed_Paa.CheckedChanged += new System.EventHandler(this.radDimRed_Paa_CheckedChanged);
            // 
            // radDimRed_Disabled
            // 
            this.radDimRed_Disabled.AutoSize = true;
            this.radDimRed_Disabled.Location = new System.Drawing.Point(30, 19);
            this.radDimRed_Disabled.Name = "radDimRed_Disabled";
            this.radDimRed_Disabled.Size = new System.Drawing.Size(66, 17);
            this.radDimRed_Disabled.TabIndex = 0;
            this.radDimRed_Disabled.Text = "Disabled";
            this.radDimRed_Disabled.UseVisualStyleBackColor = true;
            // 
            // gbxClusteringAlgo
            // 
            this.gbxClusteringAlgo.Controls.Add(this.groupBox5);
            this.gbxClusteringAlgo.Controls.Add(this.radClusterAlgo_DensityPeaks);
            this.gbxClusteringAlgo.Controls.Add(this.radClusterAlgo_ImpKMedoids);
            this.gbxClusteringAlgo.Location = new System.Drawing.Point(283, 27);
            this.gbxClusteringAlgo.Name = "gbxClusteringAlgo";
            this.gbxClusteringAlgo.Size = new System.Drawing.Size(318, 204);
            this.gbxClusteringAlgo.TabIndex = 4;
            this.gbxClusteringAlgo.TabStop = false;
            this.gbxClusteringAlgo.Text = "Clustering Algorithm";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkAutoNoOfClusters);
            this.groupBox5.Controls.Add(this.gbDensityPeaksParams);
            this.groupBox5.Controls.Add(this.nudNoOfClusters);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(17, 42);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(281, 143);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Parameters";
            // 
            // chkAutoNoOfClusters
            // 
            this.chkAutoNoOfClusters.AutoSize = true;
            this.chkAutoNoOfClusters.Location = new System.Drawing.Point(210, 24);
            this.chkAutoNoOfClusters.Name = "chkAutoNoOfClusters";
            this.chkAutoNoOfClusters.Size = new System.Drawing.Size(48, 17);
            this.chkAutoNoOfClusters.TabIndex = 3;
            this.chkAutoNoOfClusters.Text = "Auto";
            this.chkAutoNoOfClusters.UseVisualStyleBackColor = true;
            this.chkAutoNoOfClusters.Visible = false;
            this.chkAutoNoOfClusters.CheckedChanged += new System.EventHandler(this.chkAutoNoOfClusters_CheckedChanged);
            // 
            // gbDensityPeaksParams
            // 
            this.gbDensityPeaksParams.Controls.Add(this.label4);
            this.gbDensityPeaksParams.Controls.Add(this.lblNeighborPercentage);
            this.gbDensityPeaksParams.Controls.Add(this.label3);
            this.gbDensityPeaksParams.Controls.Add(this.nudDPParams_Min);
            this.gbDensityPeaksParams.Controls.Add(this.nudDPParams_Max);
            this.gbDensityPeaksParams.Location = new System.Drawing.Point(21, 47);
            this.gbDensityPeaksParams.Name = "gbDensityPeaksParams";
            this.gbDensityPeaksParams.Size = new System.Drawing.Size(237, 79);
            this.gbDensityPeaksParams.TabIndex = 2;
            this.gbDensityPeaksParams.TabStop = false;
            this.gbDensityPeaksParams.Text = "Density Peaks Parameters";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Max";
            // 
            // lblNeighborPercentage
            // 
            this.lblNeighborPercentage.AutoSize = true;
            this.lblNeighborPercentage.Location = new System.Drawing.Point(17, 23);
            this.lblNeighborPercentage.Name = "lblNeighborPercentage";
            this.lblNeighborPercentage.Size = new System.Drawing.Size(197, 13);
            this.lblNeighborPercentage.TabIndex = 0;
            this.lblNeighborPercentage.Text = "Percentage of average neighbor objects";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Min";
            // 
            // nudDPParams_Min
            // 
            this.nudDPParams_Min.Location = new System.Drawing.Point(54, 42);
            this.nudDPParams_Min.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDPParams_Min.Name = "nudDPParams_Min";
            this.nudDPParams_Min.Size = new System.Drawing.Size(50, 20);
            this.nudDPParams_Min.TabIndex = 2;
            this.nudDPParams_Min.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDPParams_Min.ValueChanged += new System.EventHandler(this.nudDPParams_Min_ValueChanged);
            // 
            // nudDPParams_Max
            // 
            this.nudDPParams_Max.Location = new System.Drawing.Point(152, 42);
            this.nudDPParams_Max.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudDPParams_Max.Name = "nudDPParams_Max";
            this.nudDPParams_Max.Size = new System.Drawing.Size(50, 20);
            this.nudDPParams_Max.TabIndex = 4;
            this.nudDPParams_Max.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudDPParams_Max.ValueChanged += new System.EventHandler(this.nudDPParams_Max_ValueChanged);
            // 
            // nudNoOfClusters
            // 
            this.nudNoOfClusters.Location = new System.Drawing.Point(143, 21);
            this.nudNoOfClusters.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudNoOfClusters.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudNoOfClusters.Name = "nudNoOfClusters";
            this.nudNoOfClusters.Size = new System.Drawing.Size(50, 20);
            this.nudNoOfClusters.TabIndex = 1;
            this.nudNoOfClusters.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Number of clusters";
            // 
            // radClusterAlgo_DensityPeaks
            // 
            this.radClusterAlgo_DensityPeaks.AutoSize = true;
            this.radClusterAlgo_DensityPeaks.Location = new System.Drawing.Point(196, 19);
            this.radClusterAlgo_DensityPeaks.Name = "radClusterAlgo_DensityPeaks";
            this.radClusterAlgo_DensityPeaks.Size = new System.Drawing.Size(93, 17);
            this.radClusterAlgo_DensityPeaks.TabIndex = 1;
            this.radClusterAlgo_DensityPeaks.Text = "Density Peaks";
            this.radClusterAlgo_DensityPeaks.UseVisualStyleBackColor = true;
            this.radClusterAlgo_DensityPeaks.CheckedChanged += new System.EventHandler(this.radClusterAlgo_DensityPeaks_CheckedChanged);
            // 
            // radClusterAlgo_ImpKMedoids
            // 
            this.radClusterAlgo_ImpKMedoids.AutoSize = true;
            this.radClusterAlgo_ImpKMedoids.Checked = true;
            this.radClusterAlgo_ImpKMedoids.Location = new System.Drawing.Point(26, 19);
            this.radClusterAlgo_ImpKMedoids.Name = "radClusterAlgo_ImpKMedoids";
            this.radClusterAlgo_ImpKMedoids.Size = new System.Drawing.Size(121, 17);
            this.radClusterAlgo_ImpKMedoids.TabIndex = 0;
            this.radClusterAlgo_ImpKMedoids.TabStop = true;
            this.radClusterAlgo_ImpKMedoids.Text = "Improved K-medoids";
            this.radClusterAlgo_ImpKMedoids.UseVisualStyleBackColor = true;
            // 
            // gbxMultithreading
            // 
            this.gbxMultithreading.Controls.Add(this.radMultithreading_Disabled);
            this.gbxMultithreading.Controls.Add(this.radMultithreading_Enabled);
            this.gbxMultithreading.Location = new System.Drawing.Point(21, 35);
            this.gbxMultithreading.Name = "gbxMultithreading";
            this.gbxMultithreading.Size = new System.Drawing.Size(108, 74);
            this.gbxMultithreading.TabIndex = 1;
            this.gbxMultithreading.TabStop = false;
            this.gbxMultithreading.Text = "Multithreading";
            // 
            // radMultithreading_Disabled
            // 
            this.radMultithreading_Disabled.AutoSize = true;
            this.radMultithreading_Disabled.Location = new System.Drawing.Point(20, 19);
            this.radMultithreading_Disabled.Name = "radMultithreading_Disabled";
            this.radMultithreading_Disabled.Size = new System.Drawing.Size(66, 17);
            this.radMultithreading_Disabled.TabIndex = 0;
            this.radMultithreading_Disabled.TabStop = true;
            this.radMultithreading_Disabled.Text = "Disabled";
            this.radMultithreading_Disabled.UseVisualStyleBackColor = true;
            // 
            // radMultithreading_Enabled
            // 
            this.radMultithreading_Enabled.AutoSize = true;
            this.radMultithreading_Enabled.Checked = true;
            this.radMultithreading_Enabled.Location = new System.Drawing.Point(20, 42);
            this.radMultithreading_Enabled.Name = "radMultithreading_Enabled";
            this.radMultithreading_Enabled.Size = new System.Drawing.Size(64, 17);
            this.radMultithreading_Enabled.TabIndex = 1;
            this.radMultithreading_Enabled.TabStop = true;
            this.radMultithreading_Enabled.Text = "Enabled";
            this.radMultithreading_Enabled.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(19, 265);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(48, 23);
            this.btnRun.TabIndex = 5;
            this.btnRun.Text = "&Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(73, 265);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(48, 23);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "&Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnViewResult
            // 
            this.btnViewResult.Location = new System.Drawing.Point(127, 265);
            this.btnViewResult.Name = "btnViewResult";
            this.btnViewResult.Size = new System.Drawing.Size(74, 23);
            this.btnViewResult.TabIndex = 7;
            this.btnViewResult.Text = "&View result";
            this.btnViewResult.UseVisualStyleBackColor = true;
            this.btnViewResult.Click += new System.EventHandler(this.btnViewResult_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(207, 265);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(48, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblExeTimeLabel
            // 
            this.lblExeTimeLabel.AutoSize = true;
            this.lblExeTimeLabel.BackColor = System.Drawing.SystemColors.Control;
            this.lblExeTimeLabel.Location = new System.Drawing.Point(348, 241);
            this.lblExeTimeLabel.Name = "lblExeTimeLabel";
            this.lblExeTimeLabel.Size = new System.Drawing.Size(83, 13);
            this.lblExeTimeLabel.TabIndex = 9;
            this.lblExeTimeLabel.Text = "Execution Time:";
            // 
            // lblExeTimeValue
            // 
            this.lblExeTimeValue.AutoSize = true;
            this.lblExeTimeValue.Location = new System.Drawing.Point(440, 241);
            this.lblExeTimeValue.Name = "lblExeTimeValue";
            this.lblExeTimeValue.Size = new System.Drawing.Size(93, 13);
            this.lblExeTimeValue.TabIndex = 10;
            this.lblExeTimeValue.Text = "(exe_time_display)";
            // 
            // pgbDoClustering
            // 
            this.pgbDoClustering.Location = new System.Drawing.Point(283, 265);
            this.pgbDoClustering.Name = "pgbDoClustering";
            this.pgbDoClustering.Size = new System.Drawing.Size(318, 23);
            this.pgbDoClustering.TabIndex = 11;
            // 
            // tmrExeTime
            // 
            this.tmrExeTime.Interval = 1000;
            this.tmrExeTime.Tick += new System.EventHandler(this.tmrExeTime_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radNormalization_ZeroMean);
            this.groupBox1.Controls.Add(this.radNormalization_MinMax);
            this.groupBox1.Controls.Add(this.radNormalization_None);
            this.groupBox1.Location = new System.Drawing.Point(153, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(103, 90);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Normalization";
            // 
            // radNormalization_ZeroMean
            // 
            this.radNormalization_ZeroMean.AutoSize = true;
            this.radNormalization_ZeroMean.Location = new System.Drawing.Point(19, 65);
            this.radNormalization_ZeroMean.Name = "radNormalization_ZeroMean";
            this.radNormalization_ZeroMean.Size = new System.Drawing.Size(77, 17);
            this.radNormalization_ZeroMean.TabIndex = 2;
            this.radNormalization_ZeroMean.Text = "Zero Mean";
            this.radNormalization_ZeroMean.UseVisualStyleBackColor = true;
            // 
            // radNormalization_MinMax
            // 
            this.radNormalization_MinMax.AutoSize = true;
            this.radNormalization_MinMax.Location = new System.Drawing.Point(19, 42);
            this.radNormalization_MinMax.Name = "radNormalization_MinMax";
            this.radNormalization_MinMax.Size = new System.Drawing.Size(65, 17);
            this.radNormalization_MinMax.TabIndex = 1;
            this.radNormalization_MinMax.Text = "Min Max";
            this.radNormalization_MinMax.UseVisualStyleBackColor = true;
            // 
            // radNormalization_None
            // 
            this.radNormalization_None.AutoSize = true;
            this.radNormalization_None.Checked = true;
            this.radNormalization_None.Location = new System.Drawing.Point(19, 19);
            this.radNormalization_None.Name = "radNormalization_None";
            this.radNormalization_None.Size = new System.Drawing.Size(51, 17);
            this.radNormalization_None.TabIndex = 0;
            this.radNormalization_None.TabStop = true;
            this.radNormalization_None.Text = "None";
            this.radNormalization_None.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 311);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblExeTimeValue);
            this.Controls.Add(this.lblExeTimeLabel);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnViewResult);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.gbxMultithreading);
            this.Controls.Add(this.gbxClusteringAlgo);
            this.Controls.Add(this.gbxDimRed);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pgbDoClustering);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "PDTW Clustering";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbxDimRed.ResumeLayout(false);
            this.gbxDimRed.PerformLayout();
            this.gbPaaParams.ResumeLayout(false);
            this.gbPaaParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompressionRate)).EndInit();
            this.gbxClusteringAlgo.ResumeLayout(false);
            this.gbxClusteringAlgo.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gbDensityPeaksParams.ResumeLayout(false);
            this.gbDensityPeaksParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDPParams_Min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDPParams_Max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoOfClusters)).EndInit();
            this.gbxMultithreading.ResumeLayout(false);
            this.gbxMultithreading.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guideToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.GroupBox gbxDimRed;
        private System.Windows.Forms.RadioButton radDimRed_Paa;
        private System.Windows.Forms.RadioButton radDimRed_Disabled;
        private System.Windows.Forms.GroupBox gbxClusteringAlgo;
        private System.Windows.Forms.GroupBox gbPaaParams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudCompressionRate;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown nudNoOfClusters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radClusterAlgo_DensityPeaks;
        private System.Windows.Forms.RadioButton radClusterAlgo_ImpKMedoids;
        private System.Windows.Forms.GroupBox gbxMultithreading;
        private System.Windows.Forms.RadioButton radMultithreading_Disabled;
        private System.Windows.Forms.RadioButton radMultithreading_Enabled;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnViewResult;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblExeTimeLabel;
        private System.Windows.Forms.Label lblExeTimeValue;
        private System.Windows.Forms.ProgressBar pgbDoClustering;
        private System.Windows.Forms.Timer tmrExeTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radNormalization_ZeroMean;
        private System.Windows.Forms.RadioButton radNormalization_MinMax;
        private System.Windows.Forms.RadioButton radNormalization_None;
        private System.Windows.Forms.GroupBox gbDensityPeaksParams;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNeighborPercentage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudDPParams_Min;
        private System.Windows.Forms.NumericUpDown nudDPParams_Max;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.CheckBox chkAutoNoOfClusters;
    }
}

