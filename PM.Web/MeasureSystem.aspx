<%@ Page Title="能源计量监测平台" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MeasureSystem.aspx.cs" Inherits="PM.Web.MeasureSystem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/MeasureSystem.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bs-docs-section" style="margin-top: 80px;">
        <ul id="NavButtons" class="NavButtons">
            <li class="steam">
                <div class="buttonInSquare btnSubSystem icon_steam">
                </div>
                <a href="#steam">蒸汽计量</a></li>
            <li  class="steamtrap">
                <div class="buttonSteamTrap buttonInSquare buttonComm">
                </div>
               <a href="#steamtrap"> 疏水监测</a></li>
            <li class=""><a href="#steamtrap" data-toggle="tab">
                <div class="buttonValve buttonInSquare buttonComm">
                </div>
                阀门监测</a></li>
            <li class="">
                <div class="ico_condensation buttonInSquare buttonComm">
                </div>
                冷凝监测</li>
        </ul>
        <div class="tab-content">
            <div id="steam">
                <ul id="steam_subnav" class="NavButtons subNavButtons">
                    <li class="" onclick="window.location.href='<%=ResolveUrl("~/structure/default.aspx") %>'">
                        <div class="buttonBlowStandard buttonInSquare buttonComm">
                        </div>
                        系统结构</li>
                    <li class=" " onclick="window.location.href='<%=ResolveUrl("~/realtime/default.aspx") %>'">
                        <div class="buttonRealTime buttonInSquare buttonComm">
                        </div>
                        实时参数</li>
                    <li class=" " onclick="window.location.href='<%=ResolveUrl("~/report/default.aspx") %>'">
                        <div class="buttonStationDayReport buttonInSquare buttonComm">
                        </div>
                        统计报表</li>
                    <li class=" " onclick="window.location.href='<%=ResolveUrl("~/analysis/default.aspx") %>'">
                        <div class="buttonChartCompare buttonInSquare buttonComm">
                        </div>
                        曲线对比</li>
                    <li class=" " onclick="window.location.href='<%=ResolveUrl("~/alarm/default.aspx") %>'">
                        <div class="buttonAlarmList buttonInSquare buttonComm">
                        </div>
                        报警管理</li>
                </ul>
            </div>
            <div id="steamtrap">
                <ul id="steamtrap_subnav" class="NavButtons subNavButtons">
                    <li class="" onclick="window.location.href='<%=ResolveUrl("~/structure/steamtrap.aspx") %>'">
                        <div class="buttonBlowStandard buttonInSquare buttonComm">
                        </div>
                        系统结构</li>
                    <li class=" " onclick="window.location.href='<%=ResolveUrl("~/analysis/streamtrap.aspx") %>'">
                        <div class="buttonChartCompare buttonInSquare buttonComm">
                        </div>
                        曲线对比</li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
