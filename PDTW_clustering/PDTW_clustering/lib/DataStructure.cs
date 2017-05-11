﻿using System;

namespace PDTW_clustering.lib
{
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

    public class ImprovedKMedoids_V : IComparable
    {
        public float value;
        public int index;

        public ImprovedKMedoids_V(float value, int index)
        {
            this.value = value;
            this.index = index;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            ImprovedKMedoids_V other = obj as ImprovedKMedoids_V;
            if (other != null)
                return this.value.CompareTo(other.value);
            else
                throw new ArgumentException("Object is not a ImprovedKMedoids_V");
        }

        //public override bool Equals(object obj)
        //{
        //    return base.Equals(obj);
        //}
        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}
        //public static bool operator >(ImprovedKMedoids_V v1, ImprovedKMedoids_V v2)
        //{
        //    return v1.value > v2.value;
        //}
        //public static bool operator <(ImprovedKMedoids_V v1, ImprovedKMedoids_V v2)
        //{
        //    return v1.value > v2.value;
        //}
        //public static bool operator >=(ImprovedKMedoids_V v1, ImprovedKMedoids_V v2)
        //{
        //    return v1.value >= v2.value;
        //}
        //public static bool operator <=(ImprovedKMedoids_V v1, ImprovedKMedoids_V v2)
        //{
        //    return v1.value <= v2.value;
        //}
        //public static bool operator ==(ImprovedKMedoids_V v1, ImprovedKMedoids_V v2)
        //{
        //    return v1.value == v2.value;
        //}
        //public static bool operator !=(ImprovedKMedoids_V v1, ImprovedKMedoids_V v2)
        //{
        //    return v1.value != v2.value;
        //}
    }
}