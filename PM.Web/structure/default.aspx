<%@ Page Title="系统结构" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PM.Web.structure._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/date.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/structure.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="row">
    <div class="structure pull-left" id="structure">
    <%--<div id="W1" class="meter" style="left:100px;top:35px;"><div>W1</div></div>
    <div id="S1" class="meter" style="left:160px;top:100px;"><div class="left">S1</div></div>
    <div id="W2" class="meter" style="left:350px;top:35px;"><div>W2</div></div>
    <div id="S2" class="meter" style="left:410px;top:100px;"><div class="left">S2</div></div>
    <div id="S3" class="meter" style="left:658px;top:100px;"><div class="left">S3</div></div>
    <div id="S4" class="meter" style="left:905px;top:100px;"><div class="left">S4</div></div>
    <div id="S5" class="meter" style="left:890px;top:230px;"><div class="left">S5</div></div>
    <div id="S6" class="meter" style="left:890px;top:380px;"><div class="left">S6</div></div>
    <div id="S7" class="meter" style="left:523px;top:230px;"><div class="left">S7</div></div>
    <div id="S8" class="meter" style="left:523px;top:360px;"><div class="left">S8</div></div>
    <div id="S9" class="meter" style="left:165px;top:230px;"><div class="left">S9</div></div>
    <div id="S10" class="meter" style="left:165px;top:380px;"><div class="left">S10</div></div>--%>

        <asp:Repeater ID="rptMeasurePoint" runat="server">
        <ItemTemplate>
            <div id="<%# Eval("Pointnum") %>" title="<%# Eval("Description") %>" class="meter" style="left:<%# Eval("X") %>px;top:<%# Eval("Y") %>px;" devicenum="<%# Eval("Devicenum") %>" cardnum="<%# Eval("Cardnum") %>" ><div class="left"><%# Eval("Pointnum") %></div></div>
        </ItemTemplate>
        </asp:Repeater>


    <img src="../assets/img/systemrunchart.png" width="1100" alt="" />
    </div>
    <div class="swichbar pull-left" id="swichbar">>></div>
    <div class="pull-right table-responsive" style="z-index:50; position:absolute;left:1000px;display:none;" id="realdata">
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
</div>
</asp:Content>
