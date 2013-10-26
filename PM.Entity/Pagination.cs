using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity
{
    public class Pagination<T>
    {
        private List<T> list;
        private PagerInfo pagerinfo;

        public List<T> List {
            get { return list; }
            set { list = value; }
        }

        public PagerInfo PagerInfo {
            get { return pagerinfo; }
            set { pagerinfo = value; }
        }

    }
}
