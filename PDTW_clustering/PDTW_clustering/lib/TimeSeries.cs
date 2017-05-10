using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDTW_clustering.lib
{
    class TimeSeries
    {
        #region PROPERTIES
        // Length of this obj
        public int Length
        {
            get
            {
                return this.Series == null ? 0 : this.Series.Count;
            }
        }
        // Index of this obj in the data read from file
        public int Index { get; private set; }
        // ??? Value
        // public int Value { get; set; }
        // An ArrayList obj of data points read from file for this obj
        public ArrayList Series { get; private set; }
        // An ArrayList obj of PAA data points
        public TimeSeries PaaSeries { get; private set; }
        // Indicate the compression rate of this time series
        public int CompressionRate { get; private set; }
        // Label of this obj
        public int Label { get; private set; }
        // Current cluster to which this obj belongs to
        public Cluster CurrentCluster { get; set; }
        #endregion

        #region CONSTRUCTOR
        public TimeSeries()
        {
            this.Index = -1;
            // this.Length = 0;
            // this.Value = 1;
            this.CurrentCluster = null;
            this.Series = new ArrayList();
            this.PaaSeries = null;
            this.CompressionRate = 1;
        }
        public TimeSeries(TimeSeries ts, int c)
        {
            this.Index = ts.Index;
            // this.Length = 0;
            this.CurrentCluster = ts.CurrentCluster;
            this.Series = new ArrayList();
            this.PaaSeries = null;
            this.CompressionRate = c;
        }
        public TimeSeries(string s, int index)
        {
            string se = s;
            // this.Value = 1;
            this.Index = index;
            this.CurrentCluster = null;
            this.Series = new ArrayList();
            //_qseries = new ArrayList();
            se = se.Replace(',', ' ');
            for (int i = 0; i < 5; i++)
            {
                se = se.Replace("  ", " ");
            }
            string[] d = se.Split('@');
            if (d.Length > 1)
            {
                this.Label = int.Parse(d[0]);
                d = d[1].Split(' ');
            }
            else
            {
                this.Label = 100;
                d = d[0].Split(' ');
            }

            for (int i = 0; i < d.Length; i++)
            {
                if (d[i].Length > 0)
                {
                    this.Series.Add(float.Parse(d[i].Trim()));
                }
            }
            //this.Length = this.Series.Count;
        }
        #endregion

        #region METHODS
        // Get data point value at specified index
        public float get_at(int index)
        {
            return (float)this.Series[index];
        }

        // Calculate PAA time series
        public TimeSeries get_paa(int c)  // c is compression rate
        {
            if (this.PaaSeries == null || this.PaaSeries.CompressionRate != c)
            {
                TimeSeries paaTimeSeries = new TimeSeries(this, c);
                ArrayList series = new ArrayList();
                int n = this.Length;
                int noOfFullFrame = n / c;
                int j = 0;
                for (int i = 0; i < noOfFullFrame; i++)
                {
                    int ubound = j + c;
                    paa_calculate_frame(series, ref j, ubound, c);
                }
                if (j < n)
                    paa_calculate_frame(series, ref j, n, n % c);
                paaTimeSeries.Series = series;
                this.PaaSeries = paaTimeSeries;
            }
            return this.PaaSeries;
        }
        #endregion

        private void paa_calculate_frame(ArrayList series, ref int index, int ubound, int quantity)
        {
            float sum = 0;
            for (; index < ubound; index++)
            {
                sum += (float)this.Series[index];
            }
            float avg = sum / quantity;
            series.Add(avg);
        }
    }
}
