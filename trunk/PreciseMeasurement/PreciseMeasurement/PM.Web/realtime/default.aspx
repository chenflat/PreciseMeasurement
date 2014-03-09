<%@ Page Title="实时参数" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="PM.Web.realtime._default" %>

<%@ Register Src="MeasurePointBaseInfo.ascx" TagName="MeasurePointBaseInfo" TagPrefix="uc1" %>
<%@ Register Src="RealtimeParams.ascx" TagName="RealtimeParams" TagPrefix="uc2" %>
<%@ Register Src="MinuteData.ascx" TagName="MinuteData" TagPrefix="uc3" %>
<%@ Register Src="HourData.ascx" TagName="HourData" TagPrefix="uc4" %>
<%@ Register Src="DayData.ascx" TagName="DayData" TagPrefix="uc5" %>
<%@ Register Src="HistoryData.ascx" TagName="HistoryData" TagPrefix="uc6" %>
<%@ Register Src="AlarmData.ascx" TagName="AlarmData" TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/lang/zh-cn.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/WdatePicker.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/ASPSnippets_Pager.min.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/date.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/highcharts/highcharts.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/realtime.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/alarm.js") %>"></script>
<script>
    var USERID = "<%=userid %>";
    var ORGID = "<%=orgid %>";
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <aside class="bg-light lter b-r aside-md hidden-print" id="nav">
    <section class="vbox">
       <header class="header bg-default lter text-center clearfix" style="padding:5px 0px;margin:0px;min-height:30px;">
           <%-- <label>计量点</label>
                            <input id="searchstationinput" class="radiuscorner" type="text" style="width: 80px;">
                            <span id="spanType1" style="overflow: hidden;">
                                <input id="radSteam1" type="radio" value="steam" name="carrier" style="width: 15px; height: auto; margin: auto; padding: 0px; cursor: pointer;" checked="checked">
                                <label for="radSteam1" style="cursor: pointer;">汽</label>
                                <input id="radWater1" type="radio" value="water" name="carrier" style="width: 15px; height: auto; margin: auto; padding: 0px; cursor: pointer;">
                                <label for="radWater1" style="cursor: pointer;">水</label>
                            </span>
