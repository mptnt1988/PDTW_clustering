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
        private List<int>[] _clusters;
        private int[] _clusterOfObject;
        private float _totalSum;
        private float _totalSumOld;
        private int _size;

        private int _k;
        private Distance _distance;

        public ImprovedKMedoids(List<object> data, int k, Distance distance)
        {
            this._data = data;
            this._k = k;
            this._distance = distance;
            this._totalSumOld = this._totalSum = 0;
        }

        public int[] do_cluster()
        {
            select_initial_medoids();
            do
            {
                update_medoids();
                assign_objects_to_medoids();
            }
            while (_totalSum != _totalSumOld);
            GC.Collect();
            return _clusterOfObject;
        }

        private void select_initial_medoids()
        {
            // Calculate the distance between every pair of all objects
            _size = _data.Count;  // the number of all time series
            _distanceMatrix = new float[_size, _size];
            for (int i = 0; i < _size; i++)
                for (int j = 0; j < _size; j++)
                {
                    if (i == j)
                        _distanceMatrix[i, j] = 0;
                    else if (i < j)
                        _distanceMatrix[i, j] = _distance.Calculate(_data[i], _data[j]);
                    else
                        _distanceMatrix[i, j] = _distanceMatrix[j, i];
                }

            // Calculate v[j] for each object j
            // Store them to variable 'v'
            List<ValueIndex> v = new List<ValueIndex>();
            for (int j = 0; j < _size; j++)  // for each time series
            {
                float vj = 0;
                for (int i = 0; i < _size; i++)
                {
                    float sumIL = 0;
                    for (int k = 0; k < _size; k++)
                    {
                        sumIL += _distanceMatrix[i, k];
                    }
                    vj += _distanceMatrix[i, j] / sumIL;
                }
                v.Add(new ValueIndex(vj, j));
            }

            // Select k objects having the first k smallest values as initial medoids
            _medoids = new int[_k];
            _clusters = new List<int>[_k];
            _clusterOfObject = new int[_size];
            for (int i = 0; i < _k; i++)
            {
                ValueIndex minObj = v.Min<ValueIndex>();
                int minObjIndex = minObj.index;
                _medoids[i] = minObjIndex;  // medoid of cluster i is the obj's index
                _clusterOfObject[minObjIndex] = i;  // cluster of obj's index is i
                _clusters[i] = new List<int>();
                _clusters[i].Add(minObjIndex);  // add obj's index to cluster i
                v.Remove(minObj);
            }

            // Obtain the initial cluster result by assigning each object to the nearest medoid
            //   stored as variable '_clusterOfObject'
            // Calculate the sum of distances from all objects to their medoid
            //   stored as variable '_totalSum'
            assign_objects_to_medoids();
        }

        private void update_medoids()
        {
            for (int i = 0; i<_k;i++)  // foreach cluster
            {
                List<ValueIndex> v = new List<ValueIndex>();  // store value & index for comparison
                foreach (int objIndexFrom in _clusters[i])  // foreach obj in cluster i
                {
                    float sum = 0;
                    foreach (int objIndexTo in _clusters[i])  // sum all distances from the obj to others
                        sum += _distanceMatrix[objIndexFrom, objIndexTo];
                    v.Add(new ValueIndex(sum, objIndexFrom));
                }
                ValueIndex newMedoid = v.Min<ValueIndex>();
                _medoids[i] = newMedoid.index;
            }
        }

        private void assign_objects_to_medoids()
        {
            _totalSumOld = _totalSum;
            Console.Write("Old: " + _totalSumOld.ToString() + " --- ");
            _totalSum = 0;
            for (int i = 0; i < _size; i++)  // foreach object
            {
                if (_medoids.Contains(i))  // ignored because it has been added above
                    continue;
                List<ValueIndex> v = new List<ValueIndex>();
                for (int j = 0; j < _k; j++)  // foreach cluster
                    v.Add(new ValueIndex(_distanceMatrix[i, j], j));
                ValueIndex nearestMedoid = v.Min<ValueIndex>();
                _clusterOfObject[i] = nearestMedoid.index;
                _clusters[nearestMedoid.index].Add(i);
                _totalSum += nearestMedoid.value;
            }
            Console.WriteLine("New: " + _totalSum.ToString());
        }
    }
}
