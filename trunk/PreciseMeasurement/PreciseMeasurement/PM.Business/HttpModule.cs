using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Xml;

using PM.Config;
using PM.Common;


namespace PM.Business
{
    public class HttpModule : System.Web.IHttpModule
    {
        static Timer eventTimer;
        /// <summary>
        /// 实现接口的Init方法
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            
            context.Error += new EventHandler(Application_OnError);
        }

        public void Application_OnError(Object sender, EventArgs e)
        {
            string requestUrl = PMRequest.GetUrl();
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;

            //if (GeneralConfigs.GetConfig().Installation == 0 && requestUrl.IndexOf("install") == -1)//当该站点未运行过安装并且当前页面不是安装程序目录下的页面时
            //{
            //    context.Server.ClearError();//清除程序异常
            //    HttpContext.Current.Response.Redirect(BaseConfigs.GetSystemPath + "install/index.aspx");
            //    return;
            //}
#if EntLib
            if (RabbitMQConfigs.GetConfig() != null && RabbitMQConfigs.GetConfig().HttpModuleErrLog.Enable)//当开启errlog错误日志记录功能时
            {
                Discuz.EntLib.ServiceBus.HttpModuleErrLogClientHelper.GetHttpModuleErrLogClient().AsyncAddLog(
                    new Discuz.EntLib.ServiceBus.HttpModuleErrLogData(
                        Discuz.EntLib.ServiceBus.LogLevel.High, 
                        context.Server.GetLastError().ToString()
                        ));
                return;
            }
#endif
            //context.Response.Write("<html><body style=\"font-size:14px;\">");
            //context.Response.Write("PM Error:<br />");
            //context.Response.Write("<textarea name=\"errormessage\" style=\"width:80%; height:200px; word-break:break-all\">");
            //context.Response.Write(System.Web.HttpUtility.HtmlEncode(context.Server.GetLastError().ToString()));
            //context.Response.Write("</textarea>");
            //context.Response.Write("</body></html>");
            //context.Response.End();

            //context.Server.ClearError();//清除程序异常
        }


        /// <summary>
        /// 实现接口的Dispose方法
        /// </summary>
        public void Dispose()
        {
            eventTimer = null;
        }
    }
}
