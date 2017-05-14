﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDTW_clustering.lib;

namespace PDTW_clustering
{
    public partial class FormMain : Form
    {
        private List<TimeSeries> _data;
        private long _exeTime;
        private long _exeTimeStart;
        private Configuration _configuration;
        private Thread _threadExe;
        private Cluster _clusters;
        private CancellationTokenSource _cts;

        public FormMain()
        {
            InitializeComponent();
            //_threadExe = null;
            btnStop.Enabled = false;
            btnViewResult.Enabled = false;
            lblExeTimeValue.Text = "0";
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
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
                    // Read data line by line
                    while ((str = reader.ReadLine()) != null)
                    {
                        // Split the string
                        t = new TimeSeries(str, index);
                        _temp.Add(t);
                        index += 1;
                    }
                    _data = _temp;
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

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormView formView = new FormView(this, _data);
            //formView.Parent = this;
            formView.Show();
            formView.Activate();
            this.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!is_execution_allowed()) return;
            reset_statistics();
            load_configuration();
            if (!is_configuration_ok()) return;
            run_execution();
        }

        private bool is_execution_allowed()
        {
            if (_data == null || _data.Count == 0)
            {
                MessageBox.Show("Please load data", "Error");
                return false;
            }
            return true;
        }

        private void reset_statistics()
        {
            _exeTime = 0;
        }

        private void load_configuration()
        {
            _configuration = new Configuration();

            // Configuration for multithreading
            if (radMultithreading_Enabled.Checked)
                _configuration.multithreading = EnumDtwMultithreading.ENABLED;
            else if (radMultithreading_Disabled.Checked)
                _configuration.multithreading = EnumDtwMultithreading.DISABLED;

            // Configuration for dimensionality reduction
            if (radDimRed_Disabled.Checked)
                _configuration.dimensionalityReduction = EnumDimentionalityReduction.DISABLED;
            else if (radDimRed_Paa.Checked)
                _configuration.dimensionalityReduction = EnumDimentionalityReduction.PAA;

            _configuration.paaCompressionRate = (int)nudCompressionRate.Value;

            // Configuration for clustering algorithm
            if (radClusterAlgo_ImpKMedoids.Checked)
                _configuration.clusteringAlgorithm = EnumClusteringAlgorithm.IMPROVED_KMEDOIDS;
            else if (radClusterAlgo_DensityPeaks.Checked)
                _configuration.clusteringAlgorithm = EnumClusteringAlgorithm.DENSITY_PEAKS;

            _configuration.noOfClusters = (int)nudNoOfClusters.Value;
        }

        private bool is_configuration_ok()
        {
            if (_configuration.noOfClusters > _data.Count)
            {
                MessageBox.Show("The number of clusters should not be greater than number of time series",
                                "Error");
                return false;
            }
            return true;
        }

