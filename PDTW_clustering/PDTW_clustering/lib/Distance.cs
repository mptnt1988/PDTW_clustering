using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Algorithms;
using System.Threading.Tasks;

namespace PDTW_clustering.lib
{
    public abstract class Distance
    {
        #region PROPERTIES
        protected object X;
        protected object Y;
        #endregion

        #region CONSTRUCTORS
        public Distance() { }
        public Distance(object objX, object objY)
        {
            this.X = objX;
            this.Y = objY;
        }
        #endregion

        #region ABSTRACTION
        public abstract float Calculate();
        public abstract float Calculate(object X, object Y);
        #endregion
    }

    public class DtwDistance : Distance
    {
        private TimeSeries _x;
        private TimeSeries _y;
        private int _compressionRate;

        #region PROPERTIES
        public List<PathPoint> PathMatrix { get; private set; }
        public float[,] DistanceMatrix { get; private set; }
        public float Value { get; private set; }
        public EnumDtwMultithreading IsMultithreading { get; set; }
        #endregion

        #region CONSTRUCTORS
        public DtwDistance() : base()
        {
            IsMultithreading = EnumDtwMultithreading.ENABLED;
        }

        public DtwDistance(TimeSeries tsX, TimeSeries tsY) : base(tsX, tsY)
        {
            IsMultithreading = EnumDtwMultithreading.ENABLED;
            _x = (TimeSeries)tsX;
            _y = (TimeSeries)tsY;
        }
        #endregion

        #region BEHAVIORS
        public override float Calculate()
        {
            if (this.X == null || this.Y == null)
                throw new ArgumentNullException("At least one of time series is null");
            else
                return Calculate(this._x, this._y);
        }

        public override float Calculate(object tsX, object tsY)
        {
            _x = ((TimeSeries)tsX).ClusteringSeries;
            _y = ((TimeSeries)tsY).ClusteringSeries;
            if (((TimeSeries)tsX).CompressionRate != ((TimeSeries)tsY).CompressionRate)
                throw new Exception("Two time series must have the same compression rate");
            _compressionRate = ((TimeSeries)tsX).CompressionRate;
            
            switch (IsMultithreading)
            {
                case EnumDtwMultithreading.DISABLED:
                    dtw();
                    break;
                case EnumDtwMultithreading.ENABLED:
                    parallel_dtw();
                    break;
                default:
                    throw new Exception("There is something wrong with configuring multithreading");
            }

            if (_compressionRate == 1)
            {
                dtw_update_path();
                Value = (float)Math.Sqrt(DistanceMatrix[_x.Length - 1, _y.Length - 1]) / PathMatrix.Count;
            }
            else
            {
                //dtw_update_path();
                Value = (float)Math.Sqrt(DistanceMatrix[_x.Length - 1, _y.Length - 1] / _compressionRate);
            }
            return Value;
        }
        #endregion

        #region FUNCTIONS
        private void parallel_dtw()
        {
            int nX = _x.Length;
            int nY = _y.Length;
            DistanceMatrix = new float[nX, nY];
            //int noOfBlocksX = calc_number_of_blocks(nX);
            //int noOfBlocksY = calc_number_of_blocks(nY);
            int noOfBlocks = calc_number_of_blocks(nX);
            ParallelAlgorithms.Wavefront(nX, nY, noOfBlocks, noOfBlocks,
                (start_i, end_i, start_j, end_j) =>
            {
                for (int i = start_i; i < end_i; i++)
                    for (int j = start_j; j < end_j; j++)
                    {
                        if (i == 0)
                            if (j == 0)
                                DistanceMatrix[0, 0] = elems_distance(_x.Series[0], _y.Series[0]);
                            else
                                DistanceMatrix[0, j] = elems_distance(_x.Series[0], _y.Series[j]) + DistanceMatrix[0, j - 1];
                        else if (j == 0)
                            DistanceMatrix[i, 0] = elems_distance(_x.Series[i], _y.Series[0]) + DistanceMatrix[i - 1, 0];
                        else
                        {
                            float minPredVal =
                                find_min(DistanceMatrix[i - 1, j],
                                         DistanceMatrix[i, j - 1],
                                         DistanceMatrix[i - 1, j - 1]);
                            DistanceMatrix[i, j] = elems_distance(_x.Series[i], _y.Series[j]) + minPredVal;
                        }
                    }
            });
        }

