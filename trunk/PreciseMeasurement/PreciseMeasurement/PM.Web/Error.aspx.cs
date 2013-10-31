using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PM.Config;

namespace PM.Web
{
    public partial class Error : System.Web.UI.Page
    {
         protected string strBasePath = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                strBasePath = BaseConfigs.GetSystemPath;
                if (Application["error"] != null)
                {
                    lblErrmsg.Text = Application["error"].ToString();
                    Server.ClearError();
                }
              

            }
        }
    }
}