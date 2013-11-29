using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PM.Business.Pages;
using PM.Business;
using PM.Common;
using PM.Config;
using PM.Entity;


namespace PM.Web.admin.measurepoints
{
    public partial class paramters : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string keyId = PMRequest.GetString("id");
                string pointnum = PMRequest.GetString("pointnum");
                if (keyId != "" && Utils.IsNumeric(keyId))
                {
                    SetPointDescrption(long.Parse(keyId));
                }
                BindData(pointnum);

               // btnBack.NavigateUrl = "edit.aspx?id="+ keyId;
            }
        }

        private void SetPointDescrption(long id) {
            if (id <= 0)
                return;
            //绑定计量点数据源
            ddlPointNum.DataSource = MeasurePoint.FindMeasurePointAndLocation();
            ddlPointNum.DataTextField = "description";
            ddlPointNum.DataValueField = "pointnum";
            ddlPointNum.DataBind();

            //绑定参量数据
            ddlMeasureUnitId.DataSource = MeasureUnit.FindAllMeasureUnitListDataTable();
            ddlMeasureUnitId.DataTextField = "description";
            ddlMeasureUnitId.DataValueField = "measureunitid";
            ddlMeasureUnitId.DataBind();

            MeasurePointInfo pointInfo = MeasurePoint.GetMeasurePointInfo(id);
            ltPointName.Text = pointInfo.Description;
            //设置当前选择的计量点
            ddlPointNum.SelectedValue = pointInfo.Pointnum;
        }

        private void BindData(string pointnum)
        {
            gvParamters.DataSource = MeasurePoint.FindMeasurePointParamByPointNum(pointnum);
            gvParamters.DataBind();
        }
    }
}