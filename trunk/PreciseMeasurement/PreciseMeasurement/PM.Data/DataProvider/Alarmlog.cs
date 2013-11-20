using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data
{
    public class Alarmlog
    {
        
        /// <summary>
        /// 查找报警信息
        /// </summary>
        /// <param name="orgid">机构ID</param>
        /// <returns></returns>
        public static DataSet FindAlarmlogInfo(string startdate, string enddate, int status, string orgid, int pageindex, int pagesize) {
            return DatabaseProvider.GetInstance().FindAlarmlogInfo(startdate, enddate, status, orgid, pageindex, pagesize);
        }
    }
}
