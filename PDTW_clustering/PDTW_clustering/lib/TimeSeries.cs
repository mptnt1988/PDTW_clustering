using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDTW_clustering.lib
{
    public class TimeSeries : ClusteringObject
    {
        private int _label;
        private int _index;

        #region PROPERTIES
        // Length of this obj
        public int Length
        {
            get
            {
                return this.Series == null ? 0 : this.Series.Count;
            }
        }
        // An ArrayList obj of data points read from file for this obj
        public List<float> Series { get; private set; }
        // An ArrayList obj of PAA data points
        public TimeSeries PaaSeries { get; private set; }
        // Indicate the compression rate of this time series
        public int CompressionRate { get; private set; }

        // Label of this obj
        public override int Label { get { return _label; } }
        // Index of this obj in the data read from file
        public override int Index { get { return _index; } }
        #endregion

        #region CONSTRUCTOR
        public TimeSeries()
        {
            this._index = -1;
            this.Series = new List<float>();
            this.PaaSeries = null;
            this.CompressionRate = 1;
        }
        public TimeSeries(List<float> series)
        {
            this._index = -1;
            this.Series = series;
            this.PaaSeries = null;
            this.CompressionRate = 1;
        }
        public TimeSeries(TimeSeries ts, int c)
        {
            this._index = ts.Index;
            this.Series = new List<float>();
            this._label = ts.Label;
            this.PaaSeries = null;
            this.CompressionRate = c;
        }
        public TimeSeries(string s, int index)
        {
            string se = s;
            this._index = index;
            this.Series = new List<float>();
            this.CompressionRate = 1;
            se = se.Replace(',', ' ');
            for (int i = 0; i < 5; i++)
            {
                se = se.Replace("  ", " ");
            }
            string[] d = se.Split('@');
            if (d.Length > 1)
            {
                this._label = int.Parse(d[0]) - 1;
                d = d[1].Split(' ');
            }
            else
            {
                this._label = -1;
                d = d[0].Split(' ');
            }

            for (int i = 0; i < d.Length; i++)
            {
                if (d[i].Length > 0)
                {
                    this.Series.Add(float.Parse(d[i].Trim()));
                }
            }
        }
        #endregion

        #region METHODS
        // Calculate PAA time series
        public TimeSeries get_paa(int c)  // c is compression rate
        {
            if (this.PaaSeries == null || this.PaaSeries.CompressionRate != c)
            {
                TimeSeries paaTimeSeries = new TimeSeries(this, c);
                List<float> series = new List<float>();
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

        private void paa_calculate_frame(List<float> series, ref int index, int ubound, int quantity)
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
