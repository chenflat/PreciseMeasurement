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
       /// 获取所有测点的最后计量值
       /// </summary>
       /// <param name="carrier">携能载体</param>
       /// <returns></returns>
       public IDataReader GetLastMeasureValueByAllPoint(string carrier) {
          
           DbParameter param = DbHelper.MakeInParam("@Carrier", (DbType)SqlDbType.VarChar, 30, carrier);

           return DbHelper.ExecuteReader(CommandType.StoredProcedure, "GetLastMeasureValueByAllPoint", param);;
       }

       /// <summary>
       /// 获取指定计量器的第一条记录值
       /// </summary>
       /// <param name="pointnum">记录器编号</param>
       /// <returns></returns>
       public IDataReader FindFirstMeasurement(string pointnum) {

           string commandText = string.Format("SELECT TOP 1 * FROM [{0}MEASUREMENT] WHERE POINTNUM='{1}' ORDER BY MEASUREMENTID ASC", BaseConfigs.GetTablePrefix, pointnum);

           return DbHelper.ExecuteReader(CommandType.Text, commandText);
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
       public DataSet FindMeasurementByAllPoint(string startdate, string enddate,string level, string type,string orgid,int pageindex, int pagesize)
       {
           DbParameter[] parms = { 
                                 
                                  DbHelper.MakeInParam("@StartDate", (DbType)SqlDbType.VarChar, 30, startdate), 
                                  DbHelper.MakeInParam("@EndDate", (DbType)SqlDbType.VarChar, 30, enddate), 
                                  DbHelper.MakeInParam("@Level", (DbType)SqlDbType.VarChar, 30, level),
                                  DbHelper.MakeInParam("@Type", (DbType)SqlDbType.VarChar, 20, type), 
                                  DbHelper.MakeInParam("@OrgId", (DbType)SqlDbType.VarChar, 20, orgid), 
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


    /// <summary>
        /// 获取指定时间内的的测量数据
        /// </summary>
        /// <param name="pointnum">测点编号</param>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="reportType">查询方式</param>
        /// <returns></returns>
       public IDataReader FindMeasurementHistoryData(string pointnum, string startdate, string enddate, ReportType reportType)
       {
           DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@PointNum", (DbType)SqlDbType.VarChar, 30, pointnum), 
                                  DbHelper.MakeInParam("@StartDate", (DbType)SqlDbType.VarChar, 30, startdate), 
                                  DbHelper.MakeInParam("@EndDate", (DbType)SqlDbType.VarChar, 30, enddate), 
                                  DbHelper.MakeInParam("@Type", (DbType)SqlDbType.VarChar, 20, reportType.ToString())
                                  };
           return DbHelper.ExecuteReader(CommandType.StoredProcedure, "GetMeasurementHistory", parms);
       }


         /// <summary>
        /// 获取指定时间内的的测量数据
        /// </summary>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <returns></returns>
       public IDataReader FindMeasurementByDate(string startdate, string enddate, string pointNum, ReportType reportType) {
           DbParameter[] parms = {                                
                                  DbHelper.MakeInParam("@StartDate", (DbType)SqlDbType.VarChar, 30, startdate), 
                                  DbHelper.MakeInParam("@EndDate", (DbType)SqlDbType.VarChar, 30, enddate), 
                                  DbHelper.MakeInParam("@PointNum", (DbType)SqlDbType.VarChar, 20, pointNum), 
                                  DbHelper.MakeInParam("@Type", (DbType)SqlDbType.VarChar, 30, reportType.ToString()),
                                  };
           return DbHelper.ExecuteReader(CommandType.StoredProcedure, "GetMeasurementByDate", parms);
       }

       /// <summary>
       /// 获取指定测点的最后计量时间
       /// </summary>
       /// <param name="pointnum">计量点编号</param>
       /// <param name="reportType">查询方式</param>
       /// <returns></returns>
       public IDataReader GetLastMeasurtimeByPointNum(string pointnum, ReportType reportType) {

           DbParameter param = DbHelper.MakeInParam("@POINTNUM", (DbType)SqlDbType.VarChar, 8, pointnum);
           string commandText = string.Format("SELECT TOP 1 * FROM [{0}MEASUREMENT_{1}] WHERE POINTNUM=@POINTNUM ORDER BY MEASUREMENTID DESC", 
               BaseConfigs.GetTablePrefix,
               reportType.ToString().ToUpper());

           return DbHelper.ExecuteReader(CommandType.Text, commandText, param);
       }

        /// <summary>
        /// 获取指定时间内的测量数据报告
        /// </summary>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="reportType">查询方式</param>
        /// <returns></returns>
       public DataTable GetMeasurementReport(string startdate, string enddate,string level,string orgid, ReportType reportType)
       {
           DbParameter[] parms = {                                
                                  DbHelper.MakeInParam("@StartDate", (DbType)SqlDbType.VarChar, 30, startdate), 
                                  DbHelper.MakeInParam("@EndDate", (DbType)SqlDbType.VarChar, 30, enddate), 
                                  DbHelper.MakeInParam("@Level", (DbType)SqlDbType.VarChar, 30, level), 
                                  DbHelper.MakeInParam("@Type", (DbType)SqlDbType.VarChar, 30, reportType.ToString()),
                                  DbHelper.MakeInParam("@Orgid", (DbType)SqlDbType.VarChar, 20, orgid.ToString()),
                                  };
           return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "GetMeasurementReport", parms).Tables[0];
       }


        /// <summary>
        /// 获取指定时间内的测量数据报告
        /// </summary>
        /// <param name="pointnum">自定义测点,多测点用半角逗号隔开,如S1,S2,S3</param>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="reportType">查询方式</param>
        /// <param name="formula">计算公式</param>
        /// <returns></returns>
       public DataTable GetMeasurementCustomReport(string pointnum, string startdate, string enddate, ReportType reportType, string formula)
       {
           DbParameter[] parms = {
                                  DbHelper.MakeInParam("@POINTNUM", (DbType)SqlDbType.VarChar, 1000, pointnum),
                                  DbHelper.MakeInParam("@StartDate", (DbType)SqlDbType.VarChar, 30, startdate), 
                                  DbHelper.MakeInParam("@EndDate", (DbType)SqlDbType.VarChar, 30, enddate), 
                                  DbHelper.MakeInParam("@Type", (DbType)SqlDbType.VarChar, 30, reportType.ToString()),
                                  DbHelper.MakeInParam("@Formula", (DbType)SqlDbType.VarChar, 1000, formula)
                                  };
           return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "GetMeasurementCustomReport", parms).Tables[0];
       }



       public bool CreateMeasurementHourData(MeasurementStatInfo statInfo) {

           DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@POINTNUM", (DbType)SqlDbType.VarChar, 1000, statInfo.Pointnum),
                                  DbHelper.MakeInParam("@MEASUREUNITID", (DbType)SqlDbType.VarChar, 20, statInfo.Measureunitid),
                                  DbHelper.MakeInParam("@MEASURETIME", (DbType)SqlDbType.DateTime, 8, statInfo.Measuretime),
                                  DbHelper.MakeInParam("@STARTVALUE", (DbType)SqlDbType.Decimal, 4, statInfo.StartValue),
                                  DbHelper.MakeInParam("@LASTVALUE", (DbType)SqlDbType.Decimal, 4, statInfo.LastValue),
                                  DbHelper.MakeInParam("@STARTTIME", (DbType)SqlDbType.DateTime, 8, statInfo.Starttime),
                                  DbHelper.MakeInParam("@ENDTIME", (DbType)SqlDbType.DateTime, 8, statInfo.Endtime),
                                  DbHelper.MakeInParam("@VALUE", (DbType)SqlDbType.Decimal, 4, statInfo.Value)
                                  };

           string commandText = string.Format("INSERT INTO [{0}MEASUREMENT_HOUR] ([POINTNUM],[MEASUREUNITID],[MEASURETIME],[STARTVALUE],[LASTVALUE],[STARTTIME],[ENDTIME],[VALUE])" +
               "VALUES(@POINTNUM,@MEASUREUNITID,@MEASURETIME,@STARTVALUE,@LASTVALUE,@STARTTIME,@ENDTIME,@VALUE);", BaseConfigs.GetTablePrefix);

           return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
       }

       /// <summary>
       /// 创建测量每日数据
       /// </summary>
       /// <param name="statInfo"></param>
       /// <returns></returns>
       public bool CreateMeasurementDayData(MeasurementStatInfo statInfo)
       {
           DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@POINTNUM", (DbType)SqlDbType.VarChar, 8, statInfo.Pointnum),
                                  DbHelper.MakeInParam("@MEASUREUNITID", (DbType)SqlDbType.VarChar, 20, statInfo.Measureunitid),
                                  DbHelper.MakeInParam("@MEASURETIME", (DbType)SqlDbType.DateTime, 8, statInfo.Measuretime),
                                  DbHelper.MakeInParam("@STARTVALUE", (DbType)SqlDbType.Decimal, 4, statInfo.StartValue),
                                  DbHelper.MakeInParam("@LASTVALUE", (DbType)SqlDbType.Decimal, 4, statInfo.LastValue),
                                  DbHelper.MakeInParam("@STARTTIME", (DbType)SqlDbType.DateTime, 8, statInfo.Starttime),
                                  DbHelper.MakeInParam("@ENDTIME", (DbType)SqlDbType.DateTime, 8, statInfo.Endtime),
                                  DbHelper.MakeInParam("@VALUE", (DbType)SqlDbType.Decimal, 4, statInfo.Value)
                                  };

           string commandText = string.Format("INSERT INTO [{0}MEASUREMENT_DAY] ([POINTNUM],[MEASUREUNITID],[MEASURETIME],[STARTVALUE],[LASTVALUE],[STARTTIME],[ENDTIME],[VALUE])" +
               "VALUES(@POINTNUM,@MEASUREUNITID,@MEASURETIME,@STARTVALUE,@LASTVALUE,@STARTTIME,@ENDTIME,@VALUE);", BaseConfigs.GetTablePrefix);

           return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
       }

       /// <summary>
       /// 创建测量每月数据
       /// </summary>
       /// <param name="statInfo"></param>
       /// <returns></returns>
       public bool CreateMeasurementMonthData(MeasurementStatInfo statInfo)
       {
           DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@POINTNUM", (DbType)SqlDbType.VarChar, 8, statInfo.Pointnum),
                                  DbHelper.MakeInParam("@MEASUREUNITID", (DbType)SqlDbType.VarChar, 20, statInfo.Measureunitid),
                                  DbHelper.MakeInParam("@MEASURETIME", (DbType)SqlDbType.DateTime, 8, statInfo.Measuretime),
                                  DbHelper.MakeInParam("@STARTVALUE", (DbType)SqlDbType.Decimal, 4, statInfo.StartValue),
                                  DbHelper.MakeInParam("@LASTVALUE", (DbType)SqlDbType.Decimal, 4, statInfo.LastValue),
                                  DbHelper.MakeInParam("@STARTTIME", (DbType)SqlDbType.DateTime, 8, statInfo.Starttime),
                                  DbHelper.MakeInParam("@ENDTIME", (DbType)SqlDbType.DateTime, 8, statInfo.Endtime),
                                  DbHelper.MakeInParam("@VALUE", (DbType)SqlDbType.Decimal, 4, statInfo.Value)
                                  };

           string commandText = string.Format("INSERT INTO [{0}MEASUREMENT_MONTH] ([POINTNUM],[MEASUREUNITID],[MEASURETIME],[STARTVALUE],[LASTVALUE],[STARTTIME],[ENDTIME],[VALUE])" +
               "VALUES(@POINTNUM,@MEASUREUNITID,@MEASURETIME,@STARTVALUE,@LASTVALUE,@STARTTIME,@ENDTIME,@VALUE);", BaseConfigs.GetTablePrefix);

           return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
       }
    }
}
