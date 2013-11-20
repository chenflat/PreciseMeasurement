using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        /// <summary>
        /// 查找报警信息
        /// </summary>
        /// <param name="orgid">机构ID</param>
        /// <returns></returns>
        public DataSet FindAlarmlogInfo(string startdate, string enddate,string pointnum, int status, string orgid, int pageindex, int pagesize)
        {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@StartDate", (DbType)SqlDbType.VarChar, 30, startdate),
                                  DbHelper.MakeInParam("@EndDate", (DbType)SqlDbType.VarChar, 30, enddate),
                                  DbHelper.MakeInParam("@PointNum", (DbType)SqlDbType.VarChar, 30, pointnum),
                                  DbHelper.MakeInParam("@STATUS", (DbType)SqlDbType.Int, 4, status),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, orgid),
                                  DbHelper.MakeInParam("@PageIndex", (DbType)SqlDbType.Int, 4, pageindex),
                                  DbHelper.MakeInParam("@PageSize", (DbType)SqlDbType.Int, 4, pagesize),
                                  DbHelper.MakeOutParam("@RecordCount",(DbType)SqlDbType.Int,4)
                                  };
           DataSet ds = new DataSet("Alarmlogs");
           if (pointnum == "")
           {
               ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "GetAlarmLog", parms);
           }
           else {
               ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "GetAlarmLogByPointNum", parms);
           }
           ds.Tables[0].TableName = "Alarmlog";
           DataTable dt = new DataTable("Pager");
           dt.Columns.Add("PageIndex");
           dt.Columns.Add("PageSize");
           dt.Columns.Add("RecordCount");
           dt.Rows.Add();
           dt.Rows[0]["PageIndex"] = pageindex;
           dt.Rows[0]["PageSize"] = pagesize;
           dt.Rows[0]["RecordCount"] = TypeConverter.ObjectToInt(parms[6].Value);
           ds.Tables.Add(dt);

           return ds;
        }
    }
}
