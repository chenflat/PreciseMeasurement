<%@ Page Title="主页" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="PM.Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="bs-docs-section" style="margin-top: 80px;">
        <ul id="NavButtons">
            <li class="btnSubSystem btnSteam" onclick="window.location.href='<%=ResolveUrl("~/measuresystem.aspx") %>'">蒸汽系统</li>
            <li class="buttonComm buttonRealTime">水系统</li>
            <li class="buttonComm buttonStationDayReport">空压系统</li>
            <li class="buttonComm buttonChartCompare">电系统</li>
        </ul>
    </div>
</asp:Content>
