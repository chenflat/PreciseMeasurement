using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Business.Pages;
using PM.Entity;
using PM.Common;

namespace PM.Web.analysis
{
    public partial class _default : BasePage
    {

        //层级计量点列表
        public Dictionary<string, List<MeasurePointInfo>> measurePointList = null;
        private string m_type = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                m_type = PMRequest.GetString("type");
                //if (m_type == "") m_type = "steam";
                BindMeasurePointData();
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

            for (int i = 1; i < 6; i++) {
                int level = i;
                List<MeasurePointInfo> listByLevel = Business.MeasurePoint.FindMeasurePointsByLevel(m_type,level,orgid, siteid);

                if (listByLevel.Count > 0) {
                    result.Add(level.ToString() + "级", listByLevel);
                }
            }






            ////获取层级对应的计量点数据
            //Dictionary<string, List<MeasurePointInfo>> result = new Dictionary<string, List<MeasurePointInfo>>();

            //int i = 0;
            //foreach (KeyValuePair<int, string> pair in levels) {
            //    int level = pair.Key;
            //    string key = pair.Value;

            //    List<MeasurePointInfo> listByLevel = Business.MeasurePoint.FindMeasurePointsByLevel(level, orgid, siteid);

            //    result.Add(key, listByLevel);
            //    i++;
            //}

            //层级计量点列表
            measurePointList = result;
        }
    }
}