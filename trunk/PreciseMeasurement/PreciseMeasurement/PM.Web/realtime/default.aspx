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
    <div class="row">
        <div class="col-md-2 col-xs-4">
            <div class="bs-sidebar hidden-print affix-top" role="complementary">
                <ul class="nav nav-list bs-sidenav">
                    <%
                        foreach (System.Collections.Generic.KeyValuePair<string, System.Collections.Generic.List<PM.Entity.MeasurePointInfo>> pair in measurePointList)
                        { 
                    %>
                    <li><a href="#">
                        <%= pair.Key %></a>
                        <ul class="nav">
                            <% foreach (PM.Entity.MeasurePointInfo point in pair.Value)
                               {%>
                            <li <%  if(measurepointid==point.Measurepointid) Response.Write("class='active'"); %>><a href="?measurepointid=<%=point.Measurepointid %>">
                                <%=point.Description%></a></li>
                            <% } %>
                        </ul>
                    </li>
                    <%
                    }
                    %>
                   
                </ul>
                
            </div>
        </div>
        <div class="col-md-10 col-xs-8" role="main">
            <div class="bs-docs-section">
                <div class="page-header" style="border-bottom: none; margin: 40px 0 0 0;">
                    <ul id="myTab" class="nav nav-tabs">
                        <li class="active"><a href="#realtime" data-toggle="tab">实时参数</a></li>
                        <li><a href="#minute" data-toggle="tab">分钟数据</a></li>
                        <li><a href="#hour" data-toggle="tab">小时数据</a></li>
                        <li><a href="#day" data-toggle="tab">每日数据</a></li>
                        <li><a href="#history" data-toggle="tab">历史曲线</a></li>
                        <li><a href="#alarm" data-toggle="tab">报警信息</a></li>
                        <li><a href="#info" data-toggle="tab">计量点信息</a></li>
                    </ul>
                </div>
                <div id="myTabContent" class="tab-content">
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
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $('#myTab a').click(function (e) {
            e.preventDefault()
            $(this).tab('show')
        })
    </script>
    
</asp:Content>
