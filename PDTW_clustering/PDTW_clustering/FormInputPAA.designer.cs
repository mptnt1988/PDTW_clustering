namespace PDTW_clustering
{
    partial class FormInputPAA
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
            this.nudPaa = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaa)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(184, 79);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 29);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOke
            // 
            this.btnOke.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOke.Location = new System.Drawing.Point(97, 79);
            this.btnOke.Name = "btnOke";
            this.btnOke.Size = new System.Drawing.Size(81, 29);
            this.btnOke.TabIndex = 19;
            this.btnOke.Text = "OK";
            this.btnOke.UseVisualStyleBackColor = true;
            this.btnOke.Click += new System.EventHandler(this.btnOke_Click);
            // 
            // nudPaa
            // 
            this.nudPaa.Location = new System.Drawing.Point(134, 29);
            this.nudPaa.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPaa.Name = "nudPaa";
            this.nudPaa.Size = new System.Drawing.Size(80, 20);
            this.nudPaa.TabIndex = 21;
            this.nudPaa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPaa.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Compression Rate";
            // 
            // FPaa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 123);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudPaa);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOke);
            this.Name = "FPaa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Input PAA";
            ((System.ComponentModel.ISupportInitialize)(this.nudPaa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOke;
        private System.Windows.Forms.NumericUpDown nudPaa;
        private System.Windows.Forms.Label label1;
    }
}