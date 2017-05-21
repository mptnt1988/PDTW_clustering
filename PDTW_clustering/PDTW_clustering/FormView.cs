using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PDTW_clustering.lib;
using System.Collections;
using System.IO;
using ZedGraph;
using System.Drawing;

namespace PDTW_clustering
{
    public partial class FormView : Form
    {
        FormMain _mainForm = null;
        private int window = 200;
        private Cluster _cluster;
        private GraphPane m_graphPane;
        private PointPairList m_pointsList;
        //private Cluster _cluster;

        #region PROPERTIES
        // Clustering time (in millisecs)
        public long Time { get; set; }
        // List of all time series to be viewed
        public List<TimeSeries> Data { get; private set; }
        #endregion

        #region CONSTRUCTOR
        public FormView(FormMain mainForm, List<TimeSeries> data)
        {
            this._mainForm = mainForm;
            InitializeComponent();
            m_graphPane = m_graph.GraphPane;
            splitContainer.Panel1Collapsed = true;
            tbViewQuality.Visible = false;
            tbNormalize.Visible = true;
            this.Data = data;
        }

        //public FormView(ArrayList mean)
        //{
        //    InitializeComponent();
        //    m_graphPane = m_graph.GraphPane;
        //    toolBar.Visible = false;
        //    splitContainer.Panel1Collapsed = true;
        //    _data = mean;
        //}

        public FormView(FormMain mainForm, List<TimeSeries> data, Cluster cluster, bool ap)
        {
            this._mainForm = mainForm;
            InitializeComponent();
            string labelCluster = "";
            m_graphPane = m_graph.GraphPane;
            tbLoadData.Visible = false;
            btnSaveClusters.Visible = true;

            _cluster = cluster;
            List<int>[] clusters = _cluster.Clusters;
            List<TimeSeries>[] tsClusters = new List<TimeSeries>[clusters.Length];

            treeView.Nodes.Clear();
            ExTreeNode root = new ExTreeNode(null, 0, "Cluster Result");

            for (int i = 0; i < clusters.Length; i++)  // for each cluster
            {
                labelCluster = "Cluster " + (i + 1).ToString() + " : " + clusters[i].Count.ToString() + " objects";
                root.Nodes.Add(new ExTreeNode(new List<TimeSeries>(), i + 1, labelCluster));
                ExTreeNode child = (ExTreeNode)root.LastNode;
                clusters[i].Sort();
                List<int> tsIndices = clusters[i];  // all time series of current cluster
                tsClusters[i] = new List<TimeSeries>();
                for (int j = 0; j < tsIndices.Count; j++)
                {
                    TimeSeries ts = data[tsIndices[j]];
                    tsClusters[i].Add(ts);
                    child.Nodes.Add(new ExTreeNode(ts, "Object " + ts.Index));
                }
                child.Cluster = tsClusters[i];
            }
            treeView.Nodes.Add(root);
            treeView.SelectedNode = root.Nodes[0];
        }
        #endregion

        #region METHODS: Drawing
        public void DrawData() 
        {
            int view = 0;
            TimeSeries t;
            if (this.Data == null || this.Data.Count <= 0)
            {
                return;
            }
            InitGraph();
            view = Math.Min(window, this.Data.Count);
            for (int i = 0; i <view ; i++) 
            {
                t = (TimeSeries) this.Data[i];
                DrawTimeSeries(t, Color.FromArgb((i * 100) % 255, Math.Abs((255 - i * 100) % 255), (i * 10) % 255));
            }
            m_graph.Refresh();
        }

        private void DrawTimeSeries(TimeSeries ts, Color color)
        {
            LineItem myCurve;
            //
            m_pointsList = new PointPairList();
            double t1 = 0.0;
            //
            for (int j = 0; j < ts.Length; j++)
            {
                //t1 = t1 + 0.1;
                t1 = t1 + 1;
                //m_pointsList.Add(t1, ts.get_at(j));
                m_pointsList.Add(t1, ts.Series[j]);
            }
            //

            myCurve = m_graphPane.AddCurve(null, m_pointsList, color, SymbolType.None);

            m_graph.AxisChange();
            //this.Refresh();
            // MessageBox.Show(t);

        }

        private void FillPaneBackground()
        {
            // Fill the axis background with a color gradient
            m_graphPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            // Fill the pane background with a color gradient
            m_graphPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
        }

        private void ProcessPointsData()
        {
            m_pointsList = new PointPairList();
            m_pointsList.Add(0.1, 1.2);
            m_pointsList.Add(0.2, 1.5);
            m_pointsList.Add(0.3, 1.2);
            m_pointsList.Add(0.4, 1.5);
        }

