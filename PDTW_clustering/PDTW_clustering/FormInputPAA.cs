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
        #region VARIABLES
        private int _compressionRate;
        private FormView _mainForm;
        #endregion

        #region PROPERTIES
        public int CompressionRate
        {
            get { return _compressionRate; }
            set { nudPaa.Value = _compressionRate = value; }
        }
        #endregion

        #region CONSTRUCTORS
        public FormInputPAA(FormView mainForm, bool editable)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _mainForm.Enabled = false;
            nudPaa.Enabled = editable;
            btnOk.Enabled = editable;
        }
        #endregion

        #region CALLBACKS
        private void btnOke_Click(object sender, EventArgs e)
        {
            CompressionRate = (int)nudPaa.Value;
            DialogResult = DialogResult.OK;
        }

        private void FormInputPAA_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainForm.Enabled = true;
        }
        #endregion
    }
}
