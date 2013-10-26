using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity
{
    public class PagerInfo
    {
        private int pageindex;

        private int pagesize;

        private int recordcount;

        public int PageIndex {
            get { return pageindex; }
            set { pageindex = value; }
        }


        public int PageSize
        {
            get { return pagesize; }
            set { pagesize = value; }
        }

        public int RecordCount
        {
            get { return recordcount; }
            set { recordcount = value; }
        }
    }
}
