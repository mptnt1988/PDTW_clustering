using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace PDTW_clustering.lib
{
    public class ExTreeNode : TreeNode
    {
        #region ATTRIBUTES
        public int Id { get; private set; }
        public EnumExTreeNodeType Type { get; private set; }
        public List<TimeSeries> Cluster { get; set; }
        public TimeSeries TimeSeries { get; set; }
        #endregion

        #region CONSTRUCTORS
        public ExTreeNode(List<TimeSeries> data, int id, string name) : base(name)
        {
            Cluster = data;
            Id = id;
            Type = EnumExTreeNodeType.CLUSTER;
        }

        public ExTreeNode(TimeSeries ts, string name) : base(name)
        {
            TimeSeries = ts;
            Type = EnumExTreeNodeType.TIMESERIES;
        }
        #endregion
    }
}
