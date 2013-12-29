<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="steamtrap.aspx.cs" Inherits="PM.Web.realtime.steamtrap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/date.js") %>"></script>
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/steamtrap_realtimedata.js") %>"></script>
    <script type="text/javascript" language="javascript" >
        var USERID = "<%=userid %>";
        var ORGID = "<%=orgid %>";
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="row">
        <div class="bs-docs-section">&nbsp;</div></div>

 <table class="table table-bordered table-striped" id="gvRealtimeData">
        <thead>
            <tr>
                <th>级别</th>
                <th>设备名称</th>
                <th>采集时间</th>
                <th>前端温度(℃)</th>
                <th>后端温度(℃)</th>
                <th>温度差(℃)</th>
                <th>设备状态</th>
            </tr>
        </thead>
        <tbody>
        
        </tbody>
        </table>


</asp:Content>
