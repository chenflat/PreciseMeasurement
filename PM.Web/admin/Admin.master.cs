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
        private string parentTitle = "";
        protected string Title;
        protected void Page_Load(object sender, EventArgs e)
        {
           // if (!IsPostBack) {

                parentTitle = BasePage.GetSystemTitle();

                Title = Page.Header.Title;

                this.Page.Header.Title = (parentTitle == "") ? Title : parentTitle + "-" + Title;
            
            //} 
        }
    }
}