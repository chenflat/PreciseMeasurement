using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity
{
    [Serializable()]
    public class LochierarchyInfo
    {
        private long lochierarchyid;
        private string location;
        private string parent;
        private bool children;
        private string orgid;
        private string siteid;
        private string systemid;

        public long Lochierarchyid
        {
            get { return lochierarchyid; }
            set { lochierarchyid = value; }
        }
        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        public string Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        public bool Children
        {
            get { return children; }
            set { children = value; }
        }
        public string Orgid
        {
            get { return orgid; }
            set { orgid = value; }
        }
        public string Siteid
        {
            get { return siteid; }
            set { siteid = value; }
        }
        public string Systemid
        {
            get { return systemid; }
            set { systemid = value; }
        }
    }
}
