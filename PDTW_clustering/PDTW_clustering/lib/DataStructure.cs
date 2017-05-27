using System;

namespace PDTW_clustering.lib
{
    public enum EnumExTreeNodeType
    {
        CLUSTER,
        TIMESERIES
    }

    enum EnumDtwPredecessorPosition
    {
        UP,
        LEFT,
        UPLEFT
    }

    enum EnumDtwMultithreading
    {
        ENABLED,
        DISABLED
    }

    enum EnumDimentionalityReduction
    {
        PAA,
        DISABLED
    }

    enum EnumClusteringAlgorithm
    {
        IMPROVED_KMEDOIDS,
        DENSITY_PEAKS
    }

   public enum EnumNormalization
    {
        NONE,
        MIN_MAX,
        ZERO_MIN
    }

    struct Configuration
    {
        public EnumDtwMultithreading multithreading;
        public EnumDimentionalityReduction dimensionalityReduction;
        public int paaCompressionRate;
        public EnumClusteringAlgorithm clusteringAlgorithm;
        public int noOfClusters;
        public EnumNormalization normalization;
    }

    struct PathPoint
    {
        public int x;
        public int y;
        public float value;
        public PathPoint(int x, int y, float value)
        {
            this.x = x;
            this.y = y;
            this.value = value;
        }
    }

    struct DtwMinPredecessor
    {
        public float value;
        public EnumDtwPredecessorPosition position;
        public DtwMinPredecessor(float value, EnumDtwPredecessorPosition position)
        {
            this.value = value;
            this.position = position;
        }
    }

    public struct ExtValidation
    {
        public float rand;     // Rand
        public float ari;      // Adjusted Rand Index (ARI)
        public float jaccard;  // Jaccard
        public float fm;       // Fowlkes and Mallow (FM)
        public float csm;      // Cluster Similarity Measure (CSM)
        public float nmi;      // Normalized Mutual Information (NMI)
    }

    public class ValueIndex : IComparable
    {
        public float value;
        public int index;

        public ValueIndex(float value, int index)
        {
            this.value = value;
            this.index = index;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            ValueIndex other = obj as ValueIndex;
            if (other != null)
                return this.value.CompareTo(other.value);
            else
                throw new ArgumentException("Object is not a ValueIndex");
        }
    }
}