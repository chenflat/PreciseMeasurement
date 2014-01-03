using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Business.Pages;

namespace PM.Web.admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected string Title;
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = Page.Header.Title;

            this.Page.Header.Title = BasePage.GetSystemTitle() + "-" + Title;
            
            
        }
    }
}