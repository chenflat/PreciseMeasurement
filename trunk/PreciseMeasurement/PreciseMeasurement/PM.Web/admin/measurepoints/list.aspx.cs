using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using PM.Business.Pages;
using PM.Business;
using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;
using PM.Common.ExcelUtils;

namespace PM.Web.admin.measurepoints
{
    public partial class list : BasePage
    {
        private string condition = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            btnQuery.Click += new EventHandler(btnQuery_Click);
            btnExport.Click += new EventHandler(btnExport_Click);

            if (!IsPostBack)
            {
                BindDropDownList();
                BindData();
            }
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            string fileName = "计量点信息_" + DateTime.Now.ToString("yyyyMMdd");
            DataTable table = Business.MeasurePoint.FindMeasurePointByCondition(condition); ;
            ExcelHelper.CreateExcel(table, fileName);
        }  

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            rptMeasurePoint.DataSource = Business.MeasurePoint.FindMeasurePointByCondition(condition);
            rptMeasurePoint.DataBind();
        }

        /// <summary>
        /// 绑定DropDownList数据源
        /// </summary>
        private void BindDropDownList() {
            ddlOrgId.Items.Clear();
            ddlOrgId.DataTextField = "DESCRIPTION";
            ddlOrgId.DataValueField = "ORGID";
            ddlOrgId.DataSource = Business.Organizations.GetOrganizationTreeList("└");
            ddlOrgId.DataBind();
            ddlOrgId.Items.Insert(0, new ListItem(""));
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnQuery_Click(object sender, EventArgs e)
        {
            condition = "";
            if (ddlOrgId.SelectedValue.Length>0)
            {
                string orgids = PM.Data.Organizations.GetOrganizationAndChildrenByOrgId(ddlOrgId.SelectedValue);

                condition += string.Format(" and {0}MEASUREPOINT.ORGID IN ({1})",
                    BaseConfigs.GetTablePrefix, orgids);
            }
            if (txtDescription.Text.Trim().Length>0)
            {
                condition += string.Format(" and {0}MEASUREPOINT.DESCRIPTION like '%{1}%'",
                    BaseConfigs.GetTablePrefix, txtDescription.Text.Trim());
            }
            if (ddlCarrier.SelectedValue.Length > 0 && ddlCarrier.SelectedValue!="")
            {
                condition += string.Format(" and {0}MEASUREPOINT.CARRIER='{1}'",
                    BaseConfigs.GetTablePrefix, ddlCarrier.SelectedValue);
            }
            if (ddlLevel.SelectedValue.Length>0 && ddlLevel.SelectedValue!="") {
                condition += string.Format(" and {0}MEASUREPOINT.level='{1}'",
                    BaseConfigs.GetTablePrefix, ddlLevel.SelectedValue);
            }
            BindData();
            
        }


    }
}