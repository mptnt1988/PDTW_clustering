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
}