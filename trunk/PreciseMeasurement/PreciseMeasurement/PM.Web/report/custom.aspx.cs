using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using PM.Common;
using PM.Business.Pages;
using PM.Entity;
using PM.Common.ExcelUtils;

namespace PM.Web.report
{
    public partial class custom : BasePage
    {

        //层级计量点列表
        public Dictionary<string, List<MeasurePointInfo>> measurePointList = null;
        private string m_type = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            btnExport.Click += new EventHandler(btnExport_Click);
            if (!IsPostBack)
            {
                m_type = PMRequest.GetString("type");
               // if (m_type == "") m_type = "steam";
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

            for (int i = 1; i < 6; i++) {
                int level = i;
                List<MeasurePointInfo> listByLevel = Business.MeasurePoint.FindMeasurePointsByLevel(m_type,level, orgid, siteid);

                if (listByLevel.Count > 0) {
                    result.Add(level.ToString() + "级", listByLevel);
                }
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
            List<ReportSettingInfo> listInfos = PM.Business.ReportSetting.GetReportSettingByUserId(settingname, AdminInfo.UserId, AdminInfo.Orgid);
            if (listInfos == null)
                return;
            foreach (var info in listInfos) {
                if (sb.Length > 0)
                    sb.Append(",");
                sb.Append(info.Pointnum);
            }
            //获取开始和结束日期
            string m_startdate, m_enddate;
            m_startdate = startdate.Text.Trim();
            m_enddate = enddate.Text.Trim();
            
            //获取结果集
            DataTable table = Data.Measurement.GetMeasurementCustomReport(sb.ToString(), m_startdate, m_enddate, ReportType.Day, "");

            //定义导出文件名称和创建Excel文件
            string fileName = "自定义报表_" + DateTime.Now.ToString("yyyyMMdd");
            ExcelHelper.CreateExcel(table, fileName);

        }
    }
}