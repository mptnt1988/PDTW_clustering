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
        private List<TimeSeries> _data;
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
            List<TimeSeries> _temp = new List<TimeSeries>();
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
        TimeSeries ts1, ts2, ts3, ts4, ts5, ts6, ts7, ts8;
        int[] clusterOfObject;
        private void btnTest_Click(object sender, EventArgs e)
        {
            ts1 = new TimeSeries(new List<float>(new float[] { 5, 6, 3, 2, 9, 5, 9, 4, 8, 5 }));
            ts2 = new TimeSeries(new List<float>(new float[] { 3, 4, 1, 8, 3, 7, 4, 4, 8, 2 }));
            ts3 = new TimeSeries(new List<float>(new float[] { 3, 4, 1, 8, 3, 7, 5, 4, 8, 2 }));
            ts4 = new TimeSeries(new List<float>(new float[] { 5, 7, 3, 2, 9, 5, 9, 4, 8, 5 }));
            ts5 = new TimeSeries(new List<float>(new float[] { 5, 6, 3, 2, 9, 5, 9, 4, 8, 5 }));
            ts6 = new TimeSeries(new List<float>(new float[] { 3, 4, 1, 8, 3, 7, 4, 4, 8, 2 }));
            ts7 = new TimeSeries(new List<float>(new float[] { 3, 4, 1, 8, 3, 7, 5, 4, 8, 2 }));
            ts8 = new TimeSeries(new List<float>(new float[] { 5, 7, 3, 2, 9, 5, 9, 4, 8, 5 }));

            dtwDist = new DtwDistance();
            //dtwDist.Calculate(ts1, ts2);
            nudTest1.Maximum = ts1.Series.Count - 1;
            nudTest2.Maximum = ts2.Series.Count - 1;

            List<object> tsList = new List<object>();
            tsList.Add(ts1); tsList.Add(ts2); tsList.Add(ts3); tsList.Add(ts4);
            tsList.Add(ts5); tsList.Add(ts6); tsList.Add(ts7); tsList.Add(ts8);
            ImprovedKMedoids cls = new ImprovedKMedoids(tsList, 3, dtwDist);
            clusterOfObject = cls.do_cluster();
            nudTest3.Maximum = clusterOfObject.Length - 1;
            //lblTest.Text = dtwDist.Value.ToString();
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
            lblTest.Text = clusterOfObject[(int)nudTest3.Value].ToString();
            //lblTest.Text = dtwDist.PathMatrix[(int)nudTest3.Value].value.ToString();
            //lblTest.Text += ": ";
            //lblTest.Text += dtwDist.X.Series[dtwDist.PathMatrix[(int)nudTest3.Value].x].ToString();
            //lblTest.Text += ", ";
            //lblTest.Text += dtwDist.Y.Series[dtwDist.PathMatrix[(int)nudTest3.Value].y].ToString();
        }

        private void tuan()
        {
            lblTest.Text = dtwDist.DistanceMatrix[(int)nudTest1.Value, (int)nudTest2.Value].ToString();
        }
    }
}

