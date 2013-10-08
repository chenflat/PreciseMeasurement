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


namespace PM.Web.admin.measurepoints
{
    public partial class paramters : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        { 
            
        }
    }
}