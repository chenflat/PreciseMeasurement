<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HistoryData.ascx.cs"
    Inherits="PM.Web.realtime.HistoryData" %>
<ol class="breadcrumb">
    <li class="active"><asp:Literal ID="ltDescription" runat="server"></asp:Literal>的历史曲线</li>
</ol>
<div class="panel panel-default">
    <!-- Default panel contents -->
    <div class="panel-heading history">
        时间类型： 
         <label><input type="radio" name="datetype" checked="checked" value="MINUTE" />分钟</label>
         <label><input type="radio" name="datetype" value="HOUR" />小时</label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        起始时间：<input type="text" id="hisStartdate" class="Wdate hsdate" />
        终止时间：<input type="text" class="Wdate hedate" id="hisEnddate" />
        &nbsp;&nbsp;&nbsp;
        <label><input type="checkbox" name="dataitem" checked="checked" value="SW_TEMPERATURE" />温度</label>&nbsp;
        <label><input type="checkbox" name="dataitem" checked="checked" value="SW_PRESSURE" />压力</label>&nbsp;
        <label><input type="checkbox" name="dataitem" checked="checked" value="AF_FLOWINSTANT" />流量</label>&nbsp;
        <label><input type="checkbox" name="dataitem" value="AI_Density" />频率</label>
        &nbsp;&nbsp;
        <button type="button" class="btn btn-info" id="btnHistoryQuery">查询</button>
        <input type="hidden" id="isInitChart" value="0" />
    </div>
    <div class="panel-body">
        <div id="temperature" style="min-width: 310px; height: 400px; margin: 0 auto;display:none;"></div>
        <div id="pressure" style="min-width: 310px; height: 400px; margin: 5px auto;display:none;"></div>
        <div id="flowinstant" style="min-width: 310px; height: 400px; margin: 5px auto;display:none;"></div>
        <div id="aidensity" style="min-width: 310px; height: 400px; margin: 5px auto;display:none;"></div>
    </div>
</div>