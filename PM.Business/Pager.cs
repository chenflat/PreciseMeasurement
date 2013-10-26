using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PM.Entity;
using PM.Data;
using PM.Common;
using PM.Config;
using System.Web;

namespace PM.Business
{
    public class Pager
    {

        public static PagerInfo GetPagerInfo(IDataReader reader) {
            PagerInfo pagerInfo = new PagerInfo();

            using (IDataReader r = reader)
            {
                while (r.Read())
                {
                    pagerInfo = LoadPagerInfo(r);
                }
                r.Close();
            }
            return pagerInfo;
        }

        public static PagerInfo LoadPagerInfo(IDataReader reader)
        {
            PagerInfo pagerInfo = new PagerInfo();
            pagerInfo.PageIndex = TypeConverter.ObjectToInt(reader["PageIndex"]);
            pagerInfo.PageSize = TypeConverter.ObjectToInt(reader["PageSize"]);
            pagerInfo.RecordCount = TypeConverter.ObjectToInt(reader["RecordCount"]);
            return pagerInfo;
        }


    }
}
