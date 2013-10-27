using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Business;
using PM.Entity;
using PM.Common;
using PM.Config;
using System.Web.Security;

namespace PM.Web.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginButton.Click += new EventHandler(LoginButton_Click);

            string strAction = PMRequest.GetQueryString("Action");

            if (strAction == "Logout")
            {
                //退出登陆状态
                DoLogout();
            }
        }

        private string msg = "<div class=\"form-group\"><div class=\"col-lg-offset-4 col-lg-8\">{0}</div></div>";


        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string m_username = UserName.Text.Trim();
            string m_password = Password.Text.Trim();

            UserInfo userinfo = Users.GetUserInfoByUserName(m_username);
            if (userinfo != null)
            {
                if (!Utils.MD5(m_password).Equals(userinfo.Password))
                {
                    ltMessage.Text = string.Format(msg, "密码错误");
                }
                else {

                    HttpCookie cookie = new HttpCookie("PMADMIN");
                    cookie.Values["key"] = userinfo.UserName;
                    cookie.Expires = DateTime.Now.AddMinutes(30);
                    HttpContext.Current.Response.AppendCookie(cookie);

                    Session["UserInfo"] = userinfo;
                    Response.Redirect("../Default.aspx", true);
                }
            }
            else {

                ltMessage.Text = string.Format(msg, "用户名或密码错误");
                return;
            
            }
        }


        /// <summary>
        /// 注销登陆账户
        /// </summary>
        private void DoLogout()
        {
            //清除缓存
            Session.RemoveAll();
            Response.Redirect(BaseConfigs.GetSystemPath + "Account/Login.aspx", true);
        }

    }
}