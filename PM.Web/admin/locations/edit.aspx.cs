using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Common;
using PM.Business;
using PM.Entity;
using PM.Business.Pages;

namespace PM.Web.admin.locations
{
    public partial class edit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLoctionsTree();
                string keyId = PMRequest.GetString("id");
                if (keyId != "" && Utils.IsNumeric(keyId))
                {
                    LoadLocationInfo(PMRequest.GetInt("id", -1));
                }
                else {
                    status.Text = "OPERATING";
                    btnDelte.Enabled = false;
                }
            }
        }

        private void BindLoctionsTree() {
            parent.DataSource = Business.Locations.GetLocationsTreeList("└");
            parent.DataTextField = "Description";
            parent.DataValueField = "Location";
            parent.DataBind();
            parent.Items.Insert(0, new ListItem("", ""));
        }

        private void LoadLocationInfo(long id) {

            LocationInfo locationInfo = new LocationInfo();
            if (id <= 0)
                return;
            locationInfo = Business.Locations.GetLocationInfo(id);
            locationsid.Value = locationInfo.Locationsid.ToString();
            location.Text = locationInfo.Location;
            location.Enabled = false;
            description.Text = locationInfo.Description;
            txtSiteid.Text = locationInfo.Siteid;
            txtSiteid.Enabled = false;
            parent.SelectedValue = locationInfo.Parent;
            type.SelectedValue = locationInfo.Type;
            status.Text = locationInfo.Status;
            status.Enabled = false;
            x.Text = locationInfo.X;
            y.Text = locationInfo.Y;
            z.Text = locationInfo.Z;
            level.SelectedValue = locationInfo.Level.ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                LocationInfo locationInfo = new LocationInfo();
                locationInfo.Locationsid = Utils.StrToInt(locationsid.Value, -1);
                locationInfo.Location = location.Text.Trim().ToUpper();
                locationInfo.Description = description.Text.Trim();
                locationInfo.Siteid = txtSiteid.Text.Trim();
                locationInfo.Parent = parent.SelectedValue;
                locationInfo.Type = type.SelectedValue;
                locationInfo.Status = status.Text.Trim();
                locationInfo.X = x.Text.Trim();
                locationInfo.Y = y.Text.Trim();
                locationInfo.Z = z.Text.Trim();
                locationInfo.Changeby = username;
                locationInfo.Changedate = DateTime.Now;
                locationInfo.Level = Utils.StrToInt(level.SelectedValue, 0);
                bool isSuccess = false;
                if (locationInfo.Locationsid > 0)
                {
                    isSuccess = Business.Locations.UpdateLocation(locationInfo);
                }
                else {
                    locationInfo.Statusdate = DateTime.Now;
                    isSuccess = Business.Locations.CreateLocation(locationInfo);
                }
                if (isSuccess)
                {
                    Response.Redirect("list.aspx");
                }
            }
        }

        private void btnDelte_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                PM.Business.Locations.DeleteLocation(PMRequest.GetInt("id", -1).ToString());
                Response.Redirect("list.aspx");
            }
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