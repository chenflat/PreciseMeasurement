<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RealtimeParams.ascx.cs"
    Inherits="PM.Web.realtime.RealtimeParams" %>
<ol class="breadcrumb">
    <li class="active">
        <asp:Literal ID="ltDescription" runat="server"></asp:Literal>的实时参数   <span class="text-info" style="margin-left:50px;"> 最后一次通讯时间：</span><span id="lastMeasuretime" class="text-info"></span> </li>
</ol>
<div class="well col-md-10">

<table class="table table-hover table-noborder table-border-bottom ">
<tr>
    <td> 频率</td>
    <td width="100"><span class=" pull-right" id="AI_Density">0</span></td>
    <td width="50"><span class="pull-right">Hz</span></td>
</tr>
<tr>
    <td> 温度</td>
    <td><span class=" pull-right" id="SW_Temperature">0</span></td>
    <td><span class="pull-right">℃</span></td>
</tr>
<tr>
    <td> 瞬时流量</td>
    <td><span class=" pull-right" id="AF_FlowInstant">0</span></td>
    <td><span class="pull-right">t/h</span></td>
</tr>
<tr>
    <td> 压力</td>
    <td><span class=" pull-right" id="SW_Pressure">0</span></td>
    <td><span class="pull-right">MPa</span></td>
</tr>
<tr>
    <td> 累计流量</td>
    <td><span class=" pull-right" id="AT_Flow">0</span></td>
    <td><span class="pull-right">t</span></td>
</tr>
</table>
</div>