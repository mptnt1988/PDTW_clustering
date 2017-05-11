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

        // TESTING
        DtwDistance dtwDist;
        TimeSeries ts1, ts2;
        private void btnTest_Click(object sender, EventArgs e)
        {
            ts1 = new TimeSeries(new List<float>(new float[] { 5, 6, 3, 2, 9, 5, 9, 4, 8, 5 }));
            ts2 = new TimeSeries(new List<float>(new float[] { 3, 4, 1, 8, 3, 7, 4, 4, 8, 2 }));
            dtwDist = new DtwDistance(ts1, ts2);
            dtwDist.dtw();
            nudTest3.Maximum = dtwDist.PathMatrix.Count - 1;
            lblTest.Text = Environment.ProcessorCount.ToString();
            //lblTest.Text = dtwDist.PathMatrix.Count.ToString();
            //lblTest.Text = (dtwDist.X.Series[3] + dtwDist.Y.Series[int.Parse(txtTest.Text)]).ToString();
            //lblTest.Text = (ts1.Series[3] + ts2.Series[int.Parse(txtTest.Text)]).ToString();
        }

        private void nudTest1_ValueChanged(object sender, EventArgs e)
        {
            tuan();
            //lblTest.Text = ts1.Series[(int)nudTest1.Value].ToString();
        }

        private void nudTest2_ValueChanged(object sender, EventArgs e)
        {
            tuan();
            //lblTest.Text = ts2.Series[(int)nudTest2.Value].ToString();
        }

        private void nudTest3_ValueChanged(object sender, EventArgs e)
        {
            lblTest.Text = dtwDist.PathMatrix[(int)nudTest3.Value].value.ToString();
            lblTest.Text += ": ";
            lblTest.Text += dtwDist.PathMatrix[(int)nudTest3.Value].x.ToString();
            lblTest.Text += ", ";
            lblTest.Text += dtwDist.PathMatrix[(int)nudTest3.Value].y.ToString();
        }

        private void tuan()
        {
            lblTest.Text = dtwDist.DistanceMatrix[(int)nudTest1.Value, (int)nudTest2.Value].ToString();
        }
    }
}

