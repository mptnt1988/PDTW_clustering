﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDTW_clustering.lib
{
    public abstract class ClusteringObject
    {
        public abstract int Label { get; }
    }

    public abstract class Cluster
    {
        public abstract int[] do_clustering();
        public abstract Evaluation do_evaluating();
        public abstract List<int>[] Clusters { get; }
        public abstract int[] ClusterOfObject { get; }
        public abstract List<ClusteringObject> Objects { get; }
        public abstract Evaluation Evaluation { get; }
        public abstract float TotalSum { get; }
    }

    class ImprovedKMedoids : Cluster
    {
        private List<ClusteringObject> _data;   // _data[i] : object with index i
        private float[,] _distanceMatrix;       // _distanceMatrix[i,j] : distance between each pair of objects i & j
        private int[] _medoids;                 // _medoids[i] : index of object which is medoid of cluster i
        private int[] _clusterOfObject;         // _clusterOfObject[i] : cluster of object with index i
        private int _size;                      // the number of objects to be clustered
        private int _k;                         // the number of clusters
        private Distance _distance;             // method to calculate distance
        private List<int>[] _clusters;          // _clusters[i] : list of all object indices which belong to cluster i
        private Evaluation _evaluation;         // custering evaluation
        private float _totalSum;                // sum of all distances between object and its medoid
        private float _totalSumOld;             // old value of sum to be compared later

        public override List<int>[] Clusters { get { return _clusters; } }
        public override Evaluation Evaluation { get { return _evaluation; } }
        public override List<ClusteringObject> Objects { get { return _data; } }
        public override int[] ClusterOfObject { get { return _clusterOfObject; } }
        public override float TotalSum { get { return _totalSum; } }

        public ImprovedKMedoids(List<ClusteringObject> data, int k, Distance distance)
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

        public override Evaluation do_evaluating()
        {
            _evaluation = new Evaluation(this);
            return _evaluation;
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
            _clusters = new List<int>[_k];
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

    public class Evaluation
    {
        private int _a;
        private int _b;
        private int _c;
        private int _d;

        public float internalValidation;
        public ExtValidation externalValidation;

        public Evaluation(Cluster cluster)
        {
            evaluate(cluster);
        }

        private void evaluate(Cluster cluster)
        {
            // INTERNAL VALIDATION
            internalValidation = cluster.TotalSum;

            // EXTERNAL VALIDATION
            // Calculate external validation parameters (a,b,c,d)
            calc_ext_validation_params(cluster);
            // Rand
            externalValidation.rand = (float)(_a + _d) / (_a + _b + _c + _d);
            // ARI
            float index = (float)_a;
            float expected_index = (float)(_a + _b) * (_a + _c) / (_a + _b + _c + _d);
            float maximum_index = (float)((_a + _b) + (_a + _c)) / 2;
            externalValidation.ari = (index - expected_index) / (maximum_index - expected_index);
            // Jaccard
            externalValidation.jaccard = (float)_a / (_a + _b + _c);
            // Fowlkes and Mallow
            externalValidation.fm = (float)Math.Sqrt(((double)_a / (_a + _b)) * ((double)_a / (_a + _c)));
            // CSM
            int M = cluster.Clusters.Length;
            float csmSum = 0;
            int[] a = new int[M];  // resulted clusters
            int[] g = new int[M];  // real clusters
            int[,] ag = new int[M, M];
            for (int i = 0; i < M; i++)
            {
                a[i] = g[i] = 0;
                for (int j = 0; j < M; j++)
                    ag[i, j] = 0;
            }
            for (int i = 0; i < cluster.Objects.Count; i++)
            {
                int realCluster = cluster.Objects[i].Label;
                int resultedCluster = cluster.ClusterOfObject[i];
                g[realCluster]++;
                a[resultedCluster]++;
                ag[resultedCluster, realCluster]++;
            }
            for (int i = 0; i < M; i++)
            {
                float maxSim = 0;
                for (int j = 0; j < M; j++)
                {
                    int aj, gi, giANDaj;
                    aj = gi = giANDaj = 0;
                }
                csmSum += maxSim;
            }
            externalValidation.csm = csmSum / M;
            // NMI
            externalValidation.nmi = 0;
        }

        // Assume that: G = {G1, G2, ..., GM} is set of real clusters
        //              A = {A1, A2, ..., AM} is set of resulted clusters
        // Calculate:   a   number of pair of objects in the same G cluster and in the same A cluster
        //              b   number of pair of objects in the same G cluster but NOT in the same A cluster
        //              c   number of pair of objects in the same A cluster but NOT in the same G cluster
        //              d   number of pair of objects NOT in the same G cluster and NOT in the same A cluster
        private void calc_ext_validation_params(Cluster cluster)
        {
            int temp_a, temp_b, temp_c, temp_d;
            temp_a = temp_b = temp_c = temp_d = 0;
            int num = cluster.Objects.Count;
            for (int i = 0; i < num - 1; i++)
                for (int j = i + 1; j < num; j++)  // Check each pair of objects
                {
                    int iClusterInG = cluster.Objects[i].Label;
                    int jClusterInG = cluster.Objects[j].Label;
                    int iClusterInA = cluster.ClusterOfObject[i];
                    int jClusterInA = cluster.ClusterOfObject[j];
                    bool sameA = (iClusterInA == jClusterInA);
                    bool sameG = (iClusterInG == jClusterInG);

                    if (sameG)
                    {
                        if (sameA) temp_a++;
                        else temp_b++;
                    }
                    else
                    {
                        if (sameA) temp_c++;
                        else temp_d++;
                    }
                }
            _a = temp_a; _b = temp_b; _c = temp_c; _d = temp_d;
        }
    }
}
