<%@ Page Title="系统结构" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PM.Web.structure._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/date.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/structure.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table width="100%" cellpadding="0" cellspacing="0">
<tr style="vertical-align:top">
    <td>
     <div class="structure pull-left" id="structure">
        <div id="refresh"> <img src=" <span id="counter">60</span>秒后刷新</div>
        <asp:Repeater ID="rptMeasurePoint" runat="server">
        <ItemTemplate>
            <div id="<%# Eval("Pointnum") %>" title="<%# Eval("Description") %>" class="meter" style="left:<%# Eval("X") %>px;top:<%# Eval("Y") %>px;" devicenum="<%# Eval("Devicenum") %>" cardnum="<%# Eval("Cardnum") %>" ><div class="left"><%# Eval("Pointnum") %></div></div>
        </ItemTemplate>
        </asp:Repeater>
        <img src="../assets/img/systemrunchart.png" width="1100" alt="" />
    </div>
    </td>
    <td> <div class="swichbar" id="swichbar">>></div></td>
    <td>
    <div class="table-responsive" style="z-index:50; display:none;" id="realdata">
        <table class="table table-bordered" id="gvRealtimeData">
        <thead>
            <tr>
                <th>计量点</th>
                <th>采集时间</th>
                <th>压力(MPa)</th>
                <th>温度(℃)</th>
                <th>瞬时流量(t/h)</th>
            </tr>
        </thead>
        <tbody>
        
        </tbody>
        </table>
    </div>
    </td>
</tr>
</table>

<div class="row">
   
   
    
</div>
</asp:Content>
