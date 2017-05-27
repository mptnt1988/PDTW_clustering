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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.gbxDimRed = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudCompressionRate = new System.Windows.Forms.NumericUpDown();
            this.radDimRed_Paa = new System.Windows.Forms.RadioButton();
            this.radDimRed_Disabled = new System.Windows.Forms.RadioButton();
            this.gbxClusteringAlgo = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.nudNoOfClusters = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.radClusterAlgo_DensityPeaks = new System.Windows.Forms.RadioButton();
            this.radClusterAlgo_ImpKMedoids = new System.Windows.Forms.RadioButton();
            this.gbxMultithreading = new System.Windows.Forms.GroupBox();
            this.radMultithreading_Disabled = new System.Windows.Forms.RadioButton();
            this.radMultithreading_Enabled = new System.Windows.Forms.RadioButton();
            this.lblTest = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnViewResult = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.txtTest = new System.Windows.Forms.TextBox();
            this.nudTest2 = new System.Windows.Forms.NumericUpDown();
            this.nudTest1 = new System.Windows.Forms.NumericUpDown();
            this.nudTest3 = new System.Windows.Forms.NumericUpDown();
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
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompressionRate)).BeginInit();
            this.gbxClusteringAlgo.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoOfClusters)).BeginInit();
            this.gbxMultithreading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTest2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTest1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTest3)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(768, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(97, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "Exit";
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
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // guideToolStripMenuItem
            // 
            this.guideToolStripMenuItem.Name = "guideToolStripMenuItem";
            this.guideToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.guideToolStripMenuItem.Text = "Guide";
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
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // gbxDimRed
            // 
            this.gbxDimRed.Controls.Add(this.groupBox4);
            this.gbxDimRed.Controls.Add(this.radDimRed_Paa);
            this.gbxDimRed.Controls.Add(this.radDimRed_Disabled);
            this.gbxDimRed.Location = new System.Drawing.Point(30, 122);
            this.gbxDimRed.Name = "gbxDimRed";
            this.gbxDimRed.Size = new System.Drawing.Size(249, 131);
            this.gbxDimRed.TabIndex = 2;
            this.gbxDimRed.TabStop = false;
            this.gbxDimRed.Text = "Dimensionality Reduction";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.nudCompressionRate);
            this.groupBox4.Location = new System.Drawing.Point(31, 62);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(161, 53);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Parameters";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Compression rate";
            // 
            // nudCompressionRate
            // 
            this.nudCompressionRate.Location = new System.Drawing.Point(100, 23);
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
            this.nudCompressionRate.Size = new System.Drawing.Size(51, 20);
            this.nudCompressionRate.TabIndex = 8;
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
            this.radDimRed_Paa.Location = new System.Drawing.Point(12, 42);
            this.radDimRed_Paa.Name = "radDimRed_Paa";
            this.radDimRed_Paa.Size = new System.Drawing.Size(46, 17);
            this.radDimRed_Paa.TabIndex = 4;
            this.radDimRed_Paa.TabStop = true;
            this.radDimRed_Paa.Text = "PAA";
            this.radDimRed_Paa.UseVisualStyleBackColor = true;
            // 
            // radDimRed_Disabled
            // 
            this.radDimRed_Disabled.AutoSize = true;
            this.radDimRed_Disabled.Location = new System.Drawing.Point(12, 19);
            this.radDimRed_Disabled.Name = "radDimRed_Disabled";
            this.radDimRed_Disabled.Size = new System.Drawing.Size(66, 17);
            this.radDimRed_Disabled.TabIndex = 3;
            this.radDimRed_Disabled.Text = "Disabled";
            this.radDimRed_Disabled.UseVisualStyleBackColor = true;
            // 
            // gbxClusteringAlgo
            // 
            this.gbxClusteringAlgo.Controls.Add(this.groupBox5);
            this.gbxClusteringAlgo.Controls.Add(this.radClusterAlgo_DensityPeaks);
            this.gbxClusteringAlgo.Controls.Add(this.radClusterAlgo_ImpKMedoids);
            this.gbxClusteringAlgo.Location = new System.Drawing.Point(308, 34);
            this.gbxClusteringAlgo.Name = "gbxClusteringAlgo";
            this.gbxClusteringAlgo.Size = new System.Drawing.Size(224, 124);
            this.gbxClusteringAlgo.TabIndex = 4;
            this.gbxClusteringAlgo.TabStop = false;
            this.gbxClusteringAlgo.Text = "Clustering Algorithm";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.nudNoOfClusters);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(22, 39);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(185, 50);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Parameters";
            // 
            // nudNoOfClusters
            // 
            this.nudNoOfClusters.Location = new System.Drawing.Point(107, 21);
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
            this.nudNoOfClusters.Size = new System.Drawing.Size(65, 20);
            this.nudNoOfClusters.TabIndex = 7;
            this.nudNoOfClusters.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Number of clusters";
            // 
            // radClusterAlgo_DensityPeaks
            // 
            this.radClusterAlgo_DensityPeaks.AutoSize = true;
            this.radClusterAlgo_DensityPeaks.Location = new System.Drawing.Point(3, 98);
            this.radClusterAlgo_DensityPeaks.Name = "radClusterAlgo_DensityPeaks";
            this.radClusterAlgo_DensityPeaks.Size = new System.Drawing.Size(93, 17);
            this.radClusterAlgo_DensityPeaks.TabIndex = 1;
            this.radClusterAlgo_DensityPeaks.Text = "Density Peaks";
            this.radClusterAlgo_DensityPeaks.UseVisualStyleBackColor = true;
            // 
            // radClusterAlgo_ImpKMedoids
            // 
            this.radClusterAlgo_ImpKMedoids.AutoSize = true;
            this.radClusterAlgo_ImpKMedoids.Checked = true;
            this.radClusterAlgo_ImpKMedoids.Location = new System.Drawing.Point(3, 16);
            this.radClusterAlgo_ImpKMedoids.Name = "radClusterAlgo_ImpKMedoids";
            this.radClusterAlgo_ImpKMedoids.Size = new System.Drawing.Size(121, 17);
            this.radClusterAlgo_ImpKMedoids.TabIndex = 0;
            this.radClusterAlgo_ImpKMedoids.TabStop = true;
            this.radClusterAlgo_ImpKMedoids.Text = "Improved k-Medoids";
            this.radClusterAlgo_ImpKMedoids.UseVisualStyleBackColor = true;
            // 
            // gbxMultithreading
            // 
            this.gbxMultithreading.Controls.Add(this.radMultithreading_Disabled);
            this.gbxMultithreading.Controls.Add(this.radMultithreading_Enabled);
            this.gbxMultithreading.Location = new System.Drawing.Point(30, 27);
            this.gbxMultithreading.Name = "gbxMultithreading";
            this.gbxMultithreading.Size = new System.Drawing.Size(108, 75);
            this.gbxMultithreading.TabIndex = 6;
            this.gbxMultithreading.TabStop = false;
            this.gbxMultithreading.Text = "Multithreading";
            // 
            // radMultithreading_Disabled
            // 
            this.radMultithreading_Disabled.AutoSize = true;
            this.radMultithreading_Disabled.Location = new System.Drawing.Point(3, 39);
            this.radMultithreading_Disabled.Name = "radMultithreading_Disabled";
            this.radMultithreading_Disabled.Size = new System.Drawing.Size(66, 17);
            this.radMultithreading_Disabled.TabIndex = 1;
            this.radMultithreading_Disabled.Text = "Disabled";
            this.radMultithreading_Disabled.UseVisualStyleBackColor = true;
            // 
            // radMultithreading_Enabled
            // 
            this.radMultithreading_Enabled.AutoSize = true;
            this.radMultithreading_Enabled.Checked = true;
            this.radMultithreading_Enabled.Location = new System.Drawing.Point(3, 16);
            this.radMultithreading_Enabled.Name = "radMultithreading_Enabled";
            this.radMultithreading_Enabled.Size = new System.Drawing.Size(64, 17);
            this.radMultithreading_Enabled.TabIndex = 0;
            this.radMultithreading_Enabled.TabStop = true;
            this.radMultithreading_Enabled.Text = "Enabled";
            this.radMultithreading_Enabled.UseVisualStyleBackColor = true;
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(473, 184);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(106, 13);
            this.lblTest.TabIndex = 7;
            this.lblTest.Text = "This text is for testing";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(412, 278);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 11;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(493, 278);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnViewResult
            // 
            this.btnViewResult.Location = new System.Drawing.Point(574, 278);
            this.btnViewResult.Name = "btnViewResult";
            this.btnViewResult.Size = new System.Drawing.Size(75, 23);
            this.btnViewResult.TabIndex = 13;
            this.btnViewResult.Text = "View result";
            this.btnViewResult.UseVisualStyleBackColor = true;
            this.btnViewResult.Click += new System.EventHandler(this.btnViewResult_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(655, 278);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(476, 218);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 15;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtTest
            // 
            this.txtTest.Location = new System.Drawing.Point(557, 218);
            this.txtTest.Name = "txtTest";
            this.txtTest.Size = new System.Drawing.Size(100, 20);
            this.txtTest.TabIndex = 16;
            // 
            // nudTest2
            // 
            this.nudTest2.Location = new System.Drawing.Point(350, 218);
            this.nudTest2.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudTest2.Name = "nudTest2";
            this.nudTest2.Size = new System.Drawing.Size(120, 20);
            this.nudTest2.TabIndex = 17;
            this.nudTest2.ValueChanged += new System.EventHandler(this.nudTest2_ValueChanged);
            // 
            // nudTest1
            // 
            this.nudTest1.Location = new System.Drawing.Point(350, 197);
            this.nudTest1.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudTest1.Name = "nudTest1";
            this.nudTest1.Size = new System.Drawing.Size(120, 20);
            this.nudTest1.TabIndex = 18;
            this.nudTest1.ValueChanged += new System.EventHandler(this.nudTest1_ValueChanged);
            // 
            // nudTest3
            // 
            this.nudTest3.Location = new System.Drawing.Point(594, 182);
            this.nudTest3.Name = "nudTest3";
            this.nudTest3.Size = new System.Drawing.Size(120, 20);
            this.nudTest3.TabIndex = 19;
            this.nudTest3.ValueChanged += new System.EventHandler(this.nudTest3_ValueChanged);
            // 
            // lblExeTimeLabel
            // 
            this.lblExeTimeLabel.AutoSize = true;
            this.lblExeTimeLabel.Location = new System.Drawing.Point(16, 278);
            this.lblExeTimeLabel.Name = "lblExeTimeLabel";
            this.lblExeTimeLabel.Size = new System.Drawing.Size(83, 13);
            this.lblExeTimeLabel.TabIndex = 20;
            this.lblExeTimeLabel.Text = "Execution Time:";
            // 
            // lblExeTimeValue
            // 
            this.lblExeTimeValue.AutoSize = true;
            this.lblExeTimeValue.Location = new System.Drawing.Point(129, 278);
            this.lblExeTimeValue.Name = "lblExeTimeValue";
            this.lblExeTimeValue.Size = new System.Drawing.Size(93, 13);
            this.lblExeTimeValue.TabIndex = 21;
            this.lblExeTimeValue.Text = "(exe_time_display)";
            // 
            // pgbDoClustering
            // 
            this.pgbDoClustering.Location = new System.Drawing.Point(19, 336);
            this.pgbDoClustering.Name = "pgbDoClustering";
            this.pgbDoClustering.Size = new System.Drawing.Size(260, 23);
            this.pgbDoClustering.TabIndex = 24;
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
            this.groupBox1.Location = new System.Drawing.Point(538, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 3;
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
            this.radNormalization_ZeroMean.TabStop = true;
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
            this.radNormalization_MinMax.TabStop = true;
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
            this.ClientSize = new System.Drawing.Size(768, 411);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pgbDoClustering);
            this.Controls.Add(this.lblExeTimeValue);
            this.Controls.Add(this.lblExeTimeLabel);
            this.Controls.Add(this.nudTest3);
            this.Controls.Add(this.nudTest1);
            this.Controls.Add(this.nudTest2);
            this.Controls.Add(this.txtTest);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnViewResult);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.gbxMultithreading);
            this.Controls.Add(this.gbxClusteringAlgo);
            this.Controls.Add(this.gbxDimRed);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "PDTW Clustering";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbxDimRed.ResumeLayout(false);
            this.gbxDimRed.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompressionRate)).EndInit();
            this.gbxClusteringAlgo.ResumeLayout(false);
            this.gbxClusteringAlgo.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoOfClusters)).EndInit();
            this.gbxMultithreading.ResumeLayout(false);
            this.gbxMultithreading.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTest2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTest1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTest3)).EndInit();
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
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guideToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.GroupBox gbxDimRed;
        private System.Windows.Forms.RadioButton radDimRed_Paa;
        private System.Windows.Forms.RadioButton radDimRed_Disabled;
        private System.Windows.Forms.GroupBox gbxClusteringAlgo;
        private System.Windows.Forms.GroupBox groupBox4;
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
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnViewResult;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox txtTest;
        private System.Windows.Forms.NumericUpDown nudTest2;
        private System.Windows.Forms.NumericUpDown nudTest1;
        private System.Windows.Forms.NumericUpDown nudTest3;
        private System.Windows.Forms.Label lblExeTimeLabel;
        private System.Windows.Forms.Label lblExeTimeValue;
        private System.Windows.Forms.ProgressBar pgbDoClustering;
        private System.Windows.Forms.Timer tmrExeTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radNormalization_ZeroMean;
        private System.Windows.Forms.RadioButton radNormalization_MinMax;
        private System.Windows.Forms.RadioButton radNormalization_None;
    }
}

