<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DayData.ascx.cs" Inherits="PM.Web.realtime.DayData" %>
<ol class="breadcrumb">
    <li class="active">
        <asp:Literal ID="ltDescription" runat="server"></asp:Literal>的每日数据  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[查询区间限定为:180小时]</li>
</ol>
<div class="panel panel-default">
    <!-- Default panel contents -->
    <div class="panel-heading day">
        起始时间： 
        <asp:TextBox ID="startdate" class="Wdate startdate" runat="server"></asp:TextBox> 
        终止时间：<asp:TextBox ID="enddate" class="Wdate enddate" runat="server"></asp:TextBox>
          <button type="button" class="btn btn-info" id="btnQuery">查询</button>
    </div>
    <div class="panel-body">
        <asp:GridView ID="gvMeasurement" runat="server" AutoGenerateColumns="False" CssClass="dayreport table table-striped"
            EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="MEASURETIME" DataFormatString="{0:d}" HeaderText="采集时间" />
                <asp:BoundField DataField="SW_TEMPERATURE" HeaderText="温度(℃)" />
                <asp:BoundField DataField="SW_PRESSURE" HeaderText="压力(MPa)" />
                <asp:BoundField DataField="AF_FLOWINSTANT" HeaderText="瞬时流量(t/h)" />
                <asp:BoundField DataField="AT_FLOW" HeaderText="累计流量(t)" />
                <asp:BoundField DataField="AI_DENSITY" HeaderText="频率(Hz)" />
            </Columns>
        </asp:GridView>
        <br />
        <div class="dayreportpager pager">
        </div>
    </div>
</div>