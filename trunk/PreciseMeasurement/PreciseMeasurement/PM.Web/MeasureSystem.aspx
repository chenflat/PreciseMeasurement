<%@ Page Title="能源计量监测平台" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MeasureSystem.aspx.cs" Inherits="PM.Web.MeasureSystem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="bs-docs-section" style="margin-top: 80px;">

        <ul id="NavButtons" class="NavButtons">
            <li id="steam"><div class="buttonInSquare btnSubSystem icon_steam"> </div>蒸汽系统</li>
            <li id="steamtrap"><div class="buttonSteamTrap buttonInSquare buttonComm"> </div>疏水系统</li>
            <li class=""><div class="buttonValve buttonInSquare buttonComm"> </div>阀门系统</li>
            <li class=""><div class="ico_condensation buttonInSquare buttonComm"> </div>冷凝系统</li>
        </ul>

        <ul id="steam_subnav" class="NavButtons subNavButtons">
        
            <li class="" onclick="window.location.href='<%=ResolveUrl("~/structure/default.aspx") %>'"><div class="buttonBlowStandard buttonInSquare buttonComm"> </div>系统结构</li>
            <li class=" " onclick="window.location.href='<%=ResolveUrl("~/realtime/default.aspx") %>'"><div class="buttonRealTime buttonInSquare buttonComm"> </div>实时参数</li>
            <li class=" " onclick="window.location.href='<%=ResolveUrl("~/report/default.aspx") %>'"><div class="buttonStationDayReport buttonInSquare buttonComm"> </div>统计报表</li>
            <li class=" " onclick="window.location.href='<%=ResolveUrl("~/analysis/default.aspx") %>'"><div class="buttonChartCompare buttonInSquare buttonComm"> </div>曲线对比</li>
            <li class=" " onclick="window.location.href='<%=ResolveUrl("~/alarm/default.aspx") %>'"><div class="buttonAlarmList buttonInSquare buttonComm"> </div>报警管理</li>
        </ul>

         <ul id="steamtrap_subnav" class="NavButtons subNavButtons" style="display:none;">
        
            <li class="" onclick="window.location.href='<%=ResolveUrl("~/structure/steamtrap.aspx") %>'"><div class="buttonBlowStandard buttonInSquare buttonComm"> </div>系统结构</li>
            <li class=" " onclick="window.location.href='<%=ResolveUrl("~/realtime/default.aspx") %>'"><div class="buttonRealTime buttonInSquare buttonComm"> </div>实时参数</li>
            <li class=" " onclick="window.location.href='<%=ResolveUrl("~/report/default.aspx") %>'"><div class="buttonStationDayReport buttonInSquare buttonComm"> </div>统计报表</li>
            <li class=" " onclick="window.location.href='<%=ResolveUrl("~/analysis/default.aspx") %>'"><div class="buttonChartCompare buttonInSquare buttonComm"> </div>曲线对比</li>
            <li class=" " onclick="window.location.href='<%=ResolveUrl("~/alarm/default.aspx") %>'"><div class="buttonAlarmList buttonInSquare buttonComm"> </div>报警管理</li>
        </ul>
    </div>

</asp:Content>