        private void CreateLineGraph()
        {
            //clear if anything exists.            
            m_graphPane.CurveList.Clear();

            string _graphTitle = "", _xTitle = "", _yTitle = "";

            // Set the titles and axis labels
            SetLineBarTitleAndAxisDetails(ref _graphTitle, ref _xTitle, ref _yTitle);
            m_graphPane.Title.Text = _graphTitle;
            m_graphPane.XAxis.Title.Text = _xTitle;
            m_graphPane.YAxis.Title.Text = _yTitle;

            // Generate a blue curve with Star symbols
            LineItem myCurve = m_graphPane.AddCurve("test", m_pointsList, Color.Blue, SymbolType.None);
            //


            //
            m_pointsList = new PointPairList();
            m_pointsList.Add(0.1, 1.4);
            m_pointsList.Add(0.2, 1.2);
            m_pointsList.Add(0.3, 1.1);
            m_pointsList.Add(0.4, 1.9);
            myCurve = m_graphPane.AddCurve("test", m_pointsList, Color.Red, SymbolType.None);
            //

            //
            m_graphPane.XAxis.Scale.Min = 0;
            m_graphPane.XAxis.Scale.Max = 1;
            m_graphPane.XAxis.Scale.MinorStep = 0.01;
            m_graphPane.XAxis.Scale.MajorStep = 0.01;
            m_graphPane.YAxis.Scale.Min = 0;
            m_graphPane.YAxis.Scale.Max = 2;
            m_graphPane.YAxis.Scale.MinorStep = 0.01;
            m_graphPane.YAxis.Scale.MajorStep = 0.01;
            // zg1.AxisChange();
            // Calculate the Axis Scale Ranges
            m_graph.AxisChange();
        }

        private void SetLineBarTitleAndAxisDetails(ref string _graphTitle, ref string _xTitle, ref string _yTitle)
        {
            _graphTitle = "Title";
            string _xTitleTemp = "Title";
            string _yTitleTemp = "Title";
            string _xUnit = "Title";
            string _yUnit = "Title";

            if (_graphTitle == "")
            {
                _graphTitle = "Graph Test";
            }
            if (_xTitleTemp == "")
            {
                _xTitle = "X Axis";
            }
            if (_yTitleTemp == "")
            {
                _yTitle = "Y Axis";
            }
            if (_xUnit != "")
            {
                _xTitle = _xTitleTemp + " (" + _xUnit + " )";
            }
            if (_yUnit != "")
            {
                _yTitle = _yTitleTemp + " (" + _yUnit + " )";
            }
        }
        #endregion

        #region EVENTS
        private void FormView_Load(object sender, EventArgs e)
        {
            if (this.Data == null)
                InitGraph();
            else
                DrawData();
        }

        private void InitGraph()
        {
            m_graphPane.CurveList.Clear();
            string _graphTitle = "TimeSeries Clustering", _xTitle = "Time", _yTitle = "Value";
            // Set the titles and axis labels
            SetLineBarTitleAndAxisDetails(ref _graphTitle, ref _xTitle, ref _yTitle);
            m_graphPane.Title.Text = "TimeSeries Clustering";
            m_graphPane.XAxis.Title.Text = "Time";
            m_graphPane.YAxis.Title.Text = "Value";
            m_graphPane.XAxis.MajorGrid.IsVisible = true;
            m_graphPane.YAxis.MajorGrid.IsVisible = true;
            m_graphPane.XAxis.Scale.FontSpec.Size = 12;
            m_graphPane.XAxis.Title.FontSpec.Size = 12;
            m_graphPane.XAxis.MinorTic.IsOutside = false;
            m_graphPane.XAxis.MinorTic.IsOpposite = false;
            m_graphPane.XAxis.MinorTic.IsInside = false;
            m_graphPane.YAxis.Scale.FontSpec.Size = 12;
            m_graphPane.YAxis.Title.FontSpec.Size = 12;
            m_graphPane.YAxis.MinorTic.IsOutside = false;
            m_graphPane.YAxis.MinorTic.IsOpposite = false;
            m_graphPane.YAxis.MinorTic.IsInside = false;
            FillPaneBackground();
        }

        private void btPath_Click(object sender, EventArgs e)
        {
            int index = 1;
            List<TimeSeries> _temp = new List<TimeSeries>();
            TimeSeries t;
            // Show file selection dialog
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = null;
                try
                {
                    string str = null;
                    // Open selected file
                    reader = File.OpenText(openFile.FileName);
                    // Read the data
                    while ((str = reader.ReadLine()) != null)
                    {
                        // Split the string
                        t = new TimeSeries(str, index);
                        _temp.Add(t);
                        index += 1;
                    }
                    this.Data = _temp;
                    MessageBox.Show("Data successfully loaded", "Information");
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to read the file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    // Close file
                    if (reader != null)
                        reader.Close();
                }
            }
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            DrawData();
        }

