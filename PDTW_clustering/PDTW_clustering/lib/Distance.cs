using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDTW_clustering.lib
{
    class Distance
    {
        public TimeSeries X { get; private set; }
        public TimeSeries Y { get; private set; }

        public Distance(TimeSeries tsX, TimeSeries tsY)
        {
            this.X = tsX;
            this.Y = tsY;
        }
    }

    class DtwDistance : Distance
    {
        public List<PathPoint> PathMatrix { get; private set; }
        public float[,] DistanceMatrix { get; private set; }

        public DtwDistance(TimeSeries tsX, TimeSeries tsY) : base(tsX, tsY) { }

        public void parallel_dtw()
        {

        }

        public void dtw()
        {
            int nY = Y.Length;
            int nX = X.Length;
            DistanceMatrix = new float[nX, nY];
            float valX = X.Series[0];
            float valY = Y.Series[0];
            DistanceMatrix[0, 0] = elems_distance(valX, valY);
            for (int j = 1; j < nY; j++)
            {
                DistanceMatrix[0, j] = elems_distance(valX, Y.Series[j]) + DistanceMatrix[0, j - 1];
            }
            for (int i = 1; i < nX; i++)
            {
                DistanceMatrix[i, 0] = elems_distance(X.Series[i], valY) + DistanceMatrix[i - 1, 0];
            }
            for (int i = 1; i < nX; i++)
                for (int j = 1; j < nY; j++)
                {
                    float minPredVal =
                        find_min(DistanceMatrix[i - 1, j],
                                 DistanceMatrix[i, j - 1],
                                 DistanceMatrix[i - 1, j - 1]);
                    DistanceMatrix[i, j] = elems_distance(X.Series[i], Y.Series[j]) + minPredVal;
                }
            update_dtw_path(DistanceMatrix);
        }

        private void update_dtw_path(float[,] DistanceMatrix)
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
    }
}
