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
                doLogout();
            }
        }

        private string msg = "<div class=\"form-group\"><div class=\"col-lg-offset-4 col-lg-8\">{0}</div></div>";

        /// <summary>
        /// 用户登陆验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            //用户名和密码
            string m_username = UserName.Text.Trim();
            string m_password = Password.Text.Trim();

            //验证用户是否存在
            UserInfo userinfo = Users.GetUserInfoByUserName(m_username);
            if (userinfo != null)
            {
                //比较密码
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

                    string url = "../Default.aspx";
                    if (PMRequest.GetQueryString("url") != "") {
                        url = PMRequest.GetQueryString("url");
                    }
                    Response.Redirect(url, true);
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
        private void doLogout()
        {
            //清除缓存
            Session.RemoveAll();
            Response.Redirect(BaseConfigs.GetSystemPath + "Account/Login.aspx", true);
        }

    }
}