        private void FormView_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainForm.Enabled = true;
        }
        #endregion

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ExTreeNode node = (ExTreeNode)treeView.SelectedNode;
            switch(node.Type)
            {
                case EnumExTreeNodeType.CLUSTER:
                    Data = node.Cluster;
                    break;
                case EnumExTreeNodeType.TIMESERIES:
                    Data = new List<TimeSeries>();
                    Data.Add(node.TimeSeries);
                    break;
                default:
                    throw new Exception("There is some error with ExTreeNodeType");
            }
            DrawData();
        }

        //private void tbResult_Click(object sender, EventArgs e)
        //{
        //    Cursor olcursor = this.Cursor;
        //    this.Cursor = Cursors.WaitCursor;

        //    CCQualMeasure qm = new CCQualMeasure();
        //    CCluster initc = qm.RebuildCluster(_cluster);
        //    qm.Evalue(_cluster);

        //    ResultForm rform = new ResultForm();
        //    rform.times = _times;
        //    rform.jaccard = qm.Jaccard();
        //    rform.rand = qm.Rand();
        //    rform.fm = qm.FolkesMallow();
        //    if (initc.Clusters.Count == _cluster.Clusters.Count)
        //    {
        //        rform.csm = qm.ClusterSim(_cluster.Clusters.Count, initc, _cluster);
        //        rform.nmi = qm.NormalMutual(_cluster.Clusters.Count, initc, _cluster);
        //    }
        //    else 
        //    {
        //        rform.csm = "0";
        //        rform.nmi = "0";
        //    }
        //    rform.adjrand = qm.AdjustedRI(_cluster);
        //    rform.ofr = qm.ObjFun(_cluster);
        //    rform.run = _cluster.Run;
        //   // rform.dval = qm.DiffFun(_cluster);
        //    this.Cursor = olcursor;
        //    rform.ShowData();

        //}

        //private void tbNormalize_Click(object sender, EventArgs e)
        //{
        //    if (_data != null && _data.Count > 0)
        //    {
        //        DialogResult rs;
        //        NormalizeForm nform = new NormalizeForm();
        //        nform.ShowDialog();
        //        rs = nform.DialogResult;
        //        if (rs == DialogResult.OK)
        //        {
        //            Cursor olcursor = this.Cursor;
        //            this.Cursor = Cursors.WaitCursor;
        //            if (nform.Ntype == NormalizeType.MinMax)
        //            {
        //                for (int i = 0; i < _data.Count; i++)
        //                {
        //                    ((TimeSeries)_data[i]).MinMaxNomalize();
        //                }
        //            }
        //            else
        //            {
        //                for (int i = 0; i < _data.Count; i++)
        //                {
        //                    ((TimeSeries)_data[i]).ZeroMeanNomalize();
        //                }
        //            }
        //            DrawData();
        //            this.Cursor = olcursor;
        //        }
        //    }
        //}

        //private void tBPaa_Click(object sender, EventArgs e)
        //{
        //    int length;
        //    if (_data != null && _data.Count > 0)
        //    {
        //        length = ((TimeSeries)_data[0]).Length;
        //        FPaa fpaa = new FPaa();
        //        fpaa.Length = length;

        //        if (fpaa.ShowDialog() == DialogResult.OK)
        //        {
        //            length = fpaa.Length;
        //            ArrayList paa = new ArrayList();
        //            for (int i = 0; i < _data.Count; i++)
        //            {
        //                ((TimeSeries)_data[i]).Paa(length);
        //                paa.Add(((TimeSeries)_data[i]).Rseries);
        //            }
        //            FormView gform = new FormView(paa);
        //            gform.MdiParent = this.MdiParent;
        //            gform.Show();
        //            gform.DrawData();
        //        }
        //    }
        //}

        //private void btnSaveClusters_Click(object sender, EventArgs e)
        //{
        //    if (_cluster != null && _cluster.Clusters != null) 
        //    {
        //        if (saveFile.ShowDialog() == DialogResult.OK)
        //        {
        //            StreamWriter writer = null;
        //            try
        //            {
        //                // open selected file
        //                String clusters = "Cluster ";
        //                writer = new StreamWriter(File.OpenWrite(saveFile.FileName));
        //                int clustetn = 1;
        //                ArrayList data;
        //                TimeSeries tsr;
        //                for (int i = 0;i< _cluster.Clusters.Count; i++)
        //                {
        //                    clustetn = i + 1;
        //                    writer.WriteLine(clusters+clustetn.ToString()+ ":");
        //                    data = (ArrayList)_cluster.Clusters[i];
        //                    for (int j = 0; j < _data.Count; j++)
        //                    {
        //                        tsr = (TimeSeries)_data[j];
        //                        tsr.save(writer);
        //                    }

        //                }
        //                MessageBox.Show("Data Saved", "Information");
        //            }
        //            catch (Exception)
        //            {
        //                MessageBox.Show("Failed Writing the file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }
        //            finally
        //            {
        //                // close file
        //                if (writer != null)
        //                    writer.Close();
        //            }
        //        }
        //    }
        //}
    }
}
