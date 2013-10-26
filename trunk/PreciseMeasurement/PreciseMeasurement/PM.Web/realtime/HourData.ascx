<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HourData.ascx.cs" Inherits="PM.Web.realtime.HourData" %>
<ol class="breadcrumb">
    <li class="active"><asp:Literal ID="ltDescription" runat="server"></asp:Literal>的小时数据 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[查询区间限定为:240小时]</li>
</ol>
<div class="panel panel-default">
    <!-- Default panel contents -->
    <div class="panel-heading hour">
        起始时间：<input type="text" id="startdate" class="Wdate" />
        终止时间：<input type="text" class="Wdate" id="enddate" /><asp:Button ID="Button1" runat="server"
            Text="查询" CssClass="btn btn-info" />
    </div>
    <div class="panel-body">
        <asp:GridView ID="gvMeasurement" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
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
        <div class="Pager">
        </div>
    </div>
</div>