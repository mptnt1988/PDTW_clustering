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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOke = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radNormalization_ZeroMean = new System.Windows.Forms.RadioButton();
            this.radNormalization_MinMax = new System.Windows.Forms.RadioButton();
            this.radNormalization_None = new System.Windows.Forms.RadioButton();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(136, 94);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 29);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOke
            // 
            this.btnOke.Location = new System.Drawing.Point(49, 94);
            this.btnOke.Name = "btnOke";
            this.btnOke.Size = new System.Drawing.Size(81, 29);
            this.btnOke.TabIndex = 20;
            this.btnOke.Text = "OK";
            this.btnOke.UseVisualStyleBackColor = true;
            this.btnOke.Click += new System.EventHandler(this.btnOke_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radNormalization_None);
            this.groupBox5.Controls.Add(this.radNormalization_ZeroMean);
            this.groupBox5.Controls.Add(this.radNormalization_MinMax);
            this.groupBox5.Location = new System.Drawing.Point(12, 11);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(254, 62);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Method";
            // 
            // radNormalization_ZeroMean
            // 
            this.radNormalization_ZeroMean.AutoSize = true;
            this.radNormalization_ZeroMean.Location = new System.Drawing.Point(160, 24);
            this.radNormalization_ZeroMean.Name = "radNormalization_ZeroMean";
            this.radNormalization_ZeroMean.Size = new System.Drawing.Size(77, 17);
            this.radNormalization_ZeroMean.TabIndex = 10;
            this.radNormalization_ZeroMean.Text = "Zero Mean";
            this.radNormalization_ZeroMean.UseVisualStyleBackColor = true;
            // 
            // radNormalization_MinMax
            // 
            this.radNormalization_MinMax.AutoSize = true;
            this.radNormalization_MinMax.Location = new System.Drawing.Point(89, 24);
            this.radNormalization_MinMax.Name = "radNormalization_MinMax";
            this.radNormalization_MinMax.Size = new System.Drawing.Size(65, 17);
            this.radNormalization_MinMax.TabIndex = 9;
            this.radNormalization_MinMax.Text = "Min Max";
            this.radNormalization_MinMax.UseVisualStyleBackColor = true;
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
            // FormNormalization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 144);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOke);
            this.Controls.Add(this.groupBox5);
            this.Name = "FormNormalization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Normalization";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormNormalization_FormClosed);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOke;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radNormalization_ZeroMean;
        private System.Windows.Forms.RadioButton radNormalization_MinMax;
        private System.Windows.Forms.RadioButton radNormalization_None;
    }
}