        private void dtw()
        {
            int nY = _y.Length;
            int nX = _x.Length;
            DistanceMatrix = new float[nX, nY];
            for (int i = 0; i < nX; i++)
                for (int j = 0; j < nY; j++)
                {
                    if (i == 0)
                        if (j == 0)
                            DistanceMatrix[0, 0] = elems_distance(_x.Series[0], _y.Series[0]);
                        else
                            DistanceMatrix[0, j] = elems_distance(_x.Series[0], _y.Series[j]) + DistanceMatrix[0, j - 1];
                    else if (j == 0)
                        DistanceMatrix[i, 0] = elems_distance(_x.Series[i], _y.Series[0]) + DistanceMatrix[i - 1, 0];
                    else
                    {
                        float minPredVal =
                            find_min(DistanceMatrix[i - 1, j],
                                     DistanceMatrix[i, j - 1],
                                     DistanceMatrix[i - 1, j - 1]);
                        DistanceMatrix[i, j] = elems_distance(_x.Series[i], _y.Series[j]) + minPredVal;
                    }
                }
        }

        private void dtw_update_path()
        {
            PathMatrix = new List<PathPoint>();
            int curX = DistanceMatrix.GetLength(0) - 1;
            int curY = DistanceMatrix.GetLength(1) - 1;
            PathMatrix.Add(new PathPoint(curX, curY, DistanceMatrix[curX, curY]));
            while(curX != 0 || curY != 0)
            {
                if (curX == 0)
                {
                    PathMatrix.Add(new PathPoint(0, --curY, DistanceMatrix[0, curY]));
                    continue;
                }
                if (curY == 0)
                {
                    PathMatrix.Add(new PathPoint(--curX, 0, DistanceMatrix[curX, 0]));
                    continue;
                }
                DtwMinPredecessor minPred =
                    find_min_predecessor(DistanceMatrix[curX - 1, curY],
                                         DistanceMatrix[curX, curY - 1],
                                         DistanceMatrix[curX - 1, curY - 1]);
                switch(minPred.position)
                {
                    case EnumDtwPredecessorPosition.UPLEFT:
                        PathMatrix.Add(new PathPoint(--curX, --curY, minPred.value));
                        break;
                    case EnumDtwPredecessorPosition.UP:
                        PathMatrix.Add(new PathPoint(--curX, curY, minPred.value));
                        break;
                    case EnumDtwPredecessorPosition.LEFT:
                        PathMatrix.Add(new PathPoint(curX, --curY, minPred.value));
                        break;
                }
            }
            PathMatrix.Reverse();
        }

        private float elems_distance(float e1, float e2)
        {
            return (e1 - e2) * (e1 - e2);
        }

        private float find_min(float x, float y, float z)
        {
            return Math.Min(Math.Min(x, y), z);
        }

        private DtwMinPredecessor find_min_predecessor(float up, float left, float upleft)
        {
            if (upleft <= up && upleft <= left)
            {
                return new DtwMinPredecessor(upleft, EnumDtwPredecessorPosition.UPLEFT);
            }
            else if (up <= left && up <= upleft)
            {
                return new DtwMinPredecessor(up, EnumDtwPredecessorPosition.UP);
            }
            else
                return new DtwMinPredecessor(left, EnumDtwPredecessorPosition.LEFT);
        }

        private int calc_number_of_blocks(int length)
        {
            int std = 10 * (Environment.ProcessorCount + 2);
            int stdDouble = 2 * std;
            if (length < stdDouble)
                return 1;
            else if (length == stdDouble)
                return 2;
            else
                return (int)Math.Round((float)length / std);
        }
        #endregion
    }
}
