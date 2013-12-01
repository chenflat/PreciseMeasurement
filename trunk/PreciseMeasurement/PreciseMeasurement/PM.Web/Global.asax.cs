using System;
using System.Collections.Generic;

using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using PM.Business.Pages;
using PM.Business;
using PM.Config;

using log4net;

namespace PM.Web
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码

        }

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }

        void Application_Error(object sender, EventArgs e)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // 在出现未处理的错误时运行的代码
            Exception objErr = Server.GetLastError().GetBaseException();
            string error = "<br />发生异常页: " + System.Web.HttpContext.Current.Request.Url.ToString() + "<br />";
            error += "异常信息: " + objErr.Message + "<br />";
            //写入错误到日志文件
            BasePage bg = new BasePage();

            logger.Error(objErr.Message, objErr);

            Server.ClearError();
            Application["error"] = error;

            System.Web.HttpContext.Current.Response.Write(error);

           // System.Web.HttpContext.Current.Response.Redirect("~/Error.aspx");

        }

        void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码

        }

        void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。
            Session.RemoveAll();
        }

    }
}
