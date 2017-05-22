﻿using System;
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
        Evaluation _evaluation;

        #region CONSTRUCTOR
        public FormQuality()
        {
            InitializeComponent();
        }

        public FormQuality(FormView mainForm, Evaluation evaluation)
        {
            this._mainForm = mainForm;
            InitializeComponent();
            _evaluation = evaluation;
            lblAdjustedRandValue.Text = _evaluation.externalValidation.ari.ToString();
            lblCSMValue.Text = _evaluation.externalValidation.csm.ToString();
            lblFowlkesMalowValue.Text = _evaluation.externalValidation.fm.ToString();
            lblJaccardValue.Text = _evaluation.externalValidation.jaccard.ToString();
            lblNormalMutualValue.Text = _evaluation.externalValidation.nmi.ToString();
            lblRandValue.Text = _evaluation.externalValidation.rand.ToString();
            lblObjFuncValue.Text = _evaluation.internalValidation.ToString();
        }
        #endregion

        private void FormQuality_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainForm.Enabled = true;
        }
    }
}
