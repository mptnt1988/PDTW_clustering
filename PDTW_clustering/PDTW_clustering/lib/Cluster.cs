using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDTW_clustering.lib
{
    public class Cluster
    {

    }

    class ImprovedKMedoids : Cluster
    {
        private List<object> _data;
        private float[,] _distanceMatrix;
        private int[] _medoids;
        private int _k;
        private Distance _distance;

        public ImprovedKMedoids(List<object> data, int k, Distance distance)
        {
            this._data = data;
            this._k = k;
            this._distance = distance;
        }

        private int[] testReturn;
        public int[] do_cluster()
        {
            select_initial_medoids();
            return testReturn;
        }

        private void select_initial_medoids()
        {
            // Calculate the distance between every pair of all objects
            int size = _data.Count;  // the number of all time series
            _distanceMatrix = new float[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                        _distanceMatrix[i, j] = 0;
                    else if (i < j)
                        _distanceMatrix[i, j] = _distance.Calculate(_data[i], _data[j]);
                    else
                        _distanceMatrix[i, j] = _distanceMatrix[j, i];
                }

            // Calculate v[j] for each object j
            // Store them to variable v
            List<ImprovedKMedoids_V> v = new List<ImprovedKMedoids_V>();
            for (int j = 0; j < size; j++)  // for each time series
            {
                float vj = 0;
                for (int i = 0; i < size; i++)
                {
                    float sumIL = 0;
                    for (int k = 0; k < size; k++)
                    {
                        sumIL += _distanceMatrix[i, k];
                    }
                    vj += _distanceMatrix[i, j] / sumIL;
                }
                v.Add(new ImprovedKMedoids_V(vj, j));
            }

            // Select k objects having the first k smallest values as initial medoids
            // List<ImprovedKMedoids_V> vTemp = new List<ImprovedKMedoids_V>(v);
            _medoids = new int[_k];
            int[] clusterOfObject = new int[size];
            for (int i = 0; i < _k; i++)
            {
                ImprovedKMedoids_V minObj = v.Min<ImprovedKMedoids_V>();
                int minObjIndex = minObj.index;
                _medoids[i] = minObjIndex;  // medoid of cluster i is the obj specified by its index
                clusterOfObject[minObjIndex] = i;
                v.Remove(minObj);
            }

            // Obtain the initial cluster result by assigning each object to the nearest medoid
            for (int i = 0; i < size; i++)  // foreach object
            {
                if (_medoids.Contains(i))
                    continue;
                v = new List<ImprovedKMedoids_V>();
                for (int j = 0; j < _k; j++)  // foreach cluster
                    v.Add(new ImprovedKMedoids_V(_distanceMatrix[i, j], j));
                ImprovedKMedoids_V nearestMedoid = v.Min<ImprovedKMedoids_V>();
                clusterOfObject[i] = nearestMedoid.index;
            }
            testReturn = clusterOfObject;

            // Calculate the sum of distances from all objects to their medoid
        }

        private void update_medoids()
        {

        }

        private void assign_object_to_medoids()
        { }
    }
}
