using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

using PM.Entity;
using PM.Data;
using PM.Common;
using PM.Config;

namespace PM.Business
{
    public class Alarmlog
    {

        public static Pagination<AlarmlogInfo> FindAlarmlogInfo(string startdate, string enddate,string pointnum, int status, string orgid, int pageindex, int pagesize)
        {
            Pagination<AlarmlogInfo> pagination = new Pagination<AlarmlogInfo>();

            DataSet ds = PM.Data.Alarmlog.FindAlarmlogInfo(startdate, enddate,pointnum, status, orgid, pageindex, pagesize);

            DataTable alarmlogs = ds.Tables["Alarmlog"];

            List<AlarmlogInfo> list = new List<AlarmlogInfo>();

            using (IDataReader reader = alarmlogs.CreateDataReader())
            {
                while (reader.Read())
                {
                    AlarmlogInfo alarmlogInfo = Data.Alarmlog.LoadAlarmlogInfo(reader);
                    list.Add(alarmlogInfo);
                }
                reader.Close();
            }

            DataTable dtPager = ds.Tables["Pager"];

            PagerInfo pagerInfo = Pager.GetPagerInfo(dtPager.CreateDataReader());

            pagination.List = list;
            pagination.PagerInfo = pagerInfo;

            return pagination;
        }
    }
}
