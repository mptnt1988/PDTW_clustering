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

    //class ImprovedKMedoids_Object
    //{
    //    public object Object { get; set; }
    //    public ImprovedKMedoids_Cluster Cluster { get; set; }
    //    public float Distance { get; set; }

    //    public ImprovedKMedoids_Object(object obj)
    //    {
    //        Object = obj;
    //    }
    //}

    //class ImprovedKMedoids_Cluster
    //{
    //    public ImprovedKMedoids_Object Medoid { get; set; }
    //    public List<ImprovedKMedoids_Object> Members;

    //    public ImprovedKMedoids_Cluster(ImprovedKMedoids_Object medoid)
    //    {
    //        Medoid = medoid;
    //    }
    //}

    class ImprovedKMedoids
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
            List<ValueIndex> v = new List<ValueIndex>();
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
                v.Add(new ValueIndex(vj, j));
            }

            // Select k objects having the first k smallest values as initial medoids
            _medoids = new int[_k];
            int[] clusterOfObject = new int[size];
            for (int i = 0; i < _k; i++)
            {
                ValueIndex minObj = v.Min<ValueIndex>();
                int minObjIndex = minObj.index;
                _medoids[i] = minObjIndex;  // medoid of cluster i is the obj specified by its index
                clusterOfObject[minObjIndex] = i;
                v.Remove(minObj);
            }

            // Obtain the initial cluster result by assigning each object to the nearest medoid
            //   stored as variable clusterOfObject
            // Calculate the sum of distances from all objects to their medoid
            //   stored as variable totalSum
            float totalSum = 0;
            for (int i = 0; i < size; i++)  // foreach object
            {
                if (_medoids.Contains(i))
                    continue;
                v = new List<ValueIndex>();
                for (int j = 0; j < _k; j++)  // foreach cluster
                    v.Add(new ValueIndex(_distanceMatrix[i, j], j));
                ValueIndex nearestMedoid = v.Min<ValueIndex>();
                clusterOfObject[i] = nearestMedoid.index;
                totalSum += nearestMedoid.value;
            }
            testReturn = clusterOfObject;
        }

        private void update_medoids()
        {

        }

        private void assign_object_to_medoids()
        { }
    }
}
