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
        private List<object> _medoids;
        private int _k;

        private void select_initial_medoids()
        {
            EnumDtwMultithreading _isMultithreading = EnumDtwMultithreading.ENABLED;
            int size = _data.Count;  // the number of all time series
            _distanceMatrix = new float[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                        _distanceMatrix[i, j] = 0;
                    else if (i < j)
                        _distanceMatrix[i, j] = (new DtwDistance((TimeSeries)_data[i],
                                                                 (TimeSeries)_data[j],
                                                                 _isMultithreading)).Value;
                    else
                        _distanceMatrix[i, j] = _distanceMatrix[j, i];
                }

            float[] v = new float[size];
            for (int j = 0; j < size; j++)  // for each time series
            {
                v[j] = 0;
                for (int i = 0; i < size; i++)
                {
                    float sumIL = 0;
                    for (int k = 0; k < size; k++)
                    {
                        sumIL += _distanceMatrix[i, k];
                    }
                    v[j] += _distanceMatrix[i, j] / sumIL;
                }
            }

        }

        private void update_medoids()
        {

        }

        private void assign_object_to_medoids()
        { }
    }
}
