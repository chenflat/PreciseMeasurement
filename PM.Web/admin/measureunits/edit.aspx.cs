using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Common;
using PM.Business;
using PM.Entity;
using PM.Business.Pages;

namespace PM.Web.admin.measureunits
{
    public partial class edit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDelte.Enabled = false;
                string keyId = PMRequest.GetString("id");
                if (keyId != "" && Utils.IsNumeric(keyId))
                {
                    LoadMeasureUnitInfo(PMRequest.GetInt("id", -1));
                }
            }

        }

        /// <summary>
        /// 加载计量单位数据
        /// </summary>
        /// <param name="id"></param>
        public void LoadMeasureUnitInfo(long id)
        {
            MeasureUnitInfo measureUnitInfo = PM.Business.MeasureUnit.GetMeasureunitInfo(id);
            if (measureUnitInfo == null)
            {
                return;
            }
            measureunituid.Value = measureUnitInfo.Measureunituid.ToString();
            description.Text = measureUnitInfo.Description;
            type.Text = measureUnitInfo.Type;
            measureunitid.Text = measureUnitInfo.Measureunitid;
            abbreviation.Text = measureUnitInfo.Abbreviation;
            isCalculate.SelectedValue = measureUnitInfo.IsCalculate ? "1" : "0";
            visabled.SelectedValue = measureUnitInfo.Visabled ? "1" : "0";
            isMainParam.SelectedValue = measureUnitInfo.IsMainParam ? "1" : "0";
            displaysequence.Text = measureUnitInfo.Displaysequence.ToString();

        }

        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                MeasureUnitInfo measureUnitInfo = new MeasureUnitInfo();
                measureUnitInfo.Measureunituid = Utils.StrToInt(measureunituid.Value, -1);
                measureUnitInfo.Description = description.Text.Trim();
                measureUnitInfo.Type = type.Text.Trim();
                measureUnitInfo.Measureunitid = measureunitid.Text.Trim();
                measureUnitInfo.Abbreviation = abbreviation.Text.Trim();
                measureUnitInfo.IsCalculate = isCalculate.SelectedValue == "1";
                measureUnitInfo.Visabled = visabled.SelectedValue == "1";
                measureUnitInfo.IsMainParam = isMainParam.SelectedValue == "1";
                measureUnitInfo.Displaysequence = Utils.StrToInt(displaysequence.Text.Trim(), 0);
                bool isSuccess = false;
                if (measureUnitInfo.Measureunituid>0)
                {
                    isSuccess = PM.Business.MeasureUnit.UpdateMeasureUnit(measureUnitInfo) > 0;
                   
                }
                else
                {
                    isSuccess = PM.Business.MeasureUnit.CreateMeasureUnit(measureUnitInfo) > 0;
                }
                if (isSuccess)
                {
                    Response.Redirect("list.aspx");
                }
            }


        }

        void btnDelte_Click(object sender, EventArgs e)
        {
            PM.Business.MeasureUnit.DeleteMeasureUnit(PMRequest.GetInt("id", -1));
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