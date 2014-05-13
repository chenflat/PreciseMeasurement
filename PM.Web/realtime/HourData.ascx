<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HourData.ascx.cs" Inherits="PM.Web.realtime.HourData" %>
<ol class="breadcrumb">
    <li class="active"><asp:Literal ID="ltDescription" runat="server"></asp:Literal>的小时数据 </li>
</ol>
<div class="panel panel-default">
    <!-- Default panel contents -->
    <div class="panel-heading hour">
        起始时间：<input type="text" id="hstartdate" class="Wdate" />
        终止时间：<input type="text" class="Wdate" id="henddate" />
         <input type="button" class="btn btn-info" id="btnHourQuery" value="查询" />
    </div>
    <div class="panel-body">
        <asp:GridView ID="gvHourMeasurement" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped table-hover"
            EnableModelValidation="True" BorderStyle="None">
            <Columns>
                <asp:BoundField DataField="POINTNUM" HeaderText="计量点" />
                <asp:BoundField DataField="Starttime" DataFormatString="{0:yyyy-MM:dd hh:mm}" HeaderText="起始时间" />
                <asp:BoundField DataField="STARTVALUE" HeaderText="起始表数(t)" />
                 <asp:BoundField DataField="Endtime" DataFormatString="{0:yyyy-MM:dd hh:mm}" HeaderText="终止时间" />
                <asp:BoundField DataField="LASTVALUE" HeaderText="终止表数(t)" />
                <asp:BoundField DataField="VALUE" HeaderText="小时用量(t)" />
            </Columns>
        </asp:GridView>
        <br />
        <div id="hourpager" class="pager">
        </div>
    </div>
</div>