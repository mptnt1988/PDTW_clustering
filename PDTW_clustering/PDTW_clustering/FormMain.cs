using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDTW_clustering.lib;

namespace PDTW_clustering
{
    public partial class FormMain : Form
    {
        private ArrayList _data;
        public long MaxLength;
        public long MinLength;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = 1;
            MaxLength = long.MinValue;
            MinLength = long.MaxValue;
            ArrayList _temp = new ArrayList();
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
                        if (t.Length > MaxLength)
                        {
                            MaxLength = t.Length;
                        }
                        if (t.Length < MinLength)
                        {
                            MinLength = t.Length;
                        }
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
            //formView.Parent = this;
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

        private void btnTest_Click(object sender, EventArgs e)
        {

            //TimeSeries ts = (TimeSeries)this._data[0];
            //ts.get_paa(int.Parse(txtTest.Text));
            //lblTest.Text = ts.PaaSeries.Series[ts.PaaSeries.Length - 1].ToString();
            //float[,] f = new float[3, 5];
            //lblTest.Text = tuan(f);
            int x = 3;
            lblTest.Text = (++x + tuan(x, 2)).ToString();
        }
        private int tuan(int x, int n)
        {
            return x * n;
        }
    }
}
