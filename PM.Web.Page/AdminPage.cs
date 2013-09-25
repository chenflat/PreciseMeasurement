using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PM.UI
{


    //public class AdminPage : System.Web.UI.Page
    //{
    //    protected internal string username;

    //    /// <summary>
    //    /// 当前用户的用户ID
    //    /// </summary>
    //    protected internal int userid;
    //    /// <summary>
    //    /// 当前用户的用户组ID
    //    /// </summary>
    //    protected internal int usergroupid;

    //    /// <summary>
    //    /// 当前用户的管理组ID
    //    /// </summary>
    //    protected internal short useradminid = 0;

    //    protected internal string grouptitle;

    //    protected internal string ip;

    //    /// <summary>
    //    /// 控件初始化时计算执行时间
    //    /// </summary>
    //    /// <param name="e"></param>
    //    protected override void OnInit(EventArgs e)
    //    {
    //        m_processtime = (Environment.TickCount - m_starttick) / 1000;
    //        base.OnInit(e);
    //    }


    //    /// <summary>
    //    /// 得到当前页面的载入时间供模板中调用(单位:毫秒)
    //    /// </summary>
    //    /// <returns>当前页面的载入时间</returns>
    //    public float Processtime
    //    {
    //        get { return m_processtime; }
    //    }

    //    /// <summary>
    //    /// 当前页面开始载入时间(毫秒)
    //    /// </summary>
    //    public float m_starttick = Environment.TickCount;

    //    /// <summary>
    //    /// 当前页面执行时间(毫秒)
    //    /// </summary>
    //    public float m_processtime;


    //    public AdminPage()
    //    {
    //        if (!Page.IsPostBack)
    //        {
    //            this.RegisterAdminPageClientScriptBlock();
    //        }

    //    }

    //}
}