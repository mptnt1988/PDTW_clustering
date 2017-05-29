namespace PDTW_clustering
{
    partial class FormView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormView));
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.tbLoadData = new System.Windows.Forms.ToolStripButton();
            this.tbSaveClusters = new System.Windows.Forms.ToolStripButton();
            this.tbViewData = new System.Windows.Forms.ToolStripButton();
            this.tbViewQuality = new System.Windows.Forms.ToolStripButton();
            this.tbNormalize = new System.Windows.Forms.ToolStripButton();
            this.tbPaa = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.m_graph = new ZedGraph.ZedGraphControl();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.toolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFile
            // 
            this.openFile.FileName = "OpenFile";
            // 
            // toolBar
            // 
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbLoadData,
            this.tbSaveClusters,
            this.tbViewData,
            this.tbViewQuality,
            this.tbNormalize,
            this.tbPaa});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(970, 25);
            this.toolBar.TabIndex = 0;
            this.toolBar.Text = "ToolBar";
            // 
            // tbLoadData
            // 
            this.tbLoadData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbLoadData.Image = ((System.Drawing.Image)(resources.GetObject("tbLoadData.Image")));
            this.tbLoadData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbLoadData.Name = "tbLoadData";
            this.tbLoadData.Size = new System.Drawing.Size(23, 22);
            this.tbLoadData.Text = "Load Data";
            this.tbLoadData.Click += new System.EventHandler(this.tbLoadData_Click);
            // 
            // tbSaveClusters
            // 
            this.tbSaveClusters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSaveClusters.Image = ((System.Drawing.Image)(resources.GetObject("tbSaveClusters.Image")));
            this.tbSaveClusters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSaveClusters.Name = "tbSaveClusters";
            this.tbSaveClusters.Size = new System.Drawing.Size(23, 22);
            this.tbSaveClusters.Text = "Save Clusters";
            this.tbSaveClusters.Visible = false;
            this.tbSaveClusters.Click += new System.EventHandler(this.tbSaveClusters_Click);
            // 
            // tbViewData
            // 
            this.tbViewData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbViewData.Image = ((System.Drawing.Image)(resources.GetObject("tbViewData.Image")));
            this.tbViewData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbViewData.Name = "tbViewData";
            this.tbViewData.Size = new System.Drawing.Size(23, 22);
            this.tbViewData.Text = "View Data";
            this.tbViewData.ToolTipText = "Display Data";
            this.tbViewData.Click += new System.EventHandler(this.tbViewData_Click);
            // 
            // tbViewQuality
            // 
            this.tbViewQuality.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbViewQuality.Image = ((System.Drawing.Image)(resources.GetObject("tbViewQuality.Image")));
            this.tbViewQuality.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbViewQuality.Name = "tbViewQuality";
            this.tbViewQuality.Size = new System.Drawing.Size(23, 22);
            this.tbViewQuality.Text = "View Quality";
            this.tbViewQuality.ToolTipText = "Clustering Quality";
            this.tbViewQuality.Click += new System.EventHandler(this.tbViewQuality_Click);
            // 
            // tbNormalize
            // 
            this.tbNormalize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbNormalize.Image = ((System.Drawing.Image)(resources.GetObject("tbNormalize.Image")));
            this.tbNormalize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbNormalize.Name = "tbNormalize";
            this.tbNormalize.Size = new System.Drawing.Size(23, 22);
            this.tbNormalize.Text = "Normalize Data";
            this.tbNormalize.Visible = false;
            this.tbNormalize.Click += new System.EventHandler(this.tbNormalize_Click);
            // 
            // tbPaa
            // 
            this.tbPaa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPaa.Image = ((System.Drawing.Image)(resources.GetObject("tbPaa.Image")));
            this.tbPaa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPaa.Name = "tbPaa";
            this.tbPaa.Size = new System.Drawing.Size(23, 22);
            this.tbPaa.Text = "PAA";
            this.tbPaa.Click += new System.EventHandler(this.tbPaa_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 25);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            this.splitContainer.Panel1MinSize = 2;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.m_graph);
            this.splitContainer.Size = new System.Drawing.Size(970, 495);
            this.splitContainer.SplitterDistance = 160;
            this.splitContainer.TabIndex = 1;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(160, 495);
            this.treeView.TabIndex = 0;
            // 
            // m_graph
            // 
            this.m_graph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_graph.Location = new System.Drawing.Point(0, 0);
            this.m_graph.Name = "m_graph";
            this.m_graph.ScrollGrace = 0D;
            this.m_graph.ScrollMaxX = 0D;
            this.m_graph.ScrollMaxY = 0D;
            this.m_graph.ScrollMaxY2 = 0D;
            this.m_graph.ScrollMinX = 0D;
            this.m_graph.ScrollMinY = 0D;
            this.m_graph.ScrollMinY2 = 0D;
            this.m_graph.Size = new System.Drawing.Size(806, 495);
            this.m_graph.TabIndex = 14;
            // 
            // saveFile
            // 
            this.saveFile.DefaultExt = "dat";
            this.saveFile.FileName = "Cluster.dat";
            // 
            // FormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 520);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graph";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormView_FormClosed);
            this.Load += new System.EventHandler(this.FormView_Load);
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        //private void TreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        //{
        //    this.treeView_AfterSelect(sender, e);
        //}

        #endregion

        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripButton tbLoadData;
        private System.Windows.Forms.SplitContainer splitContainer;
        private ZedGraph.ZedGraphControl m_graph;
        private System.Windows.Forms.ToolStripButton tbViewData;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ToolStripButton tbViewQuality;
        private System.Windows.Forms.ToolStripButton tbNormalize;
        private System.Windows.Forms.ToolStripButton tbPaa;
        private System.Windows.Forms.ToolStripButton tbSaveClusters;
        private System.Windows.Forms.SaveFileDialog saveFile;
    }
}