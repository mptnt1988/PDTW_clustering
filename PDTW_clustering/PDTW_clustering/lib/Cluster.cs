using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDTW_clustering.lib
{
    public abstract class Cluster
    {
        public abstract int[] do_clustering();
        public abstract List<int>[] Clusters { get; set; }
    }

    class ImprovedKMedoids : Cluster
    {
        private List<object> _data;
        private float[,] _distanceMatrix;
        private int[] _medoids;
        private int[] _clusterOfObject;
        private float _totalSum;
        private float _totalSumOld;
        private int _size;
        private int _k;
        private Distance _distance;

        public override List<int>[] Clusters { get; set; }

        public ImprovedKMedoids(List<object> data, int k, Distance distance)
        {
            this._data = data;
            this._k = k;
            this._distance = distance;
            this._totalSumOld = this._totalSum = 0;
        }

        public override int[] do_clustering()
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
            //Parallel.For(0, _size, delegate (int i)
            //{
            //    for (int j = 0; j < _size; j++)
            //    {
            //        if (i == j)
            //            _distanceMatrix[i, j] = 0;
            //        else if (i < j)
            //            _distanceMatrix[i, j] = _distance.Calculate(_data[i], _data[j]);
            //        else
            //            _distanceMatrix[i, j] = _distanceMatrix[j, i];
            //    }
            //});

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
            Clusters = new List<int>[_k];
            //_clusterOfObject = new int[_size];
            _clusterOfObject = Enumerable.Repeat(_k, _size).ToArray();
            for (int i = 0; i < _k; i++)  // for each cluster
            {
                ValueIndex minObj = v.Min<ValueIndex>();  // get the minimum one based on vj value
                int minObjIndex = minObj.index;
                _medoids[i] = minObjIndex;  // medoid of cluster i is the obj's index
                _clusterOfObject[minObjIndex] = i;  // cluster of obj's index is i
                Clusters[i] = new List<int>();
                Clusters[i].Add(minObjIndex);  // add obj's index to cluster i
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
            for (int i = 0; i < _k; i++)  // foreach cluster
            {
                List<ValueIndex> v = new List<ValueIndex>();  // store value & index for comparison
                foreach (int objIndexFrom in Clusters[i])  // foreach obj in cluster i
                {
                    float sum = 0;
                    foreach (int objIndexTo in Clusters[i])  // sum all distances from the obj to others
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
            _totalSum = 0;
            for (int i = 0; i < _size; i++)  // foreach object
            {
                if (_medoids.Contains(i))  // ignored because it has been added above
                    continue;
                List<ValueIndex> v = new List<ValueIndex>();
                for (int j = 0; j < _k; j++)  // foreach cluster
                    v.Add(new ValueIndex(_distanceMatrix[i, _medoids[j]], j));  // distance from the object i to medoid of cluster j, indexed by j
                ValueIndex nearestMedoid = v.Min<ValueIndex>();
                if (nearestMedoid.index != _clusterOfObject[i])  // if nearest medoid is different from the object's medoid
                {
                    if (_clusterOfObject[i] != _k)
                        Clusters[_clusterOfObject[i]].Remove(i);  // remove object of index i from old cluster
                    _clusterOfObject[i] = nearestMedoid.index;  // update new cluster for object of index i
                    Clusters[nearestMedoid.index].Add(i);  // update object of index i into new cluster
                }
                _totalSum += nearestMedoid.value;
            }
        }
    }
}
