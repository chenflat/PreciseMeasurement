<%@ Page Title="能源计量监测平台 - 首页" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="PM.Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="bs-docs-section" style="margin-top: 80px;">
        <ul id="NavButtons"  class="NavButtons">
            <%--<li onclick="window.location.href='<%=ResolveUrl("~/measuresystem.aspx") %>'"><div class="buttonInSquare btnSubSystem icon_steam"> </div>蒸汽系统</li>
            <li onclick="window.location.href='<%=ResolveUrl("~/watersystem.aspx") %>'"><div class="btnSubSystem buttonInSquare icon_water"></div> 水系统</li>
            <li onclick="window.location.href='<%=ResolveUrl("~/AirpressureSystem.aspx") %>'"><div class="btnSubSystem buttonInSquare icon_airpressure"></div> 空压系统</li>
            <li onclick="window.location.href='<%=ResolveUrl("~/electricity.aspx") %>'" ><div class="btnSubSystem buttonInSquare icon_electricity"></div> 电系统</li>--%>
            
            <li onclick="window.location.href='<%=ResolveUrl("SubSystem.aspx?sys=measurement") %>'"><div class="buttonInSquare btnSubSystem icon_steam"> </div>蒸汽系统</li>
            <li onclick="window.location.href='<%=ResolveUrl("SubSystem.aspx?sys=water") %>'"><div class="btnSubSystem buttonInSquare icon_water"></div> 水系统</li>
            <li onclick="window.location.href='<%=ResolveUrl("SubSystem.aspx?sys=airpressure") %>'"><div class="btnSubSystem buttonInSquare icon_airpressure"></div> 空压系统</li>
            <li onclick="window.location.href='<%=ResolveUrl("SubSystem.aspx?sys=electricity") %>'" ><div class="btnSubSystem buttonInSquare icon_electricity"></div> 电系统</li>
        </ul>
    </div>
</asp:Content>
