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
        private int _compressionRate;
        public int CompressionRate
        {
            get { return _compressionRate; }
            set { nudPaa.Value = _compressionRate = value; }
        }

        public FormInputPAA()
        {
            InitializeComponent();
        }

        private void btnOke_Click(object sender, EventArgs e)
        {
            CompressionRate = (int)nudPaa.Value;
            DialogResult = DialogResult.OK;
        }
    }
}
