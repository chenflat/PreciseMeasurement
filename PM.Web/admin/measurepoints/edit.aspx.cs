using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Common;
using PM.Business;
using PM.Entity;
using PM.Business.Pages;

namespace PM.Web.admin.measurepoints
{
    public partial class edit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string keyId = PMRequest.GetString("id");
                BindDropDownList();
                if (keyId != "" && Utils.IsNumeric(keyId))
                {
                    btnDelte.Attributes.Add("onclick", "return confirm('删除数据不可恢复，确定要删除码');");
                    LoadMeasurePointInfo(PMRequest.GetInt("id", -1));
                    btnParams.Visible = true;
               
                }
                else
                {
                    btnParams.Visible = false;
                    btnDelte.Enabled = false;
                }
            }
        }
        /// <summary>
        /// 绑定下拉框数据
        /// </summary>
        private void BindDropDownList()
        {
            ddlOrgid.DataTextField = "Description";
            ddlOrgid.DataValueField = "ORGID";
            ddlOrgid.DataSource = Business.Organizations.GetOrganizationTreeList("-");
            ddlOrgid.DataBind();




        }


        /// <summary>
        /// 载入指定计量点的数据
        /// </summary>
        /// <param name="id"></param>
        private void LoadMeasurePointInfo(long id)
        {
            if (id <= 0)
                return;
            MeasurePointInfo pointInfo = Business.MeasurePoint.GetMeasurePointInfo(id);
            if (pointInfo == null)
                return;
            btnParams.NavigateUrl = string.Format("paramters.aspx?id={0}&pointnum={1}", pointInfo.Measurepointid, pointInfo.Pointnum);
            measurepointid.Value = pointInfo.Measurepointid.ToString();
            description.Text = pointInfo.Description;
            pointcode.Text = pointInfo.PointCode;
            pointnum.Text = pointInfo.Pointnum;
            carrier.SelectedValue = pointInfo.Carrier;
            supervisor.Text = pointInfo.Supervisor;
            phone.Text = pointInfo.Phone;
            ddlOrgid.SelectedValue = pointInfo.Orgid;
            ddlLevel.SelectedValue = pointInfo.Level.ToString();
            //location.SelectedValue = pointInfo.Location;
            ipaddress.Text = pointInfo.Ipaddress;
            cardnum.Text = pointInfo.Cardnum;
            devicenum.Text = pointInfo.Devicenum;
            serverip.Text = pointInfo.Serverip;
            serverport.Text = pointInfo.Serverport.ToString();
            displaysequence.Text = pointInfo.Displaysequence.ToString();
            tbX.Text = pointInfo.X;
            tbY.Text = pointInfo.Y;
            tbZ.Text = pointInfo.Z;

        }


        /// <summary>
        /// 保存计量点信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                SaveMeasurepoint(false);
            }
        }

        /// <summary>
        /// 保存计量点
        /// </summary>
        /// <param name="IsSaveOrNew">是否保存并新增</param>
        private void SaveMeasurepoint(bool IsSaveOrNew) {
            try
            {
                MeasurePointInfo pointInfo = new MeasurePointInfo();
                pointInfo.Measurepointid = Utils.StrToInt(measurepointid.Value, -1);
                pointInfo.Description = description.Text.Trim();
                pointInfo.PointCode = pointcode.Text.Trim();
                pointInfo.Pointnum = pointnum.Text.Trim();
                pointInfo.Carrier = carrier.SelectedValue;
                pointInfo.Supervisor = supervisor.Text.Trim();
                pointInfo.Phone = phone.Text.Trim();
                pointInfo.Orgid = ddlOrgid.SelectedValue;
                // pointInfo.Location = location.SelectedValue;
                pointInfo.Level = Utils.StrToInt(ddlLevel.Text.Trim(), 0);
                pointInfo.Ipaddress = ipaddress.Text.Trim();
                pointInfo.Cardnum = cardnum.Text.Trim();
                pointInfo.Devicenum = devicenum.Text.Trim();
                pointInfo.Serverip = serverip.Text.Trim();
                pointInfo.Serverport = Utils.StrToInt(serverport.Text.Trim(), -1);
                pointInfo.Displaysequence = Utils.StrToInt(displaysequence.Text.Trim(), 0);
                pointInfo.X = tbX.Text.Trim();
                pointInfo.Y = tbY.Text.Trim();
                pointInfo.Z = tbZ.Text.Trim();

                bool isSuccess = false;
                if (pointInfo.Measurepointid > 0)
                {
                    isSuccess = Business.MeasurePoint.UpdateMeasurePoint(pointInfo);
                }
                else
                {
                    isSuccess = Business.MeasurePoint.CreateMeasurePoint(pointInfo) > 0;
                }
                if (isSuccess)
                {
                    if (IsSaveOrNew) {
                        Response.Redirect("edit.aspx");
                    }
                    else { 
                        Response.Redirect("list.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        void btnDelte_Click(object sender, EventArgs e)
        {
            Business.MeasurePoint.DeleteMeasurePoint(PMRequest.GetInt("id", -1).ToString());
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

        protected void btnSaveAndNew_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                SaveMeasurepoint(true);
            }
        }
    }
}