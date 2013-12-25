using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using PM.Business.Pages;
using PM.Entity;
using PM.Common;


namespace PM.Web.analysis {
    public partial class streamtrap : BasePage {
        private int assetuid = 0;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                assetuid = PMRequest.GetInt("assetuid", 0);


            }
        }

        private void BindAssst() { 
        
        
        
        }



    }
}