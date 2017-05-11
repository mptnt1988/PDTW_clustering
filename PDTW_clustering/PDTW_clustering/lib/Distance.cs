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

        //private void SimpleDtw()
        //{
        //    float v;
        //    float[,] f = new float[_x.Length, _y.Length];
        //    Pos[,] path = new Pos[_x.Length, _y.Length];
        //    for (int i = 0; i < _x.Length; i++)
        //    {
        //        for (int j = 0; j < _y.Length; j++)
        //        {
        //            if (i == 0 && j == 0)
        //            {
        //                f[i, j] = (_x.GetAt(i) - _y.GetAt(j)) * (_x.GetAt(i) - _y.GetAt(j));
        //            }
        //            else if (i == 0 && j > 0)
        //            {
        //                f[i, j] = (_x.GetAt(i) - _y.GetAt(j)) * (_x.GetAt(i) - _y.GetAt(j)) + f[i, j - 1];
        //                path[i, j].x = i;
        //                path[i, j].y = j - 1;
        //            }
        //            else if (j == 0 && i > 0)
        //            {
        //                f[i, j] = (_x.GetAt(i) - _y.GetAt(j)) * (_x.GetAt(i) - _y.GetAt(j)) + f[i - 1, j];
        //                path[i, j].x = i - 1;
        //                path[i, j].y = j;
        //            }
        //            else
        //            {
        //                f[i, j] = (_x.GetAt(i) - _y.GetAt(j)) * (_x.GetAt(i) - _y.GetAt(j));
        //                // calculate previous pos
        //                path[i, j].x = i - 1;
        //                path[i, j].y = j - 1;
        //                v = f[i - 1, j - 1];
        //                if (f[i - 1, j - 1] > f[i - 1, j])
        //                {
        //                    path[i, j].x = i - 1;
        //                    path[i, j].y = j;
        //                    v = f[i - 1, j];
        //                    if (f[i - 1, j] > f[i, j - 1])
        //                    {
        //                        path[i, j].x = i;
        //                        path[i, j].y = j - 1;
        //                        v = f[i, j - 1];
        //                    }
        //                }
        //                else
        //                {
        //                    if (f[i - 1, j - 1] > f[i, j - 1])
        //                    {
        //                        path[i, j].x = i;
        //                        path[i, j].y = j - 1;
        //                        v = f[i, j - 1];
        //                    }
        //                }
        //                f[i, j] = f[i, j] + v;
        //                v = 0;
        //            }
        //        }
        //    }
        //    //GetPath(path);
        //    _sum = f[_x.Length - 1, _y.Length - 1];
        //    if (_sum != 0)
        //    {
        //        _sum = (float)Math.Sqrt(_sum);//_path.Count;
        //    }
        //}
    }

    class DtwDistance : Distance
    {
        public List<PathPoint> PathMatrix { get; private set; }
        public void dtw()
        {
            int nY = Y.Length;
            int nX = X.Length;
            float[,] distanceMatrix = new float[nX, nY];
            float valX = X.get_at(0);
            float valY = Y.get_at(0);
            distanceMatrix[0, 0] = square(valX - valY);
            for (int j = 1; j < nY; j++)
            {
                distanceMatrix[0, j] = square(valX - Y.get_at(j));
            }
            for (int i = 1; i < nX; i++)
            {
                distanceMatrix[i, 0] = square(X.get_at(i) - valY);
            }
            for (int i = 1; i < nX; i++)
                for (int j = 1; j < nY; j++)
                {
                    float minPredVal =
                        find_min(distanceMatrix[i - 1, j],
                                 distanceMatrix[i, j - 1],
                                 distanceMatrix[i - 1, j - 1]);
                    distanceMatrix[i, j] = square(X.get_at(i) - Y.get_at(j)) + minPredVal;
                }
            update_dtw_path(distanceMatrix);
        }

        private void update_dtw_path(float[,] distanceMatrix)
        {
            PathMatrix = new List<PathPoint>();
            int curX = distanceMatrix.GetLength(0) - 1;
            int curY = distanceMatrix.GetLength(1) - 1;
            PathMatrix.Add(new PathPoint(curX, curY, distanceMatrix[curX, curY]));
            while(curX != 0 || curY != 0)
            {
                if (curX == 0)
                {
                    PathMatrix.Add(new PathPoint(0, --curY, distanceMatrix[0, curY]));
                    continue;
                }
                if (curY == 0)
                {
                    PathMatrix.Add(new PathPoint(--curX, 0, distanceMatrix[curX, 0]));
                    continue;
                }
                DtwMinPredecessor minPred =
                    find_min_predecessor(distanceMatrix[curX - 1, curY],
                                         distanceMatrix[curX, curY - 1],
                                         distanceMatrix[curX - 1, curY - 1]);
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
        }

        private float square(float x)
        {
            return x * x;
        }

        private float find_min(float x, float y, float z)
        {
            return Math.Min(Math.Min(x, y), z);
        }

        private DtwMinPredecessor find_min_predecessor(float up, float left, float upleft)
        {
            if (upleft >= up && upleft >= left)
            {
                return new DtwMinPredecessor(upleft, EnumDtwPredecessorPosition.UPLEFT);
            }
            else if (up >= left && up >= upleft)
            {
                return new DtwMinPredecessor(up, EnumDtwPredecessorPosition.UP);
            }
            else
                return new DtwMinPredecessor(left, EnumDtwPredecessorPosition.LEFT);
        }
    }
}
