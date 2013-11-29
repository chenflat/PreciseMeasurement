using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using PM.Business.Pages;
using PM.Entity;
using PM.Common.ExcelUtils;

namespace PM.Web.report
{
    public partial class custom : BasePage
    {

        //层级计量点列表
        public Dictionary<string, List<MeasurePointInfo>> measurePointList = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnExport.Click += new EventHandler(btnExport_Click);
            if (!IsPostBack)
            {

                BindMeasurePointData();
            }
        }

        public List<string> SettingList {
            get { return PM.Data.ReportSetting.GetReportSettingNameList(userid, orgid); }
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

                result.Add(key, listByLevel);
                i++;
            }

            //层级计量点列表
            measurePointList = result;
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            //获取设置对应的计量点列表
            StringBuilder sb = new StringBuilder();
            string settingname = hdnSettingName.Value;
            if (settingname == "")
                return;
            List<ReportSettingInfo> listInfos = PM.Business.ReportSetting.GetReportSettingByUserId(settingname, userid, orgid);
            foreach (var info in listInfos) {
                if (sb.Length > 0)
                    sb.Append(",");
                sb.Append(info.Pointnum);
            }
            string m_startdate, m_enddate;
            m_startdate = startdate.Text.Trim();
            m_enddate = enddate.Text.Trim();
            
            DataTable table = Data.Measurement.GetMeasurementCustomReport(sb.ToString(), m_startdate, m_enddate, ReportType.Day, "");

            string fileName = "自定义报表_" + DateTime.Now.ToString("yyyyMMdd");
            ExcelHelper.CreateExcel(table, fileName);

        }
    }
}