using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PM.Business.Pages;
using PM.Business;

namespace PM.Web.admin.measurereplace
{
    public partial class list : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            btnQuery.Click += new EventHandler(btnQuery_Click);
            if (!IsPostBack)
            {
                BindData();
            }
        }

        void btnQuery_Click(object sender, EventArgs e)
        {
           
        }

        private void BindData()
        {
         
        }
    }
}