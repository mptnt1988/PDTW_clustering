using System;
using System.Windows.Forms;
using PDTW_clustering.lib;

namespace PDTW_clustering
{
    public partial class FormNormalization : Form
    {
        private EnumNormalization _normalization;
        private Form _mainForm;

        public EnumNormalization Normalization
        {
            get { return _normalization; }
            set
            {
                _normalization = value;
                if (_normalization == EnumNormalization.MIN_MAX)
                    radNormalization_MinMax.Checked = true;
                else if (_normalization == EnumNormalization.ZERO_MIN)
                    radNormalization_ZeroMean.Checked = true;
            }
        }

        public FormNormalization(Form mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _mainForm.Enabled = false;
        }

        private void btnOke_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            if (radNormalization_MinMax.Checked)
            {
                _normalization = EnumNormalization.MIN_MAX;
            }
            else if (radNormalization_ZeroMean.Checked)
            {
                _normalization = EnumNormalization.ZERO_MIN;
            }
            else if (radNormalization_None.Checked)
            {
                _normalization = EnumNormalization.NONE;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FormNormalization_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainForm.Enabled = true;
        }
    }
}
