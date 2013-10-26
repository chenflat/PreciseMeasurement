<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MinuteData.ascx.cs"
    Inherits="PM.Web.realtime.MinuteData" %>
<ol class="breadcrumb">
    <li class="active">
        <asp:Literal ID="ltDescription" runat="server"></asp:Literal>的分钟数据 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[查询区间限定为:24小时]
    </li>
</ol>
<div class="panel panel-default">
    <!-- Default panel contents -->
    <div class="panel-heading minute">
        起始时间：<input type="text" id="startdate" class="Wdate" />
        终止时间：<input type="text" class="Wdate" id="enddate" />
        
        <input type="button" class="btn btn-info" id="btnMinuteQuery" value="查询" />
        <asp:HiddenField ID="hdnPointnum" runat="server" />
      
    </div>
    <div class="panel-body">
        <asp:GridView ID="gvMeasurement" runat="server" AutoGenerateColumns="False" CssClass="minutereport table table-striped"
            EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="MEASURETIME" DataFormatString="{0:yyyy-MM:dd hh:mm}" HeaderText="采集时间" />
                <asp:BoundField DataField="SW_TEMPERATURE" HeaderText="温度(℃)" />
                <asp:BoundField DataField="SW_PRESSURE" HeaderText="压力(MPa)" />
                <asp:BoundField DataField="AF_FLOWINSTANT" HeaderText="瞬时流量(t/h)" />
                <asp:BoundField DataField="AT_FLOW" HeaderText="累计流量(t)" />
                <asp:BoundField DataField="AI_DENSITY" HeaderText="频率(Hz)" />
            </Columns>
        </asp:GridView>
        <br />
        <div class="minutepager Pager">
        </div>
    </div>
</div>
