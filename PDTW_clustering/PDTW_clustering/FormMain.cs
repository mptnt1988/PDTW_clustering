using System;
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
        #region VARIABLES
        private List<TimeSeries> _data;
        private TimeSpan _exeTime;
        private long _exeTimeStart;
        private Configuration _configuration;
        private Cluster _cluster;
        private CancellationTokenSource _cts;
        #endregion

        #region CONSTRUCTORS
        public FormMain()
        {
            InitializeComponent();
        }
        #endregion

        #region CALLBACKS
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

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_cts != null)
                _cts.Cancel();
            GC.Collect();
            tmrExeTime.Enabled = false;
            _exeTime = TimeSpan.Zero;
            lblExeTimeValue.Text = display_time_string(_exeTime);
            pgbDoClustering.Value = 0;
        }

        private void btnViewResult_Click(object sender, EventArgs e)
        {
            FormView resultForm = new FormView(this, _cluster, false);
            resultForm.Show();
            resultForm.Activate();
            resultForm.DrawData();
            this.Enabled = false;
        }

        private void tmrExeTime_Tick(object sender, EventArgs e)
        {
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(System.Environment.TickCount - _exeTimeStart);
            lblExeTimeValue.Text = display_time_string(timeSpan);
            pgbDoClustering.Value = _cluster.Percentage;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            btnViewResult.Enabled = false;
            lblExeTimeValue.Text = display_time_string(TimeSpan.Zero);
            gbDensityPeaksParams.Enabled = false;
        }

        private void radClusterAlgo_DensityPeaks_CheckedChanged(object sender, EventArgs e)
        {
            gbDensityPeaksParams.Enabled = radClusterAlgo_DensityPeaks.Checked;
        }

        private void nudDPParams_Min_ValueChanged(object sender, EventArgs e)
        {
            if (nudDPParams_Min.Value >= nudDPParams_Max.Value)
                nudDPParams_Min.Value = nudDPParams_Max.Value - 1;
        }

        private void nudDPParams_Max_ValueChanged(object sender, EventArgs e)
        {
            if (nudDPParams_Max.Value <= nudDPParams_Min.Value)
                nudDPParams_Max.Value = nudDPParams_Min.Value + 1;
        }
        #endregion

        #region FUNCTIONS
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
            pgbDoClustering.Value = 0;
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
            {
                _configuration.clusteringAlgorithm = EnumClusteringAlgorithm.DENSITY_PEAKS;
                _configuration.densityPeaksParams.maxPercentage = (int)nudDPParams_Max.Value;
                _configuration.densityPeaksParams.minPercentage = (int)nudDPParams_Min.Value;
            }
            _configuration.noOfClusters = (int)nudNoOfClusters.Value;

            // Configuration for normalization
            if (radNormalization_None.Checked)
                _configuration.normalization = EnumNormalization.NONE;
            else if (radNormalization_MinMax.Checked)
                _configuration.normalization = EnumNormalization.MIN_MAX;
            else if (radNormalization_ZeroMean.Checked)
                _configuration.normalization = EnumNormalization.ZERO_MEAN;
        }

        private bool is_configuration_ok()
        {
            if (_configuration.noOfClusters > _data.Count)
            {
                MessageBox.Show("The number of clusters should not be greater than number of time series", "Error");
                return false;
            }
            return true;
        }

        private void run_execution()
        {
            // Change GUI status to running
            btnRun.Enabled = false;
            btnStop.Enabled = true;
            btnViewResult.Enabled = false;

            // Start executing thread
            _cluster = null;
            _exeTimeStart = System.Environment.TickCount;
            tmrExeTime.Enabled = true;

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
        }

        private void do_post_clustering_on_completion()
        {
            tmrExeTime.Enabled = false;
            TimeSpan _exeTime = TimeSpan.FromMilliseconds(System.Environment.TickCount - _exeTimeStart);
            lblExeTimeValue.Text = display_time_string(_exeTime);
            Console.WriteLine(System.Environment.TickCount - _exeTimeStart);
            pgbDoClustering.Value = 100;
            btnViewResult.Enabled = true;
        }

        private void do_clustering(CancellationToken token)
        {
            DtwDistance dtwDistance = new DtwDistance();
            dtwDistance.IsMultithreading = _configuration.multithreading;
            List<ClusteringObject> data;

            // Normalization
            bool isNormalized;
            switch (_configuration.normalization)
            {
                case EnumNormalization.NONE:
                    isNormalized = false;
                    data = new List<ClusteringObject>(_data);
                    break;
                case EnumNormalization.MIN_MAX:
                case EnumNormalization.ZERO_MEAN:
                    isNormalized = true;
                    data = new List<ClusteringObject>(_data.Select(ts =>
                    {
                        ts.normalize(_configuration.normalization);
                        return ts;
                    }));
                    break;
                default:
                    throw new Exception("There is some error in configuring normalization");
            }

            // Dimensionality Reduction
            int configCompressionRate;
            switch (_configuration.dimensionalityReduction)
            {
                case EnumDimentionalityReduction.DISABLED:
                    configCompressionRate = 1;
                    break;
                case EnumDimentionalityReduction.PAA:
                    configCompressionRate = _configuration.paaCompressionRate;
                    break;
                default:
                    throw new Exception("There is some error in configuring dimensionality reduction");
            }
            data = new List<ClusteringObject>(data.Select(ts =>
            {
                ((TimeSeries)ts).paa(configCompressionRate, isNormalized);
                return ts;
            }));

            // Clustering Algorithm
            switch (_configuration.clusteringAlgorithm)
            {
                case EnumClusteringAlgorithm.IMPROVED_KMEDOIDS:
                    _cluster = new ImprovedKMedoids(data, dtwDistance, _configuration.noOfClusters);
                    break;
                case EnumClusteringAlgorithm.DENSITY_PEAKS:
                    _cluster = new DensityPeaks(data, dtwDistance, _configuration.noOfClusters,
                        _configuration.densityPeaksParams.minPercentage,
                        _configuration.densityPeaksParams.maxPercentage);
                    break;
                default:
                    throw new Exception("There is some error in configuring clustering algorithm");
            }
            _cluster.Token = token;
            _cluster.do_clustering();  // for testing only
        }

        private string display_time_string(TimeSpan timeSpan)
        {
            return timeSpan.ToString("hh':'mm':'ss'.'fff");
        }
        #endregion
    }
}