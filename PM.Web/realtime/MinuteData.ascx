<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MinuteData.ascx.cs"
    Inherits="PM.Web.realtime.MinuteData" %>
<%@ Register src="../controls/PageControl.ascx" tagname="PageControl" tagprefix="uc1" %>
<ol class="breadcrumb">
    <li class="active">
        <asp:Literal ID="ltDescription" runat="server"></asp:Literal>的分钟数据  </li>
</ol>
<div class="panel panel-default">
    <!-- Default panel contents -->
    <div class="panel-heading minute">
        起始时间： <input type="text" id="startdate" class="Wdate startdate" />
        终止时间：<input type="text" class="Wdate enddate" id="enddate" />
         <input type="button" class="btn btn-info" id="btnMinuteQuery" value="查询" />
    </div>
    <div class="panel-body">
        <asp:GridView ID="gvMinuteMeasurement" runat="server" AutoGenerateColumns="False" CssClass="minutereport table table-striped"
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
       <div id="minutepager" class="pager">
        </div>
            
        
    </div>
</div>
