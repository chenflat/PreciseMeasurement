<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HistoryData.ascx.cs"
    Inherits="PM.Web.realtime.HistoryData" %>
<ol class="breadcrumb">
    <li class="active"><asp:Literal ID="ltDescription" runat="server"></asp:Literal>的历史曲线</li>
</ol>
<div class="panel panel-default">
    <!-- Default panel contents -->
    <div class="panel-heading history">
        时间类型： 
        <asp:RadioButtonList ID="rbDateType" runat="server" 
            RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Selected="True" Value="MINUTE">分钟</asp:ListItem>
            <asp:ListItem Value="HOUR">小时</asp:ListItem>
        </asp:RadioButtonList>

        &nbsp;&nbsp;&nbsp;&nbsp;
        起始时间：<input type="text" id="startdate" class="Wdate" />
        终止时间：<input type="text" class="Wdate" id="enddate" />
        
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBoxList 
            ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal" 
            RepeatLayout="Flow">
            <asp:ListItem Selected="True">温度</asp:ListItem>
            <asp:ListItem Selected="True">压力</asp:ListItem>
            <asp:ListItem Selected="True">流量</asp:ListItem>
        </asp:CheckBoxList>

        <asp:Button ID="Button1" runat="server"
            Text="查询" CssClass="btn btn-info" />
    </div>
    <div class="panel-body">
        <br />
        <div class="Pager">
        </div>
    </div>
</div>