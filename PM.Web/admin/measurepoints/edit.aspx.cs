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
                if (keyId != "" && Utils.IsNumeric(keyId))
                {
                    BindDropDownList();
                    btnDelte.Attributes.Add("onclick", "return confirm('删除数据不可恢复，确定要删除码');");
                    LoadMeasurePointInfo(PMRequest.GetInt("id", -1));
                }
                else
                {
                    btnParams.Enabled = false;
                    btnDelte.Enabled = false;
                }
            }
        }

        private void BindDropDownList()
        {
            orgid.DataTextField = "Description";
            orgid.DataValueField = "ORGID";
            orgid.DataSource = Business.Organizations.GetOrganizationTreeList("-");
            orgid.DataBind();

            location.DataTextField = "Description";
            location.DataValueField = "Location";
            location.DataSource = Business.Locations.GetLocationsTreeList("└");
            location.DataBind();
            location.Items.Insert(0, new ListItem("", ""));
        }



        private void LoadMeasurePointInfo(long id)
        {
            if (id <= 0)
                return;
            MeasurePointInfo pointInfo = Business.MeasurePoint.GetMeasurePointInfo(id);
            if (pointInfo == null)
                return;
            measurepointid.Value = pointInfo.Measurepointid.ToString();
            description.Text = pointInfo.Description;
            pointcode.Text = pointInfo.PointCode;
            pointnum.Text = pointInfo.Pointnum;
            carrier.SelectedValue = pointInfo.Carrier;
            supervisor.Text = pointInfo.Supervisor;
            phone.Text = pointInfo.Phone;
            orgid.SelectedValue = pointInfo.Orgid;
            location.SelectedValue = pointInfo.Location;
            ipaddress.Text = pointInfo.Ipaddress;
            cardnum.Text = pointInfo.Cardnum;
            devicenum.Text = pointInfo.Devicenum;
            serverip.Text = pointInfo.Serverip;
            serverport.Text = pointInfo.Serverport.ToString();
            displaysequence.Text = pointInfo.Displaysequence.ToString();

        }



        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
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
                    pointInfo.Orgid = orgid.Text.Trim();
                    pointInfo.Location = location.SelectedValue;
                    pointInfo.Ipaddress = ipaddress.Text.Trim();
                    pointInfo.Cardnum = cardnum.Text.Trim();
                    pointInfo.Devicenum = devicenum.Text.Trim();
                    pointInfo.Serverip = serverip.Text.Trim();
                    pointInfo.Serverport = Utils.StrToInt(serverport.Text.Trim(), -1);
                    pointInfo.Displaysequence = Utils.StrToInt(displaysequence.Text.Trim(), 0);

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
                        Response.Redirect("list.aspx");
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
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
    }
}