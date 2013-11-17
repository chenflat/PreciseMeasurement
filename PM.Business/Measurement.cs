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
    /// <summary>
    /// 计量业务逻辑操作类
    /// </summary>
    public class Measurement
    {

        /// <summary>
        /// 返回指定计量器的最后记录对象
        /// </summary>
        /// <param name="pointnum">计量器编号</param>
        /// <returns>读数对象</returns>
        public static MeasurementInfo GetLastMeasurement(string pointnum) {
            if (pointnum == null || pointnum.Length == 0)
                return null;
            return Data.Measurement.GetLastMeasurement(pointnum);
        }

        /// <summary>
        /// 获取指定查询条件的读表数据
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页显示数</param>
        /// <param name="recordcount">总条数</param>
        /// <returns></returns>
        public static DataTable FindMeasurementByCondition(string condition,string type, int pageindex, int pagesize, out int recordcount)
        {
            return Data.Measurement.FindMeasurementByCondition(condition,type, pageindex, pagesize, out recordcount);
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
        public static DataSet FindMeasurementByPointnum(string pointnum, string startdate, string enddate, string type, int pageindex, int pagesize)
        {
            return Data.Measurement.FindMeasurementByPointnum(pointnum, startdate, enddate, type, pageindex, pagesize);
        }


        /// <summary>
        /// 获取分钟统计数据
        /// </summary>
        /// <param name="pointnum"></param>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <param name="type"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public static Pagination<MeasurementInfo> GetMinuteMeasurementByPointnum(string pointnum, string startdate, string enddate, string type, int pageindex, int pagesize)
        {
            Pagination<MeasurementInfo> pagination = new Pagination<MeasurementInfo>();

            DataSet ds = Data.Measurement.FindMeasurementByPointnum(pointnum, startdate, enddate, type, pageindex, pagesize);

            DataTable meassurement = ds.Tables["Measurement"];

            List<MeasurementInfo> list = new List<MeasurementInfo>();

            using (IDataReader reader = meassurement.CreateDataReader())
            {
                while (reader.Read())
                {
                    MeasurementInfo measurementInfo = Data.Measurement.LoadMeasurementInfo(reader);
                    list.Add(measurementInfo);
                }
                reader.Close();
            }

            DataTable dtPager = ds.Tables["Pager"];

            PagerInfo pagerInfo = Pager.GetPagerInfo(dtPager.CreateDataReader());

            pagination.List = list;
            pagination.PagerInfo = pagerInfo;

            return pagination;

        }

        /// <summary>
        /// 获取指定测点的计量数据
        /// </summary>
        /// <param name="pointnum">测点编号</param>
        /// <param name="startdate">开始日期</param>
        /// <param name="enddate">结束日期</param>
        /// <param name="type">统计类型 HOUR|DAY|MONTH</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页显示数</param>
        /// <returns></returns>
        public static Pagination<MeasurementStatInfo> GetMeasurementByPointnum(string pointnum, string startdate, string enddate, string type, int pageindex, int pagesize)
        {
            Pagination<MeasurementStatInfo> pagination = new Pagination<MeasurementStatInfo>();
            DataSet ds = null;
            if (pointnum == "")
            {
                ds = Data.Measurement.FindMeasurementByAllPoint(startdate, enddate, type, pageindex, pagesize);
            }
            else {
                ds = Data.Measurement.FindMeasurementByPointnum(pointnum, startdate, enddate, type, pageindex, pagesize);
            }

            

            DataTable meassurement = ds.Tables["Measurement"];

            List<MeasurementStatInfo> list = new List<MeasurementStatInfo>();

            using (IDataReader reader = meassurement.CreateDataReader())
            {
                while (reader.Read())
                {
                    MeasurementStatInfo statInfo = Data.Measurement.LoadMeasurementStatInfo(reader);
                    list.Add(statInfo);
                }
                reader.Close();
            }

            DataTable dtPager = ds.Tables["Pager"];

            PagerInfo pagerInfo = Pager.GetPagerInfo(dtPager.CreateDataReader());

            pagination.List = list;
            pagination.PagerInfo = pagerInfo;

            return pagination;

        }


        /// <summary>
        /// 获取指定测点的计量数据
        /// </summary>
        /// <param name="pointnum">测点编号</param>
        /// <param name="startdate">开始日期</param>
        /// <param name="enddate">结束日期</param>
        /// <param name="type">统计类型 HOUR|DAY|MONTH</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页显示数</param>
        /// <returns></returns>
        public static Pagination<MeasurementStatInfo> GetMeasurementByAllPoint(string startdate, string enddate, string type, int pageindex, int pagesize)
        {
            return GetMeasurementByPointnum("", startdate, enddate, type, pageindex, pagesize);

        }
        



        public static Pagination<ReportDataInfo> GetReportData(string startdate, string enddate, string type, int pageindex, int pagesize) {
            
            Pagination<ReportDataInfo> pagination = new Pagination<ReportDataInfo>();

            DataSet ds = Data.Measurement.FindMeasurementByAllPoint( startdate, enddate, type, pageindex, pagesize);

            DataTable meassurement = ds.Tables["Measurement"];

            List<ReportDataInfo> list = new List<ReportDataInfo>();

            using (IDataReader reader = meassurement.CreateDataReader())
            {
                while (reader.Read())
                {
                    ReportDataInfo reportDataInfo = Data.Measurement.LoadReportDataInfo(reader);
                    list.Add(reportDataInfo);
                }
                reader.Close();
            }

            DataTable dtPager = ds.Tables["Pager"];
            PagerInfo pagerInfo = Pager.GetPagerInfo(dtPager.CreateDataReader());
            pagination.List = list;
            pagination.PagerInfo = pagerInfo;

            return pagination;

        }

        /// <summary>
        /// 获取测量历史数据
        /// </summary>
        /// <param name="pointnum"></param>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<MeasurementInfo> GetMeasurementHistoryData(string pointnum, string startdate, string enddate, ReportType type)
        {

            List<MeasurementInfo> measurements = new List<MeasurementInfo>();
            using (IDataReader reader = Data.Measurement.FindMeasurementHistoryData(pointnum,startdate,enddate,type))
            {
                while (reader.Read())
                {
                    MeasurementInfo measurementInfo = Data.Measurement.LoadMeasurementInfo(reader);
                    measurements.Add(measurementInfo);
                }
                reader.Close();
            }
            return measurements;
        }


       




    }
}
