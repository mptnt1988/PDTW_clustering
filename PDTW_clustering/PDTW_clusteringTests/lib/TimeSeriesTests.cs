using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDTW_clustering.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDTW_clustering.lib.Tests
{
    [TestClass()]
    public class TimeSeriesTests
    {
        // Initialize a time series with all default parameters
        [TestMethod()]
        public void TimeSeriesTest_NoArguments()
        {
            // Scenario
            TimeSeries ts = new TimeSeries();

            // Check
            Assert.AreEqual(-1, ts.Index);
            Assert.AreEqual(-1, ts.Label);
            CollectionAssert.AreEqual(new List<float>(), ts.Series);
            Assert.AreEqual(EnumNormalization.NONE, ts.NormalizedType);
            Assert.IsNull(ts.NormalizedSeries);
            Assert.IsNull(ts.PaaSeries);
            Assert.AreEqual(1, ts.CompressionRate);
        }

        // Initialize a time series with provided values
        [TestMethod()]
        public void TimeSeriesTest_ListOfValues()
        {
            // Scenario
            TimeSeries ts = new TimeSeries(new List<float> { 1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f });

            // Check
            Assert.AreEqual(-1, ts.Index);
            Assert.AreEqual(-1, ts.Label);
            CollectionAssert.AreEqual(new List<float> { 1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f }, ts.Series);
            Assert.AreEqual(EnumNormalization.NONE, ts.NormalizedType);
            Assert.IsNull(ts.NormalizedSeries);
            Assert.IsNull(ts.PaaSeries);
            Assert.AreEqual(1, ts.CompressionRate);
        }

        // Initialize a time series with another time series
        [TestMethod()]
        public void TimeSeriesTest_TimeSeries()
        {
            // Scenario
            TimeSeries ts = new TimeSeries(new List<float> { 1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f });
            TimeSeries tsNew = new TimeSeries(ts);

            // Check
            Assert.AreNotEqual(ts, tsNew);
            Assert.AreEqual(-1, tsNew.Index);
            Assert.AreEqual(-1, tsNew.Label);
            CollectionAssert.AreEqual(new List<float> { 1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f }, tsNew.Series);
            Assert.AreEqual(EnumNormalization.NONE, tsNew.NormalizedType);
            Assert.IsNull(tsNew.NormalizedSeries);
            Assert.IsNull(tsNew.PaaSeries);
            Assert.AreEqual(1, tsNew.CompressionRate);
        }

        // Initialize a time series with values represented as a string read from text file, with its ordinal number
        [TestMethod()]
        public void TimeSeriesTest_StringAndIndex()
        {
            // Scenario
            string str = "3@ 1.0 2.1 3.2 4.3";
            int label = 3;
            List<float> listOfValues = new List<float> { 1.0f, 2.1f, 3.2f, 4.3f };
            int index = 6;
            TimeSeries ts = new TimeSeries(str, index);

            // Check
            Assert.AreEqual(index, ts.Index);
            Assert.AreEqual(label - 1, ts.Label);  // label in code is started from 0, while real label is started from 1
            CollectionAssert.AreEqual(new List<float> { 1.0f, 2.1f, 3.2f, 4.3f }, ts.Series);
            Assert.AreEqual(EnumNormalization.NONE, ts.NormalizedType);
            Assert.IsNull(ts.NormalizedSeries);
            Assert.IsNull(ts.PaaSeries);
            Assert.AreEqual(1, ts.CompressionRate);
            Assert.AreEqual(4, ts.Length);
        }
        
        // Test normalization
        [TestMethod()]
        public void normalizeTest()
        {
            int label = 3;
            List<float> listOfValues = new List<float> { 2.0f, 4.0f, 4.0f, 4.0f, 5.0f, 5.0f, 7.0f, 9.0f };
            string str = "3@ 2.0 4.0 4.0 4.0 5.0 5.0 7.0 9.0";
            int index = 8;
            int length = 8;
            TimeSeries ts = new TimeSeries(str, index);

            // Scenario 1: NONE
            List<float> listOfValues1 = listOfValues;
            TimeSeries ts1 = new TimeSeries(ts);
            ts1.normalize(EnumNormalization.NONE);

            // Check 1a
            Assert.AreEqual(index, ts1.Index);
            Assert.AreEqual(label - 1, ts1.Label);
            CollectionAssert.AreEqual(listOfValues, ts1.Series);
            Assert.AreEqual(EnumNormalization.NONE, ts.NormalizedType);
            Assert.IsNotNull(ts1.NormalizedSeries);
            Assert.IsNull(ts1.PaaSeries);
            Assert.AreEqual(1, ts1.CompressionRate);
            Assert.AreEqual(length, ts1.Length);

            // Check 1b
            TimeSeries normalizedTimeSeries1 = ts1.NormalizedSeries;
            Assert.AreEqual(index, normalizedTimeSeries1.Index);
            Assert.AreEqual(label - 1, normalizedTimeSeries1.Label);
            CollectionAssert.AreEqual(listOfValues, normalizedTimeSeries1.Series);
            Assert.AreEqual(EnumNormalization.NONE, ts.NormalizedType);
            Assert.IsNull(normalizedTimeSeries1.NormalizedSeries);
            Assert.IsNull(normalizedTimeSeries1.PaaSeries);
            Assert.AreEqual(1, normalizedTimeSeries1.CompressionRate);

            //--------
            // Scenario 2: MIN MAX
            List<float> listOfValues2 = new List<float> { 0f, 2f / 7, 2f / 7, 2f / 7, 3f / 7, 3f / 7, 5f / 7, 1f };
            TimeSeries ts2 = new TimeSeries(ts);
            ts2.normalize(EnumNormalization.MIN_MAX);

            // Check 2a
            Assert.AreEqual(index, ts2.Index);
            Assert.AreEqual(label - 1, ts2.Label);
            CollectionAssert.AreEqual(listOfValues, ts2.Series);
            Assert.AreEqual(EnumNormalization.MIN_MAX, ts2.NormalizedType);
            Assert.IsNotNull(ts1.NormalizedSeries);
            Assert.IsNull(ts2.PaaSeries);
            Assert.AreEqual(1, ts2.CompressionRate);
            Assert.AreEqual(length, ts2.Length);

            // Check 2b
            TimeSeries normalizedTimeSeries2 = ts2.NormalizedSeries;
            Assert.AreEqual(index, normalizedTimeSeries2.Index);
            Assert.AreEqual(label - 1, normalizedTimeSeries2.Label);
            CollectionAssert.AreEqual(listOfValues2, normalizedTimeSeries2.Series);
            Assert.AreEqual(EnumNormalization.NONE, normalizedTimeSeries2.NormalizedType);
            Assert.IsNull(normalizedTimeSeries2.NormalizedSeries);
            Assert.IsNull(normalizedTimeSeries2.PaaSeries);
            Assert.AreEqual(1, normalizedTimeSeries2.CompressionRate);

            //--------
            // Scenario 3: ZERO MIN
            List<float> listOfValues3 = new List<float> { -3f / 2, -1f / 2, -1f / 2, -1f / 2, 0f, 0f, 1f, 2f };
            TimeSeries ts3 = new TimeSeries(ts);
            ts3.normalize(EnumNormalization.ZERO_MEAN);

            // Check 3a
            Assert.AreEqual(index, ts3.Index);
            Assert.AreEqual(label - 1, ts3.Label);
            CollectionAssert.AreEqual(listOfValues, ts3.Series);
            Assert.AreEqual(EnumNormalization.ZERO_MEAN, ts3.NormalizedType);
            Assert.IsNotNull(ts3.NormalizedSeries);
            Assert.IsNull(ts3.PaaSeries);
            Assert.AreEqual(1, ts3.CompressionRate);
            Assert.AreEqual(length, ts3.Length);

            // Check 3b
            TimeSeries normalizedTimeSeries3 = ts3.NormalizedSeries;
            Assert.AreEqual(index, normalizedTimeSeries3.Index);
            Assert.AreEqual(label - 1, normalizedTimeSeries3.Label);
            CollectionAssert.AreEqual(listOfValues3, normalizedTimeSeries3.Series);
            Assert.AreEqual(EnumNormalization.NONE, normalizedTimeSeries3.NormalizedType);
            Assert.IsNull(normalizedTimeSeries3.NormalizedSeries);
            Assert.IsNull(normalizedTimeSeries3.PaaSeries);
            Assert.AreEqual(1, normalizedTimeSeries3.CompressionRate);
        }

        // Test PAA
        [TestMethod()]
        public void paaTest()
        {
            int label = 3;
            List<float> listOfValues = new List<float> { 2.0f, 4.0f, 4.0f, 4.0f, 5.0f, 5.0f, 7.0f, 9.0f };
            string str = "3@ 2.0 4.0 4.0 4.0 5.0 5.0 7.0 9.0";
            int index = 8;
            int length = 8;
            TimeSeries ts = new TimeSeries(str, index);

            // Scenario 1: no normalization
            List<float> listOfValues1 = new List<float> { 3f, 4f, 5f, 8f };
            bool isNormalized1 = false;
            int compressionRate1 = 2;
            TimeSeries ts1 = new TimeSeries(ts);
            ts1.paa(compressionRate1, isNormalized1);

            // Check 1a
            Assert.AreEqual(index, ts1.Index);
            Assert.AreEqual(label - 1, ts1.Label);
            CollectionAssert.AreEqual(listOfValues, ts1.Series);
            Assert.AreEqual(EnumNormalization.NONE, ts1.NormalizedType);
            Assert.IsNull(ts1.NormalizedSeries);
            Assert.IsNotNull(ts1.PaaSeries);
            Assert.AreEqual(compressionRate1, ts1.CompressionRate);
            Assert.AreEqual(length, ts1.Length);

            // Check 1b
            TimeSeries paaTimeSeries1 = ts1.PaaSeries;
            Assert.AreEqual(index, paaTimeSeries1.Index);
            Assert.AreEqual(label - 1, paaTimeSeries1.Label);
            CollectionAssert.AreEqual(listOfValues1, paaTimeSeries1.Series);
            Assert.AreEqual(EnumNormalization.NONE, paaTimeSeries1.NormalizedType);
            Assert.IsNull(paaTimeSeries1.NormalizedSeries);
            Assert.IsNull(paaTimeSeries1.PaaSeries);
            Assert.AreEqual(1, paaTimeSeries1.CompressionRate);
            Assert.AreEqual(length / compressionRate1, paaTimeSeries1.Length);

            // Scenario 2: min max normalization
            List<float> listOfValues2 = new List<float> { 1.5f / 7, 4.5f / 7 };
            bool isNormalized2 = true;
            int compressionRate2 = 4;
            TimeSeries ts2 = new TimeSeries(ts);
            ts2.normalize(EnumNormalization.MIN_MAX);
            ts2.paa(compressionRate2, isNormalized2);

            // Check 2a
            Assert.AreEqual(index, ts2.Index);
            Assert.AreEqual(label - 1, ts2.Label);
            CollectionAssert.AreEqual(listOfValues, ts2.Series);
            Assert.AreEqual(EnumNormalization.MIN_MAX, ts2.NormalizedType);
            Assert.IsNotNull(ts2.NormalizedSeries);
            Assert.IsNotNull(ts2.PaaSeries);
            Assert.AreEqual(compressionRate2, ts2.CompressionRate);
            Assert.AreEqual(length, ts2.Length);

            // Check 2b
            TimeSeries paaTimeSeries2 = ts2.PaaSeries;
            Assert.AreEqual(index, paaTimeSeries2.Index);
            Assert.AreEqual(label - 1, paaTimeSeries2.Label);
            for (int i = 0; i < paaTimeSeries2.Length; i++)
                Assert.IsTrue(Math.Abs(listOfValues2[i] - paaTimeSeries2.Series[i]) < 0.000001);
            Assert.AreEqual(EnumNormalization.MIN_MAX, paaTimeSeries2.NormalizedType);
            Assert.IsNotNull(paaTimeSeries2.NormalizedSeries);
            Assert.IsNull(paaTimeSeries2.PaaSeries);
            Assert.AreEqual(1, paaTimeSeries2.CompressionRate);
            Assert.AreEqual(length / compressionRate2, paaTimeSeries2.Length);

            // Scenario 3: zero min normalization
            List<float> listOfValues3 = new List<float> { 0f };
            bool isNormalized3 = true;
            int compressionRate3 = 8;
            TimeSeries ts3 = new TimeSeries(ts);
            ts3.normalize(EnumNormalization.ZERO_MEAN);
            ts3.paa(compressionRate3, isNormalized3);

            // Check 3a
            Assert.AreEqual(index, ts3.Index);
            Assert.AreEqual(label - 1, ts3.Label);
            CollectionAssert.AreEqual(listOfValues, ts3.Series);
            Assert.AreEqual(EnumNormalization.ZERO_MEAN, ts3.NormalizedType);
            Assert.IsNotNull(ts3.NormalizedSeries);
            Assert.IsNotNull(ts3.PaaSeries);
            Assert.AreEqual(compressionRate3, ts3.CompressionRate);
            Assert.AreEqual(length, ts3.Length);

            // Check 3b
            TimeSeries paaTimeSeries3 = ts3.PaaSeries;
            Assert.AreEqual(index, paaTimeSeries3.Index);
            Assert.AreEqual(label - 1, paaTimeSeries3.Label);
            for (int i = 0; i < paaTimeSeries3.Length; i++)
                Assert.IsTrue(Math.Abs(listOfValues3[i] - paaTimeSeries3.Series[i]) < 0.000001);
            Assert.AreEqual(EnumNormalization.ZERO_MEAN, paaTimeSeries3.NormalizedType);
            Assert.IsNotNull(paaTimeSeries3.NormalizedSeries);
            Assert.IsNull(paaTimeSeries3.PaaSeries);
            Assert.AreEqual(1, paaTimeSeries3.CompressionRate);
            Assert.AreEqual(length / compressionRate3, paaTimeSeries3.Length);
        }
    }
}