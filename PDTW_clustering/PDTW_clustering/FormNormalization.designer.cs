namespace PDTW_clustering
{
    partial class FormNormalization
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNormalization));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.gbxNormalizationMethod = new System.Windows.Forms.GroupBox();
            this.radNormalization_None = new System.Windows.Forms.RadioButton();
            this.radNormalization_ZeroMean = new System.Windows.Forms.RadioButton();
            this.radNormalization_MinMax = new System.Windows.Forms.RadioButton();
            this.gbxNormalizationMethod.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(132, 79);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 29);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(45, 79);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(81, 29);
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // gbxNormalizationMethod
            // 
            this.gbxNormalizationMethod.Controls.Add(this.radNormalization_None);
            this.gbxNormalizationMethod.Controls.Add(this.radNormalization_ZeroMean);
            this.gbxNormalizationMethod.Controls.Add(this.radNormalization_MinMax);
            this.gbxNormalizationMethod.Location = new System.Drawing.Point(12, 11);
            this.gbxNormalizationMethod.Name = "gbxNormalizationMethod";
            this.gbxNormalizationMethod.Size = new System.Drawing.Size(238, 62);
            this.gbxNormalizationMethod.TabIndex = 19;
            this.gbxNormalizationMethod.TabStop = false;
            this.gbxNormalizationMethod.Text = "Method";
            // 
            // radNormalization_None
            // 
            this.radNormalization_None.AutoSize = true;
            this.radNormalization_None.Checked = true;
            this.radNormalization_None.Location = new System.Drawing.Point(19, 24);
            this.radNormalization_None.Name = "radNormalization_None";
            this.radNormalization_None.Size = new System.Drawing.Size(51, 17);
            this.radNormalization_None.TabIndex = 11;
            this.radNormalization_None.TabStop = true;
            this.radNormalization_None.Text = "None";
            this.radNormalization_None.UseVisualStyleBackColor = true;
            // 
            // radNormalization_ZeroMean
            // 
            this.radNormalization_ZeroMean.AutoSize = true;
            this.radNormalization_ZeroMean.Location = new System.Drawing.Point(147, 24);
            this.radNormalization_ZeroMean.Name = "radNormalization_ZeroMean";
            this.radNormalization_ZeroMean.Size = new System.Drawing.Size(77, 17);
            this.radNormalization_ZeroMean.TabIndex = 10;
            this.radNormalization_ZeroMean.Text = "Zero Mean";
            this.radNormalization_ZeroMean.UseVisualStyleBackColor = true;
            // 
            // radNormalization_MinMax
            // 
            this.radNormalization_MinMax.AutoSize = true;
            this.radNormalization_MinMax.Location = new System.Drawing.Point(76, 24);
            this.radNormalization_MinMax.Name = "radNormalization_MinMax";
            this.radNormalization_MinMax.Size = new System.Drawing.Size(65, 17);
            this.radNormalization_MinMax.TabIndex = 9;
            this.radNormalization_MinMax.Text = "Min Max";
            this.radNormalization_MinMax.UseVisualStyleBackColor = true;
            // 
            // FormNormalization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 122);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.gbxNormalizationMethod);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNormalization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Normalization";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormNormalization_FormClosed);
            this.gbxNormalizationMethod.ResumeLayout(false);
            this.gbxNormalizationMethod.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox gbxNormalizationMethod;
        private System.Windows.Forms.RadioButton radNormalization_ZeroMean;
        private System.Windows.Forms.RadioButton radNormalization_MinMax;
        private System.Windows.Forms.RadioButton radNormalization_None;
    }
}