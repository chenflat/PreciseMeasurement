<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MeasureSystem.aspx.cs" Inherits="PM.Web.MeasureSystem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="bs-docs-section" style="margin-top: 80px;">

        <ul id="NavButtons">
            <li class="" onclick="window.location.href='<%=ResolveUrl("~/structure/default.aspx") %>'"><div class="buttonBlowStandard buttonInSquare buttonComm"> </div>计量系统图</li>
            <li class=" " onclick="window.location.href='<%=ResolveUrl("~/realtime/default.aspx") %>'"><div class="buttonRealTime buttonInSquare buttonComm"> </div>实时参数</li>
            <li class=" " onclick="window.location.href='<%=ResolveUrl("~/report/") %>'"><div class="buttonStationDayReport buttonInSquare buttonComm"> </div>统计报表</li>
            <li class=" " onclick="window.location.href='<%=ResolveUrl("~/analysis/") %>'"><div class="buttonChartCompare buttonInSquare buttonComm"> </div>曲线对比</li>
            <li class=" " onclick="window.location.href='<%=ResolveUrl("~/alarm/") %>'"><div class="buttonAlarmList buttonInSquare buttonComm"> </div>报警管理</li>
            <li class=" " onclick="window.location.href='<%=ResolveUrl("~/alarm/") %>'"><div class="buttonAlarmList buttonInSquare buttonComm"> </div>疏水器</li>
            <li class=" " onclick="window.location.href='<%=ResolveUrl("~/alarm/") %>'"><div class="buttonAlarmList buttonInSquare buttonComm"> </div>阀门</li>
        </ul>
    </div>

</asp:Content>
