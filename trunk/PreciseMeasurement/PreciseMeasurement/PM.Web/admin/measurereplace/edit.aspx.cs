using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Common;
using PM.Business;
using PM.Entity;
using PM.Business.Pages;

namespace PM.Web.admin.measurereplace
{
    public partial class edit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMeasureUnitData();
                BindMeasurePointData();
                BindLocationsData();
                string keyId = PMRequest.GetString("id");
                if (keyId != "" && Utils.IsNumeric(keyId))
                {
                    LoadMeasureReplaceInfo(PMRequest.GetInt("id", -1));
                }
                else {
                    btnDelte.Enabled = false;
                }
            }
        }

        private void BindMeasureUnitData()
        {
            measureunitid.DataTextField = "DESCRIPTION";
            measureunitid.DataValueField = "MEASUREUNITID";
            measureunitid.DataSource = Business.MeasureUnit.FindAllMeasureUnitListDataTable();
            measureunitid.DataBind();
            measureunitid.Items.Insert(0, new ListItem(""));
        }

        private void BindMeasurePointData()
        {
            pointnum.DataTextField = "DESCRIPTION";
            pointnum.DataValueField = "POINTNUM";
            pointnum.DataSource = Business.MeasurePoint.FindMeasurePointByCondition("");
            pointnum.DataBind();
            pointnum.Items.Insert(0, new ListItem(""));
        }

        private void BindLocationsData()
        {
            fromloc.DataSource = Business.Locations.GetLocationsTreeList("└");
            fromloc.DataTextField = "Description";
            fromloc.DataValueField = "Location";
            fromloc.DataBind();
            fromloc.Items.Insert(0, new ListItem("", ""));
        }

        public void LoadMeasureReplaceInfo(long id)
        {
            MeasureReplaceInfo measureReplaceInfo = Business.MeasureReplace.GetMeasureReplaceInfo(id);
            measuretransid.Value = measureReplaceInfo.Measuretransid.ToString();
            pointnum.SelectedValue = measureReplaceInfo.Pointnum;
            topointnum.Text = measureReplaceInfo.ToPointnum;
            measureunitid.SelectedValue = measureReplaceInfo.MeasureunitId;
            measurementvalue.Text = measureReplaceInfo.MeasurementValue.ToString();
            tomeasurementvalue.Text = measureReplaceInfo.ToMeasurementValue.ToString();
            correctedvalue.Text = measureReplaceInfo.CorrectedValue.ToString();
            replacetype.Text = measureReplaceInfo.ReplaceType;
            fromdept.Text = measureReplaceInfo.FromDept;
            fromloc.SelectedValue = measureReplaceInfo.FromLoc;
            replaceperson.Text = measureReplaceInfo.ReplacePerson;
            replacedate.Text = Utils.GetStandardDate(measureReplaceInfo.ReplaceDate.ToString());
            status.Text = measureReplaceInfo.Status;
            memo.Text = measureReplaceInfo.Memo;
            enterby.Text = measureReplaceInfo.EnterBy;
            enterdate.Text = Utils.GetStandardDateTime(measureReplaceInfo.EnterDate.ToString());
        }


        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                MeasureReplaceInfo measureReplaceInfo = new MeasureReplaceInfo();
                measureReplaceInfo.Measuretransid = Utils.StrToInt(measuretransid.Value, -1);
                measureReplaceInfo.Pointnum = pointnum.SelectedValue;
                measureReplaceInfo.ToPointnum = topointnum.Text.Trim();
                measureReplaceInfo.MeasureunitId = measureunitid.SelectedValue;
                measureReplaceInfo.MeasurementValue = (measurementvalue.Text.Trim().Length > 0 && Utils.IsNumeric(measurementvalue.Text.Trim())) ? Convert.ToDecimal(measurementvalue.Text.Trim()) : 0;
                measureReplaceInfo.ToMeasurementValue = (tomeasurementvalue.Text.Trim().Length > 0 && Utils.IsNumeric(tomeasurementvalue.Text.Trim())) ? Convert.ToDecimal(tomeasurementvalue.Text.Trim()) : 0;
                measureReplaceInfo.CorrectedValue = (correctedvalue.Text.Trim().Length > 0 && Utils.IsNumeric(correctedvalue.Text.Trim())) ? Convert.ToDecimal(correctedvalue.Text.Trim()) : 0;
                measureReplaceInfo.ReplaceType = replacetype.Text.Trim();
                measureReplaceInfo.FromDept = fromdept.Text.Trim();
                measureReplaceInfo.FromLoc = fromloc.SelectedValue;
                measureReplaceInfo.ReplacePerson = replaceperson.Text.Trim();
                measureReplaceInfo.ReplaceDate = TypeConverter.ObjectToDateTime(replacedate.Text.Trim());
                measureReplaceInfo.Memo = memo.Text.Trim();
                measureReplaceInfo.EnterBy = enterby.Text.Trim();
                measureReplaceInfo.EnterDate = TypeConverter.ObjectToDateTime(enterdate.Text.Trim());
                measureReplaceInfo.Siteid = siteid;
                measureReplaceInfo.Orgid = orgid;
                bool isSuccess = false;
                if (measureReplaceInfo.Measuretransid > 0)
                {
                    isSuccess = PM.Business.MeasureReplace.UpdateMeasureReplace(measureReplaceInfo);
                }
                else
                {
                    isSuccess = PM.Business.MeasureReplace.CreateMeasureReplace(measureReplaceInfo);
                }
                if (isSuccess)
                {
                   // ShowMessage(this.Page, MsgType.SUCCESS, "保存成功");
                    Response.Redirect("list.aspx");
                }
                else
                {
                    ShowMessage(this.Page, MsgType.DANGER, "保存失败，返回重新操作");
                }
               

            }
        }

        void btnDelte_Click(object sender, EventArgs e)
        {
            PM.Business.MeasureReplace.DeleteMeasureReplace(measuretransid.Value);
            Response.Redirect("list.aspx");
        }

        #region Web 窗体设计器生成的代码

        protected override void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            btnSave.Click += new EventHandler(btnSave_Click);
            btnDelte.Click += new EventHandler(btnDelte_Click);
        }



        #endregion
    }
}