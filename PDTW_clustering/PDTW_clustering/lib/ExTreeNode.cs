using System;
using System.Windows.Forms;
using System.Collections;

namespace Dissertation.lib
{
    public class ExTreeNode : TreeNode
    {
        private ArrayList _data;

        public ArrayList Data
        {
            get { return _data; }
            set { _data = value; }
        }
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public ExTreeNode(ArrayList data, int id, string name) : base(name)
        {
            _data = data;
            _id = id;
        }
        CTimeSeries _ts;
        public CTimeSeries TS
        {
            get { return _ts; }
            set { _ts = value; }
        }
        public ExTreeNode(CTimeSeries ts, string name)
            : base(name)
        {
            _ts = ts;
        }
    }
}
