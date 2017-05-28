using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDTW_clustering
{
    public partial class FormInputPAA : Form
    {
        #region PRIVATE VARIABLES
        private int _compressionRate;
        #endregion

        #region PROPERTIES
        public int CompressionRate
        {
            get { return _compressionRate; }
            set { nudPaa.Value = _compressionRate = value; }
        }
        #endregion

        #region CONSTRUCTORS
        public FormInputPAA()
        {
            InitializeComponent();
        }
        #endregion

        #region CALLBACKS
        private void btnOke_Click(object sender, EventArgs e)
        {
            CompressionRate = (int)nudPaa.Value;
            DialogResult = DialogResult.OK;
        }
        #endregion
    }
}
