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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudCompressionRate = new System.Windows.Forms.NumericUpDown();
            this.radDimRed_Paa = new System.Windows.Forms.RadioButton();
            this.radDimRed_Disabled = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.radClusterAlgo_DensityPeaks = new System.Windows.Forms.RadioButton();
            this.radClusterAlgo_ImpKMedoids = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radMultithreading_Disabled = new System.Windows.Forms.RadioButton();
            this.radMultithreading_Enabled = new System.Windows.Forms.RadioButton();
            this.lblTest = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnViewResult = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.txtTest = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompressionRate)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.groupBox3.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.radDimRed_Paa);
            this.groupBox1.Controls.Add(this.radDimRed_Disabled);
            this.groupBox1.Location = new System.Drawing.Point(46, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 139);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dimensionality Reduction";
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
            this.nudCompressionRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCompressionRate.Name = "nudCompressionRate";
            this.nudCompressionRate.Size = new System.Drawing.Size(51, 20);
            this.nudCompressionRate.TabIndex = 8;
            this.nudCompressionRate.Value = new decimal(new int[] {
            1,
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
            this.radDimRed_Paa.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.radClusterAlgo_DensityPeaks);
            this.groupBox2.Controls.Add(this.radClusterAlgo_ImpKMedoids);
            this.groupBox2.Location = new System.Drawing.Point(355, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 124);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Clustering Algorithm";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.numericUpDown2);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(22, 39);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(213, 50);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Parameters";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(107, 21);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(65, 20);
            this.numericUpDown2.TabIndex = 7;
            this.numericUpDown2.Value = new decimal(new int[] {
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radMultithreading_Disabled);
            this.groupBox3.Controls.Add(this.radMultithreading_Enabled);
            this.groupBox3.Location = new System.Drawing.Point(65, 41);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(108, 75);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Multithreading";
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
            this.lblTest.Location = new System.Drawing.Point(492, 235);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(106, 13);
            this.lblTest.TabIndex = 7;
            this.lblTest.Text = "This text is for testing";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(301, 337);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 11;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(382, 337);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnViewResult
            // 
            this.btnViewResult.Location = new System.Drawing.Point(463, 337);
            this.btnViewResult.Name = "btnViewResult";
            this.btnViewResult.Size = new System.Drawing.Size(75, 23);
            this.btnViewResult.TabIndex = 13;
            this.btnViewResult.Text = "View result";
            this.btnViewResult.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(544, 337);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(495, 269);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 15;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtTest
            // 
            this.txtTest.Location = new System.Drawing.Point(576, 269);
            this.txtTest.Name = "txtTest";
            this.txtTest.Size = new System.Drawing.Size(100, 20);
            this.txtTest.TabIndex = 16;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 411);
            this.Controls.Add(this.txtTest);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnViewResult);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "PDTW Clustering";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompressionRate)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radDimRed_Paa;
        private System.Windows.Forms.RadioButton radDimRed_Disabled;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudCompressionRate;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radClusterAlgo_DensityPeaks;
        private System.Windows.Forms.RadioButton radClusterAlgo_ImpKMedoids;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radMultithreading_Disabled;
        private System.Windows.Forms.RadioButton radMultithreading_Enabled;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnViewResult;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox txtTest;
    }
}

