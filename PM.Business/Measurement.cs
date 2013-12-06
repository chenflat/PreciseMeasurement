﻿using System;
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
        public static Pagination<MeasurementStatInfo> GetMeasurementByPointnum(string pointnum, string startdate, string enddate,string level, string type, int pageindex, int pagesize)
        {
            Pagination<MeasurementStatInfo> pagination = new Pagination<MeasurementStatInfo>();
            DataSet ds = null;
            if (pointnum == "")
            {
                ds = Data.Measurement.FindMeasurementByAllPoint(startdate, enddate,"", type, pageindex, pagesize);
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
            return GetMeasurementByPointnum("", startdate, enddate,"", type, pageindex, pagesize);

        }

        public static Pagination<MeasurementStatInfo> GetMeasurementByAllPoint(string startdate, string enddate,string level, string type, int pageindex, int pagesize) {
            return GetMeasurementByPointnum("", startdate, enddate, level, type, pageindex, pagesize);
        }

        public static Pagination<ReportDataInfo> GetReportData(string startdate, string enddate, string type, int pageindex, int pagesize) {
            return GetReportData(startdate, enddate, "", type, pageindex, pagesize);
        }
        public static Pagination<ReportDataInfo> GetReportData(string startdate, string enddate,string level, string type, int pageindex, int pagesize) {
            
            Pagination<ReportDataInfo> pagination = new Pagination<ReportDataInfo>();

            DataSet ds = Data.Measurement.FindMeasurementByAllPoint( startdate, enddate,level, type, pageindex, pagesize);

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


        /// <summary>
        /// 生成统计数据
        /// </summary>
        /// <param name="type">报表类型</param>
        /// <returns></returns>
        public static void CreateMeasurementStatData(ReportType type) {
            CreateMeasurementStatData("", "", type);
        }

        /// <summary>
        /// 生成测试数据
        /// </summary>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="type">时间类型</param>
        public static void CreateMeasurementStatData(string startdate, string enddate, ReportType type) {


            //由于每个计量点的采集时间有可能不一致，所有这里分别针对每个计量点进行统计
            List<MeasurePointInfo> measurepoints = MeasurePoint.FindMeasurePointAndLocation();
            foreach (var measurepoint in measurepoints) {

                string curPointnum = measurepoint.Pointnum;
                int curPointLevel = measurepoint.Level;

                //开始时间，如果没有指定开始时间，则取记录的最后一条统计时间为开始时间
                DateTime dtStarttime;
                if (startdate == "") {
                    dtStarttime = Data.Measurement.GetLastMeasurtimeByPointNum(curPointnum, type);
                }
                else {
                    dtStarttime = DateTime.Parse(startdate);
                }

                //判断开始日期，如果没有开始日期，则在原始记录表中查询
                if (dtStarttime == DateTime.MinValue) {
                    dtStarttime = Data.Measurement.GetFirstMeasurtimeByPointNum(curPointnum);
                }

                //如果原始记录表没有未找开始日期，则跳过此计量点，继续执行下一条记录
                if (dtStarttime == DateTime.MinValue) {
                    continue;
                }


                //结束时间，如果没有指定结束日期，则为当前日期(零点零分零秒)
                DateTime dtEndtime;
                if (enddate == "" || enddate == null) {
                    enddate = DateTime.Now.ToString("yyyy-MM-dd HH:00:00");
                    dtEndtime = DateTime.Parse(enddate);
                }
                else {
                    dtEndtime = DateTime.Parse(enddate);
                }

                //如果未能取到结束日期，则跳过此计量点，继续执行下一条记录
                if (dtEndtime == DateTime.MinValue)
                    continue;

                //时间差
                TimeSpan t3 = dtEndtime.Subtract(dtStarttime);

                //计算TimeSpan差值
                double totalHours = t3.TotalHours;
                double totalDays = t3.TotalDays;
                double totalMonth = dtEndtime.Month - dtStarttime.Month;


                //根据不同的报表类型分别构造时间列表
                List<MeasurementStatInfo> listStatInfo = new List<MeasurementStatInfo>();

                string dateformat = "";
                if (type == ReportType.Hour) {
                    dateformat = "yyyy-MM-dd HH";
                    for (int h = 0; h < totalHours; h++) {
                        DateTime dh = dtStarttime.AddHours(h);
                        listStatInfo.Add(new MeasurementStatInfo(dh));
                    }
                }
                else if (type == ReportType.Day) {
                    dateformat = "yyyy-MM-dd";
                    for (int d = 0; d < totalDays; d++) {
                        DateTime dd = dtStarttime.AddDays(d);
                        listStatInfo.Add(new MeasurementStatInfo(dd));
                    }
                }
                else if (type == ReportType.Month) {
                    dateformat = "yyyy-MM";
                    for (int m = 0; m <= totalMonth; m++) {
                        DateTime dd = dtStarttime.AddMonths(m);
                        listStatInfo.Add(new MeasurementStatInfo(dd));
                    }
                }

                //获取测点在指定时间段内的测量数据列表
                List<MeasurementInfo> measurements = new List<MeasurementInfo>();
                using (IDataReader reader = Data.Measurement.FindMeasurementByDate(startdate, enddate,curPointnum, type)) {
                    while (reader.Read()) {
                        MeasurementInfo measurementInfo = Data.Measurement.LoadStatInfo(reader);
                        measurements.Add(measurementInfo);
                    }
                    reader.Close();
                }

                //比较时间,构造起始时间、终止时间、起始值、终止值列表
                foreach (var item in listStatInfo) {
                    List<MeasurementInfo> tempList = new List<MeasurementInfo>();

                    for (int i = 0; i < measurements.Count; i++) {
                        if (measurements[i].Measuretime.ToString(dateformat) == item.Measuretime.ToString(dateformat)) {
                            tempList.Add(measurements[i]);
                            measurements.Remove(measurements[i]);
                        }
                    }

                    //获取最后一条记录
                    if (tempList.Count > 0) {
                        MeasurementInfo lastMeasurement = tempList[tempList.Count - 1];
                        item.LastValue = lastMeasurement.AtFlow;
                        item.Pointnum = lastMeasurement.Pointnum;
                        item.Measureunitid = "AT_Flow";
                        item.Value = 0;
                    }
                }

                bool ret;
                try {
                    //计算用量差值
                    for (int i = 0; i < listStatInfo.Count; i++) {
                        string pointnum = listStatInfo[i].Pointnum;

                        if (i + 1 < listStatInfo.Count) {
                            listStatInfo[i + 1].Value = listStatInfo[i + 1].LastValue - listStatInfo[i].LastValue;

                            MeasurementStatInfo statInfo = listStatInfo[i + 1];
                            statInfo.Starttime = listStatInfo[i].Measuretime;
                            statInfo.StartValue = listStatInfo[i].LastValue;
                            statInfo.Endtime = statInfo.Measuretime;
                            statInfo.Level = curPointLevel.ToString();
                            if (statInfo.Pointnum.Length > 0) {
                                if (type == ReportType.Hour) {
                                    ret = DatabaseProvider.GetInstance().CreateMeasurementHourData(statInfo);
                                }
                                else if (type == ReportType.Day) {
                                    ret = DatabaseProvider.GetInstance().CreateMeasurementDayData(statInfo);
                                }
                                else if (type == ReportType.Month) {
                                    ret = DatabaseProvider.GetInstance().CreateMeasurementMonthData(statInfo);
                                }

                            }
                            PM.Data.MeasurePoint.UpdateMeasurePointLastSynTime(pointnum, statInfo.Measuretime);
                        }
                    }

                    // 
                }
                catch (Exception e) {
                    throw e;
                }


            }

        }





    }
}
