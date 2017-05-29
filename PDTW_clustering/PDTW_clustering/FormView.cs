using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PDTW_clustering.lib;
using System.Collections;
using System.IO;
using ZedGraph;
using System.Drawing;
using System.Linq;

namespace PDTW_clustering
{
    public partial class FormView : Form
    {
        #region VARIABLES
        FormMain _mainForm = null;
        private int _window = 200;
        private Cluster _cluster;
        private GraphPane m_graphPane;
        private PointPairList m_pointsList;
        private List<TimeSeries> _dataset;
        private List<TimeSeries>[] _tsClusters;
        // Compression rate & Normalization type
        // - ORIGINAL: input from form
        // - CLUSTERING: get from resulted cluster
        private int _compressionRate;
        private EnumNormalization _normalization;
        // 2 types of graph view: browsing time series (ORIGINAL) & view clustering result (CLUSTERING)
        private EnumViewTimeSeriesType _viewTSType = EnumViewTimeSeriesType.ORIGINAL;
        // Mode of view: NormalView or ResultView
        public EnumViewMode _mode;
        // List of time series to be drawn
        public List<TimeSeries> _drawingData;
        #endregion

        #region CONSTRUCTORS
        public FormView(FormMain mainForm, List<TimeSeries> data)
        {
            InitializeComponent();
            // Data
            this._mainForm = mainForm;
            this._dataset = data == null ? null : new List<TimeSeries>(data);
            this._drawingData = _dataset;
            _mode = EnumViewMode.NORMAL;
            _normalization = EnumNormalization.NONE;
            _compressionRate = 1;
            // Displaying
            display_based_on_mode();
        }

        public FormView(FormMain mainForm, Cluster cluster, bool ap)
        {
            InitializeComponent();
            // Data
            this._mainForm = mainForm;
            _mode = EnumViewMode.RESULT;
            TimeSeries anClusteredObject = (TimeSeries)cluster.Objects[0];
            _normalization = anClusteredObject.NormalizedType;
            _compressionRate = anClusteredObject.CompressionRate;
            // Displaying
            display_based_on_mode();

            _cluster = cluster;
            List<int>[] clusters = _cluster.Clusters;
            _tsClusters = new List<TimeSeries>[clusters.Length];

            treeView.Nodes.Clear();
            _dataset = new List<TimeSeries>(cluster.Objects.Select(ts =>
            {
                return (TimeSeries)ts;
            }));
            ExTreeNode root = new ExTreeNode(_dataset, 0, "Cluster Result");
            string labelCluster = "";
            for (int i = 0; i < clusters.Length; i++)  // for each cluster
            {
                labelCluster = "Cluster " + (i + 1).ToString() + " : " + clusters[i].Count.ToString() + " objects";
                root.Nodes.Add(new ExTreeNode(new List<TimeSeries>(), i + 1, labelCluster));
                ExTreeNode child = (ExTreeNode)root.LastNode;
                clusters[i].Sort();
                List<int> tsIndices = clusters[i];  // all time series of current cluster
                _tsClusters[i] = new List<TimeSeries>();
                for (int j = 0; j < tsIndices.Count; j++)
                {
                    TimeSeries ts = _dataset[tsIndices[j]];
                    _tsClusters[i].Add(ts);
                    child.Nodes.Add(new ExTreeNode(ts, "Object " + ts.Index));
                }
                child.Cluster = _tsClusters[i];
            }
            treeView.Nodes.Add(root);
            treeView.AfterSelect += treeView_AfterSelect;
            treeView.SelectedNode = root.Nodes[0];
        }
        #endregion

        #region CALLBACKS
        private void FormView_Load(object sender, EventArgs e)
        {
            if (this._drawingData == null)
                InitGraph();
            else
                DrawData();
        }

        private void FormView_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainForm.Enabled = true;
        }

