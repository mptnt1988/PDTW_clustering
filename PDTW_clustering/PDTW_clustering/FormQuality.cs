using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDTW_clustering.lib;

namespace PDTW_clustering
{
    public partial class FormQuality : Form
    {
        FormView _mainForm = null;
        Cluster _cluster;
        List<TimeSeries>[] _tsClusters;

        #region CONSTRUCTOR
        public FormQuality()
        {
            InitializeComponent();
        }

        public FormQuality(FormView mainForm, Cluster cluster, List<TimeSeries>[] tsClusters)
        {
            this._mainForm = mainForm;
            InitializeComponent();
            _cluster = cluster;
            _tsClusters = tsClusters;
        }
        #endregion

        private void FormQuality_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainForm.Enabled = true;
        }
    }
}
