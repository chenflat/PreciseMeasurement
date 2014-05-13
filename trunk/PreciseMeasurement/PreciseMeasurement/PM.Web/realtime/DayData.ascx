<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DayData.ascx.cs" Inherits="PM.Web.realtime.DayData" %>
<ol class="breadcrumb">
    <li class="active">
        <asp:Literal ID="ltDescription" runat="server"></asp:Literal>的每日数据</li>
</ol>
<div class="panel panel-default">
    <!-- Default panel contents -->
    <div class="panel-heading day">
        起始时间： <input type="text" id="dstartdate" class="Wdate" />
        终止时间：<input type="text" class="Wdate" id="denddate" />
          <button type="button" class="btn btn-info" id="btnDayQuery">查询</button>
    </div>
    <div class="panel-body">
        <asp:GridView ID="gvDayMeasurement" runat="server" AutoGenerateColumns="False" CssClass="dayreport table table-bordered table-striped table-hover"
            EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="DESCRIPTION" HeaderText="计量点" />
                <asp:BoundField DataField="Starttime" DataFormatString="{0:yyyy-MM:dd hh:mm}" HeaderText="起始时间" />
                <asp:BoundField DataField="STARTVALUE" HeaderText="起始表数(t)" />
                 <asp:BoundField DataField="Endtime" DataFormatString="{0:yyyy-MM:dd hh:mm}" HeaderText="终止时间" />
                <asp:BoundField DataField="ENDVALUE" HeaderText="终止表数(t)" />
                <asp:BoundField DataField="DIFFVALUE" HeaderText="每日用量(t)" />
            </Columns>
        </asp:GridView>
        <br />
        <div id="daypager" class="pager">
        </div>
    </div>
</div>