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
        // A time sereis - series of data points read from file for this obj
        public List<float> Series { get; private set; }
        // The time sereis after being normalized
        public TimeSeries NormalizedSeries { get; private set; }
        // The time series after being PAA-calculated
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
            this.PaaSeries = this;
            this.CompressionRate = 1;
        }
        public TimeSeries(List<float> series)
        {
            this._index = -1;
            this.Series = series;
            this.PaaSeries = this;
            this.CompressionRate = 1;
        }
        public TimeSeries(TimeSeries ts)
        {
            this._index = ts.Index;
            this.Series = new List<float>(ts.Series);
            this._label = ts.Label;
            this.NormalizedSeries = this;
            this.PaaSeries = this;
            this.CompressionRate = 1;
        }
        public TimeSeries(string s, int index)
        {
            string se = s;
            this._index = index;
            this.Series = new List<float>();
            this.PaaSeries = this;
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
        public TimeSeries get_paa(int c, bool isNormalized)  // c is compression rate, c >= 2
        {
            this.CompressionRate = c;
            TimeSeries paaTimeSeries = new TimeSeries(this);
            List<float> series = new List<float>();
            if (c == 1)
            {
                if (isNormalized)
                    series = this.NormalizedSeries.Series;
                else
                    series = this.Series;
            }
            else if (this.CompressionRate == 1 || this.CompressionRate != c)
            {
                
                int n = this.Length;
                int noOfFullFrame = n / c;
                int j = 0;
                for (int i = 0; i < noOfFullFrame; i++)
                {
                    int ubound = j + c;
                    paa_calculate_frame(series, ref j, ubound, c, isNormalized);
                }
                if (j < n)
                    paa_calculate_frame(series, ref j, n, n % c, isNormalized);
            }
            paaTimeSeries.Series = series;
            this.PaaSeries = paaTimeSeries;
            return this.PaaSeries;
        }

        public TimeSeries normalize(EnumNormalization normalization)
        {
            TimeSeries normalizedSeries = new TimeSeries(this);
            List<float> series;
            switch (normalization)
            {
                case EnumNormalization.MIN_MAX:
                    series = normalize_min_max();
                    break;
                case EnumNormalization.ZERO_MIN:
                    series = normalize_zero_mean();
                    break;
                default:
                    throw new Exception("There is some error in configuring normalization");
            }
            normalizedSeries.Series = series;
            this.NormalizedSeries = normalizedSeries;
            return normalizedSeries;
        }
        #endregion

        private List<float> normalize_min_max()
        {
            float max = float.NegativeInfinity;
            float min = float.PositiveInfinity;
            int length = Length;
            List<float> series = new List<float>();

            for (int i = 0; i < length; i++)
            {
                float value = Series[i];
                if (max < value)
                {
                    max = value;
                }
                if (min > value)
                {
                    min = value;
                }
            }
            for (int i = 0; i < length; i++)
            {
                series.Add((Series[i] - min) / (max - min));
            }
            return series;
        }

        private List<float> normalize_zero_mean()
        {
            float value = 0;
            float vars = 0;
            float mean = 0;
            int length = Length;
            List<float> series = new List<float>();

            for (int i = 0; i < length; i++)
            {
                value += Series[i];
            }
            mean = value / length;
            value = 0;
            for (int i = 0; i < length; i++)
            {
                value += (Series[i] - mean) * (Series[i] - mean);
            }
            vars = (float)Math.Sqrt(value / length);
            for (int i = 0; i < length; i++)
            {
                series.Add((Series[i] - mean) / vars);
            }
            return series;
        }

        private void paa_calculate_frame(List<float> series, ref int index, int ubound, int quantity, bool isNormalized)
        {
            float sum = 0;
            for (; index < ubound; index++)
            {
                float addent;
                if (isNormalized)
                    addent = this.NormalizedSeries.Series[index];
                else
                    addent = this.Series[index];
                sum += addent;
            }
            float avg = sum / quantity;
            series.Add(avg);
        }
    }
}
