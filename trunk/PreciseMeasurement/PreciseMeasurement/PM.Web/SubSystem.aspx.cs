using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Business.Pages;

namespace PM.Web {
    public partial class SubSystem : BasePage {

        private string strSystemName = "";
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                strSystemName = PM.Common.PMRequest.GetString("sys");

                Session["CURRENTSYSTEM"] = strSystemName;
                //measurement、water、airpressure、electricity

                if (strSystemName == "water") {
                    this.phMeasuresystemNav.Visible = false;
                    this.phWaterNav.Visible = true;
                    this.phAirpressureNav.Visible = false;
                    this.phElectricityNav.Visible = false;
                    
                } else if (strSystemName == "airpressure") {
                    this.phMeasuresystemNav.Visible = false;
                    this.phWaterNav.Visible = false;
                    this.phAirpressureNav.Visible = true;
                    this.phElectricityNav.Visible = false;

                } else if (strSystemName == "electricity") {
                    this.phMeasuresystemNav.Visible = false;
                    this.phWaterNav.Visible = false;
                    this.phAirpressureNav.Visible = false;
                    this.phElectricityNav.Visible = true;

                } else {
                    this.phMeasuresystemNav.Visible = true;
                    this.phWaterNav.Visible = false;
                    this.phAirpressureNav.Visible = false;
                    this.phElectricityNav.Visible = false;
                }

            }
        }
    }
}