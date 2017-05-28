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
    public class DtwDistanceTests
    {
        [TestMethod()]
        public void DtwDistanceTest_NoArguments()
        {
            DtwDistance distance = new DtwDistance();
            Assert.AreEqual(EnumDtwMultithreading.ENABLED, distance.IsMultithreading);
            distance.IsMultithreading = EnumDtwMultithreading.DISABLED;
            Assert.AreEqual(EnumDtwMultithreading.DISABLED, distance.IsMultithreading);
        }

        [TestMethod()]
        public void DtwDistanceTest_InitialTimeSeries()
        {
            TimeSeries ts1, ts2;
            ts1 = new TimeSeries(new List<float>(new float[] { 5, 6, 3, 2, 9, 5, 9, 4, 8, 5 }));
            ts2 = new TimeSeries(new List<float>(new float[] { 3, 4, 1, 8, 3, 7, 4, 4, 8, 2 }));
            DtwDistance distance = new DtwDistance(ts1, ts2);
            Assert.AreEqual(EnumDtwMultithreading.ENABLED, distance.IsMultithreading);
            distance.IsMultithreading = EnumDtwMultithreading.DISABLED;
            Assert.AreEqual(EnumDtwMultithreading.DISABLED, distance.IsMultithreading);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CalculateTest()
        {
            DtwDistance distance = new DtwDistance();
            distance.Calculate();
        }

        [TestMethod()]
        public void CalculateTest_NormalTimeSeries()
        {
            TimeSeries ts1, ts2;
            ts1 = new TimeSeries(new List<float>(new float[] { 5, 6, 3, 2, 9, 5, 9, 4, 8, 5 }));
            ts2 = new TimeSeries(new List<float>(new float[] { 3, 4, 1, 8, 3, 7, 4, 4, 8, 2 }));
            List<PathPoint> expectedPathMatrix = new List<PathPoint>
            {
                new PathPoint(0, 0, 4),
                new PathPoint(1, 1, 8),
                new PathPoint(2, 1, 9),
                new PathPoint(3, 2, 10),
                new PathPoint(4, 3, 11),
                new PathPoint(5, 4, 15),
                new PathPoint(6, 5, 19),
                new PathPoint(7, 6, 19),
                new PathPoint(7, 7, 19),
                new PathPoint(8, 8, 19),
                new PathPoint(9, 9, 28),
            };
            int expectedPathMatrixLength = expectedPathMatrix.Count;
            float expectedValue = (float)Math.Sqrt(expectedPathMatrix[expectedPathMatrixLength - 1].value) / expectedPathMatrixLength;

            // Scenario
            DtwDistance[] distance = new DtwDistance[3];
            distance[0] = new DtwDistance(ts1, ts2);
            distance[0].Calculate();
            distance[1] = new DtwDistance();
            distance[1].Calculate(ts1, ts2);
            distance[2] = new DtwDistance(ts1, ts2);
            distance[2].IsMultithreading = EnumDtwMultithreading.DISABLED;
            distance[2].Calculate(ts1, ts2);

            // Check
            for (int i = 0; i < distance.Length; i++)
            {
                CollectionAssert.AreEqual(expectedPathMatrix, distance[i].PathMatrix);
                Assert.AreEqual(expectedValue, distance[i].Value);
            }
        }

        [TestMethod()]
        public void CalculateTest_NormalizedTimeSeries()
        {
            TimeSeries ts1, ts2;
            ts1 = new TimeSeries(new List<float>(new float[] { 3, 1, 1, 3, 3, 3, 1, 1, 3, 1 }));
            ts2 = new TimeSeries(new List<float>(new float[] { 4, 6, 6, 4, 6, 4, 4, 6, 4, 6 }));
            DtwDistance distance = new DtwDistance();
            
            // Scenario MinMax
            TimeSeries tsMinMax1, tsMinMax2;
            tsMinMax1 = new TimeSeries(ts1);
            tsMinMax2 = new TimeSeries(ts2);
            EnumNormalization normalizationTypeMinMax = EnumNormalization.MIN_MAX;
            tsMinMax1.normalize(normalizationTypeMinMax);
            tsMinMax2.normalize(normalizationTypeMinMax);
            distance.Calculate(tsMinMax1, tsMinMax2);

            // Check MinMax
            List<PathPoint> expectedPathMatrixMinMax = new List<PathPoint>
            {
                new PathPoint(0, 0, 1),
                new PathPoint(0, 1, 1),
                new PathPoint(0, 2, 1),
                new PathPoint(1, 3, 1),
                new PathPoint(2, 3, 1),
                new PathPoint(3, 4, 1),
                new PathPoint(4, 4, 1),
                new PathPoint(5, 4, 1),
                new PathPoint(6, 5, 1),
                new PathPoint(7, 6, 1),
                new PathPoint(8, 7, 1),
                new PathPoint(9, 8, 1),
                new PathPoint(9, 9, 2),
            };
            int expectedPathMatrixMinMaxLength = expectedPathMatrixMinMax.Count;
            float expectedValueMinMax = (float)Math.Sqrt(expectedPathMatrixMinMax[expectedPathMatrixMinMaxLength - 1].value) / expectedPathMatrixMinMaxLength;
            CollectionAssert.AreEqual(expectedPathMatrixMinMax, distance.PathMatrix);
            Assert.AreEqual(expectedValueMinMax, distance.Value);

            // Scenario ZeroMean
            TimeSeries tsZeroMean1, tsZeroMean2;
            tsZeroMean1 = new TimeSeries(ts1);
            tsZeroMean2 = new TimeSeries(ts2);
            EnumNormalization normalizationTypeZeroMean = EnumNormalization.ZERO_MEAN;
            tsZeroMean1.normalize(normalizationTypeZeroMean);
            tsZeroMean2.normalize(normalizationTypeZeroMean);
            distance.Calculate(tsZeroMean1, tsZeroMean2);

            // Check ZeroMean
            List<PathPoint> expectedPathMatrixZeroMean = new List<PathPoint>
            {
                new PathPoint(0, 0, 4),
                new PathPoint(0, 1, 4),
                new PathPoint(0, 2, 4),
                new PathPoint(1, 3, 4),
                new PathPoint(2, 3, 4),
                new PathPoint(3, 4, 4),
                new PathPoint(4, 4, 4),
                new PathPoint(5, 4, 4),
                new PathPoint(6, 5, 4),
                new PathPoint(7, 6, 4),
                new PathPoint(8, 7, 4),
                new PathPoint(9, 8, 4),
                new PathPoint(9, 9, 8),
            };
            int expectedPathMatrixZeroMeanLength = expectedPathMatrixZeroMean.Count;
            float expectedValueZeroMean = (float)Math.Sqrt(expectedPathMatrixZeroMean[expectedPathMatrixZeroMeanLength - 1].value) / expectedPathMatrixZeroMeanLength;
            CollectionAssert.AreEqual(expectedPathMatrixZeroMean, distance.PathMatrix);
            Assert.AreEqual(expectedValueZeroMean, distance.Value);
        }

        [TestMethod()]
        public void CalculateTest_PaaTimeSeries()
        {
            TimeSeries ts1, ts2;
            // Create ts1 and ts2 from:
            // { 5, 6, 3, 2, 9, 5, 9, 4, 8, 5 }));
            // { 3, 4, 1, 8, 3, 7, 4, 4, 8, 2 }));
            ts1 = new TimeSeries(new List<float>(new float[] { 3, 7, 4, 8, 2, 4, 0, 4, 4, 14, 2, 8, 3, 15, 1, 7, 10, 6, 8, 2 }));
            ts2 = new TimeSeries(new List<float>(new float[] { 5, 1, 4, 4, 1, 1, 7, 9, 1, 5, 8, 6, 3, 5, 6, 2, 4, 12, 3, 1 }));
            int compressionRate = 2;
            bool isNormalized = false;
            // Expected path matrix is:
            // {
            //    new PathPoint(0, 0, 4),
            //    new PathPoint(1, 1, 8),
            //    new PathPoint(2, 1, 9),
            //    new PathPoint(3, 2, 10),
            //    new PathPoint(4, 3, 11),
            //    new PathPoint(5, 4, 15),
            //    new PathPoint(6, 5, 19),
            //    new PathPoint(7, 6, 19),
            //    new PathPoint(7, 7, 19),
            //    new PathPoint(8, 8, 19),
            //    new PathPoint(9, 9, 28),
            // };
            float expectedEndPointValue = 28f;
            float expectedValue = (float)Math.Sqrt(expectedEndPointValue / compressionRate);

            // Scenario
            ts1.paa(compressionRate, isNormalized);
            ts2.paa(compressionRate, isNormalized);
            DtwDistance distance = new DtwDistance();
            distance.Calculate(ts1, ts2);

            // Check
            Assert.IsNull(distance.PathMatrix);
            Assert.AreEqual(expectedEndPointValue, distance.DistanceMatrix.Cast<float>().Last());
            Assert.AreEqual(expectedValue, distance.Value);
        }

        [TestMethod()]
        public void CalculateTest_PaaNormalizedTimeSeries()
        {
            TimeSeries ts1, ts2;
            ts1 = new TimeSeries(new List<float>(new float[] { 3, 1, 1, 3, 3, 3, 1, 1, 3, 1, 3, 1 }));
            ts2 = new TimeSeries(new List<float>(new float[] { 4, 6, 6, 4, 6, 4, 4, 6, 4, 6, 6, 4 }));
            DtwDistance distance = new DtwDistance();
            bool isNormalized = true;
            int compressionRate = 3;

            // Scenario PAA MinMax
            TimeSeries tsMinMax1, tsMinMax2;
            tsMinMax1 = new TimeSeries(ts1);
            tsMinMax2 = new TimeSeries(ts2);
            EnumNormalization normalizationTypeMinMax = EnumNormalization.MIN_MAX;
            tsMinMax1.normalize(normalizationTypeMinMax);
            tsMinMax1.paa(compressionRate, isNormalized);
            tsMinMax2.normalize(normalizationTypeMinMax);
            tsMinMax2.paa(compressionRate, isNormalized);
            distance.Calculate(tsMinMax1, tsMinMax2);

            // Check PAA MinMax
            float expectedEndPointValuePaaMinMax = 1f / 3;
            float expectedValuePaaMinMax = (float)Math.Sqrt(expectedEndPointValuePaaMinMax / compressionRate);
            Assert.IsNull(distance.PathMatrix);
            Assert.IsTrue(Math.Abs(expectedEndPointValuePaaMinMax - distance.DistanceMatrix.Cast<float>().Last()) < 0.000001);
            Assert.IsTrue(Math.Abs(expectedValuePaaMinMax - distance.Value) < 0.000001);

            // Scenario PAA ZeroMean
            TimeSeries tsZeroMean1, tsZeroMean2;
            tsZeroMean1 = new TimeSeries(ts1);
            tsZeroMean2 = new TimeSeries(ts2);
            EnumNormalization normalizationTypeZeroMean = EnumNormalization.ZERO_MEAN;
            tsZeroMean1.normalize(normalizationTypeZeroMean);
            tsZeroMean1.paa(compressionRate, isNormalized);
            tsZeroMean2.normalize(normalizationTypeZeroMean);
            tsZeroMean2.paa(compressionRate, isNormalized);
            distance.Calculate(tsZeroMean1, tsZeroMean2);

            // Check PAA ZeroMean
            float expectedEndPointValuePaaZeroMean = 4f / 3;
            float expectedValuePaaZeroMean = (float)Math.Sqrt(expectedEndPointValuePaaZeroMean / compressionRate);
            Assert.IsNull(distance.PathMatrix);
            Assert.AreEqual(expectedEndPointValuePaaZeroMean, distance.DistanceMatrix.Cast<float>().Last());
            Assert.AreEqual(expectedValuePaaZeroMean, distance.Value);
        }
    }
}


