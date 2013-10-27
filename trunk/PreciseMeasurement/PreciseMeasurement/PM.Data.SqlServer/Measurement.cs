using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;


namespace PM.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {

        /// <summary>
        /// 获取指定计量器的最后记录值
        /// </summary>
        /// <param name="pointnum">记录器编号</param>
        /// <returns></returns>
       public IDataReader FindLastMeasurement(string pointnum) {

           DbParameter param = DbHelper.MakeInParam("@POINTNUM", (DbType)SqlDbType.VarChar, 8, pointnum);

           string commandText = string.Format("SELECT TOP 1 * FROM [{0}MEASUREMENT] WHERE POINTNUM=@POINTNUM ORDER BY MEASUREMENTID DESC", BaseConfigs.GetTablePrefix);

           return DbHelper.ExecuteReader(CommandType.Text, commandText, param);
        }


        /// <summary>
        /// 获取指定查询条件的读表数据
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页显示数</param>
        /// <param name="recordcount">总条数</param>
        /// <returns></returns>
       public DataTable FindMeasurementByCondition(string condition,string type, int pageindex, int pagesize, out int recordcount)
       {
           DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@Condition", (DbType)SqlDbType.VarChar, 2000, condition), 
                                  DbHelper.MakeInParam("@Type", (DbType)SqlDbType.VarChar, 20, type), 
                                  DbHelper.MakeInParam("@PageIndex",(DbType)SqlDbType.Int,4,pageindex),
                                  DbHelper.MakeInParam("@PageSize",(DbType)SqlDbType.Int,4,pagesize),
                                  DbHelper.MakeOutParam("@RecordCount",(DbType)SqlDbType.Int,4)
                                 };
          DataTable ret = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "GetMeasurements", parms).Tables[0];
          recordcount = TypeConverter.ObjectToInt(parms[3].Value);
          return ret;
       }


       /// <summary>
       /// 获取指定测点的读表数据
       /// </summary>
       /// <param name="pointnum">测点编号</param>
       /// <param name="startdate">开始时间</param>
       /// <param name="enddate">结束时间</param>
       /// <param name="type">查询类型</param>
       /// <param name="pageindex">当前页</param>
       /// <param name="pagesize">每页显示数</param>
       /// <param name="recordcount">总条数</param>
       /// <returns></returns>
       public DataSet FindMeasurementByPointnum(string pointnum, string startdate, string enddate, string type, int pageindex, int pagesize)
       {

           DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@PointNum", (DbType)SqlDbType.VarChar, 30, pointnum), 
                                  DbHelper.MakeInParam("@StartDate", (DbType)SqlDbType.VarChar, 30, startdate), 
                                  DbHelper.MakeInParam("@EndDate", (DbType)SqlDbType.VarChar, 30, enddate), 
                                  DbHelper.MakeInParam("@Type", (DbType)SqlDbType.VarChar, 20, type), 
                                  DbHelper.MakeInParam("@PageIndex",(DbType)SqlDbType.Int,4,pageindex),
                                  DbHelper.MakeInParam("@PageSize",(DbType)SqlDbType.Int,4,pagesize),
                                  DbHelper.MakeOutParam("@RecordCount",(DbType)SqlDbType.Int,4)
                                  };
           DataSet ds = new DataSet("Measurements");
           ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "GetMeasurementByPointNum", parms);
           ds.Tables[0].TableName = "Measurement";
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


       /// <summary>
       /// 获取指定时间内所有计量器的读表数据
       /// </summary>
       /// <param name="startdate">开始时间</param>
       /// <param name="enddate">结束时间</param>
       /// <param name="type">查询方式： ALL全部 DAY日报 WEEK周报 MONTH月报 </param>
       /// <param name="pageindex">当前页</param>
       /// <param name="pagesize">每页显示数</param>
       /// <returns></returns>
       public DataSet FindMeasurementByAllPoint(string pointnum, string startdate, string enddate, string type, int pageindex, int pagesize)
       {
           DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@PointNum", (DbType)SqlDbType.VarChar, 30, pointnum), 
                                  DbHelper.MakeInParam("@StartDate", (DbType)SqlDbType.VarChar, 30, startdate), 
                                  DbHelper.MakeInParam("@EndDate", (DbType)SqlDbType.VarChar, 30, enddate), 
                                  DbHelper.MakeInParam("@Type", (DbType)SqlDbType.VarChar, 20, type), 
                                  DbHelper.MakeInParam("@PageIndex",(DbType)SqlDbType.Int,4,pageindex),
                                  DbHelper.MakeInParam("@PageSize",(DbType)SqlDbType.Int,4,pagesize),
                                  DbHelper.MakeOutParam("@RecordCount",(DbType)SqlDbType.Int,4)
                                 };
           DataSet ds = new DataSet("Measurements");
           ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "GetMeasurementByAllPoint", parms);
           ds.Tables[0].TableName = "Measurement";
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