--%>

                <div class="btn-group">
                    
              <div class="btn-group hidden-nav-xs">
                <button type="button" class="btn btn-sm btn-primary dropdown-toggle" data-toggle="dropdown"> 计量点 <span class="caret"></span> </button>
                <ul class="dropdown-menu text-left" id="carrier">
                  <li id="steam"><a href="#">汽</a></li>
                  <li id="water"><a href="#" >水</a></li>
                </ul>
              </div>
              <%--<button type="button" class="btn btn-sm btn-dark btn-icon" title="Search"><i class="fa fa-fw fa-search"></i></button>--%>
              <a href="#" class="dropdown-toggle btn btn-sm btn-dark btn-icon btnSeach" data-toggle="dropdown"><i class="fa fa-fw fa-search"></i></a>
              <section class="dropdown-menu aside-xl animated fadeInUp  seachbox">
          <section class="panel bg-white">
              <div id="organizationlist">
                   <table width="100%" border="0" cellpadding="4" cellspacing="1" class="table table-bordered table-hover table-striped">
            <tr>
                <th width="20%">
                    选择部门
                </th>
            </tr>
            <%if (organizationInfoList != null)
                      {
                          foreach (PM.Entity.OrganizationInfo item in organizationInfoList)
                          {
                              string kg = "";
                              for (int i = 1; i < item.Level; i++) {
                                  kg += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                              }
                              
                    %>
        <tr onmouseover="this.className='tdbgmouseover'; " onmouseout="this.className='tdbg'" class="tdbg">
                        <td align="left">
                           <%=kg %>
                            <a id="<%=item.Orgid %>" href="#"><%=item.Description%></a>
                        </td>
                        
                    </tr>
                        <%}%>
                    <%}
                      else
                      {%>
                    <tr>
                        <td>没有数据</td>
                    </tr>
                    <%} %>
       
        </table>

              </div>
              <div class="form-group wrapper m-b-none">
                <div class="input-group">
                <form class="navbar-search">
                  <input type="text" class="form-control" placeholder="Search">
                  <span class="input-group-btn">
                  <button type="button" class="btn btn-info btn-icon"><i class="fa fa-search"></i></button>
                  </span> 
                </form>
                  </div>
              </div>
            
          </section>
        </section>


                </div>

          </header>


          <section class="w-f scrollable">
            <div class="slim-scroll" data-height="auto" data-disable-fade-out="true" data-distance="0" data-size="5px" data-color="#333333"> <!-- nav -->
           <nav class="nav-primary hidden-xs">
                <ul class="nav nav-list bs-sidenav">
                    <%
                        int k = 1;
                        foreach (System.Collections.Generic.KeyValuePair<string, System.Collections.Generic.List<PM.Entity.MeasurePointInfo>> pair in measurePointList)
                        { 
                    %>
                    <li class="<% if (currentLevel==0 && k==1) 
                                      Response.Write("active");
                                  else {
                                     if(currentLevel == k)
                                      Response.Write("active");
                                  } %>">

                    <a href="#"> <i class="fa fa-wrench"></i>
                    <span class="pull-right"> <i class="fa fa-angle-down text"></i> <i class="fa fa-angle-up text-active"></i> </span>
                      <span>  <%= pair.Key %></span></a>
                        <ul class="nav lt tree">
                            <% foreach (PM.Entity.MeasurePointInfo point in pair.Value)
                               {%>
                            <li <%  if(measurepointid==point.Measurepointid) Response.Write("class='active'"); %>><a href="?type=<%=point.Carrier %>&measurepointid=<%=point.Measurepointid %>">
                               [<%=point.Pointnum%>] <%=point.Description%></a></li>
                            <% } %>
                        </ul>
                    </li>
                    <%
                            k++;
                    }
                    %>
                   
                </ul>
                
            </nav>
        </div>
    </section>
    </section>
    </aside>
    <section id="content">
    <section class="vbox">
        <header class="header bg-white b-b b-light">
            <p><i class="fa fa-bars"></i> 实时参数</p>
          </header>
        <section class="scrollable wrapper">
                    <ul id="myTab" class="nav nav-tabs">
                        <li class="active"><a href="#realtime" data-toggle="tab">实时参数</a></li>
                        <li><a href="#minute" data-toggle="tab">分钟数据</a></li>
                        <li><a href="#hour" data-toggle="tab">小时数据</a></li>
                        <li><a href="#day" data-toggle="tab">每日数据</a></li>
                        <li><a href="#history" data-toggle="tab">历史曲线</a></li>
                        <li><a href="#alarm" data-toggle="tab">报警信息</a></li>
                        <li><a href="#info" data-toggle="tab">计量点信息</a></li>
                    </ul>
                <div id="myTabContent" class="tab-content" style="padding-top:8px;">
                    <div class="tab-pane fade in active" id="realtime">
                        <uc2:RealtimeParams ID="RealtimeParams1" runat="server" />
                    </div>
                    <div class="tab-pane fade" id="minute">
                        <uc3:MinuteData ID="MinuteData1" runat="server" />
                    </div>
                    <div class="tab-pane fade" id="hour">
                        <uc4:HourData ID="HourData1" runat="server" />
                    </div>
                    <div class="tab-pane fade" id="day">
                        <uc5:DayData ID="DayData1" runat="server" />
                    </div>
                    <div class="tab-pane fade" id="history">
                        <uc6:HistoryData ID="HistoryData1" runat="server" />
                    </div>
                    <div class="tab-pane fade" id="alarm">
                        <uc7:AlarmData ID="AlarmData1" runat="server" />
                    </div>
                    <div class="tab-pane fade" id="info">
                        <uc1:MeasurePointBaseInfo ID="MeasurePointBaseInfo" runat="server" />
                    </div>
                    <input type="hidden" id="pointnum" value="<%=measurePointInfo.Pointnum %>" />
                    <input type="hidden" id="devicenum" value="<%=measurePointInfo.Devicenum %>" />
                    <input type="hidden" id="cardnum" value="<%=measurePointInfo.Cardnum %>" />
                    
                </div>

    
        </section>

    </section>
    </section>
    
    </div>
    <script type="text/javascript">
        $('#myTab a').click(function (e) {
            e.preventDefault()
            $(this).tab('show')
        })
    </script>
    
</asp:Content>