        private void tbLoadData_Click(object sender, EventArgs e)
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
                    _dataset = _temp;
                    _drawingData = _temp;
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
            redraw_with_new_settings();
        }

        private void tbSaveClusters_Click(object sender, EventArgs e)
        {
            if (_cluster != null && _cluster.Clusters != null)
            {
                //List<int>[] clusters = _cluster.Clusters;
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = null;
                    try
                    {
                        // Open selected file
                        String labelCluster = "Cluster ";
                        writer = new StreamWriter(File.OpenWrite(saveFile.FileName));
                        int clusterNumber = 1;
                        TimeSeries timeSeries;
                        for (int i = 0; i < _tsClusters.Length; i++)
                        {
                            clusterNumber = i + 1;
                            writer.WriteLine(labelCluster + clusterNumber.ToString() + ":");
                            for (int j = 0; j < _tsClusters[i].Count; j++)
                            {
                                timeSeries = _tsClusters[i][j];
                                string data2Write = clusterNumber.ToString() + "@";
                                for (int k = 0; k < timeSeries.Series.Count; k++)
                                {
                                    data2Write = data2Write + " " + timeSeries.Series[k].ToString();
                                }
                                writer.WriteLine(data2Write);
                            }
                        }
                        MessageBox.Show("Data Saved", "Information");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Failed Writing the file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    finally
                    {
                        // Close file
                        if (writer != null)
                            writer.Close();
                    }
                }
            }
        }

        private void tbViewQuality_Click(object sender, EventArgs e)
        {
            FormQuality formView = new FormQuality(this, _cluster.do_evaluating());
            formView.Show();
            formView.Activate();
            this.Enabled = false;
        }

        private void treeView_AfterSelect(object sender, EventArgs e)
        {
            ExTreeNode node = (ExTreeNode)treeView.SelectedNode;
            switch (node.Type)
            {
                case EnumExTreeNodeType.CLUSTER:
                    _drawingData = node.Cluster;
                    break;
                case EnumExTreeNodeType.TIMESERIES:
                    _drawingData = new List<TimeSeries>();
                    _drawingData.Add(node.TimeSeries);
                    break;
                default:
                    throw new Exception("There is some error with ExTreeNodeType");
            }
            DrawData();
        }

        private void tbPaa_Click(object sender, EventArgs e)
        {
            if (_dataset != null && _dataset.Count > 0)
            {
                bool formPAAEditable = _mode == EnumViewMode.NORMAL ? true : false;
                FormInputPAA formPAA = new FormInputPAA(this, formPAAEditable);
                formPAA.CompressionRate = _compressionRate;
                if (formPAA.ShowDialog() == DialogResult.OK)
                {
                    _compressionRate = formPAA.CompressionRate;
                    redraw_with_new_settings();
                }
            }
        }

        private void tbNormalize_Click(object sender, EventArgs e)
        {
            if (_dataset != null && _dataset.Count > 0)
            {
                bool formNormalizationEditable = _mode == EnumViewMode.NORMAL ? true : false;
                FormNormalization formNormalization = new FormNormalization(this, formNormalizationEditable);
                formNormalization.Normalization = _normalization;
                if (formNormalization.ShowDialog() == DialogResult.OK)
                {
                    _normalization = formNormalization.Normalization;
                    redraw_with_new_settings();
                }
            }
        }

        private void tbToggleClusteringView_Click(object sender, EventArgs e)
        {
            switch (_viewTSType)
            {
                case EnumViewTimeSeriesType.ORIGINAL:
                    tbToggleClusteringView.Text = "Toggle Original View";
                    _viewTSType = EnumViewTimeSeriesType.CLUSTERING;
                    break;
                case EnumViewTimeSeriesType.CLUSTERING:
                    tbToggleClusteringView.Text = "Toggle Clustering View";
                    _viewTSType = EnumViewTimeSeriesType.ORIGINAL;
                    break;
            }
            DrawData();
        }
        #endregion

        #region BEHAVIORS
        public void DrawData()
        {
            List<TimeSeries> data2Draw;
            switch (_viewTSType)
            {
                case EnumViewTimeSeriesType.ORIGINAL:
                    data2Draw = _drawingData;
                    break;
                case EnumViewTimeSeriesType.CLUSTERING:
                    data2Draw = new List<TimeSeries>(_drawingData.Select(ts =>
                    {
                        return ts.ClusteringSeries;
                    }));
                    break;
                default:
                    throw new Exception("There is something wrong with Time Series Viewing Type");
            }
            int view = 0;
            TimeSeries t;
            if (data2Draw == null || data2Draw.Count <= 0)
            {
                return;
            }
            InitGraph();
            view = Math.Min(_window, data2Draw.Count);
            for (int i = 0; i < view; i++)
            {
                t = (TimeSeries)data2Draw[i];
                DrawTimeSeries(t, Color.FromArgb((i * 100) % 255, Math.Abs((255 - i * 100) % 255), (i * 10) % 255));
            }
            m_graph.Refresh();
        }
        #endregion

        #region FUNCTIONS
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

        private void display_based_on_mode()
        {
            switch (_mode)
            {
                case EnumViewMode.NORMAL:
                    m_graphPane = m_graph.GraphPane;
                    splitContainer.Panel1Collapsed = true;
                    tbLoadData.Visible = true;
                    tbSaveClusters.Visible = false;
                    tbViewQuality.Visible = false;
                    tbNormalize.Visible = true;
                    tbPaa.Visible = true;
                    tbToggleClusteringView.Visible = false;
                    break;
                case EnumViewMode.RESULT:
                    m_graphPane = m_graph.GraphPane;
                    splitContainer.Panel1Collapsed = false;
                    tbLoadData.Visible = false;
                    tbSaveClusters.Visible = true;
                    tbViewQuality.Visible = true;
                    tbNormalize.Visible = true;
                    tbPaa.Visible = true;
                    tbToggleClusteringView.Visible = true;
                    break;
            }
        }

        private void redraw_with_new_settings()
        {
            List<TimeSeries> temp = new List<TimeSeries>(_dataset.Select(ts =>
            {
                ts.normalize(_normalization);
                return ts;
            }));
            _drawingData = new List<TimeSeries>(temp.Select(ts =>
            {
                ts.paa(_compressionRate, _normalization != EnumNormalization.NONE);
                return ts.ClusteringSeries;
            }));
            DrawData();
        }
        #endregion
    }
}