        private void run_execution()
        {
            // Change GUI status to running
            //Cursor oldcursor = this.Cursor;
            //this.Cursor = Cursors.WaitCursor;
            btnRun.Enabled = false;
            btnStop.Enabled = true;
            btnViewResult.Enabled = false;
            lblExeTimeValue.Text = "0";

            // Start executing thread
            _clusters = null;
            _exeTimeStart = System.Environment.TickCount;

            //if (_threadExe != null)
            //    _threadExe.Abort();
            //_threadExe = new Thread(new ThreadStart(run_execution));
            //_threadExe.Start();

            _cts = new CancellationTokenSource();
            var task = Task.Factory.StartNew(() => do_clustering(_cts.Token), _cts.Token);
            task.ContinueWith(t => Invoke(new Action(() => do_post_clustering())));
            task.ContinueWith(t => Invoke(new Action(() => do_post_clustering_on_completion())),
                              TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        private void do_post_clustering()
        {
            _cts = null;
            // Change GUI status to idle
            btnRun.Enabled = true;
            btnStop.Enabled = false;
            //if (_result != null) btnViewResult.Enabled = true;
            btnViewResult.Enabled = true;
        }

        private void do_post_clustering_on_completion()
        {
            _exeTime = System.Environment.TickCount - _exeTimeStart;
            lblExeTimeValue.Text = _exeTime.ToString();
        }

        private void do_clustering(CancellationToken token)
        {
            //token.ThrowIfCancellationRequested();
            DtwDistance dtwDistance = new DtwDistance();
            dtwDistance.IsMultithreading = _configuration.multithreading;
            List<object> data = new List<object>(_data);
            _clusters = new ImprovedKMedoids(data, _configuration.noOfClusters, dtwDistance);
            clusterOfObject = _clusters.do_clustering();
            // check
            nudTest3.Maximum = clusterOfObject.Length - 1;

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_cts != null)
                _cts.Cancel();
        }

        // TESTING
        #region ManualTest
        DtwDistance dtwDist;
        TimeSeries ts1, ts2, ts3, ts4, ts5, ts6, ts7, ts8;

        int[] clusterOfObject;
        private void btnTest_Click(object sender, EventArgs e)
        {
            ts1 = new TimeSeries(new List<float>(new float[] { 5, 6, 3, 2, 9, 5, 9, 4, 8, 5 }));
            ts2 = new TimeSeries(new List<float>(new float[] { 3, 4, 1, 8, 3, 7, 4, 4, 8, 2 }));
            ts3 = new TimeSeries(new List<float>(new float[] { 3, 4, 1, 8, 3, 7, 5, 4, 8, 2 }));
            ts4 = new TimeSeries(new List<float>(new float[] { 5, 7, 3, 2, 9, 5, 9, 4, 8, 5 }));
            ts5 = new TimeSeries(new List<float>(new float[] { 5, 6, 3, 2, 9, 5, 9, 4, 8, 5 }));
            ts6 = new TimeSeries(new List<float>(new float[] { 3, 4, 1, 8, 3, 7, 4, 4, 8, 2 }));
            ts7 = new TimeSeries(new List<float>(new float[] { 3, 4, 1, 8, 3, 7, 5, 4, 8, 2 }));
            ts8 = new TimeSeries(new List<float>(new float[] { 5, 7, 3, 2, 9, 5, 9, 4, 8, 5 }));

            dtwDist = new DtwDistance();
            //dtwDist.Calculate(ts1, ts2);
            nudTest1.Maximum = ts1.Series.Count - 1;
            nudTest2.Maximum = ts2.Series.Count - 1;

            List<object> tsList = new List<object>();
            tsList.Add(ts1); tsList.Add(ts2); tsList.Add(ts3); tsList.Add(ts4);
            tsList.Add(ts5); tsList.Add(ts6); tsList.Add(ts7); tsList.Add(ts8);
            ImprovedKMedoids cls = new ImprovedKMedoids(tsList, 3, dtwDist);
            clusterOfObject = cls.do_clustering();
            nudTest3.Maximum = clusterOfObject.Length - 1;
            //lblTest.Text = dtwDist.Value.ToString();
        }

        private void nudTest1_ValueChanged(object sender, EventArgs e)
        {
            tuan();
            //lblTest.Text = ts1.Series[(int)nudTest1.Value].ToString();
        }

        private void nudTest2_ValueChanged(object sender, EventArgs e)
        {
            tuan();
            //lblTest.Text = ts2.Series[(int)nudTest2.Value].ToString();
        }

        private void nudTest3_ValueChanged(object sender, EventArgs e)
        {
            lblTest.Text = clusterOfObject[(int)nudTest3.Value].ToString();
            //lblTest.Text = dtwDist.PathMatrix[(int)nudTest3.Value].value.ToString();
            //lblTest.Text += ": ";
            //lblTest.Text += dtwDist.X.Series[dtwDist.PathMatrix[(int)nudTest3.Value].x].ToString();
            //lblTest.Text += ", ";
            //lblTest.Text += dtwDist.Y.Series[dtwDist.PathMatrix[(int)nudTest3.Value].y].ToString();
        }

        private void tuan()
        {
            lblTest.Text = dtwDist.DistanceMatrix[(int)nudTest1.Value, (int)nudTest2.Value].ToString();
        }
        #endregion
    }
}

