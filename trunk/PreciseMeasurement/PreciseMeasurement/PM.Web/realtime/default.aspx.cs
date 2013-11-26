using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using PM.Common;
using PM.Business;
using PM.Entity;
using PM.Business.Pages;
using System.Web.Services;

namespace PM.Web.realtime
{
    /// <summary>
    /// 实时参数信息
    /// </summary>
    public partial class _default : BasePage
    {
        //层级计量点列表
        public Dictionary<string, List<MeasurePointInfo>> measurePointList = null;
        public long measurepointid = -1;
        public MeasurePointInfo measurePointInfo = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                measurepointid = PMRequest.GetInt("measurepointid", -1);
                BindMeasurePointData();
                if (measurepointid > 0) {
                    measurePointInfo = Business.MeasurePoint.GetMeasurePointInfo(measurepointid);

                    MeasurePointBaseInfo.MeasurePointInfo = measurePointInfo;
                    RealtimeParams1.MeasurePointInfo = measurePointInfo;
                    MinuteData1.MeasurePointInfo = measurePointInfo;
                    HourData1.MeasurePointInfo = measurePointInfo;
                    DayData1.MeasurePointInfo = measurePointInfo;
                    HistoryData1.MeasurePointInfo = measurePointInfo;
                    AlarmData1.MeasurePointInfo = measurePointInfo;
                    AlarmData1.Orgid = orgid;
                    
                }

            }
        }

        /// <summary>
        /// 获取所有计量点数据
        /// </summary>
        private void BindMeasurePointData() 
        {
            //获取所有层级
            Dictionary<int, string> levels = Business.Locations.GetLevels(orgid, siteid);

            //获取层级对应的计量点数据
            Dictionary<string, List<MeasurePointInfo>> result = new Dictionary<string, List<MeasurePointInfo>>();

            int i = 0;
            foreach (KeyValuePair<int, string> pair in levels)
            {
                int level = pair.Key;
                string key = pair.Value;

                List<MeasurePointInfo> listByLevel = Business.MeasurePoint.FindMeasurePointsByLevel(level, orgid, siteid);
                if (i == 0 && measurepointid<0)
                {
                    measurepointid = listByLevel.Count > 0 ? listByLevel[0].Measurepointid : -1;
                }
                result.Add(key, listByLevel);
                i++;
            }

            //层级计量点列表
            measurePointList = result;
        }


        [WebMethod]
        public static string GetMeasurement(int pageIndex)
        {
            DataSet ds = Business.Measurement.FindMeasurementByPointnum("S1", "2013-09-07 00:00", "2013-09-07 21:00", "DAY", 1, 15);
            return ds.GetXml(); ;
        
        }
       



    }
}