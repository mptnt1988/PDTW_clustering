using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PDTW_clustering.lib
{
    public abstract class ClusteringObject
    {
        public abstract int Label { get; }  // Label of the obj given from file
        public abstract int Index { get; }  // Index of this obj in the data read from file
    }

    public abstract class Cluster
    {
        #region ABSTRACTION
        public abstract int[] do_clustering();                   // execute clustering
        public abstract Evaluation do_evaluating();              // execute clustering evaluation
        public abstract List<int>[] Clusters { get; }            // clusters in which each is a list of object index
        public abstract int[] ClusterOfObject { get; }           // cluster of a specific object index
        public abstract List<ClusteringObject> Objects { get; }  // list of all objects
        public abstract Evaluation Evaluation { get; }           // an object which has functions of evaluation
        public abstract float TotalSum { get; }                  // sum of all object-to-center distances
        public abstract CancellationToken Token { get; set; }    // token to cancel the thread
        public abstract int Percentage { get; }                  // percentage of done jobs
        #endregion

        #region VARIABLES
        protected int calcDistantMatrixPercentage { get; set; }
        #endregion

        #region FUNCTIONS
        protected float[,] calculate_distance_matrix(List<ClusteringObject> data, Distance distance)
        {
            int size = data.Count;
            float[,] distanceMatrix = new float[size, size];
            float percentageUnit = 100f / (size * size);
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    Token.ThrowIfCancellationRequested();
                    calcDistantMatrixPercentage = (int)Math.Floor(percentageUnit * (i * size + j + 1));
                    if (i == j)
                        distanceMatrix[i, j] = 0;
                    else if (i < j)
                        distanceMatrix[i, j] = distance.Calculate(data[i], data[j]);
                    else
                        distanceMatrix[i, j] = distanceMatrix[j, i];
                }
            //for (int i = 0; i < size; i++)
            //{
            //    Parallel.For(0, size, delegate (int j)
            //    {
            //            if (i == j)
            //                distanceMatrix[i, j] = 0;
            //            else if (i < j)
            //                distanceMatrix[i, j] = distance.Calculate(data[i], data[j]);
            //            else
            //                distanceMatrix[i, j] = distanceMatrix[j, i];
            //    });
            //}
            return distanceMatrix;
        }
        #endregion
    }

    class ImprovedKMedoids : Cluster
    {
        #region VARIABLES
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
        private CancellationToken _token;       // token to cancel calculation
        #endregion

        #region CONSTRUCTORS
        public ImprovedKMedoids(List<ClusteringObject> data, Distance distance, int k)
        {
            _data = data;
            _k = k;
            _distance = distance;
            _totalSumOld = _totalSum = 0;
            _size = _data.Count;
        }
        #endregion

        #region BEHAVIORS
        public override List<int>[] Clusters { get { return _clusters; } }
        public override Evaluation Evaluation { get { return _evaluation; } }
        public override List<ClusteringObject> Objects { get { return _data; } }
        public override int[] ClusterOfObject { get { return _clusterOfObject; } }
        public override float TotalSum { get { return _totalSum; } }
        public override CancellationToken Token { get { return _token; } set { _token = value; } }
        public override int Percentage { get { return (int)calcDistantMatrixPercentage; } }

        public override int[] do_clustering()
        {
            select_initial_medoids();
            do
            {
                _token.ThrowIfCancellationRequested();
                update_medoids();
                assign_objects_to_medoids();
            }
            while (_totalSum != _totalSumOld);
            return _clusterOfObject;
        }

        public override Evaluation do_evaluating()
        {
            _evaluation = new Evaluation(this);
            return _evaluation;
        }
        #endregion

        #region FUNCTIONS
        private void select_initial_medoids()
        {
            // Calculate the distance between every pair of all objects
            _distanceMatrix = calculate_distance_matrix(_data, _distance);
            
            // Calculate v[j] for each object j
            // Store them to variable 'v'
            List<ValueIndex> v = new List<ValueIndex>();
            for (int j = 0; j < _size; j++)  // for each object
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
            _clusterOfObject = Enumerable.Repeat(_k, _size).ToArray();
            for (int i = 0; i < _k; i++)  // for each cluster
            {
                ValueIndex minObj = v.Min<ValueIndex>();  // get the minimum one based on vj value
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
            for (int i = 0; i < _k; i++)  // foreach cluster
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
            _totalSum = 0;
            for (int i = 0; i < _size; i++)  // foreach object
            {
                if (_medoids.Contains(i))  // ignored because it has been added above
                    continue;
                List<ValueIndex> v = new List<ValueIndex>();
                for (int j = 0; j < _k; j++)  // foreach cluster
                    v.Add(new ValueIndex(_distanceMatrix[i, _medoids[j]], j));  // distance from the object i to medoid of cluster j, indexed by j
                ValueIndex nearestMedoid = v.Min<ValueIndex>();
                if (nearestMedoid.index != _clusterOfObject[i])  // if nearest medoid's cluster is different from object's current cluster
                {
                    if (_clusterOfObject[i] != _k)
                        _clusters[_clusterOfObject[i]].Remove(i);  // remove object of index i from old cluster
                    _clusterOfObject[i] = nearestMedoid.index;  // update new cluster for object of index i
                    _clusters[nearestMedoid.index].Add(i);  // update object of index i into new cluster
                }
                _totalSum += nearestMedoid.value;
            }
        }
        #endregion
    }

    class DensityPeaks : Cluster
    {
        #region VARIABLES
        private List<ClusteringObject> _data;   // _data[i] : object with index i
        private float[,] _distanceMatrix;       // _distanceMatrix[i,j] : distance between each pair of objects i & j
        private int[] _medoids;                 // _medoids[i] : index of object which is medoid of cluster i
        private List<int>[] _clusters;          // _clusters[i] : list of all object indices which belong to cluster i
        private int[] _clusterOfObject;         // _clusterOfObject[i] : cluster of object with index i
        private Evaluation _evaluation;         // custering evaluation
        private float _totalSum;                // sum of all distances between object and its medoid
        private float _totalSumOld;             // old value of sum to be compared later
        private int _size;                      // the number of objects to be clustered
        private int _k;                         // the number of clusters
        private float _dC;                      // cutoff distance
        private int[] _localDensity;            // _localDensity[i]: local density of object i
        private float[] _deltaDistance;         // _deltaDistance[i]: distance from object i to nearest object with higher local density
        private int[] _adjacentOfObject;        // _adjacentOfObject[i]: nearest neighbor of object i
        private Distance _distance;             // method to calculate distance
        private CancellationToken _token;       // token to cancel calculation
        private int _minPercentage;
        private int _maxPercentage;
        #endregion

        #region CONSTRUCTORS
        public DensityPeaks(List<ClusteringObject> data, Distance distance, int k)
        {
            _data = data;
            _k = k;
            _minPercentage = 1;
            _maxPercentage = 2;
            _distance = distance;
            _totalSumOld = _totalSum = 0;
            _size = _data.Count;
        }

        public DensityPeaks(List<ClusteringObject> data, Distance distance, int k, int minP, int maxP)
        {
            _data = data;
            _k = k;
            _minPercentage = minP;
            _maxPercentage = maxP;
            _distance = distance;
            _totalSumOld = _totalSum = 0;
            _size = _data.Count;
        }
        #endregion

        #region BEHAVIORS
        public override List<int>[] Clusters { get { return _clusters; } }
        public override Evaluation Evaluation { get { return _evaluation; } }
        public override List<ClusteringObject> Objects { get { return _data; } }
        public override int[] ClusterOfObject { get { return _clusterOfObject; } }
        public override float TotalSum
        {
            get
            {
                _totalSum = 0;
                for (int i = 0; i < _size; i++)
                    _totalSum += _distanceMatrix[i, _medoids[_clusterOfObject[i]]];
                return _totalSum;
            }
        }
        public override CancellationToken Token { get { return _token; } set { _token = value; } }
        public override int Percentage
        {
            get
            {
                return calcDistantMatrixPercentage;
            }
        }

        public override int[] do_clustering()
        {
            _distanceMatrix = calculate_distance_matrix(_data, _distance);
            calculate_local_density();
            calculate_distance_to_higher_density_points();
            select_cluster_centers();
            assign_objects_to_clusters();
            return _clusterOfObject;
        }

        public override Evaluation do_evaluating()
        {
            _evaluation = new Evaluation(this);
            return _evaluation;
        }
        #endregion
        
        #region FUNCTIONS
        private void calculate_local_density()
        {
            int[] localDensity = new int[_size];
            float sum = 0;  // sum all distances between every pair of object
            for (int i = 0; i < _size - 1; i++)
                for (int j = i + 1; j < _size; j++)
                    sum += _distanceMatrix[i, j];
            float averageDistance = sum / (_size * (_size - 1) / 2);
            float dCHi = averageDistance;  // the upperbound to calculate looped dC
            float dCLo = 0;                // the lowerbound to calculate looped dC
            float dC = (dCHi + dCLo) / 2;  // choose initial dC
            bool isContinued = true;
            float averageLocalDensity = 0;
            float percent = (float)_size / 100;  // number of objects in each percent
            float lBound = percent * _minPercentage;  // max number of objects to considered neighbors
            float uBound = percent * _maxPercentage;  // min number of objects to considered neighbors
            do
            {
                _token.ThrowIfCancellationRequested();
                for (int i = 0; i < _size; i++)
                    localDensity[i] = 0;
                for (int i = 0; i < _size - 1; i++)
                    for (int j = i + 1; j < _size; j++)
                        if (_distanceMatrix[i, j] < dC)
                        {
                            localDensity[i]++;
                            localDensity[j]++;
                        }
                averageLocalDensity = (float)localDensity.Average();
                if (averageLocalDensity < lBound)
                {
                    dCLo = dC;
                    dC = (dCHi + dCLo) / 2;
                }
                else if (averageLocalDensity > uBound)
                {
                    dCHi = dC;
                    dC = (dCHi + dCLo) / 2;
                }
                else isContinued = false;
            }
            while (isContinued);
            _dC = dC;
            _localDensity = localDensity;

            //// Simply calculating local density based on given dC
            //_localDensity = new int[_size];
            //for (int i = 0; i < _size; i++)
            //    _localDensity[i] = 0;
            //for (int i = 0; i < _size - 1; i++)
            //    for (int j = i + 1; j < _size; j++)
            //        if (_distanceMatrix[i, j] < _dC)
            //        {
            //            _localDensity[i]++;
            //            _localDensity[j]++;
            //        }
        }

        private void calculate_distance_to_higher_density_points()
        {
            _deltaDistance = new float[_size];
            // deltaDistanceList[i]: list of (distance, index)s of nearest higher local density objects
            //                       from object i
            List<float>[] deltaDistanceList = new List<float>[_size];
            _adjacentOfObject = new int[_size];

            // Create iteration list for each object, which is list of other object indices
            // For example, iteration list of object i is list of all objects except i
            List<int> seqOfIndices = Enumerable.Range(0, _size).ToList();
            List<int>[] iterationList = new List<int>[_size];
            for (int i = 0; i < _size; i++)
            {
                iterationList[i] = new List<int>(seqOfIndices);
                iterationList[i].Remove(i);
            }

            for (int i = 0; i < _size; i++)  // foreach object
            {
                _token.ThrowIfCancellationRequested();
                deltaDistanceList[i] = new List<float>();
                int nearestNeighbor = -1;
                float nearestNeigborDistance = float.PositiveInfinity;
                // foreach other object which might have higher local density
                foreach (int j in iterationList[i])
                {
                    if (_localDensity[j] > _localDensity[i])  // not for highest local density objects
                    {
                        deltaDistanceList[i].Add(_distanceMatrix[i, j]);
                        iterationList[j].Remove(i);
                        if (_distanceMatrix[i, j] < nearestNeigborDistance)
                        {
                            nearestNeigborDistance = _distanceMatrix[i, j];
                            nearestNeighbor = j;
                        }
                    }
                }
                _adjacentOfObject[i] = nearestNeighbor;
                // for highest local density objects, same as _adjacentOfObject[i] == -1
                if (deltaDistanceList[i].Count == 0)  
                {
                    float maxJ = 0;
                    for (int j = 0; j < _size; j++)
                        if (_distanceMatrix[i, j] > maxJ)
                            maxJ = _distanceMatrix[i, j];
                    _deltaDistance[i] = maxJ;
                }
                else
                {
                    _deltaDistance[i] = deltaDistanceList[i].Min();
                }
            }
        }

        private void select_cluster_centers()
        {
            _medoids = new int[_k];
            List<ValueIndex> heuristicValueList = new List<ValueIndex>();
            for (int i = 0; i < _size; i++)
            {
                heuristicValueList.Add(new ValueIndex(_localDensity[i] * _deltaDistance[i], i));
            }
            _clusters = new List<int>[_k];
            _clusterOfObject = Enumerable.Repeat(_k, _size).ToArray();
            for (int i = 0; i < _k; i++)  // foreach cluster
            {
                ValueIndex maxObj = heuristicValueList.Max();
                int maxObjIndex = maxObj.index;
                _medoids[i] = maxObjIndex;
                _clusterOfObject[maxObjIndex] = i;  // cluster of obj's index is i
                _clusters[i] = new List<int>();
                _clusters[i].Add(maxObjIndex);  // add obj's index to cluster i
                heuristicValueList.Remove(maxObj);
            }
        }

        private void assign_objects_to_clusters()
        {
            for (int i = 0; i < _size; i++)
                assign_object_to_cluster_of_adjacent_object(i);
        }


        // This function return cluster of object i if i is already assigned to a cluster
        // If i has not been assigned to any cluster, check (and maybe assign) the adjacent object of i
        private int assign_object_to_cluster_of_adjacent_object(int i)
        {
            if (_clusterOfObject[i] == _k)  // object i has NOT cluster yet
            {
                int clusterToAssign = assign_object_to_cluster_of_adjacent_object(_adjacentOfObject[i]);
                _clusterOfObject[i] = clusterToAssign;
                _clusters[clusterToAssign].Add(i);
                return clusterToAssign;
            }
            else
                return _clusterOfObject[i];
        }
        #endregion
    }

    public class Evaluation
    {
        #region VARIABLES
        private int _a;
        private int _b;
        private int _c;
        private int _d;
        #endregion

        #region ATTRIBUTES
        public float internalValidation;
        public ExtValidation externalValidation;
        #endregion

        #region CONSTRUCTORS
        public Evaluation(Cluster cluster)
        {
            evaluate(cluster);
        }
        #endregion

        #region FUNCTIONS
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
            // CSM & NMI
            int M = cluster.Clusters.Length;  // number of clusters
            int N = cluster.Objects.Count;    // number of objects
            int[] a = new int[M];  // resulted clusters
            int[] g = new int[M];  // real clusters
            int[,] ag = new int[M, M];
            for (int i = 0; i < M; i++)
            {
                a[i] = g[i] = 0;
                for (int j = 0; j < M; j++)
                    ag[i, j] = 0;
            }
            for (int i = 0; i < cluster.Objects.Count; i++) // foreach object
            {
                int realCluster = cluster.Objects[i].Label;
                int resultedCluster = cluster.ClusterOfObject[i];
                g[realCluster]++;
                a[resultedCluster]++;
                ag[resultedCluster, realCluster]++;
            }
            // CSM
            float csmSum = 0;
            for (int i = 0; i < M; i++)
            {
                float maxSim = 0;
                for (int j = 0; j < M; j++)
                {
                    float sim = 2 * (float)ag[j, i] / (g[i] + a[j]);
                    if (maxSim < sim) maxSim = sim;
                }
                csmSum += maxSim;
            }
            externalValidation.csm = csmSum / M;
            // NMI
            float numerator = 0;
            float denominatorG = 0;
            float denominatorA = 0;
            for (int i = 0; i < M; i++)
            {
                denominatorA += average_log(a[i], a[i], N);
                denominatorG += average_log(g[i], g[i], N);
                for (int j = 0; j < M; j++)
                    numerator += average_log(ag[j, i], N * ag[j, i], g[i] * a[j]);
            }
            externalValidation.nmi = numerator / (float)Math.Sqrt(denominatorA * denominatorG);
        }

        // Assume that: G = {G1, G2, ..., GM} is set of real clusters
        //              A = {A1, A2, ..., AM} is set of resulted clusters
        // Calculate:   a   number of pair of objects in the same G cluster and in the same A cluster
        //              b   number of pair of objects in the same G cluster but NOT in the same A cluster
        //              c   number of pair of objects in the same A cluster but NOT in the same G cluster
        //              d   number of pair of objects NOT in the same G cluster and NOT in the same A cluster
        private void calc_ext_validation_params(Cluster cluster)
        {
            int tempA, tempB, tempC, tempD;
            tempA = tempB = tempC = tempD = 0;
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
                        if (sameA) tempA++;
                        else tempB++;
                    }
                    else
                    {
                        if (sameA) tempC++;
                        else tempD++;
                    }
                }
            _a = tempA; _b = tempB; _c = tempC; _d = tempD;
        }

        private float average_log(float factor, float numerator, float denominator)
        {
            if (factor == 0)
                return 0;
            else
                return factor * (float)Math.Log(numerator / denominator);
        }
        #endregion
    }
}
